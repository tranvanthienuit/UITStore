using System;
using UITStore.Models;
using UITStore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.Views.UserPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        public UserVM userViews;

        public Register()
        {
            InitializeComponent();
            userViews = new UserVM();
            BindingContext = userViews;

            username.Focused += UsernameEntry_Focused;
            username.Unfocused += UsernameEntry_Unfocused;
            password.Focused += PasswordEntry_Focused;
            password.Unfocused += PasswordEntry_Unfocused;
            fullname.Focused += FullNameEntry_Focused;
            fullname.Unfocused += FullNameEntry_Unfocused;
            phone.Focused += PhoneEntry_Focused;
            phone.Unfocused += PhoneEntry_Unfocused;
            address.Focused += AddressEntry_Focused;
            address.Unfocused += AddressEntry_Unfocused;
        }

        private async void signin(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }

        private async void signUp(object sender, EventArgs e)
        {
            if (ValidationUsername() && ValidationPassword() && ValidationFullname() && ValidationPhone() && ValidationAddress())
            {
                var result = userViews.addNewUser();
                if (result)
                {
                    var signResult = await DisplayAlert("Successfully", "You sign up, successfully", "Yes", "No");
                    if (signResult) await Navigation.PushAsync(new Login());
                }
            }
            ValidationUsername();
            ValidationPassword();
            ValidationFullname();
            ValidationPhone();
            ValidationAddress();
        }
        private void UsernameEntry_Unfocused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(username.Text))
            {
                usernameLabel.ScaleXTo(1);
                usernameLabel.ScaleYTo(1);
                usernameLabel.TranslateTo(0, 0);
            }
        }

        private void UsernameEntry_Focused(object sender, FocusEventArgs e)
        {
            usernameLabel.ScaleYTo(0.8);
            usernameLabel.ScaleXTo(0.8);
            usernameLabel.TranslateTo(0, -usernameLabel.Height);
        }
        private void PasswordEntry_Unfocused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(password.Text))
            {
                passwordLabel.ScaleXTo(1);
                passwordLabel.ScaleYTo(1);
                passwordLabel.TranslateTo(0, 0);
            }
        }

        private void PasswordEntry_Focused(object sender, FocusEventArgs e)
        {
            passwordLabel.ScaleYTo(0.8);
            passwordLabel.ScaleXTo(0.8);
            passwordLabel.TranslateTo(0, -passwordLabel.Height);
        }
        private void FullNameEntry_Unfocused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(fullname.Text))
            {
                fullnameLabel.ScaleXTo(1);
                fullnameLabel.ScaleYTo(1);
                fullnameLabel.TranslateTo(0, 0);
            }
        }

        private void FullNameEntry_Focused(object sender, FocusEventArgs e)
        {
            fullnameLabel.ScaleYTo(0.8);
            fullnameLabel.ScaleXTo(0.8);
            fullnameLabel.TranslateTo(0, -fullnameLabel.Height);
        }
        private void PhoneEntry_Unfocused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(phone.Text))
            {
                phoneLabel.ScaleXTo(1);
                phoneLabel.ScaleYTo(1);
                phoneLabel.TranslateTo(0, 0);
            }
        }

        private void PhoneEntry_Focused(object sender, FocusEventArgs e)
        {
            phoneLabel.ScaleYTo(0.8);
            phoneLabel.ScaleXTo(0.8);
            phoneLabel.TranslateTo(0, -phoneLabel.Height);
        }
        private void AddressEntry_Unfocused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(address.Text))
            {
                addressLabel.ScaleXTo(1);
                addressLabel.ScaleYTo(1);
                addressLabel.TranslateTo(0, 0);
            }
        }

        private void AddressEntry_Focused(object sender, FocusEventArgs e)
        {
            addressLabel.ScaleYTo(0.8);
            addressLabel.ScaleXTo(0.8);
            addressLabel.TranslateTo(0, -addressLabel.Height);
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
    }
}