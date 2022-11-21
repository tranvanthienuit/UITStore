using UITStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UITStore.BlogPage;
using UITStore.Models;
using UITStore.Views.ProductPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.Views.HomePage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeSneaker : ContentPage
    {
        private ObservableCollection<Sneakers> _sneakersList;
        private List<Blog> listBlog = new BlogVM().GetBlogs();
        private readonly User _user;
        public HomeSneaker()
        {
            InitializeComponent();
            initSneaker();
            Banner();
            initBlog();
            _user = Application.Current.Properties["user"] as User;
        }

        public void Banner()
        {
            List<Banner> banner = new List<Banner>()
            {
                new Banner{Img = "Banner1.png", Title = "Banner1"},
                new Banner{Img = "Banner2.png", Title = "Banner2"},
                new Banner{Img = "Banner3.jpg", Title = "Banner3"},
                new Banner{Img = "Banner4.png", Title = "Banner4"},
                new Banner{Img = "Banner5.jpg", Title = "Banner5"}
            };
            Carousel.ItemsSource = banner;

            Device.StartTimer(TimeSpan.FromSeconds(2), (Func<bool>)(() =>
            {
                Carousel.Position = (Carousel.Position + 1) % banner.Count;
                return true;
            }));
        }
        private void initSneaker()
        {
            _sneakersList = new ObservableCollection<Sneakers>
            {
               new Sneakers
                (
                    "sneaker1", "NMD_R1 candy", "Sneakers1", 500000, 400000,
                     "tuyet voi ông mặt trời", "24", 24, "1"

                ),
                new Sneakers
                (
                    "sneaker2", "NMD_R1 candy", "Sneakers2", 500000, 400000,
                     "tuyet voi ông mặt trời", "24", 24, "2"

                ),
                new Sneakers
                (
                    "sneaker3", "NMD_R1 candy", "Sneakers1", 500000, 400000,
                     "tuyet voi ông mặt trời", "24", 24, "1"

                ),
                new Sneakers
                (
                    "sneaker4", "NMD_R1 candy", "Sneakers3", 500000, 400000,
                     "tuyet voi ông mặt trời", "24", 24, "3"

                ),
            };
            BestSellProduct.ItemsSource = _sneakersList.Where(p => p.category == "1");
            BestDiscountProduct.ItemsSource = _sneakersList.Where(p => p.category == "2");
            NewProduct.ItemsSource = _sneakersList.Where(p => p.category == "3");
        }

        private void TapFavourite_Tapped(object sender, EventArgs e)
        {
            Image img = (Image)sender;
            TapGestureRecognizer tapGesture = (TapGestureRecognizer)img.GestureRecognizers[0];
            Sneakers sneakerFavourite = tapGesture.CommandParameter as Sneakers;
            var favourite = new Favourite { userid = _user.ID, sneakerId = sneakerFavourite.sneakerId, name = sneakerFavourite.name, description = sneakerFavourite.description, category = sneakerFavourite.category, discount = sneakerFavourite.discount,
            img = sneakerFavourite.img, price = sneakerFavourite.price, rating = sneakerFavourite.rating, saleprice = sneakerFavourite.saleprice, size = sneakerFavourite.size, stock = sneakerFavourite.stock};
            var db = new SQLiteDatabase();
            if(db.ExistFavourite(favourite))
            {
                DisplayAlert("Message", "Sneaker is already in your favourite.", "ok");
            } else
            {
                db.addFavourite(favourite);
                DisplayAlert("Message", "Add Sneaker in your favourite successfully.", "ok");
            }
        }

        private void initBlog()
        {
            BlogHot.ItemsSource = listBlog;
        }
        private async void TapBlog_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            TapGestureRecognizer tapGesture = (TapGestureRecognizer)frame.GestureRecognizers[0];
            Blog detailBlog = tapGesture.CommandParameter as Blog;
            await Navigation.PushAsync(new BlogDetail(detailBlog));
        }

        private async void TapDetail_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            TapGestureRecognizer tapGesture = (TapGestureRecognizer)frame.GestureRecognizers[0];
            Sneakers detailProduct = tapGesture.CommandParameter as Sneakers;
            await Navigation.PushAsync(new SneakerDetailPage(detailProduct));
        }

    }
}