using System;
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
        }

        private async void login(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
        

        private void register(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}