using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Net.Http;
using EnixerBanks.ModelApp;
using Newtonsoft.Json;
using System.Threading.Tasks;
using EnixerBank.Models;


namespace EnixerBanks
{
    public static class Services
    {
        public static readonly HttpClient Client = new HttpClient();

        #region Services URL

        public static string AzureURL = "https://enixerbankapi.azurewebsites.net/api/";

        public static Uri UserNameValidateURI = new Uri(AzureURL + "UserNameValidate");
        public static Uri FavoritedBillsURI = new Uri(AzureURL + "FavoritedBills");
        public static Uri UpdateAccountDeleteStatusURI = new Uri(AzureURL + "UpdateAccountDeleteStatus");
        public static Uri RegisterOnlineAccountURI = new Uri(AzureURL + "RegisterOnlineAccount");
        public static Uri CheckOTPURI = new Uri(AzureURL + "CheckOTP");
        public static Uri UpdatePinURI = new Uri(AzureURL + "UpdatePin");
        public static Uri CheckUserLoginURI = new Uri(AzureURL + "CheckUserLogin");

        internal static Task<bool> MinusAccountBalance(int iD, string accountNumber, string amount)
        {
            throw new NotImplementedException();
        }

        public static Uri BillersURI = new Uri(AzureURL + "Billers");  // * มี Get 2 Function รับ parameter ต่างกัน //
        public static Uri GetAccountInfoByCardNumberURI = new Uri(AzureURL + "GetAccountInfoByCardNumber");
        public static Uri SendOTPURI = new Uri(AzureURL + "SendOTP");
        public static Uri GetUserRefNumberURI = new Uri(AzureURL + "GetUserRefNumber");
        public static Uri ValuesURI = new Uri(AzureURL + "Values"); // ใส่ paramerter ต่างกัน 5 แบบ //
        public static Uri RegisterNonConfirmUserURI = new Uri(AzureURL + "RegisterNonConfirmUser");
        public static Uri GetUserInfoByPassbookNumberURI = new Uri(AzureURL + "GetUserInfoByPassbookNumber");
        public static Uri UserPasswordURI = new Uri(AzureURL + "UserPassword");  //มี Method 2 อัน put,post //
        public static Uri UpdateStatusUnlockPinURI = new Uri(AzureURL + "UpdateStatusUnlockPin");
        public static Uri CheckAccountForUnlockPINURI = new Uri(AzureURL + "CheckAccountForUnlockPIN");
        public static Uri AccountBalanceURI = new Uri(AzureURL + "AccountBalance");
        public static Uri GetAccountFromUserIDURI = new Uri(AzureURL + "GetAccountFromUserID");
        public static Uri AccountsURI = new Uri(AzureURL + "Accounts"); // รับ paramerter ได้ 2 แบบ // 
        public static Uri InsertTransactionURI = new Uri(AzureURL + "InsertTransaction");
        public static Uri SavePinURI = new Uri(AzureURL + "SavePin");
        public static Uri GetAccountInfoByAccountNumberURI = new Uri(AzureURL + "GetAccountInfoByAccountNumber");
        public static Uri UserURI = new Uri(AzureURL + "User");
        public static Uri PINURI = new Uri(AzureURL + "PIN");
        #endregion



        #region UserNameValidate
        public async static Task<bool> UserNameValidate(string username)
        {

            var valuse = new Dictionary<string, object> { { "Username",username } };
            String jsonContent = JsonConvert.SerializeObject(valuse);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(UserNameValidateURI, content);

            if (response != null)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                BoolStatusMessageSimpleResponse data = JsonConvert.DeserializeObject<BoolStatusMessageSimpleResponse>(responseString);
               
                return data.Status;
            }
            return false;
        }
        #endregion

        #region FavoritedBills
        public async static Task<List<FavoritedBillInfo>> FavoritedBills(int userid, string account_No)
        {
            Uri unsettleURI = FavoritedBillsURI.AddParameter("userId", userid.ToString());
            Uri settleURI = unsettleURI.AddParameter("accountNo", account_No);

            string response = await Client.GetStringAsync(settleURI);
            if (response != null)
            {
                Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
                var Favbills = JsonConvert.DeserializeObject<List<FavoritedBillInfo>>(data["FavoritedBills"].ToString());
                return Favbills;

            }
            return null;

        }


        #endregion

