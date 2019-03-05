using System;
using System.Collections.Generic;

namespace App3.Data
{
    public class NewsJson
    {
        public Response response { get; set; }

        public string GetJson()
        {
            string result = "";

            #region response

            result += "response:\n";
            result += "{\n";
            result += response?.ToString("\t", "\t\t", "\t\t\t", "\t\t\t\t", "\t\t\t\t\t");
            result += "}\n";

            #endregion

            return result;
        }
    }

    public class Response
    {
        public List<Item> items { get; set; }
        public List<Profile> profiles { get; set; }
        public List<Group> groups { get; set; }
        public string next_from { get; set; }

        public string ToString(string splitSimbols0, string splitSimbols1, string splitSimbols2, string splitSimbols3, string splitSimbols4)
        {
            string result = "";
            #region items

            result += splitSimbols0 + "items:\n";
            result += splitSimbols0 + "[\n";
            if (items != null) foreach (var item in items)
            {
                result += splitSimbols1 + "{\n";
                result += item?.ToString(splitSimbols1, splitSimbols2, splitSimbols3, splitSimbols4);
                result += splitSimbols1 + "},\n";
            }
            result += splitSimbols0 + "],\n";
            
            #endregion
            #region profiles

            result += splitSimbols0 + "profiles:\n";
            result += splitSimbols0 + "[\n";
            if (profiles != null) foreach (var profile in profiles)
            {
                result += splitSimbols1 + "{\n";
                result += profile?.ToString(splitSimbols1);
                result += splitSimbols1 + "},\n";
            }
            result += splitSimbols0 + "],\n";
            
            #endregion
            #region profiles

            result += splitSimbols0 + "groups:\n";
            result += splitSimbols0 + "[\n";
            if (groups != null) foreach (var group in groups)
            {
                result += splitSimbols1 + "{\n";
                result += group?.ToString(splitSimbols1);
                result += splitSimbols1 + "},\n";
            }
            result += splitSimbols0 + "],\n";

            #endregion
            result += splitSimbols0 + "next_from: " + next_from + ",\n";
            return result;
        }
    }

    public class Item
    {
        public string type { get; set; }
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


        public string ToString(string splitSimbols0, string splitSimbols1, string splitSimbols2, string splitSimbols3)
        {
            string result = "";

            result += splitSimbols0 + "type: " + type + ",\n";
            result += splitSimbols0 + "source_id: " + source_id + ",\n";
            result += splitSimbols0 + "date: " + date + ",\n";
            result += splitSimbols0 + "post_id: " + post_id + ",\n";
            result += splitSimbols0 + "post_type: " + post_type + ",\n";
            result += splitSimbols0 + "text: " + text + ",\n";
            result += splitSimbols0 + "marked_as_ads: " + marked_as_ads + ",\n";
            #region attachments

            result += splitSimbols0 + "attachments:\n";
            result += splitSimbols0 + "[\n";
            if (attachments != null) foreach (var attachment in attachments)
            {
                result += splitSimbols1 + "{\n";
                result += attachment?.ToString(splitSimbols1, splitSimbols2, splitSimbols3);
                result += splitSimbols1 + "},\n";
            }
            result += splitSimbols0 + "],\n";

            #endregion
            #region post_source

            result += splitSimbols0 + "post_source:\n";
            result += splitSimbols0 + "{\n";
            result += post_source?.ToString(splitSimbols1);
            result += splitSimbols0 + "}\n";

            #endregion
            #region comments

            result += splitSimbols0 + "comments:\n";
            result += splitSimbols0 + "{\n";
            result += comments?.ToString(splitSimbols1);
            result += splitSimbols0 + "}\n";

            #endregion
            #region likes

            result += splitSimbols0 + "likes:\n";
            result += splitSimbols0 + "{\n";
            result += likes?.ToString(splitSimbols1);
            result += splitSimbols0 + "}\n";

            #endregion
            #region reposts

            result += "\t\t" + "reposts:\n";
            result += "\t\t" + "{\n";
            result += reposts?.ToString(splitSimbols0);
            result += "\t\t" + "}\n";

            #endregion
            #region views

            result += splitSimbols0 + "views:\n";
            result += splitSimbols0 + "{\n";
            result += views?.ToString(splitSimbols1);
            result += splitSimbols0 + "}\n";

            #endregion
            return result;
        }

    }

