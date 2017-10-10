using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APITester.Models
{
    public class RecieverDTO
    {

        public Int64 ReciverID { get; set; }
        public string NationalIdentificationNumber { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Password { get { return "lol trodde du det?"; } set { } }
        public virtual List<long> PackagesID { get; set; }
    }
}