using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Maydear.WeiXin.Public.Infrastructure
{
    public interface IStore
    {
        Task RenewAsync(string key, object value, long expire);

        Task<object> RetrieveAsync(string key);

        Task RemoveAsync(string key);
    }
}
