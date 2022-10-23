using UITStore.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsDetail : ContentPage
    {
        public NewsDetail(NewModel newModel)
        {
            InitializeComponent();
            BindingContext = newModel;
        }
    }
}