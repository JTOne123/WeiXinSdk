using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.WeiXin.Public.Internal
{
    internal class Oauth2Refresh
    {
        /// <summary>
        /// 获取access_token填写
        /// </summary>
        internal string GrantType { get { return "refresh_token"; } }

        /// <summary>
        /// 第三方用户唯一凭证,微信开放平台的appid
        /// </summary>
        internal string AppId { get; set; }

        /// <summary>
        /// 第三方用户唯一凭证密钥，即appsecret
        /// </summary>
        internal string AppSecret { get; set; }

        /// <summary>
        /// 刷新TOKEN
        /// </summary>
        internal string RefreshToken { get; set; }

        /// <summary>
        /// 返回字符串格式
        /// </summary>
        /// <returns></returns>
        internal string ToQueryString()
        {
            return $"appid={AppId}&secret={AppSecret}&refresh_token={RefreshToken}&grant_type={GrantType}";
        }

    }
}
