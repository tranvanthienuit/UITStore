using System;
using System.Collections.Generic;
using Newtonsoft.Json;

using System.Threading.Tasks;
using UITStore.Models;
using UITStore.Views.OrderPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.Views.ProductPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SneakerDetailPage : ContentPage
    {
        public Sneakers sneaker;
        private readonly User _user;
        public SneakerDetailPage(Sneakers sneakers)
        {
            InitializeComponent();
            BindingContext = sneakers;
            sneaker = sneakers;
            _user = Application.Current.Properties["user"] as User;
        }

        private void TapFavourite_Tapped(object sender, EventArgs e)
        {

        }

        
        private async void TapSize_Tapped(object sender, EventArgs e)
        {

            string[] listSize = sneaker.size.Split(',');
            string action;
            if (listSize.Length > 0)
            {
                action = await DisplayActionSheet("Size", "Cancel", null, listSize);
                size.Text = action != "Cancel" ? action : size.Text;
            }
            else
            {
                await DisplayAlert("Size", "UnAvailable", "OK");
                size.Text = "Null";
            }
        }

        private void Sub_Clicked(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(Count.Text);
            if(count > 1)
            {
                count = count - 1;
            } else
            {
                count = 1;
            }
            Count.Text = count.ToString();
        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            Count.Text = (Convert.ToInt32(Count.Text) + 1).ToString();
        }

        private async void AddToCart_Clicked(object sender, EventArgs e)
        {
            if(size.Text != null && sneaker.stock > 0)
            {
                var cart = new Cart { userid = _user.ID, productid = sneaker.sneakerId ,img = sneaker.img, name = sneaker.name, price = sneaker.saleprice ,productsize = Convert.ToInt32(size.Text), quantity = Convert.ToInt32(Count.Text)};
                var db = new SQLiteDatabase();
                db.addCart(cart);
                await DisplayAlert("Notification", "Add to cart successfully!", "Ok");
            } else
            {
                if(size.Text == null)
                {
                    await DisplayAlert("Notification", "Please chosse size sneaker.", "Ok");
                } else
                {
                    await DisplayAlert("Notification", "Out of stock.", "Ok");
                }
            }
        }

        private void SaveComment_Clicked(object sender, EventArgs e)
        {                                             
            if(Rating.SelectedStarValue != 0 && Comment.Text != null)
            {
                DisplayAlert("Show", Rating.SelectedStarValue.ToString() + Comment.Text, "Ok");
            }
        }
    }
}