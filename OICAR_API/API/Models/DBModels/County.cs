using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class County
    {
        public County()
        {
            Cities = new HashSet<City>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public ICollection<City> Cities { get; set; }
    }
}
