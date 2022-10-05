using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SneakersUIApp.Models;
using SneakersUIApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SneakersPage : ContentPage
    {
        public SneakersPage()
        {
            InitializeComponent();
            BindingContext = new SneakersViewModel();
        }

        private async void viewDetail(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var product = (Sneakers)btn.BindingContext;
            await Navigation.PushAsync(new SneakerDetailPage(product.Name, product.Picture, product.Price));
        }
    }
}