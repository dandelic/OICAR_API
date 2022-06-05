using Newtonsoft.Json;

namespace API.Models.DTO.Add
{
    public class OfferAddDto
    {

        public int ClientId { get; set; }

        public int ServiceSubcategoryId { get; set; }

        public int CityId { get; set; }

        public string? Caption { get; set; }
    }
}
