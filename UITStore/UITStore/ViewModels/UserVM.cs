using System;
using System.ComponentModel;
using System.Threading.Tasks;
using UITStore.Models;
using UITStore.Services;
using Xamarin.Forms;

namespace UITStore.ViewModels
{
    public class UserVM : INotifyPropertyChanged
    {
        public Guid _id;
        public string _address;
        public string _fullname;
        public string _password;
        public string _telephone;
        public string _username;
        public DateTime _birthday;
        public string _email;
        public string _avatar;
        public int _loyalPoint;
        public Guid id
        {
            get => _id;
            set
            {
                _id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(id)));
            }
        }
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
        public int loyalPoint
        {
            get => _loyalPoint;
            set
            {
                _loyalPoint = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(loyalPoint)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

       
        public bool addNewUser()
        {
            RequestUser user = new RequestUser
            {
                username = _username, password = _password, fullname = _fullname, telephone = _telephone,
                address = _address, birthday = DateTime.Now, email = "", avatar = "AvatarDefault.png", loyalPoint = 10, role = "user"
            };
            UserModel result =  UserService.ServiceClientInstance.AddUser(user).Result;
            if(result.success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Login()
        {
            LoginModel login = new LoginModel
            {
                username = _username,
                password = _password,
            };
            UserModel result = UserService.ServiceClientInstance.Login(login).Result;
            if (result.success)
            {
                Application.Current.Properties["user"] = result.data;
                Application.Current.SavePropertiesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Update(Guid Id, string Username, string Password, string Fullname, string Phone, string Address, DateTime Birthday, string Email, int LoyalPoint)
        {
            User user = new User
            {
                id = Id, username = Username, password = Password, fullname = Fullname, telephone = Phone, address = Address,
                birthday = Birthday, email = Email, avatar = "AvatarDefault.png", loyalPoint = LoyalPoint, role = "user"
            };
            UserModel result = UserService.ServiceClientInstance.UpdateUser(user).Result;
            if (result.success)
            {
                Application.Current.Properties["user"] = result.data;
                Application.Current.SavePropertiesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ChangePassword(Guid Id, string Password)
        {
            UserModel result = UserService.ServiceClientInstance.ChangePassword(Id, Password).Result;
            if(result.success)
            {
                Application.Current.Properties["user"] = result.data;
                Application.Current.SavePropertiesAsync();
                return true;
            }
            else
            {
                return false;
            }
        
        }
        public User GetUserById(Guid id)
        {
            UserModel result = UserService.ServiceClientInstance.GetUserById(id).Result;
            if(result.success)
            {
                User user = result.data;
                return user;
            } else
            {
                return null;
            }
        }

    }
}