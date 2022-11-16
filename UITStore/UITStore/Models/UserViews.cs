using System;
using System.ComponentModel;
using System.Threading.Tasks;
using ProjSQLite;
using Xamarin.Forms;

namespace UITStore.Models
{
    public class UserViews : INotifyPropertyChanged
    {
        public string _address;
        public string _fullname;
        public string _password;
        public string _telephone;
        public string _username;
        public DateTime _birthday;
        public string _email;
        public string _avatar;
        public int _loyaltyPoint;

        public string username
        {
            get => _username;
            set
            {
                _username = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(username)));
            }
        }

        public string password
        {
            get => _password;
            set
            {
                _password = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(password)));
            }
        }

        public string fullname
        {
            get => _fullname;
            set
            {
                _fullname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(fullname)));
            }
        }

        public string telephone
        {
            get => _telephone;
            set
            {
                _telephone = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(telephone)));
            }
        }

        public string address
        {
            get => _address;
            set
            {
                _address = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(address)));
            }
        }
        public DateTime birthday
        {
            get => _birthday;
            set
            {
                _birthday = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(birthday)));
            }
        }
        public string email
        {
            get => _email;
            set
            {
                _email = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(email)));
            }
        }
        public string avatar
        {
            get => _avatar;
            set
            {
                _avatar = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(avatar)));
            }
        }
        public int loyaltyPoint
        {
            get => _loyaltyPoint;
            set
            {
                _loyaltyPoint = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(loyaltyPoint)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async Task<bool> updateUserExist()
        {
            var db = new Database();
            var user = new User
            {
                username = _username, password = _password, fullname = _fullname, telephone = _telephone,
                address = _address
            };
            if (db.updateUser(user).Result) return true;

            return false;
        }

        public bool addNewUser()
        {
            var user = new User
            {
                username = _username, password = _password, fullname = _fullname, telephone = _telephone,
                address = _address, birthday = _birthday, email = _email
            };
            var db = new Database();
            if (db.addUser(user))
            {
                Application.Current.Properties["user"] = user;
                return true;
            }

            return false;
        }
    }
}