using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;

namespace EnixerBanks
{
    class LocalManu
    {
        public string ImgManu { get; set; }
        public string TexManu { get; set; }


        public static void SaveImgManu(string manu,string tex)
        {
            SQLiteConnection conn = new SQLiteConnection(App.DBPath);
           
            var item = conn.Table<LocalManu>().Count();
            if (item > 11)
            {
                conn.DeleteAll<LocalManu>();
                conn.CreateTable<LocalManu>();
            }
            else
            {
                conn.CreateTable<LocalManu>();
                LocalManu manuAdd = new LocalManu()
                {
                    ImgManu = manu,
                    TexManu = tex
                };
                conn.Insert(manuAdd);
                conn.Close();

            }
        }


        public static void Delete()
        {
            SQLiteConnection conn = new SQLiteConnection(App.DBPath);
            conn.DeleteAll<LocalManu>();
            conn.CreateTable<LocalManu>();
            conn.Close();

        }



    }
}
