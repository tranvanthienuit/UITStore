using UITStore.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.BlogPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BlogDetail : ContentPage
    {
        public BlogDetail(Blog detailBlog)
        {
            InitializeComponent();
            BindingContext = detailBlog;
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = "Heko";
            Browser.Source = htmlSource;
            
        }
    }
}