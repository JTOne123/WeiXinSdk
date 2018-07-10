using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.WeiXin.Public.Internal
{
    public class AccessTokenRequest
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
        /// 填写第一步获取的code参数
        /// </summary>
        internal string AppSecret { get; set; }

        /// <summary>
        /// 返回字符串格式
        /// </summary>
        /// <returns></returns>
        internal string ToQueryString()
        {
            return $"grant_type={GrantType}&appid={AppId}&secret={AppSecret}";
        }

    }
}
