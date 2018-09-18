using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.WeiXin.Public
{
    public static class SignatureHelper
    {
        /// <summary>
        /// 生成jsapi_ticket签名
        /// </summary>
        /// <param name="jsapi_ticket">JsApi票据</param>
        /// <param name="noncestr">生成签名的随机串</param>
        /// <param name="timestamp">生成签名的时间戳</param>
        /// <param name="url">当前请求页面的完成url，含http协议头，不含#号后的锚数据</param>
        /// <returns>返回签名字符串</returns>
        public static string BuildTicketSignature(string jsapi_ticket, string noncestr, long timestamp, string url)
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
