using System;
namespace EnixerBanks.ModelApp
{
    public class AccountInfo
    {
        public string AccountNumber { get; set; }
        public string Prefix { get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CountryCode { get; set; }
        public DateTime? BirthDate { get; set; }
        public string CitizenID { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string AccountType { get; set; }

        public string PassbookNumber { get; set; }
        public string MyProperty { get; set; }


        public string CardNumber { get; set; }
        public string CardType { get; set; }
        public string ATMPin { get; set; }

        public string ProfilePic { get; set; }
        public int ID { get; set; }
        public string ReferenceNO { get; set; }

        public string FullName{ get { return $"{FirstName} {LastName}"; }}
    }
}
