using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.WeiXin.Public.Exceptions
{
    public class WxMessageException : Exception
    {
        /// <summary>
        /// 使用指定错误消息初始化<see cref="MaydearException"/>类的新实例。
        /// </summary>
        /// <remarks>
        /// message 参数的内容应为人所理解。 此构造函数的调用方需要确保此字符串已针对当前系统区域性进行了本地化。
        /// </remarks>
        /// <param name="message">
        /// 描述错误的消息。
        /// </param>
        public WxMessageException(WxMessage message)
            : base($"({message.ErrCode}){message.ErrMsg}") { }
    }
}
