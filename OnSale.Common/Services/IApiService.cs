using OnSale.Common.Responses;
using System.Threading.Tasks;


namespace OnSale.Common.Services
{
    public interface IApiService
    {
        //<T>deme una lista de lo que sea
        Task<Response> GetListAsync<T>(string urlBase, string servicePrefix, string controller);
    }

}
