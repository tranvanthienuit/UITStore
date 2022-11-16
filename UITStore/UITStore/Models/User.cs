using SQLite;
using System;

namespace UITStore.Models
{
    public class User
    {
        [PrimaryKey] [AutoIncrement] public int ID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string fullname { get; set; }
        public string telephone { get; set; }
        public string address { get; set; }
        public DateTime birthday { get; set; } = DateTime.Now;
        public string email { get; set; }
        public string avatar { get; set; } = "AvatarDefault.png";
        public int loyaltyPoint { get; set; } = 10;
        public string role { get; set; } = "user";

    }
}