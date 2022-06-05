using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Review
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string? Caption { get; set; }
        public int Grade { get; set; }

        public  Client Client { get; set; } = null!;
    }
}
