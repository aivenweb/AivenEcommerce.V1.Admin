using AivenEcommerce.V1.Admin.Wasm.Services.Interfaces;
using AivenEcommerce.V1.Domain.Shared.Dtos.ProductCategories;
using AivenEcommerce.V1.Domain.Shared.OperationResults;

using System;
using System.Threading.Tasks;

namespace AivenEcommerce.V1.Admin.Wasm.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IApiClientService _apiClient;

        public ProductCategoryService(IApiClientService apiClient)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
        }

        public Task<OperationResult<ProductCategoryDto>> CreateAsync(CreateProductCategoryInput input)
        {
            return _apiClient.PostAsync<CreateProductCategoryInput, OperationResult<ProductCategoryDto>>("api/v1/productcategories", input);
        }

        public Task<OperationResult> DeleteAsync(string category)
        {
            return _apiClient.DeleteAsync<OperationResult>("api/v1/productcategories/" + category);
        }

        public Task<OperationResult> DeleteAsync(string category, string subcategory)
        {
            return _apiClient.DeleteAsync<OperationResult>($"api/v1/productcategories/{category}/SubCategories/{subcategory}");
        }

        public Task<OperationResultEnumerable<ProductCategoryDto>> GetAllAsync()
        {
            return _apiClient.GetAsync<OperationResultEnumerable<ProductCategoryDto>>("api/v1/productcategories");
        }

        public Task<OperationResult<ProductCategoryDto>> GetAsync(string name)
        {
            return _apiClient.GetAsync<OperationResult<ProductCategoryDto>>("api/v1/productcategories/" + name);
        }

        public Task<OperationResultEnumerable<ProductSubCategoryDto>> GetSubCategoriesAsync(string categoryName)
        {
            return _apiClient.GetAsync<OperationResultEnumerable<ProductSubCategoryDto>>($"api/v1/productcategories/{categoryName}/Subcategories");
        }

        public Task<OperationResult<ProductCategoryDto>> UpdateAsync(UpdateProductCategoryInput input)
        {
            return _apiClient.PutAsync<UpdateProductCategoryInput, OperationResult<ProductCategoryDto>>("api/v1/productcategories", input);
        }

        public Task<OperationResult<ProductCategoryDto>> UpdateCategoryNameAsync(UpdateProductCategoryNameInput input)
        {
            return _apiClient.PutAsync<UpdateProductCategoryNameInput, OperationResult<ProductCategoryDto>>("api/v1/productcategories/UpdateCategoryName", input);
        }

        public Task<OperationResult<ProductCategoryDto>> UpdateSubCategoryNameAsync(UpdateProductSubCategoryNameInput input)
        {
            return _apiClient.PutAsync<UpdateProductSubCategoryNameInput, OperationResult<ProductCategoryDto>>("api/v1/productcategories/UpdateSubCategoryName", input);
        }
    }
}
