using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITStore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.Views.AdminPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserAdmin : ContentPage
    {
        public UserVM userVM = new UserVM();
        public UserAdmin()
        {
            InitializeComponent();
            dataUser.ItemsSource = userVM.GetListUser();
        }
    }
}