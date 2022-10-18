using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using UITStore.Models;
using UITStore.views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Store : ContentPage
    {
        public ObservableCollection<SneakerBy> sneakerList;
        public Store()
        {
            if (Application.Current.Properties.ContainsKey("store"))
            {
                string listSneaker = Application.Current.Properties["store"] as string;
                Console.WriteLine(listSneaker);
                List<SneakerBy> list = JsonConvert.DeserializeObject<List<SneakerBy>>(listSneaker);
                if (list.Count != 0)
                {
                    sneakerList = new ObservableCollection<SneakerBy>(list);
                }
                else
                {
                    sneakerList = null;
                }
            }
            InitializeComponent();
            listSneaker.ItemsSource = sneakerList;
        }
        private async void viewDetail(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            SneakerBy sneakerBy = (SneakerBy)btn.BindingContext;
            await Navigation.PushAsync(new SneakerDetailPage(sneakerBy.Sneakers));
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var sneakersList = new ObservableCollection<Sneakers>();
            var key = e.NewTextValue;
            foreach (var item in sneakersList)
                if (item.name.ToLower().Contains(key.ToLower()))
                    sneakersList.Add(item);

            listSneaker.ItemsSource = sneakersList;
        }
    }
}