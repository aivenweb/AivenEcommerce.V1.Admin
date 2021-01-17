using AivenEcommerce.V1.Domain.Shared.Dtos.ProductImages;
using AivenEcommerce.V1.Domain.Shared.OperationResults;

using System;
using System.Threading.Tasks;

namespace AivenEcommerce.V1.Admin.Wasm.Services.Interfaces
{
    public interface IProductImageService
    {
        Task<OperationResultEnumerable<ProductImageDto>> GetAllAsync(string productId);
        Task<OperationResult> DeleteImageAsync(string productId, Guid productImageId);
    }
}
