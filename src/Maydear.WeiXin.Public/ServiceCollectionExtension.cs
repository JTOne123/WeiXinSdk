using Maydear.WeiXin.Public;
using Maydear.WeiXin.Public.Infrastructure;
using Maydear.WeiXin.Public.Internal;
using Microsoft.Extensions.Configuration;
using Polly;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// 注册微信公众号
        /// </summary>
        /// <param name="services">DI容器服务集合</param>
        /// <param name="configuration">配置对象</param>
        /// <returns></returns>
        public static IServiceCollection AddWerXinPublic(this IServiceCollection services, Action<WxPublicOptions> setupAction)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            if (setupAction == null)
            {
                throw new ArgumentNullException(nameof(setupAction));
            }

            services.AddOptions();
            services.Configure(setupAction);
            services.AddMemoryCache();
            services.AddWeiXinClient();
            services.AddSingleton<IStore, DefaultMemoryStore>();
            services.AddSingleton<AccessTokenService>();
            services.AddSingleton<JsApiTicketService>();
            services.AddSingleton<WxOauthService>();
            services.AddSingleton<WxJsConfigService>();
            return services;
        }


        /// <summary>
        /// 注册微信公众号
        /// </summary>
        /// <param name="services">DI容器服务集合</param>
        /// <param name="configuration">配置对象</param>
        /// <returns></returns>
        public static IServiceCollection AddWerXinPublic(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return services.AddWerXinPublic(options =>
            {
                options.AppId = configuration.GetSection("WeiXin:Public:AppId")?.Value;
                options.AppSecret = configuration.GetSection("WeiXin:Public:AppSecret")?.Value;
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private static IServiceCollection AddWeiXinClient(this IServiceCollection services)
        {
            var registry = services.AddPolicyRegistry();

            var timeout = Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(10));
            var longTimeout = Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(30));

            registry.Add("regular", timeout);
            registry.Add("long", longTimeout);

            services.AddHttpClient("weixin", c =>
            {
                c.BaseAddress = new Uri("https://api.weixin.qq.com/");
                c.DefaultRequestHeaders.Connection.Add("keep-alive");
                c.DefaultRequestHeaders.Add("Accept", "application/json");
                c.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Linux; U; Android 2.3.7; en-us; Nexus One Build/FRF91) AppleWebKit/533.1 (KHTML, like Gecko)");
            })

            // Build a totally custom policy using any criteria
            .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(10)))

            // Use a specific named policy from the registry. Simplest way, policy is cached for the
            // lifetime of the handler.
            .AddPolicyHandlerFromRegistry("regular")

            // Run some code to select a policy based on the request
            .AddPolicyHandler((request) =>
            {
                return request.Method == HttpMethod.Get ? timeout : longTimeout;
            })

            // Run some code to select a policy from the registry based on the request
            .AddPolicyHandlerFromRegistry((reg, request) =>
            {
                return request.Method == HttpMethod.Get ?
                    reg.Get<IAsyncPolicy<HttpResponseMessage>>("regular") :
                    reg.Get<IAsyncPolicy<HttpResponseMessage>>("long");
            })

            // Build a policy that will handle exceptions, 408s, and 500s from the remote server
            .AddTransientHttpErrorPolicy(p => p.RetryAsync())
            .AddHttpMessageHandler(() => new RetryHandler()) // Retry requests to github using our retry handler
            .AddTypedClient<WeiXinClient>();

            return services;
        }
    }
}
