using System;
using System.Collections.Generic;
using Newtonsoft.Json;

using System.Threading.Tasks;
using UITStore.Models;
using UITStore.Views.OrderPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UITStore.ViewModels;

namespace UITStore.Views.ProductPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SneakerDetailPage : ContentPage
    {
        public Sneakers sneaker;
        private readonly User _user;
        public CommentVM commentVM = new CommentVM();
        public SneakerVM sneakerVM = new SneakerVM();
        public SneakerDetailPage(Sneakers sneakers)
        {
            InitializeComponent();
            BindingContext = sneakers;
            sneaker = sneakers;
            _user = Application.Current.Properties["user"] as User;
            ListComment.ItemsSource = commentVM.GetComments(sneaker.id);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ListComment.ItemsSource = commentVM.GetComments(sneaker.id);
            BindingContext = sneakerVM.GetSneakerById(sneaker.id);
        }

        private void TapFavourite_Tapped(object sender, EventArgs e)
        {
            Image img = (Image)sender;
            TapGestureRecognizer tapGesture = (TapGestureRecognizer)img.GestureRecognizers[0];
            Sneakers sneakerFavourite = tapGesture.CommandParameter as Sneakers;
            var favourite = new Favourite
            {
                userid = _user.id,
                sneakerId = sneakerFavourite.id.ToString(),
                name = sneakerFavourite.name,
                description = sneakerFavourite.description,
                category = sneakerFavourite.category,
                discount = sneakerFavourite.discount,
                img = sneakerFavourite.image,
                price = sneakerFavourite.price,
                rating = sneakerFavourite.rating,
                saleprice = sneakerFavourite.salePrice,
                size = sneakerFavourite.size,
                stock = sneakerFavourite.stock
            };
            var db = new SQLiteDatabase();
            if (db.ExistFavourite(favourite))
            {
                DisplayAlert("Message", "Sneaker is already in your favourite.", "ok");
            }
            else
            {
                db.addFavourite(favourite);
                DisplayAlert("Message", "Add Sneaker in your favourite successfully.", "ok");
            }
        }
        private void OnDelete(object sender, EventArgs e)
        {
            SwipeItem swipeItem = (SwipeItem)sender;
            DataComment cmt = swipeItem.CommandParameter as DataComment;
            if(cmt.userid == _user.id)
            {
                commentVM.DeleteComment(cmt.id);
            }
            ListComment.ItemsSource = commentVM.GetComments(sneaker.id);
            BindingContext = sneakerVM.GetSneakerById(sneaker.id);
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
            if(size.Text != null && sneaker.stock > 0 && Convert.ToInt32(Count.Text) < sneaker.stock)
            {
                var cart = new Cart { userid = _user.id, productid = sneaker.id ,img = sneaker.image, name = sneaker.name, price = sneaker.salePrice ,productsize = Convert.ToInt32(size.Text), quantity = Convert.ToInt32(Count.Text)};
                var db = new SQLiteDatabase();
                db.addCart(cart);
                bool answer = await DisplayAlert("Notification", "Add to cart successfully! Do you want to go to the shopping cart page?", "Yes", "No");
                if(answer)
                {
                    await Navigation.PushAsync(new CartOrder());
                }
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
                bool answer = commentVM.AddNewComment(sneaker.id, _user.id, Rating.SelectedStarValue, Comment.Text);
                if(answer)
                {
                    DisplayAlert("Successfully", "Add comment succesfully", "Ok");
                } else
                {
                    DisplayAlert("Erorr", "Fail!", "Ok");
                }
            } else
            {
                DisplayAlert("Warning", "Please fill in all the details!", "Ok");
            }
            ListComment.ItemsSource = commentVM.GetComments(sneaker.id);
            BindingContext = sneakerVM.GetSneakerById(sneaker.id);
            Rating.SelectedStarValue = 0;
            Comment.Text = "";
        }
    }
}