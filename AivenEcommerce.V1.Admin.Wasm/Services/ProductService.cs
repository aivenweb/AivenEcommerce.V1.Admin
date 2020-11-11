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

        public Task<OperationResult<ProductDto>> UpdateMainImageAsync(string id, Uri image)
        {
            return _apiClient.PutAsync<UpdateProductMainImageInput, OperationResult<ProductDto>>("api/v1/products/UpdateMainImage", new UpdateProductMainImageInput(id, image));
        }

        public Task<OperationResult<ProductDto>> UpdateCostPriceAsync(string id, decimal cost, decimal price)
        {
            return _apiClient.PutAsync<UpdateProductCostPriceInput, OperationResult<ProductDto>>("api/v1/products/UpdateCostPrice", new UpdateProductCostPriceInput(id, cost, price));
        }

        public Task<OperationResult<ProductDto>> UpdateCategory(string id, string category, string subcategory)
        {
            return _apiClient.PutAsync<UpdateProductCategorySubCategoryInput, OperationResult<ProductDto>>("api/v1/products/UpdateCategory", new UpdateProductCategorySubCategoryInput(id, category, subcategory));
        }

        public Task<OperationResult<ProductDto>> UpdateAvailabilityAsync(string id, bool isActive, int stock)
        {
            return _apiClient.PutAsync<UpdateProductAvailabilityInput, OperationResult<ProductDto>>("api/v1/products/UpdateAvailability", new UpdateProductAvailabilityInput(id, stock, isActive));
        }

        public Task<OperationResult<ProductDto>> UpdateNameDescriptionAsync(string id, string name, string descripción)
        {
            return _apiClient.PutAsync<UpdateProductNameDescriptionInput, OperationResult<ProductDto>>("api/v1/products/UpdateNameDescription", new UpdateProductNameDescriptionInput(id, name, descripción));
        }

        public Task<OperationResult<ProductDto>> CreateProduct(CreateProductInput input)
        {
            return _apiClient.PostAsync<CreateProductInput, OperationResult<ProductDto>>("api/v1/products", input);
        }
    }
}
