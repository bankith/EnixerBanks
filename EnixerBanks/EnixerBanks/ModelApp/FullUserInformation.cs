using System;
using System.Collections.Generic;
using System.Text;

namespace EnixerBanks
{
   public class FullUserInformation
    {
        public string AccountNumber { get; set; }
        public int UserID { get; set; }
        public int AccountTypeID { get; set; }
        public string SerialNumber { get; set; }
        public string AccountStatus { get; set; }
        public string PassbookNumber { get; set; }

        public string Firstname { get; set; }
        public string LastName { get; set; }

       
        public int AvailableBalance { get; set; }
        public string Currency { get; set; }


    }
}
