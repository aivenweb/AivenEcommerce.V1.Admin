using System;
using System.Threading.Tasks;

using AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.Products;
using AivenEcommerce.V1.Admin.Wasm.Domain.OperationResults;
using AivenEcommerce.V1.Admin.Wasm.Services.Interfaces;

namespace AivenEcommerce.V1.Admin.Wasm.Services
{
    public class ProductService : IProductService
    {
        private readonly IApiClientService _apiClient;

        public ProductService(IApiClientService apiClient)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
        }

        public Task<OperationResult<ProductDto>> GetAsync(string id)
        {
            return _apiClient.GetAsync<OperationResult<ProductDto>>("api/v1/products/" + id);
        }

        public Task<OperationResultEnumerable<ProductDto>> GetAllAsync()
        {
            return _apiClient.GetAsync<OperationResultEnumerable<ProductDto>>("api/v1/products");
        }

        public Task<OperationResultEnumerable<ProductDto>> GetByCategoryAsync(string category)
        {
            return _apiClient.GetAsync<OperationResultEnumerable<ProductDto>>($"api/v1/products/categories/{category}");
        }

        public Task<OperationResultEnumerable<ProductDto>> GetByCategoryAsync(string category, string subcategory)
        {
            return _apiClient.GetAsync<OperationResultEnumerable<ProductDto>>($"api/v1/products/categories/{category}/subcategories/{subcategory}");
        }

        public Task<OperationResult<ProductDto>> UpdateMainImageAsync(UpdateProductMainImageInput input)
        {
            return _apiClient.PutAsync<UpdateProductMainImageInput, OperationResult<ProductDto>>("api/v1/products/UpdateMainImage", input);
        }

        public Task<OperationResult<ProductDto>> UpdateCostPriceAsync(UpdateProductCostPriceInput input)
        {
            return _apiClient.PutAsync<UpdateProductCostPriceInput, OperationResult<ProductDto>>("api/v1/products/UpdateCostPrice", input);
        }

        public Task<OperationResult<ProductDto>> UpdateCategory(UpdateProductCategorySubCategoryInput input)
        {
            return _apiClient.PutAsync<UpdateProductCategorySubCategoryInput, OperationResult<ProductDto>>("api/v1/products/UpdateCategory", input);
        }

        public Task<OperationResult<ProductDto>> UpdateAvailabilityAsync(UpdateProductAvailabilityInput input)
        {
            return _apiClient.PutAsync<UpdateProductAvailabilityInput, OperationResult<ProductDto>>("api/v1/products/UpdateAvailability", input);
        }

        public Task<OperationResult<ProductDto>> UpdateNameDescriptionAsync(UpdateProductNameDescriptionInput input)
        {
            return _apiClient.PutAsync<UpdateProductNameDescriptionInput, OperationResult<ProductDto>>("api/v1/products/UpdateNameDescription", input);
        }

        public Task<OperationResult<ProductDto>> CreateProduct(CreateProductInput input)
        {
            return _apiClient.PostAsync<CreateProductInput, OperationResult<ProductDto>>("api/v1/products", input);
        }

        public Task<OperationResult<ProductDto>> UpdateBadgeAsync(UpdateProductBadgeInput input)
        {
            return _apiClient.PutAsync<UpdateProductBadgeInput, OperationResult<ProductDto>>("api/v1/products/UpdateBadge", input);
        }

        public Task<OperationResult> DeleteAsync(string id)
        {
            return _apiClient.DeleteAsync<OperationResult>("api/v1/products/" + id);
        }
    }
}
