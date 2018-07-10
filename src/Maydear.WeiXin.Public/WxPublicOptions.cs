using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.WeiXin.Public
{
    /// <summary>
    /// 
    /// </summary>
    public class WxPublicOptions : IOptions<WxPublicOptions>
    {
        /// <summary>
        /// 用户唯一凭证
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 密钥
        /// </summary>
        public string AppSecret { get; set; }

        /// <summary>
        /// 返回对象
        /// </summary>
        public WxPublicOptions Value
        {
            get { return this; }
        }
    }
}
