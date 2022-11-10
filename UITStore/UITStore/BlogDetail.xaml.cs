using UITStore.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BlogDetail : ContentPage
    {
        public BlogDetail(Blog newModel)
        {
            InitializeComponent();
            BindingContext = newModel;
        }
    }
}