        #region UpdateAccountDeleteStatus
        public async static Task<bool> UpdateAccountDeleteStatus(int userid, string accountNO)
        {
            var valuse = new Dictionary<string, object>
            {
                { "Id",userid },
                {"AccountNumber",accountNO }
            };
            String jsonContent = JsonConvert.SerializeObject(valuse);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await Client.PutAsync(UpdateAccountDeleteStatusURI, content);

            if( response != null){
                var responseString = await response.Content.ReadAsStringAsync(); //

                BoolStatusMessageSimpleResponse data = JsonConvert.DeserializeObject<BoolStatusMessageSimpleResponse>(responseString);

                if( data.Status == false)
                {
                    Console.WriteLine(data.Message);
                    return false;
                }

                return true;
            }

            return false;


        }

        #endregion

        #region RegisterOnlineAccount

        public async static Task<bool> RegisterOnlineAccount(UserProfile user)
        {
            var valuse = new Dictionary<string, object>
            {
                {"UserID",user.ID },
                {"UserName",user.Username},
                {"Password",user.Password},
                {"Email",user.UserEmail },
                {"MobileNumber",user.MobileNo },
                {"StatusUser",user.StatusUser },
                {"StatusUnlock",user.StatusUnlock }

            };
            String jsonContent = JsonConvert.SerializeObject(valuse);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await Client.PutAsync(RegisterOnlineAccountURI, content);
            if (response != null)
            {
                var responseString = await response.Content.ReadAsStringAsync(); //

                BoolStatusMessageSimpleResponse data = JsonConvert.DeserializeObject<BoolStatusMessageSimpleResponse>(responseString);

                if (data.Status == false)
                {
                    Console.WriteLine(data.Message);
                    return false;
                }

                return true;
            }

            return false;
        }

        #endregion

        #region CheckOTP

        public async static Task<bool> CheckOTP(int userID, string otp)
        {
            var valuse = new Dictionary<string, object>
            {
                {"Id", userID},
                {"OTP",otp }
            };

            String jsonContent = JsonConvert.SerializeObject(valuse);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(CheckOTPURI, content);
            if (response != null)
            {
                var responseString = await response.Content.ReadAsStringAsync(); //

                BoolStatusMessageSimpleResponse data = JsonConvert.DeserializeObject<BoolStatusMessageSimpleResponse>(responseString);

                if (data.Status == false)
                {
                    Console.WriteLine(data.Message);
                    return false;
                }

                return true;
            }

            return false;
        }
        #endregion

        #region UpdatePin
        public async static Task<bool> UpdatePin(int id, string newPin)
        {
            var valuse = new Dictionary<string, object>
            {
                {"Id",id },
                {"NewPIN",newPin }
            };

            String jsonContent = JsonConvert.SerializeObject(valuse);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await Client.PutAsync(UpdatePinURI, content);
            if (response != null)
            {
                var responseString = await response.Content.ReadAsStringAsync(); //

                BoolStatusMessageSimpleResponse data = JsonConvert.DeserializeObject<BoolStatusMessageSimpleResponse>(responseString);

                if (data.Status == false)
                {
                    Console.WriteLine(data.Message);
                    return false;
                }

                return true;
            }

            return false;
        }
        #endregion

        #region CheckUserLogin
        public async static Task<bool> UserLogin(string username, string pass, bool isLogin)
        {
            var valuse = new Dictionary<string, object>
            {
                {"Username",username },
                {"Password",pass },
                {"LastLoginDateTime",DateTime.Now },
                {"ActiveSession",isLogin }
            };

            String jsonContent = JsonConvert.SerializeObject(valuse);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await Client.PutAsync(CheckUserLoginURI, content);
            if (response != null)
            {
                var responseString = await response.Content.ReadAsStringAsync();

                BoolStatusMessageSimpleResponse data = JsonConvert.DeserializeObject<BoolStatusMessageSimpleResponse>(responseString);

                if (data.Status == false)
                {
                    Console.WriteLine(data.Message);
                    return false;
                }

                return true;
            }

            return false;
        }

        #endregion

        #region Billers
        public async static Task<List<GreenBank_BillerCompany>> GetBillerByType(string BillerType)
        {
            Uri settleURI = BillersURI.AddParameter("type", BillerType);
            string response = await Client.GetStringAsync(settleURI);
            if (response != null)
            {
                Dictionary<string, object> serial = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
                var ListBiller = JsonConvert.DeserializeObject<List<GreenBank_BillerCompany>>(serial["BillerCompanys"].ToString());
                return ListBiller;
            }
            return null;
        }

