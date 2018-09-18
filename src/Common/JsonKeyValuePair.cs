using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;

namespace Maydear.WeiXin
{
    /// <summary>
    /// 
    /// </summary>
    internal class JsonKeyValuePair
    {
        /// <summary>
        /// 将json结构的字符串序列化为keyvalue结构
        /// </summary>
        /// <param name="jsonString">待序列化的json字符串</param>
        /// <returns>返回键值对集合</returns>
        internal static IEnumerable<KeyValuePair<string, string>> Deserialize(string jsonString)
        {
            JsonReader reader = new JsonTextReader(new StringReader(jsonString));
            List<KeyValuePair<string, string>> requestKeyValue = new List<KeyValuePair<string, string>>();

            NameValueCollection jsonKeyValue = new NameValueCollection();
            while (reader.Read())
            {

                if (reader.Depth > 0)
                {
                    if (reader.TokenType != JsonToken.PropertyName
                        && reader.TokenType != JsonToken.Comment
                        && reader.TokenType != JsonToken.StartArray
                        && reader.TokenType != JsonToken.EndArray
                        && reader.TokenType != JsonToken.StartConstructor
                        && reader.TokenType != JsonToken.StartObject
                        && reader.TokenType != JsonToken.EndConstructor
                        && reader.TokenType != JsonToken.EndObject
                        && reader.TokenType != JsonToken.Date
                        && reader.Value != null
                        )
                    {
                        string path = reader.Path;
                        jsonKeyValue.Add(path, reader.Value.ToString());
                    }

                    if (reader.TokenType == JsonToken.Date)
                    {
                        string path = reader.Path;
                        jsonKeyValue.Add(path, ((DateTime)reader.Value).ToString("yyyy-MM-ddTHH:mm:ss.fffffff"));
                    }

                }
            }
            foreach (string propertyNameKey in jsonKeyValue.AllKeys)
            {
                foreach (string propertyNameValue in jsonKeyValue.GetValues(propertyNameKey))
                {
                    requestKeyValue.Add(new KeyValuePair<string, string>(propertyNameKey, propertyNameValue));
                }
            }

            return requestKeyValue;
        }

        /// <summary>
        /// 将object对象序列化为键值对结构
        /// </summary>
        /// <param name="obj">待序列化的对象</param>
        /// <returns>返回键值对集合</returns>
        internal static IEnumerable<KeyValuePair<string, string>> Deserialize(object obj)
        {
            if (obj == null)
                return null;

            string jsonStr = JsonConvert.SerializeObject(obj);

            return Deserialize(jsonStr);
        }
    }
}
