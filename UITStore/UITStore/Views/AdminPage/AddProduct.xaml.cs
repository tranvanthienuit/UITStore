using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITStore.Models;
using UITStore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.Views.AdminPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProduct : ContentPage
    {
        Sneakers _sneaker;
        public SneakerVM sneakerVM = new SneakerVM();
        public AddProduct()
        {
            InitializeComponent();
            Title = "Thêm sản phẩm";
        }
        public AddProduct(Sneakers sneaker)
        {
            InitializeComponent();
            Title = "Sửa sản phẩm";
            _sneaker = sneaker;
            name.Text = sneaker.name;
            stock.Text = sneaker.stock.ToString();
            size.Text = sneaker.size;
            price.Text = sneaker.price.ToString();
            salePrice.Text = sneaker.salePrice.ToString();
            category.Text = sneaker.category;
            image.Text = sneaker.image;
            description.Text = sneaker.description;
        }

        private async void save_product_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(name.Text) || string.IsNullOrWhiteSpace(stock.Text) || string.IsNullOrWhiteSpace(size.Text)
                || string.IsNullOrWhiteSpace(price.Text) || string.IsNullOrWhiteSpace(salePrice.Text) || string.IsNullOrWhiteSpace(category.Text)
                || string.IsNullOrWhiteSpace(image.Text) || string.IsNullOrWhiteSpace(description.Text))
            {
                await DisplayAlert("Thông báo", "Vui lòng điền đầy đủ thông tin!", "OK");
            }
            else if(_sneaker != null)
            {
                bool ans = sneakerVM.UpdateSneaker(_sneaker.id, name.Text, size.Text, Convert.ToInt32(stock.Text), Convert.ToDouble(price.Text), description.Text, category.Text,
                    Convert.ToDouble(salePrice.Text), image.Text, _sneaker.rating, _sneaker.createDate);
                if (ans)
                {
                    await DisplayAlert("Thông báo", "Sửa thành công!", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Thông báo", "Sửa thất bại!", "OK");
                }
            } else
            {
                bool ans = sneakerVM.CreateSneaker(name.Text, size.Text, Convert.ToInt32(stock.Text), Convert.ToDouble(price.Text), description.Text, category.Text,
                    Convert.ToDouble(salePrice.Text), image.Text);
                if (ans)
                {
                    await DisplayAlert("Thông báo", "Thêm thành công!", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Thông báo", "Thêm thất bại!", "OK");
                }
            }
        }
    }
}