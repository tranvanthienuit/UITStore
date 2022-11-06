using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.Views.UserPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserMainPage : ContentPage
    {
        public UserMainPage()
        {
            InitializeComponent();
        }

        private async void logout_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Warning", "Do you really want to logout?", "Yes", "No");
            if(answer)
            {
                _ = Navigation.PushAsync(new Login());
            }
        }
    }
}