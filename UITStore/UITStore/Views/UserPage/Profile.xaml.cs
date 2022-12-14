using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UITStore.Models;
using UITStore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.Views.UserPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        private User _user;
        public UserVM userViews = new UserVM();
        public Profile()
        {
            InitializeComponent();
            _user = Application.Current.Properties["user"] as User;
            BindingContext = _user;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _user = Application.Current.Properties["user"] as User;
            BindingContext = _user;
        }
        private void update_profile_Clicked(object sender, EventArgs e)
        {
            if(update_profile.Text == "Cập nhật")
            {
                update_profile.Text = "Lưu";
                username.IsEnabled = true;
                birthday.IsEnabled = true;
                fullname.IsEnabled = true;
                phone.IsEnabled = true;
                email.IsEnabled = true;
                address.IsEnabled = true;
                cancel_profile.IsEnabled = true;

            } else if (update_profile.Text == "Lưu")
            {
               
                if (ValidationUsername() && ValidationEmail() && ValidationFullname() && ValidationPhone() && ValidationAddress())
                {
                    bool result = userViews.Update(_user.id, username.Text, _user.password, fullname.Text,
                        phone.Text, address.Text, birthday.Date, email.Text, _user.loyalPoint);
                    if (result)
                    {
                        _ = DisplayAlert("Thành công", "Cập nhật thành công", "Ok");
                    }
                    else
                    {
                        _ = DisplayAlert("Lỗi", "Lỗi", "Ok");
                    }
                    username.IsEnabled = false;
                    birthday.IsEnabled = false;
                    fullname.IsEnabled = false;
                    phone.IsEnabled = false;
                    email.IsEnabled = false;
                    address.IsEnabled = false;
                    cancel_profile.IsEnabled = false;
                    update_profile.Text = "Cập nhật";
                }
                ValidationUsername();
                ValidationFullname();
                ValidationPhone();
                ValidationAddress();
                ValidationEmail();
            }
        }

        private void cancel_profile_Clicked(object sender, EventArgs e)
        {
            username.Text = _user.username;
            birthday.Date = _user.birthday;
            fullname.Text = _user.fullname;
            phone.Text = _user.telephone;
            email.Text = _user.email;
            address.Text = _user.address;
            username.IsEnabled = false;
            birthday.IsEnabled = false;
            fullname.IsEnabled = false;
            phone.IsEnabled = false;
            email.IsEnabled = false;
            address.IsEnabled = false;
            cancel_profile.IsEnabled = false;
            update_profile.Text = "Cập nhật";   
        }

        public bool ValidationUsername()
        {
            if (string.IsNullOrWhiteSpace(username.Text) || username.Text.Length < 4)
            {
                vldUsername.Text = "Ít nhất 4 kí tự";
                return false;
            }
            else
            {
                vldUsername.Text = "";
                return true;
            }
        }
        public bool ValidationFullname()
        {
            if (string.IsNullOrWhiteSpace(fullname.Text) || fullname.Text.Length < 4)
            {
                vldFullname.Text = "Ít nhất 4 kí tự";
                return false;
            }
            else
            {
                vldFullname.Text = "";
                return true;
            }
        }
        public bool ValidationPhone()
        {
            if (string.IsNullOrWhiteSpace(phone.Text) || phone.Text.Length < 10 || phone.Text.Length > 11)
            {
                vldPhone.Text = "SĐT không đúng";
                return false;
            }
            else
            {
                vldPhone.Text = "";
                return true;
            }
        }
        public bool ValidationAddress()
        {
            if (string.IsNullOrWhiteSpace(address.Text) || address.Text.Length < 10)
            {
                vldAddress.Text = "Ít nhất 10 kí tự";
                return false;
            }
            else
            {
                vldAddress.Text = "";
                return true;
            }
        }
        public bool ValidationEmail()
        {
            var regex = "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$";
            if (string.IsNullOrWhiteSpace(email.Text) || !Regex.IsMatch(email.Text, regex))
            {
                vldEmail.Text = "Email không đúng";
                return false;
            }
            else
            {
                vldEmail.Text = "";
                return true;
            }
        }
    }
}