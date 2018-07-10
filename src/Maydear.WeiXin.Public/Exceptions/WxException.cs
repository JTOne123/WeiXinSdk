using Maydear.WeiXin.Public.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.WeiXin.Public.Exceptions
{
    public class WxException : Exception
    {
        /// <summary>
        /// 使用指定错误消息初始化<see cref="WxException"/>类的新实例。
        /// </summary>
        /// <remarks>
        /// message 参数的内容应为人所理解。 此构造函数的调用方需要确保此字符串已针对当前系统区域性进行了本地化。
        /// </remarks>
        /// <param name="errcode">
        /// 错误码
        /// </param>
        /// <param name="errcode">
        /// 错误信息
        /// </param>
        public WxException(int errcode, string errMsg)
            : base($"({errcode}){errMsg}") { }
    }
}
