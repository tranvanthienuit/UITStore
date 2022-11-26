using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITStore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.Views.StoragePage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailOrder : ContentPage
    {
        public OrderVM orderVM = new OrderVM();
        public DetailOrder(Guid id)
        {
            InitializeComponent();
            dataDetail.ItemsSource = orderVM.GetDetailOrders(id);
        }
    }
}