using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.Views.AdminPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminMainPage : ContentPage
    {
        public AdminMainPage()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }

        private void MUser_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserAdmin());
        }

        private void MProduct_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProductAdmin());
        }

        private void MOrder_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OrderAdmin());
        }
    }
}