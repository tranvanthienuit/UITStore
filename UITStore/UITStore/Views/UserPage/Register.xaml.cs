using System;
using UITStore.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.Views.UserPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        public UserViews userViews;

        public Register()
        {
            InitializeComponent();
            userViews = new UserViews();
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
            var result = userViews.addNewUser();
            if (result)
            {
                var signResult = await DisplayAlert("Successfully", "You sign up, successfully", "Yes", "No");
                if (signResult) await Navigation.PushAsync(new Login());
            }
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
    }
}