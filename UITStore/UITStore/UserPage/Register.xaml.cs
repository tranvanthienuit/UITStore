using System;
using UITStore.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.UserPage
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
    }
}