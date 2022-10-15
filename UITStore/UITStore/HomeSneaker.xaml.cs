using System;
using System.Collections.ObjectModel;
using SneakersUIApp.Models;
using UITStore.views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeSneaker : ContentPage
    {
        private ObservableCollection<Sneakers> _sneakersList;

        public HomeSneaker()
        {
            InitializeComponent();
            initSneaker();
            listSneaker.ItemsSource = _sneakersList;
            // lấy dữ liệu từ store
            var ten = Application.Current.Properties["user"] as string;
            Console.WriteLine(ten);
        }

        private void initSneaker()
        {
            _sneakersList = new ObservableCollection<Sneakers>
            {
                new Sneakers { name = "NMD_R1 candy", price = "162", picture = "Sneakers1", description = "tuyet voi" },
                new Sneakers
                    { name = "NMD_R1 pink white", price = "142", picture = "Sneakers2", description = "tuyet voi" },
                new Sneakers
                    { name = "NMD_R1 mint pink", price = "179", picture = "Sneakers3", description = "tuyet voi" },
                new Sneakers
                    { name = "NMD_R1 white mint", price = "154", picture = "Sneakers4", description = "tuyet voi" }
            };
        }

        private async void viewDetail(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            await Navigation.PushAsync(new SneakerDetailPage((Sneakers)btn.BindingContext));
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var sneakersList = new ObservableCollection<Sneakers>();
            var key = e.NewTextValue;
            foreach (var item in _sneakersList)
                if (item.name.ToLower().Contains(key.ToLower()))
                    sneakersList.Add(item);

            listSneaker.ItemsSource = sneakersList;
        }
    }
}