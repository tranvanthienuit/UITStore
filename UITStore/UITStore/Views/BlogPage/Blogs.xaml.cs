using System;
using System.Collections.Generic;
using System.Linq;
using UITStore.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore.BlogPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Blogs : ContentPage
    {
        public Blogs()
        {
            InitializeComponent();
            initBlog();
        }

        private void initBlog()
        {
            List<Blog> NewsList = new List<Blog>();
            NewsList.Add(new Blog
            {
                title = "Top 2 Mẫu Giày Cho Người Lùn Nam Được Yêu Thích Nhất",
                img = "news_1_2",
                content =
                    "Giày Thể Thao Nam DT20: DT20 là một mẫu giày cho người lùn nam rất được nhiều anh ưa chuộng. Diện mạo trẻ trung, hiện đại gây ấn tượng ngay cái nhìn đầu tiên.Chất da được tuyển chọn kỹ lưỡng nhằm đảm bảo chất lượng cho đôi giày. Dây giày được thiết kế theo kiểu truyền thống.Để bảo vệ cho gót chân, DT20 có phần lót vải dày dặn ở cổ giày. Còn phần lót chân thì chịu lực, có khả năng thấm hút mồ hôi tốt.",
                description =
                    "Dòng giày này phong phú về kiểu dáng và chất lượng. hdifhdsfhdufhdufhduhufhgudfghdfughdfughdfughdfughdfuhgdfughdfudhfudhfudh",
                date = "22/10/2022",
                author = "Lê Văn Luyện"
            });
            NewsList.Add(new Blog
            {
                title = "Top 2 Mẫu Giày Cho Người Lùn Nam Được Yêu Thích Nhất",
                img = "news_1_2",
                content =
                    "Giày Thể Thao Nam DT20: DT20 là một mẫu giày cho người lùn nam rất được nhiều anh ưa chuộng. Diện mạo trẻ trung, hiện đại gây ấn tượng ngay cái nhìn đầu tiên.Chất da được tuyển chọn kỹ lưỡng nhằm đảm bảo chất lượng cho đôi giày. Dây giày được thiết kế theo kiểu truyền thống.Để bảo vệ cho gót chân, DT20 có phần lót vải dày dặn ở cổ giày. Còn phần lót chân thì chịu lực, có khả năng thấm hút mồ hôi tốt.",
                description =
                    "Dòng giày này phong phú về kiểu dáng và chất lượng.",
                date = "22/10/2022",
                author = "admin1"
            });
            BlogList.ItemsSource = NewsList;
        }

        /*private async void selectItem(object sender, SelectedItemChangedEventArgs selectedItemChangedEventArgs)
        {
            var newModel = selectedItemChangedEventArgs.SelectedItem as Blog;
            await Navigation.PushAsync(new BlogDetail(newModel));
        
        }*/

        private async void BlogList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var detailBlog = e.CurrentSelection[0] as Blog;
            await Navigation.PushAsync(new BlogDetail(detailBlog));
        }
    }
}