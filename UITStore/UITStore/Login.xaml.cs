using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            // cách để lưu dữ liệu tạm thời thời
            Application.Current.Properties["user"] = "vanthien";
            Application.Current.SavePropertiesAsync();
        }

        private async void signin(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
        

        private async void signup(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }
    }
}