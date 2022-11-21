using UITStore.Models;
using UITStore.Views.OrderPage;
using Xamarin.Forms;

namespace UITStore
{
    public partial class MainPage : TabbedPage
    {
        private readonly User _user;
        public MainPage()
        {
            InitializeComponent();
            _user = Application.Current.Properties["user"] as User;
            if(_user.role == "user")
            {
                Main.Children.Remove(Admin);
            }
        }

        private void CartOrder_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new CartOrder());
        }
    }
}