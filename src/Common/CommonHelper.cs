using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.WeiXin
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
    }
}
