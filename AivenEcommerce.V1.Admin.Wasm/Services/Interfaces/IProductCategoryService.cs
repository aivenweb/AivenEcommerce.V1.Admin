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
        Task<OperationResult<ProductCategoryDto>> CreateAsync(string name, IEnumerable<string> subcategories);
        Task<OperationResult<ProductCategoryDto>> UpdateAsync(Guid id, string name, IEnumerable<string> subcategories);
        Task<OperationResult> DeleteAsync(string name);
    }
}
