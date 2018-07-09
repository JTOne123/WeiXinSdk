using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Maydear.WeiXin.Public;

namespace System.Net.Http
{
    /// <summary>
    /// HttpContent扩展
    /// </summary>
    public static class HttpContentExtension
    {
        /// <summary>
        /// 转换为格式json对象HttpContent，mime：text/plain
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static HttpContent ToTextPlainTypeHttpContent(this object data)
        {
            return new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "text/plain");
        }

        /// <summary>
        /// 转换为格式json对象HttpContent，mime：application/json
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static HttpContent ToJsonTypeHttpContent(this object data)
        {
            return new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
        }

        /// <summary>
        /// 转换为FormUrlEncodedContent对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static HttpContent ToFormUrlEncodedContent(this object data)
        {
            return new FormUrlEncodedContent(JsonKeyValuePair.Deserialize(data));
        }
    }
}
