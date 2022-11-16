using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using UITStore.Models;
using UITStore.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.Views.ProductPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Store : ContentPage
    {
        public ObservableCollection<SneakerBy> sneakerList;
        private ObservableCollection<Sneakers> _sneakersList;

        public Store()
        {
            /*if (Application.Current.Properties.ContainsKey("store"))
            {
                var listSneaker = Application.Current.Properties["store"] as string;
                Console.WriteLine(listSneaker);
                var list = JsonConvert.DeserializeObject<List<SneakerBy>>(listSneaker);
                if (list.Count != 0)
                    sneakerList = new ObservableCollection<SneakerBy>(list);
                else
                    sneakerList = null;
            }*/

            InitializeComponent();
            initSneaker();
            
            /*if (Application.Current.Properties["pay"] as string == "notbuy")
            {
                Pay.Text = "Let's select item you want";
            }
            else
            {
                if (Application.Current.Properties["pay"] as string == "true")
                    Pay.Text = "Order Ordered";
                else
                    Pay.Text = "You Now";
            }


            listSneaker.ItemsSource = sneakerList;*/
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
                    "sneaker1", "NMD_R1 candy", "Sneakers1", 500000, 400000,
                     "tuyet voi ông mặt trời", "24", 24, "1"

                ),
                new Sneakers
                (
                    "sneaker1", "NMD_R1 candy", "Sneakers1", 500000, 400000,
                     "tuyet voi ông mặt trời", "24", 24, "1"

                ),
                new Sneakers
                (
                    "sneaker1", "NMD_R1 candy", "Sneakers1", 500000, 400000,
                     "tuyet voi ông mặt trời", "24,26,28", 24, "1"

                ),
                new Sneakers
                (
                    "sneaker1", "NMD_R1 candy", "Sneakers1", 500000, 400000,
                     "tuyet voi ông mặt trời", "24,25,26", 24, "1"

                ),
            };
            Product.ItemsSource = _sneakersList;
            
        }


        private void Tap_Nike_Tapped(object sender, EventArgs e)
        {
            if(FNike.BackgroundColor != Color.FromHex("#38B6FF"))
            {
                FNike.BackgroundColor = Color.FromHex("#38B6FF");
                LNike.TextColor = Color.FromHex("#38B6FF");
                FAdidas.BackgroundColor = Color.White;
                LAdidas.TextColor = Color.Black;
                FNB.BackgroundColor = Color.White;
                LNB.TextColor = Color.Black;
                FVans.BackgroundColor = Color.White;
                LVans.TextColor = Color.Black;
                FMLB.BackgroundColor = Color.White;
                LMLB.TextColor = Color.Black;
                TitleTag.Text = "Sản phẩm Nike";
                Product.ItemsSource = _sneakersList.Where(p => p.category == "1");
            } else
            {
                FNike.BackgroundColor = Color.White;
                LNike.TextColor = Color.Black;
                TitleTag.Text = "Tất cả sản phẩm";
                Product.ItemsSource = _sneakersList;
            }
        }

        

        private void Tap_Adidas_Tapped(object sender, EventArgs e)
        {
            if (FAdidas.BackgroundColor != Color.FromHex("#38B6FF"))
            {
                FNike.BackgroundColor = Color.White;
                LNike.TextColor = Color.Black;
                FAdidas.BackgroundColor = Color.FromHex("#38B6FF");
                LAdidas.TextColor = Color.FromHex("#38B6FF");
                FNB.BackgroundColor = Color.White;
                LNB.TextColor = Color.Black;
                FVans.BackgroundColor = Color.White;
                LVans.TextColor = Color.Black;
                FMLB.BackgroundColor = Color.White;
                LMLB.TextColor = Color.Black;
                TitleTag.Text = "Sản phẩm Adidas";
                Product.ItemsSource = _sneakersList.Where(p => p.category == "2");
            }
            else
            {
                FAdidas.BackgroundColor = Color.White;
                LAdidas.TextColor = Color.Black;
                TitleTag.Text = "Tất cả sản phẩm";
                Product.ItemsSource = _sneakersList;
            }
        }

        private void Tap_NB_Tapped(object sender, EventArgs e)
        {
            if (FNB.BackgroundColor != Color.FromHex("#38B6FF"))
            {
                FNike.BackgroundColor = Color.White;
                LNike.TextColor = Color.Black;
                FAdidas.BackgroundColor = Color.White;
                LAdidas.TextColor = Color.Black;
                FNB.BackgroundColor = Color.FromHex("#38B6FF");
                LNB.TextColor = Color.FromHex("#38B6FF");
                FVans.BackgroundColor = Color.White;
                LVans.TextColor = Color.Black;
                FMLB.BackgroundColor = Color.White;
                LMLB.TextColor = Color.Black;
                TitleTag.Text = "Sản phẩm NB";
                Product.ItemsSource = _sneakersList.Where(p => p.category == "3");
            }
            else
            {
                FNB.BackgroundColor = Color.White;
                LNB.TextColor = Color.Black;
                TitleTag.Text = "Tất cả sản phẩm";
                Product.ItemsSource = _sneakersList;
            }
        }

        private void Tap_Vans_Tapped(object sender, EventArgs e)
        {
            if (FVans.BackgroundColor != Color.FromHex("#38B6FF"))
            {
                FNike.BackgroundColor = Color.White;
                LNike.TextColor = Color.Black;
                FAdidas.BackgroundColor = Color.White;
                LAdidas.TextColor = Color.Black;
                FNB.BackgroundColor = Color.White;
                LNB.TextColor = Color.Black;
                FVans.BackgroundColor = Color.FromHex("#38B6FF");
                LVans.TextColor = Color.FromHex("#38B6FF");
                FMLB.BackgroundColor = Color.White;
                LMLB.TextColor = Color.Black;
                TitleTag.Text = "Sản phẩm Vans";
                Product.ItemsSource = _sneakersList.Where(p => p.category == "4");
            }
            else
            {
                FVans.BackgroundColor = Color.White;
                LVans.TextColor = Color.Black;
                TitleTag.Text = "Tất cả sản phẩm";
                Product.ItemsSource = _sneakersList;
            }
        }

        private void Tap_MLB_Tapped(object sender, EventArgs e)
        {
            if (FMLB.BackgroundColor != Color.FromHex("#38B6FF"))
            {
                FNike.BackgroundColor = Color.White;
                LNike.TextColor = Color.Black;
                FAdidas.BackgroundColor = Color.White;
                LAdidas.TextColor = Color.Black;
                FNB.BackgroundColor = Color.White;
                LNB.TextColor = Color.Black;
                FVans.BackgroundColor = Color.White;
                LVans.TextColor = Color.Black;
                FMLB.BackgroundColor = Color.FromHex("#38B6FF");
                LMLB.TextColor = Color.FromHex("#38B6FF");
                TitleTag.Text = "Sản phẩm MLB";
                Product.ItemsSource = _sneakersList.Where(p => p.category == "5");
            }
            else
            {
                FMLB.BackgroundColor = Color.White;
                LMLB.TextColor = Color.Black;
                TitleTag.Text = "Tất cả sản phẩm";
                Product.ItemsSource = _sneakersList;
            }
        }

        private async void TapProduct_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            TapGestureRecognizer tapGesture = (TapGestureRecognizer)frame.GestureRecognizers[0];
            Sneakers detailProduct = tapGesture.CommandParameter as Sneakers;
            await Navigation.PushAsync(new SneakerDetailPage(detailProduct));
        }
        /*      private async void viewDetail(object sender, EventArgs e)
{
var btn = (Button)sender;
var sneakerBy = (SneakerBy)btn.BindingContext;
await Navigation.PushAsync(new SneakerDetailPage(sneakerBy.Sneakers));
}
        private async void Product_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var detailProduct = e.CurrentSelection[0] as Sneakers;
            await Navigation.PushAsync(new SneakerDetailPage(detailProduct));
        }
private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
{
var sneakersList = new ObservableCollection<Sneakers>();
var key = e.NewTextValue;
foreach (var item in sneakersList)
if (item.name.ToLower().Contains(key.ToLower()))
sneakersList.Add(item);

listSneaker.ItemsSource = sneakersList;
}

private async void payNow(object sender, EventArgs e)
{
await DisplayAlert("Congratulation", "You ordered, successfully", "Yes", "No");
Application.Current.Properties["pay"] = "true";
await Application.Current.SavePropertiesAsync();
await Navigation.PushAsync(new MainPage());
Application.Current.MainPage = new NavigationPage(new MainPage());
}*/
    }
}