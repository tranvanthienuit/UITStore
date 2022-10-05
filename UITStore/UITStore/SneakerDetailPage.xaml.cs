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
    public partial class SneakerDetailPage : ContentPage
    {
        public Sneakers _sneakers = new Sneakers();
        public SneakerDetailPage(string productName, string productPicture, string productPrice)
        {
            InitializeComponent();
            _sneakers.Name = productName;
            _sneakers.Picture = productPicture;
            _sneakers.Price = productPrice;
            Console.WriteLine(_sneakers);
            BindingContext = _sneakers;
        }

    }
}