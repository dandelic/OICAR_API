using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class ServiceSubcategory
    {
        public ServiceSubcategory()
        {
            Offers = new HashSet<Offer>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int ServiceCategoryId { get; set; }

        public  ServiceCategory ServiceCategory { get; set; } = null!;
        public  ICollection<Offer> Offers { get; set; }
    }
}
