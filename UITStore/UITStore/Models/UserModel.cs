using System;
using System.Collections.Generic;
using System.Text;

namespace UITStore.Models
{
    public class RequestUser
    {
        public string username { get; set; }
        public string password { get; set; }
        public string fullname { get; set; }
        public string telephone { get; set; }
        public string address { get; set; }
        public DateTime birthday { get; set; }
        public string email { get; set; }
        public string avatar { get; set; }
        public int loyalPoint { get; set; }
        public string role { get; set; }
    }
    public class LoginModel
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    public class UserModel
    {
        public bool success { get; set; }
        public User data { get; set; }
    }
    public class ListUserModel
    {
        public bool success { get; set; }
        public List<User> data { get; set; }
    }
}
