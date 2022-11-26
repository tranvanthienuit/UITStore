using System;
using UITStore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.Views.UserPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public UserVM userViews = new UserVM();

        public Login()
        {
            InitializeComponent();
            BindingContext = userViews;
            username.Focused += UsernameEntry_Focused;
            username.Unfocused += UsernameEntry_Unfocused;
            password.Focused += PasswordEntry_Focused;
            password.Unfocused += PasswordEntry_Unfocused;
        }

        private async void signin(object sender, EventArgs e)
        {
            if (ValidationUsername() && ValidationPassword())
            {
                bool result = userViews.Login();
                if (result)
                {
                    await Navigation.PushAsync(new MainPage());
                    Application.Current.MainPage = new NavigationPage(new MainPage());
                }
                else
                {
                    _ = DisplayAlert("Error", "Your username or password is correct.\rPlease, Sign in again !", "Yes", "No");
                }
            }
            ValidationUsername();
            ValidationPassword();
        }


        private async void signup(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
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
    }
}