
using UITStore.Views.AdminPage;
using UITStore.Views.UserPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace UITStore
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var db = new SQLiteDatabase();
            db.CreateDatabase();
            MainPage = new NavigationPage(new Login());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}