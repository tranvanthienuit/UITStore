using System;
using UITStore.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.UserPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private User _user;

        public Login()
        {
            InitializeComponent();
        }

        private async void signin(object sender, EventArgs e)
        {
            _user = new User
                { username = "admin", password = "admin", fullname = "admin", address = "ktx", telephone = "012345" };
            // cách để lưu dữ liệu tạm thời thời
            var name = username.Text;
            var pass = password.Text;
            if (name == _user.username && pass == _user.password)
            {
                Application.Current.Properties["user"] = _user;
                await Application.Current.SavePropertiesAsync();
                await Navigation.PushAsync(new MainPage());
                Application.Current.MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                DisplayAlert("Error", "Your username or password is correct.\rPlease, Sign in again !", "Yes", "No");
            }
        }


        private async void signup(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }
    }
}