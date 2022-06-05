using API.Dto;
using API.Utility.JWT;

namespace API.DAL.Interfaces
{
    public interface IClientsRepository
    {        
        Task<int> CreateClientAsync(ClientAddDto clientRegistrationModel);
        Task<int> DeleteClientAsync(int client_id);
        Task<ClientDto> GetClientAsync(int client_id);
        Task<List<ChatConversationDto>> GetClientChatsAsync(int client_id);
        Task<JwtAuthResponse> AuthorizeClient(string username,string password);
    }
}
