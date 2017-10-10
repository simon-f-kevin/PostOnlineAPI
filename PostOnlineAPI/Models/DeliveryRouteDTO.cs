using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APITester.Models
{
    public class DeliveryRouteDTO
    {
        public Int64 DeliveryID { get; set; }
        public double Price { get; set; }
        public int Stops { get; set; }
        public int CurrentStop { get; set; }
        public double Distance { get; set; }
        public virtual List<long> PackagesID { get; set; }
    }
}