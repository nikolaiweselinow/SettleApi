using System.Threading.Tasks;
using SettleApi.Helpers;

namespace SettleApi
{
    public interface ISettleApiClient
    {
        Task<T> Get<T>(string url);
        Task<Result<T>> Post<T>(string url, object obj);
        Task<Result<T>> Put<T>(string url, object obj);
        
    }
}
