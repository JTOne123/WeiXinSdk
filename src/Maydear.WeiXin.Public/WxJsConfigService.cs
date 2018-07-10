using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Maydear.WeiXin.Public
{
    /// <summary>
    /// 
    /// </summary>
    public class WxJsConfigService
    {
        private JsApiTicketService _jsApiTicketService;
        private WxPublic _wxPublic;

        public WxJsConfigService(JsApiTicketService jsApiTicketService, IOptions<WxPublic> wxPublic)
        {
            _jsApiTicketService = jsApiTicketService;
            _wxPublic = wxPublic.Value;
        }

        public Task<WxJsConfig> GetConfigAsync(string url)
        {
            return GetConfigAsync(_wxPublic.AppId, _wxPublic.AppSecret, url);
        }

        public async Task<WxJsConfig> GetConfigAsync(string appId, string appSecret, string url)
        {
            var ticket = await _jsApiTicketService.GetJsApiTicketAsync(appId, appSecret);

            var jsConfig = new WxJsConfig()
            {
                AppId = appId,
                NonceStr = CommonHelper.GetNonceStr(),
                Timestamp = CommonHelper.GetTimestamp()
            };
            jsConfig.Signature = CommonHelper.BuildSignature(ticket, jsConfig.NonceStr, jsConfig.Timestamp, url);

            return jsConfig;
        }



    }
}
