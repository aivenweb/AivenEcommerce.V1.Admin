using System.Threading.Tasks;

using AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.ProductVariants;
using AivenEcommerce.V1.Admin.Wasm.Domain.OperationResults;

namespace AivenEcommerce.V1.Admin.Wasm.Services.Interfaces
{
    public interface IProductVariantService
    {
        Task<OperationResult<ProductVariantDto>> GetAsync(string productId, string name);
        Task<OperationResultEnumerable<ProductVariantDto>> GetAllAsync(string productId);
        Task<OperationResult<ProductVariantDto>> CreateAsync(CreateProductVariantInput input);
        Task<OperationResultEnumerable<ProductVariantDto>> UpdateAsync(UpdateProductVariantInput input);
        Task<OperationResult> DeleteAsync(DeleteProductVariantInput input);
    }
}
