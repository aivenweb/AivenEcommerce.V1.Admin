using AivenEcommerce.V1.Domain.Shared.OperationResults;

using System.Threading.Tasks;

namespace AivenEcommerce.V1.Admin.Wasm.Services.Interfaces
{
    public interface IApiClientService
    {
        Task<TResponse> GetAsync<TResponse>(string requestUri) where TResponse : OperationResult;
        Task<TResponse> PostAsync<TRequest, TResponse>(string requestUri, TRequest requestBody) where TResponse : OperationResult;
        Task<TResponse> PutAsync<TRequest, TResponse>(string requestUri, TRequest requestBody) where TResponse : OperationResult;
        Task<TResponse> DeleteAsync<TResponse>(string requestUri) where TResponse : OperationResult;
    }
}
