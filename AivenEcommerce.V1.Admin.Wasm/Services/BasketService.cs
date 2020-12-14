using System;
using System.Threading.Tasks;

using AivenEcommerce.V1.Domain.Shared.Dtos.Baskets;
using AivenEcommerce.V1.Domain.Shared.OperationResults;
using AivenEcommerce.V1.Admin.Wasm.Services.Interfaces;

namespace AivenEcommerce.V1.Admin.Wasm.Services
{
    public class BasketService : IBasketService
    {
        private readonly IApiClientService _apiClient;

        public BasketService(IApiClientService apiClient)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
        }

        public Task<OperationResult<BasketDto>> AddBasketProductAsync(AddBasketProductInput input)
        {
            return _apiClient.PostAsync<AddBasketProductInput, OperationResult<BasketDto>>("api/v1/Baskets", input);
        }

        public Task<OperationResult<BasketDto>> GetBasketAsync(string customerEmail)
        {
            return _apiClient.GetAsync<OperationResult<BasketDto>>($"api/v1/Baskets/{customerEmail}");
        }

        public Task<OperationResult<BasketProductsDto>> GetBasketProductsAsync(string customerEmail)
        {
            return _apiClient.GetAsync<OperationResult<BasketProductsDto>>($"api/v1/Baskets/{customerEmail}/products");
        }

        public Task<OperationResult> RemoveAllBasketAsync(RemoveAllBasketInput input)
        {
            return _apiClient.DeleteAsync<OperationResult>($"api/v1/Baskets/{input.CustomerEmail}");
        }

        public Task<OperationResult<BasketDto>> RemoveBasketProductAsync(RemoveBasketProductInput input)
        {
            return _apiClient.DeleteAsync<OperationResult<BasketDto>>($"api/v1/Baskets/{input.CustomerEmail}/products/{input.ProductId}");
        }

        public Task<OperationResult<BasketDto>> UpdateBasketAsync(UpdateBasketInput input)
        {
            return _apiClient.PutAsync<UpdateBasketInput, OperationResult<BasketDto>>("api/v1/Baskets", input);
        }
    }
}
