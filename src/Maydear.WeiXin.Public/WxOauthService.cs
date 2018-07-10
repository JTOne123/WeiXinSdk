using Maydear.WeiXin.Public.Infrastructure;
using Maydear.WeiXin.Public.Internal;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Maydear.WeiXin.Public
{
    /// <summary>
    /// 微信认证
    /// </summary>
    public class WxOauthService
    {
        private WeiXinClient _weiXinClient;
        private IStore _store;
        private WxPublicOptions _wxPublic;

        /// <summary>
        /// 公众号认证
        /// </summary>
        /// <param name="store"></param>
        /// <param name="wxPublic"></param>
        /// <param name="weiXinClient"></param>
        public WxOauthService(IStore store, IOptions<WxPublicOptions> wxPublic, WeiXinClient weiXinClient)
        {
            _store = store;
            _weiXinClient = weiXinClient;
            _wxPublic = wxPublic.Value;
        }

        /// <summary>
        /// 通过读取配置文件获取
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<string> GetOpenidAsync(string code)
        {
            if (_wxPublic == null)
                throw new ArgumentException("GetOpenidAsync.WxPublicOptions is null");
            return GetOpenidAsync(_wxPublic.AppId, _wxPublic.AppSecret, code);
        }

        /// <summary>
        /// 获取当前公众号对应的openid
        /// </summary>
        /// <param name="appid"></param>
        /// <param name="appSecret"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<string> GetOpenidAsync(string appid, string appSecret, string code)
        {
            if (string.IsNullOrEmpty(appid))
                throw new ArgumentNullException("GetOpenidAsync appId");

            if (string.IsNullOrEmpty(appSecret))
                throw new ArgumentNullException("GetOpenidAsync appSecret");

            if (string.IsNullOrEmpty(code))
                throw new ArgumentNullException("GetOpenidAsync appSecret");


            var oauth2Message = await _weiXinClient.GetOauth2AccessTokenAsync(new Oauth2Request() { AppId = appid, AppSecret = appSecret, Code = code });
            if (oauth2Message == null)
                throw new ArgumentNullException("oauth2Message is null");
            string Key = $"Openid-{oauth2Message.Openid}";
            await _store.RenewAsync(Key, oauth2Message, oauth2Message.ExpiresIn);
            return oauth2Message.Openid;
        }

        /// <summary>
        /// 拉取已登录用户信息
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public async Task<WxUserInfo> GetWxUserInfoAsync(string openid)
        {
            if (string.IsNullOrEmpty(openid))
                throw new ArgumentNullException("GetWxUserInfoAsync openid");

            string Key = $"Openid-{openid}";
            var oauth2Message = (Oauth2Message)await _store.RetrieveAsync(Key);
            if (oauth2Message == null)
                throw new ArgumentNullException("oauth2Message is null");
            var userMessage = await _weiXinClient.GetUserInfoAsync(oauth2Message.AccessToken, oauth2Message.Openid);
            if (userMessage == null)
                return null;
            return new WxUserInfo()
            {
                City = userMessage.City,
                Country = userMessage.Country,
                HeadImgurl = userMessage.HeadImgurl,
                Nickname = userMessage.Nickname,
                Openid = userMessage.Openid,
                Privilege = userMessage.Privilege,
                Province = userMessage.Province,
                Sex = userMessage.Sex,
                Unionid = userMessage.Unionid
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appid"></param>
        /// <param name="appSecret"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<WxUserInfo> GetWxUserInfoAsync(string appid, string appSecret, string code)
        {
            if (string.IsNullOrEmpty(appid))
                throw new ArgumentNullException("GetOpenidAsync appId");

            if (string.IsNullOrEmpty(appSecret))
                throw new ArgumentNullException("GetOpenidAsync appSecret");

            if (string.IsNullOrEmpty(code))
                throw new ArgumentNullException("GetOpenidAsync appSecret");

            var oauth2Message = await _weiXinClient.GetOauth2AccessTokenAsync(new Oauth2Request() { AppId = appid, AppSecret = appSecret, Code = code });
            if (oauth2Message == null)
                throw new ArgumentNullException("oauth2Message is null");
            string Key = $"Openid-{oauth2Message.Openid}";
            await _store.RenewAsync(Key, oauth2Message, oauth2Message.ExpiresIn);
            var userMessage = await _weiXinClient.GetUserInfoAsync(oauth2Message.AccessToken, oauth2Message.Openid);
            if (userMessage == null)
                return null;
            return new WxUserInfo()
            {
                City = userMessage.City,
                Country = userMessage.Country,
                HeadImgurl = userMessage.HeadImgurl,
                Nickname = userMessage.Nickname,
                Openid = userMessage.Openid,
                Privilege = userMessage.Privilege,
                Province = userMessage.Province,
                Sex = userMessage.Sex,
                Unionid = userMessage.Unionid
            };
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<WxUserInfo> GetWxUserInfoByOptionsAsync(string code)
        {
            if (_wxPublic == null)
                throw new ArgumentException("GetOpenidAsync.WxPublicOptions is null");
            return GetWxUserInfoAsync(_wxPublic.AppId, _wxPublic.AppSecret, code);
        }
    }
}
