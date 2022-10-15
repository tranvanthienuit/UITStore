using UITStore.Models;
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
            //truyền userViews extend từ INotifyPropertyChanged ra ngoài khi các tham số của userViews ở views thay đổi
            //thì sẽ được cập nhật các tham số đó ở trong class userViews qua đó cập nhật các giá trị
            UserViews userViews = new UserViews();
            userViews.username = User.username;
            userViews.password = User.password;
            userViews.fullname = User.fullname;
            userViews.telephone = User.telephone;
            userViews.address = User.address;
            BindingContext = userViews;
        }
    }
}