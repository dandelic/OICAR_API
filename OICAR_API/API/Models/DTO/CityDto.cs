using Newtonsoft.Json;

namespace API.Dto
{
    public class CityDto
    {
        [JsonProperty("city_id")]
        public int Id { get; set; }
        [JsonProperty("city_title")]
        public string Title { get; set; } = null!;      
        [JsonIgnore]
        public CountyDto County { get; set; } = null!;

    }
}
