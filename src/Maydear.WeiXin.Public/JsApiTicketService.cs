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
    public class JsApiTicketService
    {
        private WeiXinClient _weiXinClient;

        private IStore _store;
        private WxPublic _wxPublic;
        private IServiceCollection _serviceDescriptors;
        private AccessTokenService _accessTokenService;

        public JsApiTicketService(IStore store, IOptions<WxPublic> wxPublic, IServiceCollection collection, AccessTokenService accessTokenService)
        {
            _store = store;
            _serviceDescriptors = collection;
            _wxPublic = wxPublic.Value;
            _accessTokenService = accessTokenService;
        }

        private WeiXinClient GetWeiXinClient()
        {
            if (_weiXinClient == null)
            {
                var provider = _serviceDescriptors.BuildServiceProvider();
                _weiXinClient = provider.GetRequiredService<WeiXinClient>();
            }

            return _weiXinClient;
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
            string Key = $"JsApiTicket-{appid}";
            string accessToken = await _accessTokenService.GetAccessTokenAsync(appid, appSecret);
            if (string.IsNullOrEmpty(accessToken))
                throw new ArgumentNullException("accessToken is null");

            var cacheTicket = await GetWeiXinClient().GetJsApiTicketAsync(accessToken);
            if (cacheTicket == null)
                throw new ArgumentNullException("cacheTicket is null");
            await _store.RenewAsync(Key, cacheTicket, cacheTicket.ExpiresIn);
            return cacheTicket.Ticket;
        }

    }
}
