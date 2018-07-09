using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Maydear.WeiXin.Public
{
    internal class JsApiTicketMessage : WxMessage
    {
        /// <summary>
        /// 微信JS接口的临时票据
        /// </summary>
        [JsonProperty("ticket")]
        public string Ticket { get; set; }

        /// <summary>
        /// 超时时间
        /// </summary>
        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }
    }
}
