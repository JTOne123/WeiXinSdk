using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.WeiXin.Payment
{
    /// <summary>
    /// 
    /// </summary>
    public class WxPaymentOptions : IOptions<WxPaymentOptions>
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
        /// 商户编号
        /// </summary>
        public string MchId { get; set; }

        /// <summary>
        /// 证书（仅退款、撤销订单时需要）
        /// </summary>
        public string Certificate { get; set; }

        /// <summary>
        /// 返回对象
        /// </summary>
        public WxPaymentOptions Value
        {
            get { return this; }
        }
    }
}
