using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using UITStore.Models;
using UITStore.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.Views.ProductPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Store : ContentPage
    {
        public ObservableCollection<SneakerBy> sneakerList;
        private ObservableCollection<Sneakers> _sneakersList;

        public Store()
        {
            /*if (Application.Current.Properties.ContainsKey("store"))
            {
                var listSneaker = Application.Current.Properties["store"] as string;
                Console.WriteLine(listSneaker);
                var list = JsonConvert.DeserializeObject<List<SneakerBy>>(listSneaker);
                if (list.Count != 0)
                    sneakerList = new ObservableCollection<SneakerBy>(list);
                else
                    sneakerList = null;
            }*/

            InitializeComponent();
            initSneaker();
            /*if (Application.Current.Properties["pay"] as string == "notbuy")
            {
                Pay.Text = "Let's select item you want";
            }
            else
            {
                if (Application.Current.Properties["pay"] as string == "true")
                    Pay.Text = "Order Ordered";
                else
                    Pay.Text = "You Now";
            }


            listSneaker.ItemsSource = sneakerList;*/
        }
        private void initSneaker()
        {
            _sneakersList = new ObservableCollection<Sneakers>
            {
                new Sneakers
                {
                    sneakerId = "sneaker1", name = "NMD_R1 candy", price = "500000", saleprice = "400000", picture = "Sneakers1",
                    description = "tuyet voi ông mặt trời", size = "24", category = "new", stock = "24"
                },
                new Sneakers
                {
                    sneakerId = "sneaker2", name = "NMD_R1 pink white", price = "500000", saleprice = "400000", picture = "Sneakers2",
                    description = "tuyet voi ông mặt trời", size = "24", category = "bestsell", stock = "24"
                },
                new Sneakers
                {
                    sneakerId = "sneaker3", name = "NMD_R1 mint pink", price = "500000", saleprice = "400000", picture = "Sneakers3",
                    description = "tuyet voi ông mặt trời", size = "24", category = "bestsell", stock = "24"
                },
                new Sneakers
                {
                    sneakerId = "sneaker4", name = "NMD_R1 white mint", price = "500000", saleprice = "400000", picture = "Sneakers4",
                    description = "tuyet voi ông mặt trời", size = "24", category = "discount", stock = "24"
                }
            };
            Product.ItemsSource = _sneakersList;
        }
        /*      private async void viewDetail(object sender, EventArgs e)
              {
                  var btn = (Button)sender;
                  var sneakerBy = (SneakerBy)btn.BindingContext;
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

              private async void payNow(object sender, EventArgs e)
              {
                  await DisplayAlert("Congratulation", "You ordered, successfully", "Yes", "No");
                  Application.Current.Properties["pay"] = "true";
                  await Application.Current.SavePropertiesAsync();
                  await Navigation.PushAsync(new MainPage());
                  Application.Current.MainPage = new NavigationPage(new MainPage());
              }*/
    }
}