using API.Dto;
using API.DAL.Interfaces;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using API.Models.DTO;
using API.Utility.JWT;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace API.Repositories
{
    public class ClientRepository : IClientsRepository
    {

        private readonly OicarDBContext _ctx;
        private readonly IMapper _mapper;

        public ClientRepository(OicarDBContext ctx,IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<JwtAuthResponse> AuthorizeClient(string username,string password)
        {
            var client = await _ctx.Clients.Where(c=>c.Passw==password && c.Username == username).FirstAsync();
            if (client == null)
            {
                return null;
            }

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(Constants.JWT_SECURITY_KEY);
            var securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new List<Claim>
                {
                    new Claim("username",username)                
                }),
                Expires = DateTime.Now.AddMinutes(Constants.JW_TOKEN_VALIDITY_MINS),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return new JwtAuthResponse
            {
                Token = token,
                ClientID = client.Id,
                Expires_In = Constants.JW_TOKEN_VALIDITY_MINS
            };
        }

        public async Task<int> CreateClientAsync(ClientAddDto clientModel)
        {        
            var client = _mapper.Map<Client>(clientModel);
            await _ctx.Clients.AddAsync(client);
            await _ctx.SaveChangesAsync();
            return client.Id;
        }

        public async Task<int> DeleteClientAsync(int id)
        {
            var client = await _ctx.Clients.FirstAsync(u => u.Id==id);
            _ctx.Remove(_mapper.Map<Client>(client));
            return await _ctx.SaveChangesAsync();
        }

        public async Task<List<ChatConversationDto>> GetClientChatsAsync(int id)
        {
            var chatConversations = await _ctx.ChatConversations
                .Include(cc => cc.ChatReplies
                .OrderByDescending(cr => cr.DateSent))
                .ThenInclude(cr => cr.Sender)
                .Where(cr => cr.ClientIdOne == id || cr.ClientIdTwo == id)
                .Select(cc => new ChatConversationDto
                {
                    Id = cc.Id,
                    DateCreated = cc.DateCreated,
                    ClientID = cc.ClientIdOne == id ? cc.ClientIdTwo : cc.ClientIdOne,
                    ClientName = cc.ClientIdOne == id ? cc.ClientIdTwoNavigation.ToString() : cc.ClientIdOneNavigation.ToString(),
                    UnreadMessagesCount = cc.ClientIdOne == id? cc.ChatReplies.Where(cr=>cr.SenderId!= cc.ClientIdOne && cr.IsRead == false).Count() 
                    : cc.ChatReplies.Where(cr => cr.SenderId != cc.ClientIdTwo && cr.IsRead ==false).Count(),
                    LastMessage = new ChatLastMessageDto()
                    {
                        DateSent = cc.ChatReplies.First().DateSent,
                        Caption = cc.ChatReplies.First().Caption,
                        SenderID = cc.ChatReplies.First().SenderId,
                        Read = cc.ChatReplies.First().IsRead,
                    },
                    ChatReplies = _mapper.Map<List<ChatReplyDto>>(cc.ChatReplies)
                })
                .ToListAsync();
            return _mapper.Map<List<ChatConversationDto>>(chatConversations);
        }

        public async Task<ClientDto> GetClientAsync(int id)
        {
            var client = await _ctx.Clients
                .Where(c => c.Id == id)
                .Select(client => new ClientDto()
                {
                    Id = id,
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    IsContractor = client.IsContractor,
                    OffersCount = client.IsContractor == true ? client.Offers.Count() : 0,
                    ReviewsCount = client.IsContractor == true ? client.Reviews.Count() : 0,
                    AverageReviewGrade = client.IsContractor == true ? client.Reviews.Average(r => r.Grade) : 0,
                    UnreadMessagesCount = _ctx.ChatConversations.Where(ch=>ch.ClientIdOne == id || ch.ClientIdTwo == id)
                    .Select(ch=>ch.ChatReplies.Where(cr=>cr.IsRead==false && cr.SenderId!=id).Count()).First(),
                                                             
                    Reviews = (List<ReviewDto>) client.Reviews.Select(r=>new ReviewDto()
                    {
                        Id=r.Id,
                        Caption=r.Caption,
                        Grade = r.Grade
                    }),
                    Offers = (List<OfferDto>)client.Offers.Select(r => new OfferDto()
                    {
                        Id = r.Id,
                        ClientId = r.Client.Id,
                        ClientName = r.Client.ToString(),
                        SubcategoryTitle = r.ServiceSubcategory.Title,
                        CategoryTitle = r.ServiceSubcategory.ServiceCategory.Title,
                        CityTitle = r.City.Title,
                        DatePublished = r.DatePublished,
                        Caption = r.Caption,
                        AverageReviewGrade = r.Client.Reviews.Average(r => r.Grade) == null ? 0 : r.Client.Reviews.Average(r => r.Grade)
                    })

                })
                .FirstAsync();
            return _mapper.Map<ClientDto>(client);
        }
    }
}
