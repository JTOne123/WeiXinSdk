using Maydear.WeiXin.Public.Exceptions;
using Maydear.WeiXin.Public.Internal;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Maydear.WeiXin.Public.Internal
{
    internal class WeiXinClient
    {
        public WeiXinClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public HttpClient HttpClient { get; }

        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AccessTokenMessage> GetAccessTokenAsync(AccessTokenRequest request)
        {
            return await HttpClient.GetAsync<AccessTokenMessage>(string.Format("/cgi-bin/token?{0}", request.ToQueryString()));
        }

        /// <summary>
        /// 获取JsApiTicket
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<JsApiTicketMessage> GetJsApiTicketAsync(string accessToken)
        {

            var message = await HttpClient.GetAsync<JsApiTicketMessage>($"/cgi-bin/ticket/getticket?access_token={accessToken}&type=jsapi");

            if (message.ErrCode > 0)
                throw new WxException(message.ErrCode, message.ErrMsg);
            return message;
        }

        /// <summary>
        /// 获取JsApiTicket
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<JsApiTicketMessage> GetJsApiTicketAsync(AccessTokenRequest request)
        {
            AccessTokenMessage accessTokenMessage = await GetAccessTokenAsync(request);
            if (accessTokenMessage.ErrCode > 0)
                throw new WxException(accessTokenMessage.ErrCode, accessTokenMessage.ErrMsg);
            var accessToken = accessTokenMessage.AccessToken;
            var ticketMessage = await HttpClient.GetAsync<JsApiTicketMessage>($"/cgi-bin/ticket/getticket?access_token={accessToken}&type=jsapi");
            if (ticketMessage.ErrCode > 0)
                throw new WxException(ticketMessage.ErrCode, ticketMessage.ErrMsg);

            return ticketMessage;
        }

        /// <summary>
        /// 获取开放授权的AccessToken
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<Oauth2Message> GetOauth2AccessTokenAsync(Oauth2Request request)
        {
            var message = await HttpClient.GetAsync<Oauth2Message>($"/sns/oauth2/access_token?{request.ToQueryString()}");
            if (message.ErrCode > 0)
                throw new WxException(message.ErrCode, message.ErrMsg);
            return message;
        }

        /// <summary>
        /// 刷新用户的AccessToken
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<Oauth2Message> RefreshOauth2AccessTokenAsync(Oauth2Refresh request)
        {
            var message = await HttpClient.GetAsync<Oauth2Message>($"/sns/oauth2/refresh_token?{request.ToQueryString()}");
            if (message.ErrCode > 0)
                throw new WxException(message.ErrCode, message.ErrMsg);
            return message;

        }


        /// <summary>
        /// 拉取用户信息
        /// </summary>
        /// <param name="accessToken">Oauth2返回的AccessToken</param>
        /// <param name="openid">Oauth2返回的openid</param>
        /// <returns></returns>
        public async Task<UserInfoMessage> GetUserInfoAsync(string accessToken, string openid)
        {
            var message = await HttpClient.GetAsync<UserInfoMessage>($"/sns/userinfo?access_token={accessToken}&openid={openid}&lang=zh_CN");
            if (message.ErrCode > 0)
                throw new WxException(message.ErrCode, message.ErrMsg);
            return message;
        }
    }
}