        public async static Task<List<GreenBank_BillerCompany>> GetBillerByName(string BillerName)
        {
            Uri settleURI = BillersURI.AddParameter("billerName", BillerName);
            string response = await Client.GetStringAsync(settleURI);
            if (response != null)
            {
                Dictionary<string, object> serial = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
                var ListBiller = JsonConvert.DeserializeObject<List<GreenBank_BillerCompany>>(serial["BillerCompanys"].ToString());
                return ListBiller;
            }
            return null;
        }

        #endregion


        #region User
        async public static Task<UserProfile> GetUserProfileFrom(string Username,string Password )
        {
            var values = new Dictionary<string, object> { { "Username", Username }, { "Password", Password } };
            String jsonContent = JsonConvert.SerializeObject(values);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(UserURI, content);
            if (response != null)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseString);

                if ((bool)data["Status"] == false)
                {
                    Console.WriteLine(data["Message"]);
                    return null;
                }

                GreenBank_UserProfile user = JsonConvert.DeserializeObject<GreenBank_UserProfile>(data["UserProfile"].ToString());

                return new UserProfile(user);
            }

            return null;
        }
        #endregion


        #region GetAccountInfoByCardNumber
        async public static Task<UserProfile> GetAccountInfoByCardNumber(string CitizenID, DateTime BirthDate, string AccountNumber, string CardNumber, string ATMPin)
        {
            var values = new Dictionary<string, object> { { "CitizenID", CitizenID }, { "BirthDate", BirthDate }, { "AccountNumber", AccountNumber }, { "CardNumber", CardNumber }, { "ATMPin", ATMPin } };
            String jsonContent = JsonConvert.SerializeObject(values);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(GetAccountInfoByCardNumberURI, content);
            if (response != null)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseString);

                if ((bool)data["Status"] == false)
                {
                    Console.WriteLine(data["Message"]);
                    return null;
                }

                GreenBank_UserProfile user = JsonConvert.DeserializeObject<GreenBank_UserProfile>(data["UserProfile"].ToString());

                return new UserProfile(user);
            }

            return null;
        }
        #endregion


        #region SendOTP
        async public static Task<string> SendOTP(int Id, string PhoneNo)
        {
            var values = new Dictionary<string, object> { { "Id", Id }, { "PhoneNo", PhoneNo } };
            String jsonContent = JsonConvert.SerializeObject(values);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(SendOTPURI, content);
            if (response != null)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string,object>>(responseString);

                if ( (bool)data["Status"] == false)
                {
                    Console.WriteLine(data["Message"]);
                    return null;
                }

                return data["OTP"].ToString();
            }

            return null;
        }
        #endregion

        #region GetUserRefNumber
        async public static Task<Dictionary<string,string>> GetUserRefNumber(int id)
        {
            Uri settleURI = GetUserRefNumberURI.AddParameter("id", id.ToString());

            string response = await Client.GetStringAsync(settleURI);
            if (response != null)
            {
                Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);

                if ((bool)data["Status"] == false)
                {
                    Console.WriteLine(data["Message"]);
                    return null;
                }

                Dictionary<string, string> usernameRefNoDic = new Dictionary<string, string>
                {
                    ["Username"] = data["Username"].ToString(),
                    ["ReferenceNumber"] = data["ReferenceNumber"].ToString()
                };

                return usernameRefNoDic;
            }

            return null;
        }
        #endregion

        #region RegisterNonConfirmUser
        async public static Task<bool> RegisterNonConfirmUser(int Id, string ReferenceNumber)
        {
            var values = new Dictionary<string, object> { { "Id", Id }, { "ReferenceNumber", ReferenceNumber} };
            String jsonContent = JsonConvert.SerializeObject(values);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await Client.PutAsync(RegisterNonConfirmUserURI, content);
            if (response != null)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                BoolStatusMessageSimpleResponse data = JsonConvert.DeserializeObject<BoolStatusMessageSimpleResponse>(responseString);

                if (data.Status == false)
                {
                    Console.WriteLine(data.Message);
                    return false;
                }

                return true;
            }

            return false;
        }
        #endregion


        #region GetUserInfoByPassbookNumber
        async public static Task<GreenBank_UserProfile> GetUserInfoByPassbookNumber(string passbook_no)
        {
            Uri settleURI = GetUserInfoByPassbookNumberURI.AddParameter("passbook_no", passbook_no);


            string response = await Client.GetStringAsync(settleURI);
            if (response != null)
            {
                Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);

                if ( (bool)data["Status"] == false)
                {
                    Console.WriteLine(data["Message"]);
                    return null;
                }

                GreenBank_UserProfile userProfile = JsonConvert.DeserializeObject<GreenBank_UserProfile>(data["UserProfile"].ToString());

                return userProfile;
            }

            return null;
        }
        #endregion


        #region UserPassword
        async public static Task<bool> ChangePassword(int id, string NewPassword)
        {

            Uri settleURI = UserPasswordURI.AddParameter("id", id.ToString());

            var values = new Dictionary<string, object> { { "NewPassword", NewPassword } };
            String jsonContent = JsonConvert.SerializeObject(values);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await Client.PutAsync(settleURI, content);
            if (response != null)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                Dictionary<string,object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseString);

                if ((bool)data["Status"] == false)
                {
                    Console.WriteLine(data["Message"].ToString());
                    return false;
                }

                return true;
            }

            return false;
        }

        async public static Task<bool> CheckPassword(int Id, string Password)
        {

            var values = new Dictionary<string, object> { {"Id", Id }, {  "Password", Password } };
            String jsonContent = JsonConvert.SerializeObject(values);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(UserPasswordURI, content);
            if (response != null)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                BoolStatusMessageSimpleResponse data = JsonConvert.DeserializeObject<BoolStatusMessageSimpleResponse>(responseString);

                if (data.Status == false)
                {
                    Console.WriteLine(data.Message);
                    return false;
                }

                return true;
            }

            return false;
        }
        #endregion

        #region UpdateStatusUnlockPin
        async public static Task<bool> UpdateStatusUnlockPin(int UserID, bool StatusUnlock)
        {
            var values = new Dictionary<string, object> { { "Id", UserID }, { "StatusUnlock", StatusUnlock } };
            String jsonContent = JsonConvert.SerializeObject(values);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await Client.PutAsync(UpdateStatusUnlockPinURI, content);

            if (response != null)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                BoolStatusMessageSimpleResponse data = JsonConvert.DeserializeObject<BoolStatusMessageSimpleResponse>(responseString);

                if (data.Status == false)
                {
                    Console.WriteLine(data.Message);
                    return false;
                }

                return true;

            }

            return false;
        }
        #endregion

        #region CheckAccountForUnlockPIN
        async public static Task<bool> CheckAccountForUnlockPIN(string card_no)
        {
            Uri settleURI = CheckAccountForUnlockPINURI.AddParameter("card_no", card_no);

            string response = await Client.GetStringAsync(settleURI);
            if (response != null)
            {
                BoolStatusMessageSimpleResponse data = JsonConvert.DeserializeObject<BoolStatusMessageSimpleResponse>(response);

                if (data.Status == false)
                {
                    Console.WriteLine(data.Message);
                    return false;
                }

                return true;

            }

            return false;
        }
        #endregion

        #region AccountBalance
        async public static Task<GreenBank_Balance> GetAccountBalance(string acc_no)
        {
            Uri settleURI = AccountBalanceURI.AddParameter("acc_no", acc_no.ToString());

            string response = await Client.GetStringAsync(settleURI);
            if (response != null)
            {
                GreenBank_Balance balance = JsonConvert.DeserializeObject<GreenBank_Balance>(response);

                return balance;
            }

            return null;
        }

        async public static Task<bool> MinusAccountBalance(int Id, string AccountNumber, int Cost)
        {
            var values = new Dictionary<string, object> { { "Id", Id }, { "AccountNumber", AccountNumber },{ "Cost", Cost } };
            String jsonContent = JsonConvert.SerializeObject(values);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await Client.PutAsync(AccountBalanceURI, content);
            if (response != null)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                BoolStatusMessageSimpleResponse data = JsonConvert.DeserializeObject<BoolStatusMessageSimpleResponse>(responseString);

                if (data.Status == false)
                {
                    Console.WriteLine(data.Message);
                    return false;
                }

                return true;
            }

            return false;
        }
        #endregion

        #region GetAccountsFromUserID
        async public static Task<List<GreenBank_Account>> GetAccountsFromUserID(int id)
        {
            Uri settleURI = GetAccountFromUserIDURI.AddParameter("id", id.ToString());

            string response = await Client.GetStringAsync(settleURI);
            if (response != null)
            {
                Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);

                if ( (bool)data["Status"] == false)
                {
                    Console.WriteLine(data["Message"]);
                    return null;
                }

                List<GreenBank_Account> Accounts = JsonConvert.DeserializeObject<List<GreenBank_Account>>(data["Accounts"].ToString());

                return Accounts;
            }

            return null;
        }
        #endregion

        #region Accounts
        async public static Task<AccountInfo> GetAccounts(string accountNo, string serialNo)
        {
            Uri firstURI = AccountsURI.AddParameter("accountNo", accountNo);
            Uri settleURI = firstURI.AddParameter("serialNo", serialNo);

            string response = await Client.GetStringAsync(settleURI);
            if (response != null)
            {
                Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);

                if (data["Status"].ToString() == "404")
                {
                    Console.WriteLine(data["Message"]);
                    return null;
                }

                AccountInfo AccountInfo = JsonConvert.DeserializeObject<AccountInfo>(data["AccountInfo"].ToString());

                return AccountInfo;
            }

            return null;
        }

        async public static Task<bool> AddAccounts(string accountNo, int userId)
        {
            var values = new Dictionary<string, object> { { "accountNo", accountNo }, { "userId", userId } };
            String jsonContent = JsonConvert.SerializeObject(values);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            Uri firstURI = AccountsURI.AddParameter("accountNo", accountNo);
            Uri settleURI = firstURI.AddParameter("userId", userId.ToString());

            var response = await Client.PutAsync(settleURI,content);
            if (response != null)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                StringStatusMessageSimpleResponse data = JsonConvert.DeserializeObject<StringStatusMessageSimpleResponse>(responseString);

                if (data.Status == "404")
                {
                    Console.WriteLine(data.Message);
                    return false;
                }

                return true;
            }

            return false;
        }
        #endregion

        #region InsertTransaction  ##POST
        async public static Task<bool> InsertTransaction(GreenBank_Transaction GBtransaction)
        {

            String jsonContent = JsonConvert.SerializeObject(GBtransaction);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(InsertTransactionURI, content);
            if (response != null)
            {

                var responseString = await response.Content.ReadAsStringAsync();
                BoolStatusMessageSimpleResponse data = JsonConvert.DeserializeObject<BoolStatusMessageSimpleResponse>(responseString);

                if (data.Status == false)
                {
                    Console.WriteLine(data.Message);
                    return false;
                }

                return true;
            }

            return false;
        }
        #endregion

        #region SavePin  ##PUT
        async public static Task<bool> SavePin(int Id, string PIN)
        {

            var values = new Dictionary<string, object> { { "Id", Id }, { "PIN", PIN } };
            String jsonContent = JsonConvert.SerializeObject(values);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await Client.PutAsync(SavePinURI, content);
            if (response != null)
            {

                var responseString = await response.Content.ReadAsStringAsync();
                BoolStatusMessageSimpleResponse data = JsonConvert.DeserializeObject<BoolStatusMessageSimpleResponse>(responseString);

                if (data.Status == false)
                {
                    Console.WriteLine(data.Message);
                    return false;
                }

                return true;
            }

            return false;
        }
        #endregion

        #region GetAccountInfoByAccountNumber   ##GET
        async public static Task<AccountInfo> GetAccountInfoByAccountNumber(string acc_no)
        {
            Uri settleURI = GetAccountInfoByAccountNumberURI.AddParameter("acc_no", acc_no);

            string response = await Client.GetStringAsync(settleURI);
            if (response != null)
            {
                Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);

                if ((bool)data["Status"] == false)
                {
                    Console.WriteLine(data["Message"].ToString());
                    return null;
                }

                return JsonConvert.DeserializeObject<AccountInfo>(data["Account"].ToString());
            }

            return null;
        }
        #endregion

        #region PIN  
        async public static Task<bool> IsPINExist(int UserID, string PIN)
        {
            var values = new Dictionary<string, object> { { "UserID", UserID }, { "PIN", PIN } };
            String jsonContent = JsonConvert.SerializeObject(values);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(PINURI, content);
            if (response != null)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                BoolStatusMessageSimpleResponse data = JsonConvert.DeserializeObject<BoolStatusMessageSimpleResponse>(responseString);

                if (data.Status == false)
                {
                    Console.WriteLine(data.Message);
                    return false;
                }

                return true;
            }

            return false;
        }
        #endregion


        #region Private Helper
        private static Uri AddParameter(this Uri url, string paramName, string paramValue)
        {

            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query[paramName] = paramValue;
            uriBuilder.Query = query.ToString();

            return uriBuilder.Uri;
        }


        #endregion

        #region response helper class
        private class BoolStatusMessageSimpleResponse
        {
            public bool Status { get; set; }
            public string Message { get; set; }
        }
        private class StringStatusMessageSimpleResponse
        {
            public string Status { get; set; }
            public string Message { get; set; }
        }
        #endregion

    }
}
