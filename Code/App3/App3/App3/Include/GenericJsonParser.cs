using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App3.Include
{
    public class GenericJsonParser
    {
        public class GenericJson
        {
            public string key = "";
            public object value = null;
        }

        public async Task<string> ReadJson(JsonTextReader reader, GenericJson jenericJson, string deep = "")
        {
            //result += ">>>>>>>>>>>>>>>>>>>>>>>>>\n";
            string str = "";
            string result = "";

            if (reader.TokenType.ToString() == "None")
            {
                if (!reader.Read()) return result;
            }
            switch (reader.TokenType.ToString())
            {
                case "StartObject":
                    if (jenericJson.value == null)
                    {
                        jenericJson.value = new List<GenericJson>();
                    }
                    result += deep + "StartObject\n";
                    if (!reader.Read()) return result;
                    while (str != "EndObject")
                    {
                        str = reader.TokenType.ToString();
                        //result += "!!! " + str + "\n";
                        (jenericJson.value as List<GenericJson>).Add(new GenericJson());
                        result += await ReadJson(reader, (jenericJson.value as List<GenericJson>)[(jenericJson.value as List<GenericJson>).Count - 1], deep + " ");
                        //if (!reader.Read()) return;
                    }
                    //await ReadJson(reader, jenericJson);
                    break;
                case "StartArray":
                    if (jenericJson.value == null)
                    {
                        jenericJson.value = new List<GenericJson>();
                    }
                    result += deep + "StartArray\n";
                    if (!reader.Read()) return result;
                    while (str != "EndArray")
                    {
                        str = reader.TokenType.ToString();
                        //result += ">>> " + str + "\n";
                        (jenericJson.value as List<GenericJson>).Add(new GenericJson());
                        await ReadJson(reader, (jenericJson.value as List<GenericJson>)[(jenericJson.value as List<GenericJson>).Count - 1], deep + " ");
                        //if (!reader.Read()) return;
                    }
                    break;
                case "PropertyName":
                    if (jenericJson.value == null)
                    {
                        //jenericJson.value = new List<GenericJson>();
                    }
                    str = reader.Value.ToString();
                    result += deep + "PropertyName: " + str + "\n";
                    //(jenericJson.value as List<GenericJson>).Add(new GenericJson());
                    //(jenericJson.value as List<GenericJson>)[(jenericJson.value as List<GenericJson>).Count - 1].key = str;
                    jenericJson.key = str;
                    if (!reader.Read()) return result;
                    //await ReadJson(reader, (jenericJson.value as List<GenericJson>)[(jenericJson.value as List<GenericJson>).Count - 1], deep + " ");
                    await ReadJson(reader, jenericJson, deep);
                    break;
                case "String":
                    str = reader.Value.ToString();
                    result += deep + "String: " + str + "\n";
                    jenericJson.value = str;
                    if (!reader.Read()) return result;
                    //await ReadJson(reader, jenericJson);
                    break;
                case "Integer":
                    str = reader.Value.ToString();
                    result += deep + "Integer: " + str + "\n";
                    jenericJson.value = str;
                    if (!reader.Read()) return result;
                    //await ReadJson(reader, jenericJson);
                    break;
                default:
                    //result += "<<< Skip " + reader.TokenType + "\n";
                    if (!reader.Read()) return result;
                    //await ReadJson(reader, jenericJson);
                    break;
            }
            //result += "<<<<<<<<<<<<<<<<<<<<<<<<<\n";
            return result;
        }

        public async Task<string> GetFormattedJson(GenericJson jenericJson, string deep = "")
        {
            string result = "";
            if (jenericJson.value == null)
                return result;
            if (jenericJson.key != "")
                result += deep + "key: \"" + jenericJson.key + "\" ";
            if (jenericJson.value.GetType() == typeof(List<GenericJson>))
            {
                if (jenericJson.key == "")
                    result += deep + "[\n";
                else
                    result += "\n" + deep + "{\n";
                foreach (var item in (jenericJson.value as List<GenericJson>))
                {
                    result += await GetFormattedJson(item, deep + "    ");
                }
                if (jenericJson.key == "")
                    result += deep + "]\n";
                else
                    result += deep + "}\n";
            }
            else if (jenericJson.value != null)
            {
                result += ", value = " + jenericJson.value.ToString() + "\n";
            }
            return result;
        }

        public async Task<List<string>> GetImagesFromJson(JsonTextReader reader)
        {
            List<string> result = new List<string>(); ;
            while (reader.ReadAsync().Result)
            {
                if (reader.Value != null)
                {
                    if (reader.Value.ToString().Contains("photo_"))
                    {
                        await reader.ReadAsync();
                        result.Add(reader.Value.ToString());
                    }
                }
            }
            return result;
        }
    }
}