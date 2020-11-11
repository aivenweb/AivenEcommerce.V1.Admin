using System;
using System.Threading.Tasks;

using AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.Products;
using AivenEcommerce.V1.Admin.Wasm.Domain.OperationResults;

namespace AivenEcommerce.V1.Admin.Wasm.Services.Interfaces
{
    public interface IProductService
    {
        Task<OperationResult<ProductDto>> GetAsync(string id);
        Task<OperationResultEnumerable<ProductDto>> GetAllAsync();
        Task<OperationResult<ProductDto>> UpdateCategory(string id, string category, string subcategory);
        Task<OperationResult<ProductDto>> CreateProduct(CreateProductInput input);
        Task<OperationResult<ProductDto>> UpdateMainImageAsync(string id, Uri image);
        Task<OperationResult<ProductDto>> UpdateCostPriceAsync(string id, decimal cost, decimal price);
        Task<OperationResult<ProductDto>> UpdateAvailabilityAsync(string id, bool isActive, int stock);
        Task<OperationResult<ProductDto>> UpdateNameDescriptionAsync(string id, string name, string descripción);

    }
}
