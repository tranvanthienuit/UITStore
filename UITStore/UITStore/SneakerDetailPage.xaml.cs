using System;
using SneakersUIApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SneakerDetailPage : ContentPage
    {
        public SneakerDetailPage(string productName, string productPicture, string productPrice)
        {
            InitializeComponent(); 
            Sneakers _sneakers = new Sneakers()
        {
            Name = productName,
            Picture = productPicture,
            Price = productPrice
        };
        BindingContext = _sneakers;
        }
    }
}