using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.ProductBadges;
using AivenEcommerce.V1.Admin.Wasm.Domain.OperationResults;
using AivenEcommerce.V1.Admin.Wasm.Services.Interfaces;

namespace AivenEcommerce.V1.Admin.Wasm.Services
{
    public class ProductBadgeService : IProductBadgeService
    {
        private readonly IApiClientService _apiClient;

        public ProductBadgeService(IApiClientService apiClient)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
        }
        public Task<OperationResult<ProductBadgeDto>> GetByProductAsync(string productId)
        {
            return _apiClient.GetAsync<OperationResult<ProductBadgeDto>>($"api/v1/ProductBadges/product/{productId}");
        }
    }
}
