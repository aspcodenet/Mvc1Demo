using System;
using System.Collections.Generic;

#nullable disable

namespace Mvc1Demo.Models
{
    public partial class QuarterlyOrder
    {
        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
