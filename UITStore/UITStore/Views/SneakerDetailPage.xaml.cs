using SneakersUIApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SneakerDetailPage : ContentPage
    {
        public SneakerDetailPage(Sneakers sneakers)
        {
            InitializeComponent();
            var _sneakers = new Sneakers
            {
                name = sneakers.name,
                picture = sneakers.picture,
                price = sneakers.price,
                description = sneakers.description
            };
            BindingContext = _sneakers;
        }
    }
}