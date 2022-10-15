using System;
using SneakersUIApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.UserPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProfile : ContentPage
    {
        public User User;

        public EditProfile()
        {
            InitializeComponent();
            User = Application.Current.Properties["user"] as User;
            BindingContext = User;
        }

        private void Update(object sender, EventArgs e)
        {
            var name = username.Text;
            var pass = password.Text;
            var full_name = fullname.Text;
            var tele = telephone.Text;
            var address_ = address.Text;
            Console.WriteLine(name + pass);
        }
    }
}