using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UITStore.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.Views.ProductPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SneakerDetailPage : ContentPage
    {
        public Sneakers sneaker;
        public SneakerDetailPage(Sneakers sneakers)
        {
            InitializeComponent();
            BindingContext = sneakers;
            sneaker = sneakers;

        }

        private void TapFavourite_Tapped(object sender, EventArgs e)
        {

        }

        
        private async void TapSize_Tapped(object sender, EventArgs e)
        {

            string[] listSize = sneaker.size.Split(',');
            string action;
            if (listSize.Length > 0)
            {
                action = await DisplayActionSheet("Size", "Cancel", null, listSize);
                size.Text = action != "Cancel" ? action : size.Text;
            }
            else
            {
                await DisplayAlert("Size", "UnAvailable", "OK");
                size.Text = "Null";
            }
        }

        private void Sub_Clicked(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(Count.Text);
            if(count > 1)
            {
                count = count - 1;
            } else
            {
                count = 1;
            }
            Count.Text = count.ToString();
        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            Count.Text = (Convert.ToInt32(Count.Text) + 1).ToString();
        }

        /*private async void addToStore(object sender, EventArgs e)
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
        }*/
    }
}