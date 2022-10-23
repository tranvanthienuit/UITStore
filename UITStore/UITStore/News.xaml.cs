using System.Collections.Generic;
using UITStore.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITStore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class News : ContentPage
    {
        public List<NewModel> NewsList;

        public News()
        {
            InitializeComponent();
            init();
            collectionNews.ItemsSource = NewsList;
        }

        private void init()
        {
            NewsList = new List<NewModel>();
            NewsList.Add(new NewModel
            {
                title = "Top 2 Mẫu Giày Cho Người Lùn Nam Được Yêu Thích Nhất", image1 = "news_1_1",
                image2 = "news_1_2",
                content1 =
                    "Giày Thể Thao Nam DT20: DT20 là một mẫu giày cho người lùn nam rất được nhiều anh ưa chuộng. Diện mạo trẻ trung, hiện đại gây ấn tượng ngay cái nhìn đầu tiên.Chất da được tuyển chọn kỹ lưỡng nhằm đảm bảo chất lượng cho đôi giày. Dây giày được thiết kế theo kiểu truyền thống.Để bảo vệ cho gót chân, DT20 có phần lót vải dày dặn ở cổ giày. Còn phần lót chân thì chịu lực, có khả năng thấm hút mồ hôi tốt.",
                content2 =
                    "Giày Thể Thao Nam TD65: TD65 là một đôi giày thể thao trẻ trung, đang làm mưa làm gió trong thời gian qua. Kiểu giày này có hai phiên bản màu đen và màu kem.Điểm đáng giá nhất của mẫu giày này chính là phần vải vừa mềm êm vừa thoáng khí. Ngoài ra, chất vải này có độ dày dặn tốt, không bị bung rách khi va chạm.",
                description =
                    "Dòng giày này phong phú về kiểu dáng và chất lượng.",
                date = "22/10/2022"
            });
            NewsList.Add(new NewModel
            {
                title = "Top 2 Mẫu Giày Cho Người Lùn Nam Được Yêu Thích Nhất", image1 = "news_1_1",
                image2 = "news_1_2",
                content1 =
                    "Giày Thể Thao Nam DT20: DT20 là một mẫu giày cho người lùn nam rất được nhiều anh ưa chuộng. Diện mạo trẻ trung, hiện đại gây ấn tượng ngay cái nhìn đầu tiên.Chất da được tuyển chọn kỹ lưỡng nhằm đảm bảo chất lượng cho đôi giày. Dây giày được thiết kế theo kiểu truyền thống.Để bảo vệ cho gót chân, DT20 có phần lót vải dày dặn ở cổ giày. Còn phần lót chân thì chịu lực, có khả năng thấm hút mồ hôi tốt.",
                content2 =
                    "Giày Thể Thao Nam TD65: TD65 là một đôi giày thể thao trẻ trung, đang làm mưa làm gió trong thời gian qua. Kiểu giày này có hai phiên bản màu đen và màu kem.Điểm đáng giá nhất của mẫu giày này chính là phần vải vừa mềm êm vừa thoáng khí. Ngoài ra, chất vải này có độ dày dặn tốt, không bị bung rách khi va chạm.",
                description =
                    "Dòng giày này phong phú về kiểu dáng và chất lượng.",
                date = "22/10/2022"
            });
        }

        private async void selectItem(object sender, SelectedItemChangedEventArgs selectedItemChangedEventArgs)
        {
            var newModel = selectedItemChangedEventArgs.SelectedItem as NewModel;
            await Navigation.PushAsync(new NewsDetail(newModel));
        }
    }
}