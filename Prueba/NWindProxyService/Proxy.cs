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
    public class Proxy : IProductService
    {
        private const string BaseAddress = "http://localhost:63617/"; // Cambia esto por la URL base de tu API.

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

        public Products CreateProduct(Products product)
        {
            Products result = null;
            Task.Run(async () => result = await SendPost<Products, Products>("/api/nwind/createproduct", product)).Wait();
            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            Task.Run(async () => result = await SendGet<bool>($"/api/nwind/DeleteProduct/{id}")).Wait();
            return result;
        }

        public List<Products> Filter(string name)
        {
            List<Products> result = null;
            Task.Run(async () => result = await SendGet<List<Products>>($"/api/nwind/FilterProductsByName/{name}")).Wait();
            return result;
        }

        public List<Products> RetrieveAll()
        {
            List<Products> result = null;
            Task.Run(async () => result = await SendGet<List<Products>>("/api/nwind/RetrieveAllProducts")).Wait();
            return result;
        }

        public Products RetrieveById(int id)
        {
            Products result = null;
            Task.Run(async () => result = await SendGet<Products>($"/api/nwind/RetrieveProductByID/{id}")).Wait();
            return result;
        }

        public bool Update(Products product)
        {
            bool result = false;
            Task.Run(async () => result = await SendPost<bool, Products>("/api/nwind/UpdateProduct", product)).Wait();
            return result;
        }
    }
}