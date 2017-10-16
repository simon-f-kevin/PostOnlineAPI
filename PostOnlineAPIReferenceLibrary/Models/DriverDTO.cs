using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostOnlineAPIReferenceLibrary.Models
{
    public class DriverDTO
    {
        public Int64 DriverID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Longitude { get; set; }
        public String Latitude { get; set; }
        public String PhoneNumber { get; set; }
    }
}