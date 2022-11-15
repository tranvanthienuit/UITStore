using System;
using System.Collections.Generic;
using System.Linq;
using UITStore.Models;
using UITStore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.BlogPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Blogs : ContentPage
    {
        private List<Blog> listBlog = new BlogVM().GetBlogs();
        public Blogs()
        {
            InitializeComponent();
            initBlog();
        }

        private void initBlog()
        {
            BlogList.ItemsSource = listBlog;
        }

        private async void TapBlog_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            TapGestureRecognizer tapGesture = (TapGestureRecognizer)frame.GestureRecognizers[0];
            Blog detailBlog = tapGesture.CommandParameter as Blog;
            await Navigation.PushAsync(new BlogDetail(detailBlog));
        }
    }
}