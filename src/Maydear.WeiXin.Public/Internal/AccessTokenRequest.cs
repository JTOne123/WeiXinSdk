using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.WeiXin.Public.Internal
{
    internal class AccessTokenRequest
    {
        /// <summary>
        /// 获取access_token填写
        /// </summary>
        internal string GrantType { get { return "client_credential"; } }

        /// <summary>
        /// 第三方用户唯一凭证,微信开放平台的appid
        /// </summary>
        internal string AppId { get; set; }

        /// <summary>
        /// 第三方用户唯一凭证密钥，即appsecret
        /// </summary>
        internal string Secret { get; set; }

        /// <summary>
        /// 返回字符串格式
        /// </summary>
        /// <returns></returns>
        internal string ToQueryString()
        {
            return string.Format("grant_type={0}&appid={1}&secret={2}", this.GrantType, this.AppId, this.Secret);
        }

    }
}
