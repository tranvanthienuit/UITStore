
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using UITStore.Models;
using UITStore.ViewModels;
using UITStore.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.Views.ProductPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Store : ContentPage
    {
        private readonly User _user;
        public SneakerVM sneakerVM = new SneakerVM();
        public Store()
        {
            InitializeComponent();
            initSneaker();
            _user = Application.Current.Properties["user"] as User;
        }
    
        private void initSneaker()
        {
            Product.ItemsSource = sneakerVM.GetSneaker();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Product.ItemsSource = sneakerVM.GetSneaker();
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
                Product.ItemsSource = sneakerVM.GetSneaker().Where(p => p.category == "Nike");
            } else
            {
                FNike.BackgroundColor = Color.White;
                LNike.TextColor = Color.Black;
                TitleTag.Text = "Tất cả sản phẩm";
                Product.ItemsSource = sneakerVM.GetSneaker();
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
                Product.ItemsSource = sneakerVM.GetSneaker().Where(p => p.category == "Adidas");
            }
            else
            {
                FAdidas.BackgroundColor = Color.White;
                LAdidas.TextColor = Color.Black;
                TitleTag.Text = "Tất cả sản phẩm";
                Product.ItemsSource = sneakerVM.GetSneaker();
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
                Product.ItemsSource = sneakerVM.GetSneaker().Where(p => p.category == "New Balance");
            }
            else
            {
                FNB.BackgroundColor = Color.White;
                LNB.TextColor = Color.Black;
                TitleTag.Text = "Tất cả sản phẩm";
                Product.ItemsSource = sneakerVM.GetSneaker();
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
                Product.ItemsSource = sneakerVM.GetSneaker().Where(p => p.category == "Vans");
            }
            else
            {
                FVans.BackgroundColor = Color.White;
                LVans.TextColor = Color.Black;
                TitleTag.Text = "Tất cả sản phẩm";
                Product.ItemsSource = sneakerVM.GetSneaker();
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
                Product.ItemsSource = sneakerVM.GetSneaker().Where(p => p.category == "MLB");
            }
            else
            {
                FMLB.BackgroundColor = Color.White;
                LMLB.TextColor = Color.Black;
                TitleTag.Text = "Tất cả sản phẩm";
                Product.ItemsSource = sneakerVM.GetSneaker();
            }
        }

        private async void TapProduct_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            TapGestureRecognizer tapGesture = (TapGestureRecognizer)frame.GestureRecognizers[0];
            Sneakers detailProduct = tapGesture.CommandParameter as Sneakers;
            await Navigation.PushAsync(new SneakerDetailPage(detailProduct));
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            FNike.BackgroundColor = Color.White;
            LNike.TextColor = Color.Black;
            FAdidas.BackgroundColor = Color.White;
            LAdidas.TextColor = Color.Black;
            FNB.BackgroundColor = Color.White;
            LNB.TextColor = Color.Black;
            FVans.BackgroundColor = Color.White;
            LVans.TextColor = Color.Black;
            FMLB.BackgroundColor = Color.White;
            LMLB.TextColor = Color.Black;
            if(e.NewTextValue != "")
            {
                int length = sneakerVM.GetSneaker().Where(p => p.name.ToLower().Contains(e.NewTextValue)).ToArray().Length;
                TitleTag.Text = "Có " + length + " sản phẩm";
            } else
            {
                TitleTag.Text = "Tất cả sản phẩm";
            }
            
            Product.ItemsSource = sneakerVM.GetSneaker().Where(p => p.name.ToLower().Contains(e.NewTextValue));
        }

        private void SortProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            FNike.BackgroundColor = Color.White;
            LNike.TextColor = Color.Black;
            FAdidas.BackgroundColor = Color.White;
            LAdidas.TextColor = Color.Black;
            FNB.BackgroundColor = Color.White;
            LNB.TextColor = Color.Black;
            FVans.BackgroundColor = Color.White;
            LVans.TextColor = Color.Black;
            FMLB.BackgroundColor = Color.White;
            LMLB.TextColor = Color.Black;
            if (SortProduct.SelectedIndex == 0)
            {
                Product.ItemsSource = sneakerVM.FilterSneaker(100, "salePrice", "DESC");
            }
            else if (SortProduct.SelectedIndex == 1)
            {
                Product.ItemsSource = sneakerVM.FilterSneaker(100, "salePrice", "ASC");
            }
            else
          if (SortProduct.SelectedIndex == 2)
            {
                Product.ItemsSource = sneakerVM.FilterSneaker(100, "discount", "DESC");
            }
            else if (SortProduct.SelectedIndex == 3)
            {
                Product.ItemsSource = sneakerVM.FilterSneaker(100, "createDate", "DESC");
            }
        }
    }
}