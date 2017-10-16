using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostOnlineAPIReferenceLibrary.Models
{
    public class PackageDTO
    {
        public Int64 PackageID { get; set; }
        public Int64 ReciverID { get; set; }
        public Int64? DeliveryID { get; set; }
        public Int64 SenderID { get; set; }
        public string DeliveryStreetAdress { get; set; }
        public string DeliveryCity { get; set; }
        public string DeliveryPostalCode { get; set; }
        public String PickUpStreetAdress { get; set; }
        public string PickUpCity { get; set; }
        public string PickUpPostalCode { get; set; }
        public DateTime EarliestDeliveryDay { get; set; }
        public DateTime CheckedInDate { get; set; }
        public String Message { get; set; }
        public string SenderName { get; set; }
        public int Priority { get; set; }
        public bool Delivered { get; set; }

    }
}