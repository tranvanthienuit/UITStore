using System;
using ProjSQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.UserPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private Database _database;

        public Login()
        {
            InitializeComponent();
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
                DisplayAlert("Error", "Your username or password is correct.\rPlease, Sign in again !", "Yes", "No");
            }
        }


        private async void signup(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }
    }
}