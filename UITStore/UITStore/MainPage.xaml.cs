using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UITStore
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage LoginPage = new NavigationPage(new Login());
            NavigationPage Register = new NavigationPage(new Register());
            
            Children.Add(new Home());
            Children.Add(LoginPage);
            Children.Add(Register);
        }
    }
}