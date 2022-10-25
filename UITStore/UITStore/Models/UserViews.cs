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

        public event PropertyChangedEventHandler PropertyChanged;

        public async Task<bool> updateUserExist()
        {
            var db = new Database();
            var user = new User
            {
                username = _username, password = _password, fullname = _fullname, telephone = _telephone,
                address = _address
            };
            if (db.updateUser(user))
            {
                var oleUser = Application.Current.Properties["user"] as User;
                oleUser.username = _username;
                oleUser.password = _password;
                oleUser.fullname = _fullname;
                oleUser.telephone = _telephone;
                oleUser.address = _address;
                Application.Current.Properties["user"] = user;
                await Application.Current.SavePropertiesAsync();
                return true;
            }

            return false;
        }

        public bool addNewUser()
        {
            var user = new User
            {
                username = _username, password = _password, fullname = _fullname, telephone = _telephone,
                address = _address
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