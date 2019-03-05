using System;
using System.Collections.Generic;
using System.Text;

namespace App12.Data
{
    public class NewsJsondes
    {
        public Response response { get; set; }

        public string Print()
        {
            string result = "response: {\n\titems: [{\n";
            string tabs = "\t\t";

            foreach (var item in response.items)
            {

                result += tabs+ "type:          "          + item.type      + ",\n";
                result += tabs + "source_id:     "     + item.source_id + ",\n";
                result += tabs + "date:          "          + item.date + ",\n";
                result += tabs + "post_id:       "       + item.post_id + ",\n";
                result += tabs + "post_type:     "     + item.post_type+ ",\n";
                result += tabs + "text:          "          + item.text + ",\n";
                result += tabs + "marked_as_ads: " + item.text + ",\n";
                result += tabs + "attachments: [{\n";
                
                tabs+="\t";
                bool ch = true;
                foreach (var attachment in item.attachments )
                {
                    result += tabs + "type:          " + attachment.type + ",\n";
                    result += tabs + "photo: [{\n";
                    if(ch==true)
                    {
                        tabs += "\t";
                        ch = false;
                    }
                    result += tabs + "type:          " + item.type + ",\n";
                    result += tabs + "source_id:     " + item.source_id + ",\n";
                    result += tabs + "date:          " + item.date + ",\n";
                    result += tabs + "post_id:       " + item.post_id + ",\n";
                    result += tabs + "post_type:     " + item.post_type + ",\n";
                    result += tabs + "text:          " + item.text + ",\n";
                    result += tabs + "marked_as_ads: " + item.text + ",\n";

                }

                tabs = "\t\t";



            }

            return result;
        }
    }

    public class Response
    {
        public List<Item> items { get; set; }
        public List<object> profiles { get; set; }
        public List<Group> groups { get; set; }
        public string next_from { get; set; }
    }

    public class Item
    {
        public string            type { get; set; }
        public int               source_id { get; set; }
        public int               date { get; set; }
        public int               post_id { get; set; }
        public string            post_type { get; set; }
        public string            text { get; set; }
        public int               marked_as_ads { get; set; }
        public List<Attachment> attachments { get; set; }
        public PostSource       post_source { get; set; }
        public Comments         comments { get; set; }
        public Likes            likes { get; set; }
        public Reposts          reposts { get; set; }
        public Views            views { get; set; }

    }

    public class Attachment
    {
        public string type { get; set; }
        public Photo photo { get; set; }
    }

    public class Photo
    {
        public int id { get; set; }
        public int album_id { get; set; }
        public int owner_id { get; set; }
        public int user_id { get; set; }
        public string photo_75 { get; set; }
        public string photo_130 { get; set; }
        public string photo_604 { get; set; }
        public string photo_807 { get; set; }
        public string photo_1280 { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string text { get; set; }
        public int date { get; set; }
        public string access_key { get; set; }

    }

    public class PostSource
    {
        public string type { get; set; }
    }

    public class Comments
    {
        public int count { get; set; }
        public int can_post { get; set; }
    }

    public class Likes
    {
        public int count { get; set; }
        public int user_likes { get; set; }
        public int can_like { get; set; }
        public int can_publish { get; set; }
    }

    public class Reposts
    {
        public int count { get; set; }
        public int user_reposted { get; set; }
    }

    public class Views
    {
        public int count { get; set; }
    }

    public class Group
    {
        public int id { get; set; }
        public string name { get; set; }
        public string screen_name { get; set; }
        public int is_closed { get; set; }
        public string type { get; set; }
        public int is_admin { get; set; }
        public int is_member { get; set; }
        public string photo_50 { get; set; }
        public string photo_100 { get; set; }
        public string photo_200 { get; set; }
    }

    public class Profile
    {
        public int id { get; set; }
        public int first_name { get; set; }
        public int last_name { get; set; }
        public int sex { get; set; }
        public int screen_name { get; set; }
        public int photo_50 { get; set; }
        public int photo_100 { get; set; }
        public int online { get; set; }
    }

}
