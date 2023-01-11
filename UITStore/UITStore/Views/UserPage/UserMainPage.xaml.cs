using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITStore.Models;
using UITStore.ViewModels;
using UITStore.Views.AdminPage;
using UITStore.Views.StoragePage;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.Views.UserPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserMainPage : ContentPage
    {
        private User _user;
        private List<Vouchers> vouchers = new VoucherVM().GetVoucher();
        private ObservableCollection<Favourite> favourites;
        public OrderVM orderVM = new OrderVM();
        public UserMainPage()
        {
            InitializeComponent();
            _user = Application.Current.Properties["user"] as User;
            BindingContext = _user;
            int lengthVoucher = vouchers.ToArray().Length;
            voucher.Text = lengthVoucher.ToString();
            var db = new SQLiteDatabase();
            favourites = db.getFavourite(_user.id);
            favourite.Text = favourites.ToArray().Length > 0 ? favourites.ToArray().Length.ToString() : "0";
            Order.Text = orderVM.GetOrderByUserId(_user.id).ToArray().Length.ToString();
            if(_user.role != "admin")
            {
                Main.Children.Remove(MainAdmin);
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var db = new SQLiteDatabase();
            favourites = db.getFavourite(_user.id);
            favourite.Text = favourites.ToArray().Length > 0 ? favourites.ToArray().Length.ToString() : "0";
            Order.Text = orderVM.GetOrderByUserId(_user.id).ToArray().Length.ToString();
            _user = Application.Current.Properties["user"] as User;
            BindingContext = _user;
        }
        private async void Logout_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Cảnh báo!", "Bạn thực sự muốn đăng xuất?", "Có", "Không");
            if (answer)
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
                Title = "Chọn avatar!"
            });
            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                avatar.Source = ImageSource.FromStream(() => stream);
            }
        }

        private void ChangePassword_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChangePassword());
        }

        private void Voucher_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Voucher());
        }

        private void Favourite_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FavouritePage());
        }

        private void MyOrder_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MyOrderPage());
        }

        private void Admin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdminMainPage());
            Application.Current.MainPage = new NavigationPage(new AdminMainPage());
        }
    }
}