using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UITStore.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SneakerDetailPage : ContentPage
    {
        public Sneakers sneaker;

        public SneakerDetailPage(Sneakers sneakers)
        {
            InitializeComponent();
            var _sneakers = new Sneakers
            {
                sneakerId = sneakers.sneakerId,
                name = sneakers.name,
                picture = sneakers.picture,
                price = sneakers.price,
                description = sneakers.description
            };
            sneaker = _sneakers;
            BindingContext = _sneakers;
        }

        private async void addToStore(object sender, EventArgs e)
        {
            try
            {
                if (Application.Current.Properties.ContainsKey("store"))
                {
                    var listSneaker = Application.Current.Properties["store"] as string;
                    Console.WriteLine(listSneaker);
                    var countSneaker = 1;
                    Console.WriteLine(this.countSneaker.Text.GetType());
                    if (this.countSneaker.Text != "") countSneaker = int.Parse(this.countSneaker.Text);

                    var sneakersList = JsonConvert.DeserializeObject<List<SneakerBy>>(listSneaker);
                    if (sneakersList != null)
                    {
                        var checkItem = false;
                        foreach (var item in sneakersList)
                            if (item.Sneakers.sneakerId == sneaker.sneakerId)
                            {
                                item.count += countSneaker;
                                checkItem = true;
                            }

                        if (checkItem == false)
                        {
                            var sneakerBy = new SneakerBy { Sneakers = sneaker, count = countSneaker };
                            sneakersList.Add(sneakerBy);
                        }

                        var jsonValueToSave = JsonConvert.SerializeObject(sneakersList);
                        Application.Current.Properties["store"] = jsonValueToSave;
                    }

                    await Application.Current.SavePropertiesAsync();
                }
                else
                {
                    var countSneaker = 1;
                    if (this.countSneaker.Text != "") countSneaker = int.Parse(this.countSneaker.Text);

                    var sneakersList = new List<SneakerBy>();
                    var sneakerBy = new SneakerBy { Sneakers = sneaker, count = countSneaker };
                    sneakersList.Add(sneakerBy);
                    var jsonValueToSave = JsonConvert.SerializeObject(sneakersList);
                    Application.Current.Properties["store"] = jsonValueToSave;
                    await Application.Current.SavePropertiesAsync();
                }

                Application.Current.Properties["pay"] = "false";
                DisplayAlert("Congratulation", "Sneaker is added to store", "Yes", "No");
                Application.Current.MainPage = new NavigationPage(new MainPage());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                DisplayAlert("Unlucky", "Sneaker is't added to store", "Yes", "No");
            }
        }
    }
}