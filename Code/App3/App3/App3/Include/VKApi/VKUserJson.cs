using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Include.VKApi
{
    public class VKUser
    {
        private VKUserJson userJson { get; set; }

        VKUser(string json)
        {
            Deserialize(json);
        }

        public VKUser()
        {
        }

        public string GetJsonFormatted()
        {
            return userJson.ToString();
        }

        public void Deserialize(string json)
        {
            userJson = JsonConvert.DeserializeObject<VKUserJson>(json);
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(userJson);
        }

        public VKUserJson Get()
        {
            return userJson;
        }
    }

    public class VKUserJson
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public string user_id { get; set; }

        override
        public string ToString()
        {
            string result = "";
            result += access_token + "id: " + access_token + ",\n";
            result += expires_in + "first_name: " + expires_in + ",\n";
            result += user_id + "last_name: " + user_id + "\n";
            return result;
        }
    }
}
