using System;
using ProjSQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.Views.UserPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private Database _database;
        public Login()
        {
            InitializeComponent();
            username.Focused += UsernameEntry_Focused;
            username.Unfocused += UsernameEntry_Unfocused;
            password.Focused += PasswordEntry_Focused;
            password.Unfocused += PasswordEntry_Unfocused;
        }

        private async void signin(object sender, EventArgs e)
        {
            _database = new Database();
            var user = _database.getUser(username.Text, password.Text);
            // cách để lưu dữ liệu tạm thời thời
            // var name = username.Text;
            // var pass = password.Text;
            if (user != null)
            {
                Application.Current.Properties["user"] = user;
                Application.Current.Properties["pay"] = "notbuy";
                await Application.Current.SavePropertiesAsync();
                await Navigation.PushAsync(new MainPage());
                Application.Current.MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                _ = DisplayAlert("Error", "Your username or password is correct.\rPlease, Sign in again !", "Yes", "No");
            }
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
    }
}