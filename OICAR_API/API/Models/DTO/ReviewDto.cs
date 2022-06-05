using Newtonsoft.Json;

namespace API.Dto
{
    public class ReviewDto
    {
        [JsonProperty("review_id")]
        public int Id { get; set; }
        [JsonProperty("caption")]    
        public string? Caption { get; set; }
        [JsonProperty("grade")]
        public int Grade { get; set; }
        [JsonIgnore]
        public ClientDto Client { get; set; } = null!;
    }
}
