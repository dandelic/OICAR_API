using Newtonsoft.Json;

namespace API.Models.DTO
{
    public class ChatLastMessageDto
    {
        [JsonProperty("sender_id")]
        public int? SenderID { get; set; }
        [JsonProperty("caption")]
        public string? Caption { get; set; }
        [JsonProperty("read")]
        public bool? Read { get; set; }
        [JsonProperty("date")]
        public DateTime? DateSent { get; set; }
    }
}
