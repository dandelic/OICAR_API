using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class ServiceCategory
    {
        public ServiceCategory()
        {
            ServiceSubcategories = new HashSet<ServiceSubcategory>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public  ICollection<ServiceSubcategory> ServiceSubcategories { get; set; }
    }
}
