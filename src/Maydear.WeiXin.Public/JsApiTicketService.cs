using Maydear.WeiXin.Public.Infrastructure;
using Maydear.WeiXin.Public.Internal;
using Microsoft.Extensions.DependencyInjection;
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
    public class JsApiTicketService
    {
        private WeiXinPublicClient _weiXinClient;

        private IStore _store;
        private WxPublicOptions _wxPublic;
        private AccessTokenService _accessTokenService;

        public JsApiTicketService(IStore store, IOptions<WxPublicOptions> wxPublic, WeiXinPublicClient weiXinClient, AccessTokenService accessTokenService)
        {
            _store = store;
            _weiXinClient = weiXinClient;
            _wxPublic = wxPublic.Value;
            _accessTokenService = accessTokenService;
        }

        public string GetJsApiTicket()
        {
            return GetJsApiTicketAsync().Result;
        }

        public string GetJsApiTicket(string appid, string appSecret)
        {
            return GetJsApiTicketAsync(appid, appSecret).Result;
        }

        public Task<string> GetJsApiTicketAsync()
        {
            return GetJsApiTicketAsync(_wxPublic.AppId, _wxPublic.AppSecret);
        }

        public async Task<string> GetJsApiTicketAsync(string appid, string appSecret)
        {
            if (string.IsNullOrEmpty(appid))
                throw new ArgumentNullException("GetJsApiTicketAsync appId");

            if (string.IsNullOrEmpty(appSecret))
                throw new ArgumentNullException("GetJsApiTicketAsync appSecret");

            string Key = $"JsApiTicket-{appid}";
            string accessToken = await _accessTokenService.GetAccessTokenAsync(appid, appSecret);
            if (string.IsNullOrEmpty(accessToken))
                throw new ArgumentNullException("accessToken is null");

            var cacheTicket = await _weiXinClient.GetJsApiTicketAsync(accessToken);
            if (cacheTicket == null)
                throw new ArgumentNullException("cacheTicket is null");
            await _store.RenewAsync(Key, cacheTicket, cacheTicket.ExpiresIn);
            return cacheTicket.Ticket;
        }

    }
}
