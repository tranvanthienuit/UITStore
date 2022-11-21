using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITStore.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.Views.OrderPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartOrder : ContentPage
    {
        private ObservableCollection<Cart> cart;

        private readonly User _user;
        public CartOrder()
        {
            InitializeComponent();
            _user = Application.Current.Properties["user"] as User;
            var db = new SQLiteDatabase();
            cart = db.getCart(_user.ID);
            dataCart.ItemsSource = cart;
            ShowTotal(cart);
        }
        public void ShowTotal(ObservableCollection<Cart> carts)
        {
            double total = 0;
            foreach (var item in carts)
            {
                total += item.price * item.quantity;
            }
            if(Voucher.Text == "Voucher 1: -20%")
            {
                total = total - total * 20 / 100;
                Total.Text = total.ToString("0,0");
            } else
            if (Voucher.Text == "Voucher 2: -50,000 VNĐ")
            {
                total = total - 50000;
                Total.Text = total.ToString("0,0");
            } else
            if (Voucher.Text == "Voucher 3: -15%")
            {
                total = total - total * 15 / 100;
                Total.Text = total.ToString("0,0");
            } else
            if (Voucher.Text == "Voucher 4: -40,000 VNĐ")
            {
                total = total - 40000;
                Total.Text = total.ToString("0,0");
            } else
            {
                Total.Text = total.ToString("0,0");
            }
        }
        private void Sub_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            Cart cart = button.CommandParameter as Cart;
            int count = cart.quantity;
            if (count > 1)
            {
                count = count - 1;
            }
            else
            {
                count = 1;
            }
            var db = new SQLiteDatabase();
            db.updateCart(cart.id, count);
            dataCart.ItemsSource = db.getCart(_user.ID);
            ShowTotal(db.getCart(_user.ID));
        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            Cart cart = button.CommandParameter as Cart;
            var db = new SQLiteDatabase();
            int count = cart.quantity + 1;
            db.updateCart(cart.id, count);
            dataCart.ItemsSource = db.getCart(_user.ID);
            ShowTotal(db.getCart(_user.ID));
        }
        private void OnDelete(object sender, EventArgs e)
        {
            SwipeItem swipeItem = (SwipeItem)sender;
            Cart cart = swipeItem.CommandParameter as Cart;
            var db = new SQLiteDatabase();
            db.deleteCart(cart.id);
            dataCart.ItemsSource = db.getCart(_user.ID);
            ShowTotal(db.getCart(_user.ID));
        }

        private void PayNow_Clicked(object sender, EventArgs e)
        {

        }

        private async void TapVoucher_Tapped(object sender, EventArgs e)
        {
            string[] listVoucher = new string[]
            {
                "Voucher 1: -20%", "Voucher 2: -50,000 VNĐ", "Voucher 3: -15%", "Voucher 4: -40,000 VNĐ"
            };
            string action;
            action = await DisplayActionSheet("Voucher", "Cancel", null, listVoucher);
            Voucher.Text = action != "Cancel" ? action : Voucher.Text;
            var db = new SQLiteDatabase();
            ShowTotal(db.getCart(_user.ID));
        }
    }
}