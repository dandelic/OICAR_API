using API.Dto;
using API.Models.DTO;

namespace API.DAL.Interfaces
{
    public interface IChatsRepository
    {
        Task<List<ChatReplyDto>> GetChatRepliesAsync(int chat_idid);
        Task<int> CreateChatConversationAsync(ChatConversationAddDto chatConversationDto);
        Task<int> AddChatReplyAsync(ChatReplyAddDto chatReplyDto);
        Task<int> DeleteChatConversationAsync(int chat_id);
        Task<int> ReadClientChatMessagesAsync(int client_id,int chat_id);
    }
}
