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
                DisplayAlert("Thông báo", "Sản phẩm đã có trong yêu thích.", "ok");
            }
            else
            {
                db.addFavourite(favourite);
                DisplayAlert("Thông báo", "Thêm vào yêu thích thành công.", "ok");
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
                action = await DisplayActionSheet("Size", "Hủy", null, listSize);
                size.Text = action != "Hủy" ? action : size.Text;
            }
            else
            {
                await DisplayAlert("Size", "Không có sẵn", "OK");
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
                bool answer = await DisplayAlert("Thông báo", "Thêm vào giỏ hàng thành công! Đi tới giỏ hàng?", "Có", "Không");
                if(answer)
                {
                    await Navigation.PushAsync(new CartOrder());
                }
            } else
            {
                if(size.Text == null)
                {
                    await DisplayAlert("Thông báo", "Vui lòng chọn size.", "Ok");
                } else
                {
                    await DisplayAlert("Thông báo", "Hết hàng.", "Ok");
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
                    DisplayAlert("Thành công", "Thêm đánh giá thành công", "Ok");
                } else
                {
                    DisplayAlert("Lỗi", "Lỗi!", "Ok");
                }
            } else
            {
                DisplayAlert("Cảnh báo", "Điền đầy đủ thông tin", "Ok");
            }
            ListComment.ItemsSource = commentVM.GetComments(sneaker.id);
            BindingContext = sneakerVM.GetSneakerById(sneaker.id);
            Rating.SelectedStarValue = 0;
            Comment.Text = "";
        }
    }
}