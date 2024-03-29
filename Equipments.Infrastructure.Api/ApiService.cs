using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace Equipments.Api
{
    public class ApiService<T> : ApiClient where T : class
    {
        public ApiService(string baseAddress) : base(baseAddress)
        {

        }
    }
    public class ApiService
    {
        protected readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected async Task<HttpResponseMessage> SendRequestAsync(HttpMethod method, string requestUri)
        {
            var request = new HttpRequestMessage(method, new Uri(requestUri));
            var response = await _httpClient.SendAsync(request);
            return response;
        }
    }

}