    public class Attachment
    {
        public string type { get; set; }
        public Photo photo { get; set; }

        public string ToString(string splitSimbols0, string splitSimbols1, string splitSimbols2)
        {
            string result = "";
            result += splitSimbols0 + "type: " + type + ",\n";
            result += splitSimbols0 + "photo:\n";
            result += splitSimbols0 + "{\n";
            result += photo?.ToString( splitSimbols1, splitSimbols2 );
            result += splitSimbols0 + "}\n";
            return result;
        }
    }

    #region Photo
    public class Photo
    {
        public int id { get; set; }
        public int album_id { get; set; }
        public int owner_id { get; set; }
        public int user_id { get; set; }
        public List<Size> sizes { get; set; }
        public string text { get; set; }
        public int date { get; set; }
        public int post_id { get; set; }
        public string access_key { get; set; }

        public string ToString(string splitSimbols0, string splitSimbols1)
        {
            string result = "";
            result += splitSimbols0 + "id: " + id + ",\n";
            result += splitSimbols0 + "album_id: " + album_id + ",\n";
            result += splitSimbols0 + "owner_id: " + owner_id + ",\n";
            result += splitSimbols0 + "user_id: " + user_id + ",\n";
            result += splitSimbols0 + "[\n";
            if (sizes != null) foreach (var size in sizes)
            {
                result += splitSimbols1 + "{\n";
                result += size?.ToString(splitSimbols1);
                result += splitSimbols1 + "},\n";
            }
            result += splitSimbols0 + "],\n";
            result += splitSimbols0 + "date: " + date + ",\n";
            result += splitSimbols0 + "post_id: " + post_id + ",\n";
            result += splitSimbols0 + "access_key: " + access_key + "\n";
            return result;
        }

    }

    public class Size
    {
        public string type { get; set; }
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public string ToString(string splitSimbols)
        {
            string result = "";
            result += splitSimbols + "type: " + type + ",\n";
            result += splitSimbols + "url: " + url + ",\n";
            result += splitSimbols + "width: " + width + ",\n";
            result += splitSimbols + "height: " + height + "\n";
            return result;
        }
    }
    #endregion

    /*
    #region Video
    public class Video
    {
        public int id { get; set; }
        public int owner_id { get; set; }
        public string title { get; set; }
        public int duration { get; set; }
        public string description { get; set; }
        public int date { get; set; }
        public int comments { get; set; }
        public int views { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string photo_130 { get; set; }
        public string photo_320 { get; set; }
        public string photo_800 { get; set; }
        public string photo_1280 { get; set; }
        public bool is_favorite { get; set; }
        public string access_key { get; set; }
        public int repeat { get; set; }
        public string first_frame_0 { get; set; }
        public string first_frame_1280 { get; set; }
        public string first_frame_800 { get; set; }
        public string first_frame_320 { get; set; }
        public string first_frame_160 { get; set; }
        public string first_frame_130 { get; set; }
        public int can_add { get; set; }
    }
    #endregion

    #region WallPhoto
    public class WallPhoto
    {
        public int aaaaaaaaaaaaaaa { get; set; }
        public string bbbbbbbbbbbb { get; set; }
        public bool cccccccccccccc { get; set; }
    }
    #endregion
    //*/

    public class PostSource
    {
        public string type { get; set; }
        public string platform { get; set; }

        public string ToString(string splitSimbols)
        {
            string result = "";
            result += splitSimbols + "type: " + type + ",\n";
            result += splitSimbols + "platform: " + platform + "\n";
            return result;
        }
    }

