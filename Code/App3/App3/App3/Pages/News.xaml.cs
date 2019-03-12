using App3.Include.VKApi;
using App3.Pages;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class News : ContentPage
    {
        public News()
        {
            InitializeComponent();
            SetWall();
            listViewLoading.RefreshCommand = new Command(async () => {
                //Do your stuff.
                await UpdateWall();
                listViewLoading.IsRefreshing = false;
            });
        }

        private async void SetWall()
        {
            await UpdateWall();
        }

        public class FrameKostyl
        {
            public View content { get; set; }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Fullimg((sender as Image).Source));
        }

        private async Task UpdateWall()
        {
            await VKSession.LoadNews();
            var content = new ObservableCollection<FrameKostyl>();
            StackLayout layout = new StackLayout();
            foreach (var item in VKSession.news.Get().response.items)
            {
                /*public string type { get; set; }
                    public int source_id { get; set; }
                    public int date { get; set; }
                    public int post_id { get; set; }
                    public string post_type { get; set; }
                    public string text { get; set; }
                    public int marked_as_ads { get; set; }
                    public List<Attachment> attachments { get; set; }
                    public PostSource post_source { get; set; }
                    public Comments comments { get; set; }
                    public Likes likes { get; set; }
                    public Reposts reposts { get; set; }
                    public Views views { get; set; }
                    public bool is_favorite { get; set; }
                 */
                if (item.type == "post")
                {
                    Frame frame = new Frame();
                    frame.CornerRadius = 10;
                    frame.BackgroundColor = Color.FromHex("#31343a");
                    StackLayout stackLayout = new StackLayout();
                    Label label = new Label();
                    label.TextColor = Color.White;
                    label.Text = item.text;
                    stackLayout.Children.Add(label);
                    if (item.attachments != null) foreach (var attachment in item.attachments)
                        {
                            if (attachment.type == "photo")
                            {
                                /*
                                    public int id { get; set; }
                                    public int album_id { get; set; }
                                    public int owner_id { get; set; }
                                    public int user_id { get; set; }
                                    public List<Size> sizes { get; set; }
                                    public string text { get; set; }
                                    public int date { get; set; }
                                    public int post_id { get; set; }
                                    public string access_key { get; set; }
                                 */
                                var tap = new TapGestureRecognizer();
                                tap.Tapped += TapGestureRecognizer_Tapped;
                                Image image = new Image();
                                image.GestureRecognizers.Add(tap);
                                if (attachment.photo.sizes != null) image.Source = attachment.photo.sizes[attachment.photo.sizes.Count - 1].url;
                                stackLayout.Children.Add(image);
                            }
                        }
                    frame.Content = stackLayout;
                    layout.Children.Add(frame);
                }
            }
            WallLayout.Children.Clear();
            WallLayout.Children.Add(layout);
            loading.IsRunning = false;
        }
    }
}