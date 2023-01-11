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
    public partial class OrderAdmin : ContentPage
    {
        public OrderVM orderVM = new OrderVM();
        public OrderAdmin()
        {
            InitializeComponent();
            dataOrder.ItemsSource = orderVM.GetListOrder();
        }

        private async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            SwipeItem swipeItem = (SwipeItem)sender;
            Order order = swipeItem.CommandParameter as Order;
            string[] listStatus = new string[]
            {
                "Đang giao hàng", "Đã giao hàng", "Đã hủy"
            };
            string action;
            action = await DisplayActionSheet("Trạng thái", "Hủy", null, listStatus);
            if(action != "Hủy")
            {
                orderVM.UpdateOrder(order.id, order.userId, order.fullName, order.telephone, order.address, order.total, action);
                dataOrder.ItemsSource = orderVM.GetListOrder();
            }
        }
    }
}