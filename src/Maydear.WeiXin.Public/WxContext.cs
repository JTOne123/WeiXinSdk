using Maydear.WeiXin.Public.Exceptions;
using Maydear.WeiXin.Public.Internal;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Maydear.WeiXin.Public
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
        public async Task<AccessTokenMessage> GetAccessToken(AccessTokenRequest request)
        {
            return await HttpClient.GetAsync<AccessTokenMessage>(string.Format("/cgi-bin/token?{0}", request.ToQueryString()));
        }

        /// <summary>
        /// 获取JsApiTicket
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<JsApiTicketMessage> GetJsApiTicket(string accessToken)
        {
            return await HttpClient.GetAsync<JsApiTicketMessage>($"/cgi-bin/ticket/getticket?access_token={accessToken}&type=jsapi");
        }

        /// <summary>
        /// 获取JsApiTicket
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<JsApiTicketMessage> GetJsApiTicket(AccessTokenRequest request)
        {
            var accessTokenMessage = await GetAccessToken(request);
            if (accessTokenMessage.ErrCode == 0)
            {
                var accessToken = accessTokenMessage.AccessToken;
                return await HttpClient.GetAsync<JsApiTicketMessage>($"/cgi-bin/ticket/getticket?access_token={accessToken}&type=jsapi");
            }
            else
                throw new WxMessageException(accessTokenMessage);
        }
    }
}
