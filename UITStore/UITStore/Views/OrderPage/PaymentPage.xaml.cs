using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITStore.Models;
using UITStore.ViewModels;
using UITStore.Views.StoragePage;
using UITStore.Views.UserPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.Views.OrderPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentPage : ContentPage
    {
        private User _user;
        public UserVM userVM = new UserVM();
        public SneakerVM sneakerVM = new SneakerVM();
        public OrderVM orderVM = new OrderVM();
        List<ListDetailOrder> listDetailOrders;
        public PaymentPage(double total)
        {
            InitializeComponent();
            _user = Application.Current.Properties["user"] as User;
            BindingContext = _user;
            Total.Text = total.ToString("0,0");
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _user = Application.Current.Properties["user"] as User;
            BindingContext = _user;
        }
        public bool ValidationFullname()
        {
            if (string.IsNullOrWhiteSpace(fullname.Text) || fullname.Text.Length < 4)
            {
                vldFullname.Text = "Ít nhất 4 kí tự";
                return false;
            }
            else
            {
                vldFullname.Text = "";
                return true;
            }
        }
        public bool ValidationPhone()
        {
            if (string.IsNullOrWhiteSpace(phone.Text) || phone.Text.Length < 10 || phone.Text.Length > 11)
            {
                vldPhone.Text = "SĐT không đúng";
                return false;
            }
            else
            {
                vldPhone.Text = "";
                return true;
            }
        }
        public bool ValidationAddress()
        {
            if (string.IsNullOrWhiteSpace(address.Text) || address.Text.Length < 10)
            {
                vldAddress.Text = "Ít nhất 10 kí tự";
                return false;
            }
            else
            {
                vldAddress.Text = "";
                return true;
            }
        }

        private async void Payment_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteDatabase();
            List<Cart> cart = db.getCart(_user.id).ToList();
            listDetailOrders = new List<ListDetailOrder>();
            foreach (var item in cart)
            {
                listDetailOrders.Add(new ListDetailOrder { productId = item.productid, image = item.img, name = item.name, price = item.price, size = item.productsize, quantity = item.quantity});
            }

            if (ValidationFullname() && ValidationPhone() && ValidationAddress())
            {
                bool answer = await DisplayAlert("Xác nhận", "Xác nhận đặt hàng", "Có", "Không");
                if(answer)
                {
                    double addPoint = Convert.ToDouble(Total.Text) / 50000;
                    bool result = orderVM.AddNewOrder(_user.id, fullname.Text, phone.Text, address.Text, Convert.ToDouble(Total.Text), listDetailOrders);
                    if(result)
                    {
                        await DisplayAlert("Thành công", "Đặt hàng thành công", "Ok");
                        await Navigation.PushAsync(new MainPage());
                        Application.Current.MainPage = new NavigationPage(new MainPage());
                        db.deleteFullCart(_user.id);
                        userVM.Update(_user.id, _user.username, _user.password, _user.fullname, _user.telephone, _user.address, _user.birthday, _user.email, _user.loyalPoint + Convert.ToInt32(addPoint));
                        foreach (var item in cart)
                        {
                            Sneakers sneaker = sneakerVM.GetSneakerById(item.productid);
                            sneakerVM.UpdateSneaker(sneaker.id, sneaker.name, sneaker.size, sneaker.stock - item.quantity, sneaker.price, sneaker.description, sneaker.category, sneaker.salePrice,
                                sneaker.image, sneaker.rating, sneaker.createDate);
                        }
                    } else
                    {
                        await DisplayAlert("Lỗi", "Lỗi", "Ok");
                    }
                }
            }
        }
    }
}