    public class Comments
    {
        public int count { get; set; }
        public int can_post { get; set; }
        public bool groups_can_post { get; set; }

        public string ToString(string splitSimbols)
        {
            string result = "";
            result += splitSimbols + "count: " + count + ",\n";
            result += splitSimbols + "can_post: " + can_post + ",\n";
            result += splitSimbols + "groups_can_post: " + groups_can_post + "\n";
            return result;
        }
    }

    public class Likes
    {
        public int count { get; set; }
        public int user_likes { get; set; }
        public int can_like { get; set; }
        public int can_publish { get; set; }

        public string ToString(string splitSimbols)
        {
            string result = "";
            result += splitSimbols + "count: " + count + ",\n";
            result += splitSimbols + "user_likes: " + user_likes + ",\n";
            result += splitSimbols + "can_like: " + can_like + ",\n";
            result += splitSimbols + "can_publish: " + can_publish + "\n";
            return result;
        }
    }

    public class Reposts
    {
        public int count { get; set; }
        public int user_reposted { get; set; }

        public string ToString(string splitSimbols)
        {
            string result = "";
            result += splitSimbols + "count: " + count + ",\n";
            result += splitSimbols + "user_reposted: " + user_reposted + ",\n";
            return result;
        }
    }

    public class Views
    {
        public int count { get; set; }

        public string ToString(string splitSimbols)
        {
            return splitSimbols + "count: " + count + "\n";
        }
    }

    public class Group
    {
        public int id { get; set; }
        public string name { get; set; }
        public string screen_name { get; set; }
        public int is_closed { get; set; }
        public string type { get; set; }
        public int is_admin { get; set; }
        public int admin_level { get; set; }
        public int is_member { get; set; }
        public int is_advertiser { get; set; }
        public string photo_50 { get; set; }
        public string photo_100 { get; set; }
        public string photo_200 { get; set; }

        public string ToString(string splitSimbols)
        {
            string result = "";
            result += splitSimbols + "id: " + id + ",\n";
            result += splitSimbols + "first_name: " + name + ",\n";
            result += splitSimbols + "last_name: " + screen_name + ",\n";
            result += splitSimbols + "sex: " + is_closed + ",\n";
            result += splitSimbols + "screen_name: " + type + ",\n";
            result += splitSimbols + "photo_50: " + is_admin + ",\n";
            result += splitSimbols + "photo_100: " + admin_level + ",\n";
            result += splitSimbols + "online: " + is_member + ",\n";
            result += splitSimbols + "online: " + is_advertiser + ",\n";
            result += splitSimbols + "online: " + photo_50 + ",\n";
            result += splitSimbols + "online: " + photo_100 + ",\n";
            result += splitSimbols + "online: " + photo_200 + "\n";
            return result;
        }
    }

    public class Profile
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public bool is_closed { get; set; }
        public bool can_access_closed { get; set; }
        public int sex { get; set; }
        public string screen_name { get; set; }
        public string photo_50 { get; set; }
        public string photo_100 { get; set; }
        public int online { get; set; }

        public string ToString(string splitSimbols)
        {
            string result = "";
            result += splitSimbols + "id: " + id + ",\n";
            result += splitSimbols + "first_name: " + first_name + ",\n";
            result += splitSimbols + "last_name: " + last_name + ",\n";
            result += splitSimbols + "is_closed: " + is_closed + ",\n";
            result += splitSimbols + "can_access_closed: " + can_access_closed + ",\n";
            result += splitSimbols + "sex: " + sex + ",\n";
            result += splitSimbols + "screen_name: " + screen_name + ",\n";
            result += splitSimbols + "photo_50: " + photo_50 + ",\n";
            result += splitSimbols + "photo_100: " + photo_100 + ",\n";
            result += splitSimbols + "online: " + online + "\n";
            return result;
        }
    }

}
