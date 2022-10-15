using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace UITStore.Models
{
    public class UserViews : INotifyPropertyChanged
    {
        public string _username;
        public string username
        {
            get { return _username; }
            set
            {
                _username = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(username)));
            }
        }

        public string _password;
        public string password
        {
            get { return _password; }
            set
            {
                _password = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(password)));
            }
        }

        public string _fullname;
        public string fullname
        {
            get { return _fullname; }
            set
            {
                _fullname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(fullname)));
            }
        }

        public string _telephone;
        public string telephone
        {
            get { return _telephone; }
            set
            {
                _telephone = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(telephone)));
            }
        }

        public string _address;
        public string address
        {
            get { return _address; }
            set
            {
                _address = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(address)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand editUser => new Command(editUserExist);

        void editUserExist()
        {
            User user = new User();
            user.username = this._username;
            user.password = this._password;
            user.fullname = this._fullname;
            user.telephone = this._telephone;
            user.address = this._address;
        }
    }
}