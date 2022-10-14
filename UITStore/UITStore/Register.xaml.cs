using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
        }

        private async void signup(object sender, EventArgs e)
        {
            DisplayAlert("Successfull", "", "Yes", "");
            await Navigation.PushAsync(new Login());
        }

        private async void signin(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }
    }
}