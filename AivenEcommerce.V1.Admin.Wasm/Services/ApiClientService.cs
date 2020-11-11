using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using AivenEcommerce.V1.Admin.Wasm.Domain.OperationResults;
using AivenEcommerce.V1.Admin.Wasm.Services.Interfaces;

namespace AivenEcommerce.V1.Admin.Wasm.Services
{
    public class ApiClientService : IApiClientService
    {
        private readonly HttpClient _httpClient;

        public ApiClientService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<TResponse> GetAsync<TResponse>(string requestUri) where TResponse : OperationResult
        {
            var httpResponse = await _httpClient.GetAsync(requestUri);

            return await httpResponse.Content.ReadFromJsonAsync<TResponse>();
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string requestUri, TRequest requestBody) where TResponse : OperationResult
        {
            var httpResponse = await _httpClient.PostAsJsonAsync(requestUri, requestBody);

            return await httpResponse.Content.ReadFromJsonAsync<TResponse>();
        }

        public async Task<TResponse> PutAsync<TRequest, TResponse>(string requestUri, TRequest requestBody) where TResponse : OperationResult
        {
            var httpResponse = await _httpClient.PutAsJsonAsync(requestUri, requestBody);

            return await httpResponse.Content.ReadFromJsonAsync<TResponse>();
        }

        public async Task<TResponse> DeleteAsync<TResponse>(string requestUri) where TResponse : OperationResult
        {
            var httpResponse = await _httpClient.DeleteAsync(requestUri);

            return await httpResponse.Content.ReadFromJsonAsync<TResponse>();
        }
    }
}
