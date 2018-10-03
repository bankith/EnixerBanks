
using EnixerBank.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnixerBanks
{
    public class UserProfile
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public string Prefix { get; set; }
        public string MobileNo { get; set; }
        public string CountryCode { get; set; }
        public string UserEmail { get; set; }
        public string ProfilePic { get; set; }
        public string CitizenID { get; set; }
        public DateTime Birthdate { get; set; }
        public string StatusUser { get; set; }
        public string ReferenceNO { get; set; }
        public bool StatusUnlock { get; set; }
        public string Role { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string PIN { get; set; }
        public string CurrentBalance { get; set; }


        public GreenBank_UserProfile greenBank_UserProfile
        {
            get
            {
                return new GreenBank_UserProfile()
                {
                    ID = this.ID,
                    FirstName = this.Firstname,
                    LastName = this.Lastname,
                    Gender = this.Gender,
                    Prefix = this.Prefix,
                    MobileNumber = this.MobileNo,
                    CountryCode = this.CountryCode,
                    UserName = this.Username,
                    ProfilePic = this.ProfilePic,
                    CitizenID = this.CitizenID,
                    BirthDate = this.Birthdate,
                    StatusUser = this.StatusUser,
                    ReferenceNumber = this.ReferenceNO,
                    StatusUnlock = this.StatusUnlock,
                    Role = this.Role,
                };
            }

        }


        public GreenBank_Login greenBank_Login
        {
            get
            {
                return new GreenBank_Login()
                {
                    Password = this.Password,
                    PIN = this.PIN
                };
            }
        }

        public UserProfile()
        {

        }
       

        public UserProfile(GreenBank_UserProfile greenBank_UserProfile)
        {
            ID = greenBank_UserProfile.ID;
            Firstname = greenBank_UserProfile.FirstName;
            Lastname = greenBank_UserProfile.LastName;
            Gender = greenBank_UserProfile.Gender;
            Prefix = greenBank_UserProfile.Prefix;
            MobileNo = greenBank_UserProfile.MobileNumber;
            CountryCode = greenBank_UserProfile.CountryCode;
            Username = greenBank_UserProfile.UserName;
            ProfilePic = greenBank_UserProfile.ProfilePic;
            CitizenID = greenBank_UserProfile.CitizenID;
            Birthdate = (DateTime)greenBank_UserProfile.BirthDate;
            StatusUser = greenBank_UserProfile.StatusUser;
            ReferenceNO = greenBank_UserProfile.ReferenceNumber;
            StatusUnlock = (bool)greenBank_UserProfile.StatusUnlock;
            Role = greenBank_UserProfile.Role;

        }



    }
}
