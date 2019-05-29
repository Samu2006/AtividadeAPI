using AulaLTP6.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace AulaLTP6.WebApplication.Services.APIService
{
    public class PersonService
    {
        private HttpClient client = new HttpClient();
        private string prefix = "https://localhost:44353/api/";

        protected async Task<string> GetAsync(string url)
        {
            return await client.GetStringAsync(prefix + url);
        }

        public Person Get(string url)
        {
            var result = client.GetAsync(prefix + url).GetAwaiter().GetResult();

            var resultado = result.Content.ReadAsAsync<Person>().GetAwaiter().GetResult();
            return resultado;
        }

        public IEnumerable<Person> List(string url)
        {

            var result = client.GetAsync(prefix + url).GetAwaiter().GetResult();

            if (result.IsSuccessStatusCode)
            {
                var resultado = result.Content.ReadAsAsync<IEnumerable<Person>>().GetAwaiter().GetResult();
                return resultado;
            }
            return null;
        }

        public bool Post(string url, Person obj)
        {
            HttpResponseMessage response = client.PostAsJsonAsync(prefix + url, obj).GetAwaiter().GetResult();
            if (!response.IsSuccessStatusCode)
            {
                var resultado = response.Content.ReadAsAsync<bool>().GetAwaiter().GetResult();
                return resultado;
            }
            return response.IsSuccessStatusCode;
        }
        public bool Put(string url, Person obj)
        {
            HttpResponseMessage response = client.PutAsJsonAsync(prefix + url, obj).GetAwaiter().GetResult();
            if (!response.IsSuccessStatusCode)
            {
                var resultado = response.Content.ReadAsAsync<bool>().GetAwaiter().GetResult();
                return resultado;
            }
            return response.IsSuccessStatusCode;
        }

        public bool Delete(string url)
        {
            HttpResponseMessage response = client.DeleteAsync(prefix + url).GetAwaiter().GetResult();
            if (!response.IsSuccessStatusCode)
            {
                var resultado = response.Content.ReadAsAsync<bool>().GetAwaiter().GetResult();
                return resultado;
            }
            return response.IsSuccessStatusCode;
        }
    }
}