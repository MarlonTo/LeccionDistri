using SLC;
using Entities;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NWindProxyService
{
    public class ProxyCate : ICategoryService
    {
        private const string BaseAddress = "http://localhost:63617/";

        // Método para enviar una solicitud POST genérica
        private async Task<T> SendPost<T, PostData>(string requestURI, PostData data)
        {
            T result = default(T);
            using (var client = new HttpClient())
            {
                try
                {
                    requestURI = BaseAddress + requestURI;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var jsonData = JsonConvert.SerializeObject(data);
                    HttpResponseMessage response = await client.PostAsync(requestURI,
                        new StringContent(jsonData, Encoding.UTF8, "application/json"));

                    var resultWebAPI = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<T>(resultWebAPI);
                }
                catch (Exception ex)
                {
                    // Manejar la excepción
                    throw new Exception("Error en la solicitud POST", ex);
                }
            }
            return result;
        }

        // Método para enviar una solicitud GET genérica
        private async Task<T> SendGet<T>(string requestURI)
        {
            T result = default(T);
            using (var client = new HttpClient())
            {
                try
                {
                    requestURI = BaseAddress + requestURI;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var resultJSON = await client.GetStringAsync(requestURI);
                    result = JsonConvert.DeserializeObject<T>(resultJSON);
                }
                catch (Exception ex)
                {
                    // Manejar la excepción
                    throw new Exception("Error en la solicitud GET", ex);
                }
            }
            return result;
        }

        public Categories CreateCategory(Categories category)
        {
            Categories result = null;
            Task.Run(async () => result = await SendPost<Categories, Categories>("/api/nwind/CreateCategory", category)).Wait();
            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            Task.Run(async () => result = await SendGet<bool>($"/api/nwind/DeleteCategory/{id}")).Wait();
            return result;
        }

        public List<Categories> Filter(string name)
        {
            List<Categories> result = null;
            Task.Run(async () => result = await SendGet<List<Categories>>($"/api/nwind/FilterCategoriesByName/{name}")).Wait();
            return result;
        }

        public List<Categories> RetrieveAll()
        {
            List<Categories> result = null;
            Task.Run(async () => result = await SendGet<List<Categories>>("/api/nwind/RetrieveAllCategories")).Wait();
            return result;
        }

        public Categories RetrieveById(int id)
        {
            Categories result = null;
            Task.Run(async () => result = await SendGet<Categories>($"/api/nwind/RetrieveCategoryByID/{id}")).Wait();
            return result;
        }

        public bool Update(Categories category)
        {
            bool result = false;
            Task.Run(async () => result = await SendPost<bool, Categories>("/api/nwind/UpdateCategory", category)).Wait();
            return result;
        }
    }
}
