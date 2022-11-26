using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITStore.Models;
using UITStore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.Views.StoragePage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyOrderPage : ContentPage
    {
        public OrderVM orderVM = new OrderVM();
        private readonly User _user;

        public MyOrderPage()
        {
            InitializeComponent();
            _user = Application.Current.Properties["user"] as User;
            dataOrder.ItemsSource = orderVM.GetOrderByUserId(_user.id);
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            TapGestureRecognizer tapGesture = (TapGestureRecognizer)frame.GestureRecognizers[0];
            Order detailOrder = tapGesture.CommandParameter as Order;
            await Navigation.PushAsync(new DetailOrder(detailOrder.id));
        }
        private void OnDelete(object sender, EventArgs e)
        {
            SwipeItem swipeItem = (SwipeItem)sender;
            Order order = swipeItem.CommandParameter as Order;
            orderVM.DeleteOrder(order.id);
            orderVM.DeleteDetailOrder(order.id);
            dataOrder.ItemsSource = orderVM.GetOrderByUserId(_user.id);
        }
    }
}