using API.DAL.Interfaces;
using API.Dto;
using API.Models;
using API.Models.DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.DAL.Repositories
{
    public class ChatsRepository : IChatsRepository
    {
        private readonly OicarDBContext _ctx;
        private readonly IMapper _mapper;


        public ChatsRepository(OicarDBContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<int> AddChatReplyAsync(ChatReplyAddDto chatReplyDto)
        {
            var chatReply = _mapper.Map<ChatReply>(chatReplyDto);
            await _ctx.ChatReplies.AddAsync(chatReply);
            await _ctx.SaveChangesAsync();
            return chatReply.Id;
        }
     
        public async Task<int> CreateChatConversationAsync(ChatConversationAddDto chatConversationDto)
        {
            var chat = _mapper.Map<ChatConversation>(chatConversationDto);
            await _ctx.ChatConversations.AddAsync(chat);
            await _ctx.SaveChangesAsync();
            return chat.Id;
        }

        public async Task<int> DeleteChatConversationAsync(int id)
        {
            var chat = await _ctx.ChatConversations.Include(cc=>cc.ChatReplies).FirstAsync(u => u.Id == id);
            _ctx.Remove(_mapper.Map<ChatConversation>(chat));
            return await _ctx.SaveChangesAsync();
        }

        public async Task<List<ChatReplyDto>> GetChatRepliesAsync(int id)
        {
           var chatReplies = await _ctx.ChatReplies
                .Include(cr=>cr.Sender)
                .Where(cr=>cr.ChatId==id)
                .OrderByDescending(cr=>cr.DateSent)
                .Select(cr=>new ChatReplyDto()
                {
                    Id = cr.Id,
                    SenderID = cr.Sender.Id,
                    SenderFirstName = cr.Sender.FirstName,
                    SenderLastName = cr.Sender.LastName,
                    Caption = cr.Caption,
                    DateSent = cr.DateSent,
                    IsRead = cr.IsRead
                })
                .ToListAsync();
           return _mapper.Map<List<ChatReplyDto>>(chatReplies);
        }

        public async Task<int> ReadClientChatMessagesAsync(int client_id, int chat_id)
        {
            var replies = await _ctx.ChatReplies.Where(cr => cr.IsRead == false && cr.Chat.Id == chat_id && cr.SenderId != client_id).ToListAsync();
            replies.ForEach(reply=>reply.IsRead = true);
            return await _ctx.SaveChangesAsync();          
        }
    }
}
