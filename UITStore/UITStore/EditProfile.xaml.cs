using System;
using UITStore.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.UserPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProfile : ContentPage
    {
        public User User;
        public UserViews userViews;

        public EditProfile()
        {
            InitializeComponent();
            User = new User();
            userViews = new UserViews();
            User = Application.Current.Properties["user"] as User;
            //truyền userViews extend từ INotifyPropertyChanged ra ngoài khi các tham số của userViews ở views thay đổi
            //thì sẽ được cập nhật các tham số đó ở trong class userViews qua đó cập nhật các giá trị
            if (User != null)
            {
                userViews.username = User.username;
                userViews.password = User.password;
                userViews.fullname = User.fullname;
                userViews.telephone = User.telephone;
                userViews.address = User.address;
            }

            BindingContext = userViews;
        }

        private async void updateProfile(object sender, EventArgs e)
        {
            var result = userViews.updateUserExist();
            if (result.Result)
            {
                var signResult = await DisplayAlert("Successfull", "You update, successfully", "Yes", "No");
                if (signResult) await Navigation.PushAsync(new UserProfile());
            }
        }
    }
}