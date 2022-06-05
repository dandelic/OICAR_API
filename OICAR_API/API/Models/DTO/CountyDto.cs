using Newtonsoft.Json;

namespace API.Dto
{
    public class CountyDto
    {
        public CountyDto()
        {
            Cities = new List<CityDto>();
        }
        [JsonProperty("county_id")]
        public int Id { get; set; }
        [JsonProperty("county_title")]
        public string Title { get; set; } = null!;
        [JsonProperty("cities")]
        public List <CityDto> Cities { get; set; }
    }
}
