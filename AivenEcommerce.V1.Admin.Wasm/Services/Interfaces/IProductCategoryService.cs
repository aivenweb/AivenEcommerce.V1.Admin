using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.ProductCategories;
using AivenEcommerce.V1.Admin.Wasm.Domain.OperationResults;

namespace AivenEcommerce.V1.Admin.Wasm.Services.Interfaces
{
    public interface IProductCategoryService
    {
        Task<OperationResult<ProductCategoryDto>> GetAsync(string name);
        Task<OperationResultEnumerable<ProductCategoryDto>> GetAllAsync();
        Task<OperationResultEnumerable<ProductSubCategoryDto>> GetSubCategoriesAsync(string categoryName);
        Task<OperationResult<ProductCategoryDto>> CreateAsync(CreateProductCategoryInput input);
        Task<OperationResult<ProductCategoryDto>> UpdateAsync(UpdateProductCategoryInput input);
        Task<OperationResult> DeleteAsync(string category);
        Task<OperationResult> DeleteAsync(string category, string subcategory);
        Task<OperationResult<ProductCategoryDto>> UpdateCategoryNameAsync(UpdateProductCategoryNameInput input);
        Task<OperationResult<ProductCategoryDto>> UpdateSubCategoryNameAsync(UpdateProductSubCategoryNameInput input);
    }
}
