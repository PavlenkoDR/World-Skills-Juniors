using App3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class News : ContentPage
    {
        public News(NewsJson newsJson)
        {
            InitializeComponent();
            foreach (var item in newsJson.response.items)
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
                    StackLayout stackLayout = new StackLayout();
                    Label label = new Label();
                    label.Text = item.text;
                    stackLayout.Children.Add(label);
                    if (item.attachments != null) foreach(var attachment in item.attachments)
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
                            Image image = new Image();
                            if (attachment.photo.sizes != null) image.Source = attachment.photo.sizes[attachment.photo.sizes.Count - 1].url;
                            stackLayout.Children.Add(image);
                        }
                    }
                    frame.Content = stackLayout;
                    layout.Children.Add(frame);
                }
            }
        }
    }
}