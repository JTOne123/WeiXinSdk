using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.WeiXin.Public
{
    /// <summary>
    /// 通用助手类
    /// </summary>
    public static class CommonHelper
    {

        /// <summary>
        /// 获取当前的时间戳
        /// </summary>
        /// <returns></returns>
        public static long GetTimestamp()
        {
            return DateTimeOffset.Now.ToUnixTimeSeconds();
        }

        /// <summary>
        /// 获取一个新的随机串
        /// </summary>
        /// <returns>返回16位随机数字加英文的字符串</returns>
        public static string GetNonceStr()
        {
            string charKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder sb = new StringBuilder();
            Random rand = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < 16; i++)
            {
                var index = rand.Next(charKey.Length - 1);
                sb.Append(charKey[index]);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 生成签名
        /// </summary>
        /// <param name="jsapi_ticket">JsApi票据</param>
        /// <param name="noncestr">生成签名的随机串</param>
        /// <param name="timestamp">生成签名的时间戳</param>
        /// <param name="url">当前请求页面的完成url，含http协议头，不含#号后的锚数据</param>
        /// <returns>返回签名字符串</returns>
        public static string BuildSignature(string jsapi_ticket, string noncestr, long timestamp, string url)
        {
            var data = $"jsapi_ticket={jsapi_ticket}&noncestr={noncestr}&timestamp={timestamp}&url={url}";
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            var sha1Provider = System.Security.Cryptography.SHA1.Create();
            byte[] inArray = sha1Provider.ComputeHash(bytes);
            StringBuilder sb = new StringBuilder();
            foreach (var item in inArray)
            {
                sb.Append(string.Format("{0:x2}", item));
            }
            return sb.ToString();
        }
    }
}
