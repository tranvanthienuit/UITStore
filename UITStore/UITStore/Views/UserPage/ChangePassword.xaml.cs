using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITStore.Models;
using UITStore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.Views.UserPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePassword : ContentPage
    {
        private readonly User _user;
        public UserVM userViews = new UserVM();
        public ChangePassword()
        {
            InitializeComponent();
            _user = Application.Current.Properties["user"] as User;
        }
        public bool ValidationPassword()
        {
            if (string.IsNullOrWhiteSpace(password.Text) || password.Text.Length < 4)
            {
                vldPassword.Text = "Ít nhất 4 kí tự";
                return false;
            }
            else
            {
                vldPassword.Text = "";
                return true;
            }
        }
        public bool ValidationNewPassword()
        {
            if (string.IsNullOrWhiteSpace(newPassword.Text) || newPassword.Text.Length < 4)
            {
                vldNewPassword.Text = "Ít nhất 4 kí tự";
                return false;
            }
            else
            {
                vldNewPassword.Text = "";
                return true;
            }
        }
        public bool ValidationVNPassword()
        {
            if (string.IsNullOrWhiteSpace(verifyPassword.Text) || verifyPassword.Text.Length < 4)
            {
                vldVNPassword.Text = "Ít nhất 4 kí tự";
                return false;
            }
            else
            {
                vldVNPassword.Text = "";
                return true;
            }
        }
        private void savePassword_Clicked(object sender, EventArgs e)
        {
            if(ValidationPassword() && ValidationNewPassword() && ValidationVNPassword())
            {
                if (_user.password != password.Text)
                {
                    DisplayAlert("Error", "Password is wrong!", "OK");
                } 
                else if (newPassword.Text != verifyPassword.Text)
                {
                    DisplayAlert("Error", "Verify Password is wrong!", "OK");   
                }
                else
                {
                    bool result = userViews.ChangePassword(_user.id, newPassword.Text);
                    if (result)
                    {
                        _ = DisplayAlert("Successfully", "You updated password successfully", "Ok");
                    }
                    else
                    {
                        _ = DisplayAlert("Error", "Fail", "Ok");
                    }
                    password.Text = "";
                    newPassword.Text = "";
                    verifyPassword.Text = "";
                }
            }
            ValidationPassword();
            ValidationNewPassword();
            ValidationVNPassword();
        }
    }
}