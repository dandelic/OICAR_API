using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Offer
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ServiceSubcategoryId { get; set; }
        public DateTime? DatePublished { get; set; }
        public int CityId { get; set; }
        public string? Caption { get; set; }

        public  City City { get; set; } = null!;
        public  Client Client { get; set; } = null!;
        public  ServiceSubcategory ServiceSubcategory { get; set; } = null!;
    }
}
