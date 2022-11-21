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
    public partial class Voucher : ContentPage
    {
        private List<Vouchers> vouchers = new VoucherVM().GetVoucher();
        public Voucher()
        {
            InitializeComponent();
            dataVoucher.ItemsSource = vouchers;
        }

    }
}