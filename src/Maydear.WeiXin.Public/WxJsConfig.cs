using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.WeiXin.Public
{
    /// <summary>
    /// WxJsConfig
    /// </summary>
    public class WxJsConfig
    {
        /// <summary>
        /// 公众号的唯一标识
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 生成签名的时间戳
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// 生成签名的随机串
        /// </summary>
        public string NonceStr { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string Signature { get; set; }
    }
}
