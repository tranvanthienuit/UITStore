
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITStore.Models;
using UITStore.Views.ProductPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.Views.StoragePage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavouritePage : ContentPage
    {
        private ObservableCollection<Favourite> favourites;
        private readonly User _user;
        public FavouritePage()
        {
            InitializeComponent();
            var db = new SQLiteDatabase();
            _user = Application.Current.Properties["user"] as User;
            favourites = db.getFavourite(_user.id);
            DataFavourite.ItemsSource = favourites;
        }

        private async void  TapFavourite_Tapped(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Cảnh báo", "Bạn thực sự muốn xóa nó?", "Có", "Không");
            if(answer)
            {
                Image img = (Image)sender;
                TapGestureRecognizer tapGesture = (TapGestureRecognizer)img.GestureRecognizers[0];
                Favourite favourite = tapGesture.CommandParameter as Favourite;
                var db = new SQLiteDatabase();
                db.deleteFavourite(favourite.id);
                DataFavourite.ItemsSource = db.getFavourite(_user.id);
            }
        }
    }
}