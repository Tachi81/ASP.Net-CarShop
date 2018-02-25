using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CarShop.API_Consumer.Interfaces
{
    public interface IClientAbstract<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<HttpStatusCode> Post(T model);
        void SetUrl(string url);
    }
}