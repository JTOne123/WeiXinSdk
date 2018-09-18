using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Maydear.WeiXin
{
    internal class RetryHandler : DelegatingHandler
    {
        public int RetryCount { get; set; } = 5;

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            for (var i = 0; i < RetryCount; i++)
            {
                try
                {
                    return await base.SendAsync(request, cancellationToken);
                }
                catch (HttpRequestException) when (i == RetryCount - 1)
                {
                    throw;
                }
                catch (HttpRequestException)
                {
                    // Retry
                    await Task.Delay(TimeSpan.FromMilliseconds(50));
                }
            }

            // Unreachable.
            throw null;
        }
    }
}
