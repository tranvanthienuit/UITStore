using SQLite;

namespace UITStore.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string fullname { get; set; }
        public string telephone { get; set; }
        public string address { get; set; }
    }
}