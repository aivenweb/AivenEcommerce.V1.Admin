using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.ProductCategories;
using AivenEcommerce.V1.Admin.Wasm.Domain.OperationResults;
using AivenEcommerce.V1.Admin.Wasm.Services.Interfaces;

namespace AivenEcommerce.V1.Admin.Wasm.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IApiClientService _apiClient;

        public ProductCategoryService(IApiClientService apiClient)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
        }

        public Task<OperationResult<ProductCategoryDto>> CreateAsync(string name, IEnumerable<string> subcategories)
        {
            return _apiClient.PostAsync<CreateProductCategoryInput, OperationResult<ProductCategoryDto>>("api/v1/productcategories", new CreateProductCategoryInput(name, subcategories));
        }

        public Task<OperationResult> DeleteAsync(string name)
        {
            return _apiClient.DeleteAsync<OperationResult>("api/v1/productcategories/" + name);
        }

        public Task<OperationResultEnumerable<ProductCategoryDto>> GetAllAsync()
        {
            return _apiClient.GetAsync<OperationResultEnumerable<ProductCategoryDto>>("api/v1/productcategories");
        }

        public Task<OperationResult<ProductCategoryDto>> GetAsync(string name)
        {
            return _apiClient.GetAsync<OperationResult<ProductCategoryDto>>("api/v1/productcategories/" + name);
        }

        public Task<OperationResult<ProductCategoryDto>> UpdateAsync(Guid id, string name, IEnumerable<string> subcategories)
        {
            return _apiClient.PutAsync<UpdateProductCategoryInput, OperationResult<ProductCategoryDto>>("api/v1/productcategories", new UpdateProductCategoryInput(id, name, subcategories));
        }
    }
}
