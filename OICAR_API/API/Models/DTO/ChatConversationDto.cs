using API.Models.DTO;
using Newtonsoft.Json;

namespace API.Dto
{
    public class ChatConversationDto
    {
        public ChatConversationDto()
        {
            ChatReplies = new List<ChatReplyDto>();
        }
        [JsonProperty("chat_id")]
        public int Id { get; set; }
        [JsonProperty("date_created")]     
        public DateTime? DateCreated { get; set; }
        [JsonProperty("unread_messages")]
        public int UnreadMessagesCount { get; set; }
        [JsonProperty("client_two_name")]
        public string? ClientName { get; set; }
        [JsonProperty("client_two_id")]
        public int? ClientID { get; set; }
        [JsonProperty("last_message")]
        public ChatLastMessageDto? LastMessage { get; set; }
        [JsonProperty("replies")]
        public List<ChatReplyDto> ChatReplies { get; set; }

      
    }
}
