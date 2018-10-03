using System;
using System.Collections.Generic;
using SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace EnixerBanks
{
    public class LocalDB
    {
        [AutoIncrement, PrimaryKey]
        public int ID { get; set; }

        public string My_NumberPhone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool touchID { get; set; }


        public static void Save(string username, string password)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DBPath))
            {
                LocalDB localDB = new LocalDB()
                {
                    Username = username,
                    Password = password
                };
                conn.DeleteAll<LocalDB>();
                conn.CreateTable<LocalDB>();
                conn.Insert(localDB);
            }               
        }

        public static void TouchID(bool Enable)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DBPath))
            {
                var db = conn.Table<LocalDB>().ToList().LastOrDefault();
                if (db != null)
                {
                    db.touchID = Enable;
                    conn.Update(db);
                }
            }
        }

        public static bool TouchIDEnable()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DBPath))
            {
                var db = conn.Table<LocalDB>().ToList().LastOrDefault();
                if (db != null)
                {
                    return db.touchID;
                }

                return false;
            }
        }

        public static LocalDB GetUsernamePassword()  //insert Phone number 
        {
            SQLiteConnection conn = new SQLiteConnection(App.DBPath);
            conn.CreateTable<LocalDB>();
            LocalDB localDB = new LocalDB();
            var db = conn.Table<LocalDB>().ToList().LastOrDefault();
            conn.Close();

            return db;
        }


        public static void Delete()
        {
            SQLiteConnection conn = new SQLiteConnection(App.DBPath);
            conn.DeleteAll<LocalDB>();
            conn.CreateTable<LocalDB>();
            conn.Close();

        }

        public override string ToString()
        {
            return this.My_NumberPhone;
        }
    }
}
