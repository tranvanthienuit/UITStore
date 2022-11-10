using System;
using UITStore.Models;
using UITStore.UserPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserProfile : ContentPage
    {
        private readonly User _user;

        public UserProfile()
        {
            InitializeComponent();
            _user = Application.Current.Properties["user"] as User;
            BindingContext = _user;
        }

        private async void editProfile(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditProfile());
        }
    }
}