using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.WeiXin.Public.Internal
{
    public class AccessTokenMessage : WxMessage
    {
        /// <summary>
        /// 接口调用凭据
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// 超时时间
        /// </summary>
        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }

    }
}
