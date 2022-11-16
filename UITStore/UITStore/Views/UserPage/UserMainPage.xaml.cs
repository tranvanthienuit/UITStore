using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITStore.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.Views.UserPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserMainPage : ContentPage
    {
        private readonly User _user;
        public UserMainPage()
        {
            InitializeComponent();
            _user = Application.Current.Properties["user"] as User;
            BindingContext = _user;
        }

        private async void Logout_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Warning", "Do you really want to logout?", "Yes", "No");
            if(answer)
            {
                _ = Navigation.PushAsync(new Login());
            }
        }

        private void Profile_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Profile());
        }

        public async void changeAvatar_Clicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Please pick a avatar!"
            });
            if(result !=null)
            {
                var stream = await result.OpenReadAsync();
                avatar.Source = ImageSource.FromStream(() => stream);
            }   
        }
    }
}