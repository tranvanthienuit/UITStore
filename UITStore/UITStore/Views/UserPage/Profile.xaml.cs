using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.Views.UserPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void update_profile_Clicked(object sender, EventArgs e)
        {
            if(update_profile.Text == "Update")
            {
                update_profile.Text = "Save";
                username.IsEnabled = true;
                birthday.IsEnabled = true;
                fullname.IsEnabled = true;
                telephone.IsEnabled = true;
                email.IsEnabled = true;
                address.IsEnabled = true;
                cancel_profile.IsEnabled = true;
            } else if (update_profile.Text == "Save")
            {
                username.IsEnabled = false;
                birthday.IsEnabled = false;
                fullname.IsEnabled = false;
                telephone.IsEnabled = false;
                email.IsEnabled = false;
                address.IsEnabled = false;
                cancel_profile.IsEnabled = false;
                update_profile.Text = "Update";
            }
        }

        private void cancel_profile_Clicked(object sender, EventArgs e)
        {

        }
    }
}