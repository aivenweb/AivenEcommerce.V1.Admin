using AivenEcommerce.V1.Domain.Shared.Dtos.Products;
using AivenEcommerce.V1.Domain.Shared.OperationResults;
using AivenEcommerce.V1.Domain.Shared.Paginations;

using System.Threading.Tasks;

namespace AivenEcommerce.V1.Admin.Wasm.Services.Interfaces
{
    public interface IProductService
    {
        Task<OperationResult<ProductDto>> GetAsync(string id);
        Task<OperationResultEnumerable<ProductDto>> GetByCategoryAsync(string category);
        Task<OperationResultEnumerable<ProductDto>> GetByCategoryAsync(string category, string subcategory);
        Task<OperationResult> DeleteAsync(string id);
        Task<OperationResult<PagedResult<ProductDto>>> GetAllAsync();
        Task<OperationResult<ProductDto>> UpdateCategory(UpdateProductCategorySubCategoryInput input);
        Task<OperationResult<ProductDto>> CreateProduct(CreateProductInput input);
        Task<OperationResult<ProductDto>> UpdateMainImageAsync(UpdateProductMainImageInput input);
        Task<OperationResult<ProductDto>> UpdateCostPriceAsync(UpdateProductCostPriceInput input);
        Task<OperationResult<ProductDto>> UpdateAvailabilityAsync(UpdateProductAvailabilityInput input);
        Task<OperationResult<ProductDto>> UpdateNameDescriptionAsync(UpdateProductNameDescriptionInput input);
        Task<OperationResult<ProductDto>> UpdateBadgeAsync(UpdateProductBadgeInput input);

    }
}
