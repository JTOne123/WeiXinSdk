using Maydear.WeiXin.Public;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http
{
    /// <summary>
    /// Http 扩展方法
    /// </summary>
    public static class HttpClientExtension
    {
        /// <summary>
        /// Get方式执行Http请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client"></param>
        /// <param name="requestUri"></param>
        /// <param name="headers">头信息</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<T> GetAsync<T>(this HttpClient client, string requestUri, IDictionary<string, string> headers = null, CancellationToken cancellationToken = default(CancellationToken)) where T : class
        {
            TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();
            if (headers != null && headers.Count > 0)
            {
                foreach (var item in headers)
                {
                    if (client.DefaultRequestHeaders.Contains(item.Key))
                        client.DefaultRequestHeaders.Remove(item.Key);
                    client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
            }
            client.GetAsync(requestUri).ContinueWith((requestTask) =>
            {
                if (TaskHelper.HandleFaultsAndCancelation(requestTask, tcs))
                {
                    return;
                }
                try
                {
                    var result = requestTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        result.Content.ReadAsStringAsync().ContinueWith((resultTask) =>
                        {
                            var text = resultTask.Result;
                            if (TaskHelper.HandleFaultsAndCancelation(resultTask, tcs))
                                return;
                            try
                            {
                                tcs.SetResult(JsonConvert.DeserializeObject<T>(text));
                            }
                            catch (Exception deserializeException)
                            {
                                tcs.SetException(deserializeException);
                            }
                        });
                    }
                    else
                    {
                        tcs.SetException(new HttpRequestException(result.ReasonPhrase));
                    }
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            });

            return tcs.Task;
        }

        /// <summary>
        /// Delete方式执行Http请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client"></param>
        /// <param name="requestUri"></param>
        /// <param name="headers">头信息</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<T> DeleteAsync<T>(this HttpClient client, string requestUri, IDictionary<string, string> headers = null, CancellationToken cancellationToken = default(CancellationToken)) where T : class
        {
            TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();
            if (headers != null && headers.Count > 0)
            {
                foreach (var item in headers)
                {
                    if (client.DefaultRequestHeaders.Contains(item.Key))
                        client.DefaultRequestHeaders.Remove(item.Key);
                    client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }

            }
            client.DeleteAsync(requestUri).ContinueWith((requestTask) =>
            {
                if (TaskHelper.HandleFaultsAndCancelation(requestTask, tcs))
                {
                    return;
                }
                try
                {
                    var result = requestTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        result.Content.ReadAsStringAsync().ContinueWith((resultTask) =>
                        {
                            var text = resultTask.Result;
                            if (TaskHelper.HandleFaultsAndCancelation(resultTask, tcs))
                                return;
                            try
                            {
                                tcs.SetResult(JsonConvert.DeserializeObject<T>(text));
                            }
                            catch (Exception deserializeException)
                            {
                                tcs.SetException(deserializeException);
                            }
                        });
                    }
                    else
                    {
                        tcs.SetException(new HttpRequestException(result.ReasonPhrase));
                    }

                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            });

            return tcs.Task;
        }


        /// <summary>
        /// POST方式执行Http请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client"></param>
        /// <param name="requestUri"></param>
        /// <param name="content"></param>
        /// <param name="headers">头信息</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<T> PostAsync<T>(this HttpClient client, string requestUri, HttpContent content, IDictionary<string, string> headers = null, CancellationToken cancellationToken = default(CancellationToken)) where T : class
        {
            TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();
            if (headers != null && headers.Count > 0)
            {
                foreach (var item in headers)
                {
                    if (client.DefaultRequestHeaders.Contains(item.Key))
                        client.DefaultRequestHeaders.Remove(item.Key);
                    client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
            }
            client.PostAsync(requestUri, content).ContinueWith((requestTask) =>
            {
                if (TaskHelper.HandleFaultsAndCancelation(requestTask, tcs))
                    return;
                try
                {
                    var result = requestTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        result.Content.ReadAsStringAsync().ContinueWith((resultTask) =>
                        {
                            var text = resultTask.Result;
                            if (TaskHelper.HandleFaultsAndCancelation(resultTask, tcs))
                                return;
                            try
                            {
                                tcs.SetResult(JsonConvert.DeserializeObject<T>(text));
                            }
                            catch (Exception deserializeException)
                            {
                                tcs.SetException(deserializeException);
                            }

                        });
                    }
                    else
                    {
                        tcs.SetException(new HttpRequestException(result.ReasonPhrase));
                    }
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            });

            return tcs.Task;
        }

        /// <summary>
        /// Put方式执行Http请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client"></param>
        /// <param name="requestUri"></param>
        /// <param name="content"></param>
        /// <param name="headers">头信息</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<T> PutAsync<T>(this HttpClient client, string requestUri, HttpContent content, IDictionary<string, string> headers = null, CancellationToken cancellationToken = default(CancellationToken)) where T : class
        {
            TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();
            if (headers != null && headers.Count > 0)
            {
                foreach (var item in headers)
                {
                    if (client.DefaultRequestHeaders.Contains(item.Key))
                        client.DefaultRequestHeaders.Remove(item.Key);
                    client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
            }
            client.PutAsync(requestUri, content).ContinueWith((requestTask) =>
            {
                if (TaskHelper.HandleFaultsAndCancelation(requestTask, tcs))
                    return;
                try
                {
                    var result = requestTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        result.Content.ReadAsStringAsync().ContinueWith((resultTask) =>
                        {
                            try
                            {
                                var text = resultTask.Result;
                                if (TaskHelper.HandleFaultsAndCancelation(resultTask, tcs))
                                    return;
                                tcs.SetResult(JsonConvert.DeserializeObject<T>(text));
                            }
                            catch (Exception deserializeException)
                            {
                                tcs.SetException(deserializeException);
                            }
                        });
                    }
                    else
                    {
                        tcs.SetException(new HttpRequestException(result.ReasonPhrase));
                    }
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            });

            return tcs.Task;
        }
    }
}
