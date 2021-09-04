using Newtonsoft.Json;
using OnSale.Common.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnSale.Common.Services
{

    public class ApiService : IApiService
    {
        public async Task<Response> GetListAsync<T>(
            string urlBase,//url que consumimos
            string servicePrefix,//ruteo de los controladores en este caso con la palabra Api
            string controller)//nombre del controlador
        {
            try
            {
                //creamos el cliente http
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase),
                };
                //armado de la dirección 
                string url = $"{servicePrefix}{controller}";
                //ejecucion del Get, es un met assync que puede demorar, lo mismo que hace postman
                HttpResponseMessage response = await client.GetAsync(url);
                //leemos la respuesta
                string result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }
                //leemos como un string y lo pasamos a una lista de <T>
                List<T> list = JsonConvert.DeserializeObject<List<T>>(result);
                return new Response
                {
                    IsSuccess = true,
                    Result = list
                };
            }
            catch (Exception ex) 
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
