using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.ProductVariants;
using AivenEcommerce.V1.Admin.Wasm.Domain.OperationResults;
using AivenEcommerce.V1.Admin.Wasm.Services.Interfaces;

namespace AivenEcommerce.V1.Admin.Wasm.Services
{
    public class ProductVariantService : IProductVariantService
    {
        private readonly IApiClientService _apiClient;

        public ProductVariantService(IApiClientService apiClient)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
        }

        public Task<OperationResult<ProductVariantDto>> CreateAsync(CreateProductVariantInput input)
        {
            return _apiClient.PostAsync<CreateProductVariantInput, OperationResult<ProductVariantDto>>("api/v1/ProductVariants", input);
        }

        public Task<OperationResult> DeleteAsync(DeleteProductVariantInput input)
        {
            return _apiClient.DeleteAsync<OperationResult>($"api/v1/ProductVariants/{input.Name}/products/{input.ProductId}");
        }

        public Task<OperationResultEnumerable<ProductVariantDto>> GetAllAsync(string productId)
        {
            return _apiClient.GetAsync<OperationResultEnumerable<ProductVariantDto>>($"api/v1/ProductVariants/products/{productId}");
        }

        public Task<OperationResult<ProductVariantDto>> GetAsync(string productId, string name)
        {
            return _apiClient.GetAsync<OperationResult<ProductVariantDto>>($"api/v1/ProductVariants/{name}/products/{productId}");
        }

        public Task<OperationResultEnumerable<ProductVariantDto>> UpdateAsync(UpdateProductVariantInput input)
        {
            return _apiClient.PutAsync<UpdateProductVariantInput, OperationResultEnumerable<ProductVariantDto>>("api/v1/ProductVariants", input);
        }
    }
}
