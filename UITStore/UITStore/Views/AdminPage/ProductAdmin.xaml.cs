using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITStore.Models;
using UITStore.ViewModels;
using UITStore.Views.ProductPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.Views.AdminPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductAdmin : ContentPage
    {
        public SneakerVM sneakerVM = new SneakerVM();
        public ProductAdmin()
        {
            InitializeComponent();
            Product.ItemsSource = sneakerVM.GetSneaker();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Product.ItemsSource = sneakerVM.GetSneaker();
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
            
            if (e.NewTextValue != "")
            {
                Product.ItemsSource = sneakerVM.GetSneaker().Where(p => p.name.ToLower().Contains(e.NewTextValue));
            }
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddProduct());
        }

        private void TapEdit_Tapped(object sender, EventArgs e)
        {
            Image img = (Image)sender;
            TapGestureRecognizer tapGesture = (TapGestureRecognizer)img.GestureRecognizers[0];
            Sneakers sneaker = tapGesture.CommandParameter as Sneakers;
            Navigation.PushAsync(new AddProduct(sneaker));
        }

        private async void TapDelete_Tapped(object sender, EventArgs e)
        {
            Image img = (Image)sender;
            TapGestureRecognizer tapGesture = (TapGestureRecognizer)img.GestureRecognizers[0];
            Sneakers sneaker = tapGesture.CommandParameter as Sneakers;
            bool ans = await DisplayAlert("Cảnh báo", "Bạn thực sự muốn xóa sản phẩm này?", "Có", "Không");
            if(ans)
            {
                sneakerVM.DeleteSneaker(sneaker.id);
                Product.ItemsSource = sneakerVM.GetSneaker();
            }
        }
    }
}