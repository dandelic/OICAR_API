using API.Models;
using Newtonsoft.Json;

namespace API.Dto
{
    public class ChatReplyDto
    {
        [JsonProperty("reply_id")]
        public int Id { get; set; }
        [JsonProperty("caption")]
        public string? Caption { get; set; }
        [JsonProperty("read")]
        public bool? IsRead { get; set; }
        [JsonProperty("date")]
        public DateTime? DateSent { get; set; }       
        [JsonProperty("sender_id")]
        public int? SenderID { get; set; }
        [JsonProperty("sender_firstname")]
        public string? SenderFirstName { get; set; }
        [JsonProperty("sender_lastname")]
        public string? SenderLastName { get; set; }
        [JsonIgnore]
        public ClientDto Sender { get; set; } = null!;

    }
}
