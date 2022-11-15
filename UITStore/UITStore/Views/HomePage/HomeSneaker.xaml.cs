using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UITStore.BlogPage;
using UITStore.Models;
using UITStore.ViewModels;
using UITStore.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.Views.HomePage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeSneaker : ContentPage
    {
        private ObservableCollection<Sneakers> _sneakersList;
        private List<Blog> listBlog = new BlogVM().GetBlogs();

        public HomeSneaker()
        {
            InitializeComponent();
            initSneaker();
            Banner();
            initBlog();
            /*listSneaker.ItemsSource = _sneakersList;
            // lấy dữ liệu từ store
            var ten = Application.Current.Properties["user"] as string;
            Console.WriteLine(ten);*/
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
                {
                    sneakerId = "sneaker1", name = "NMD_R1 candy", price = "500000", saleprice = "400000", picture = "Sneakers1",
                    description = "tuyet voi ông mặt trời", size = "24", category = "new", stock = "24"
                },
                new Sneakers
                {
                    sneakerId = "sneaker2", name = "NMD_R1 pink white", price = "500000", saleprice = "400000", picture = "Sneakers2",
                    description = "tuyet voi ông mặt trời", size = "24", category = "bestsell", stock = "24"
                },
                new Sneakers
                {
                    sneakerId = "sneaker3", name = "NMD_R1 mint pink", price = "500000", saleprice = "400000", picture = "Sneakers3",
                    description = "tuyet voi ông mặt trời", size = "24", category = "bestsell", stock = "24"
                },
                new Sneakers
                {
                    sneakerId = "sneaker4", name = "NMD_R1 white mint", price = "500000", saleprice = "400000", picture = "Sneakers4",
                    description = "tuyet voi ông mặt trời", size = "24", category = "discount", stock = "24"
                }
            };
            BestSellProduct.ItemsSource = _sneakersList.Where(p => p.category == "bestsell");
        }

        private void BestSellProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DisplayAlert("ok", "test", "ok");
        }

        private void TapFavourite_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("ok", "Favourite", "ok");
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
        /* private async void viewDetail(object sender, EventArgs e)
         {
             var btn = (Button)sender;
             await Navigation.PushAsync(new SneakerDetailPage((Sneakers)btn.BindingContext));
         }

         private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
         {
             var sneakersList = new ObservableCollection<Sneakers>();
             var key = e.NewTextValue;
             foreach (var item in _sneakersList)
                 if (item.name.ToLower().Contains(key.ToLower()))
                     sneakersList.Add(item);

             listSneaker.ItemsSource = sneakersList;
         }*/
    }
}