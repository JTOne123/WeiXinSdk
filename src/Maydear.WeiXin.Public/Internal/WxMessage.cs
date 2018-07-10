using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.WeiXin.Public.Internal
{
    public class WxMessage
    {
        /// <summary>
        /// 错误码
        /// </summary>
        /// <remarks>
        /// <see cref="https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1445241432&token=&lang=zh_CN"/>
        /// </remarks>
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

    }
}
