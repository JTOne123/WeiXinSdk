using Maydear.WeiXin.Public.Infrastructure;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Maydear.WeiXin.Public.Internal;
using System.Threading.Tasks;

namespace Maydear.WeiXin.Public
{
    public class AccessTokenService
    {
        private WeiXinClient _weiXinClient;
        private IStore _store;
        private WxPublic _wxPublic;

        public AccessTokenService(IStore store, IOptions<WxPublic> wxPublic, WeiXinClient weiXinClient)
        {
            _store = store;
            _weiXinClient = weiXinClient;
            _wxPublic = wxPublic.Value;
        }

        public string GetAccessToken()
        {
            return GetAccessTokenAsync().Result;
        }

        public string GetAccessToken(string appid, string appSecret)
        {
            return GetAccessTokenAsync(appid, appSecret).Result;
        }

        public Task<string> GetAccessTokenAsync()
        {
            return GetAccessTokenAsync(_wxPublic.AppId, _wxPublic.AppSecret);
        }

        public async Task<string> GetAccessTokenAsync(string appid, string appSecret)
        {
            string Key = $"AccessToken-{appid}";
            AccessTokenMessage cacheAccessToken = (AccessTokenMessage)await _store.RetrieveAsync(Key);
            if (cacheAccessToken == null)
            {
                cacheAccessToken = await _weiXinClient.GetAccessTokenAsync(new Internal.AccessTokenRequest() { AppId = appid, AppSecret = appSecret });
                if (cacheAccessToken == null || cacheAccessToken.ErrCode != 0)
                    throw new ArgumentNullException(cacheAccessToken.ErrMsg);
                await _store.RenewAsync(Key, cacheAccessToken, cacheAccessToken.ExpiresIn);
            }
            return cacheAccessToken.AccessToken;
        }
    }
}
