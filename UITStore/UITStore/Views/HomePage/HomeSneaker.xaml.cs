using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UITStore.Models;
using UITStore.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.Views.HomePage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeSneaker : ContentPage
    {
        private ObservableCollection<Sneakers> _sneakersList;

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
            List<Blog>  NewsList = new List<Blog>();
            NewsList.Add(new Blog
            {
                title = "Top 2 Mẫu Giày Cho Người Lùn Nam Được Yêu Thích Nhất",
                img = "news_1_2",
                content =
                    "Giày Thể Thao Nam DT20: DT20 là một mẫu giày cho người lùn nam rất được nhiều anh ưa chuộng. Diện mạo trẻ trung, hiện đại gây ấn tượng ngay cái nhìn đầu tiên.Chất da được tuyển chọn kỹ lưỡng nhằm đảm bảo chất lượng cho đôi giày. Dây giày được thiết kế theo kiểu truyền thống.Để bảo vệ cho gót chân, DT20 có phần lót vải dày dặn ở cổ giày. Còn phần lót chân thì chịu lực, có khả năng thấm hút mồ hôi tốt.",
                description =
                    "Dòng giày này phong phú về kiểu dáng và chất lượng. hdifhdsfhdufhdufhduhufhgudfghdfughdfughdfughdfughdfuhgdfughdfudhfudhfudh",
                date = "22/10/2022",
                author = "Lê Văn Luyện"
            });
            NewsList.Add(new Blog
            {
                title = "Top 2 Mẫu Giày Cho Người Lùn Nam Được Yêu Thích Nhất",
                img = "news_1_2",
                content =
                    "Giày Thể Thao Nam DT20: DT20 là một mẫu giày cho người lùn nam rất được nhiều anh ưa chuộng. Diện mạo trẻ trung, hiện đại gây ấn tượng ngay cái nhìn đầu tiên.Chất da được tuyển chọn kỹ lưỡng nhằm đảm bảo chất lượng cho đôi giày. Dây giày được thiết kế theo kiểu truyền thống.Để bảo vệ cho gót chân, DT20 có phần lót vải dày dặn ở cổ giày. Còn phần lót chân thì chịu lực, có khả năng thấm hút mồ hôi tốt.",
                description =
                    "Dòng giày này phong phú về kiểu dáng và chất lượng.",
                date = "22/10/2022",
                author = "admin1"
            });
            BlogHot.ItemsSource = NewsList;
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