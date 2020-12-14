using System;
using System.Threading.Tasks;

using AivenEcommerce.V1.Domain.Shared.Dtos.ProductImages;
using AivenEcommerce.V1.Domain.Shared.OperationResults;
using AivenEcommerce.V1.Admin.Wasm.Services.Interfaces;

namespace AivenEcommerce.V1.Admin.Wasm.Services
{
    public class ProductImageService : IProductImageService
    {
        private readonly IApiClientService _apiClient;

        public ProductImageService(IApiClientService apiClient)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
        }

        public Task<OperationResult> DeleteImageAsync(string productId, Guid productImageId)
        {
            return _apiClient.DeleteAsync<OperationResult>($"api/v1/ProductImages/{productImageId}/product/{productId}");
        }

        public Task<OperationResultEnumerable<ProductImageDto>> GetAllAsync(string productId)
        {
            return _apiClient.GetAsync<OperationResultEnumerable<ProductImageDto>>($"api/v1/ProductImages/product/{productId}");
        }
    }
}
