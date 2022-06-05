using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class City
    {
        public City()
        {
            Offers = new HashSet<Offer>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int CountyId { get; set; }

        public  County County { get; set; } = null!;
        public  ICollection<Offer> Offers { get; set; }
    }
}
