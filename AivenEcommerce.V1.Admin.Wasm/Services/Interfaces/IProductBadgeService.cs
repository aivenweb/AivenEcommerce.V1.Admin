using System.Threading.Tasks;

using AivenEcommerce.V1.Domain.Shared.Dtos.ProductBadges;
using AivenEcommerce.V1.Domain.Shared.OperationResults;

namespace AivenEcommerce.V1.Admin.Wasm.Services.Interfaces
{
    public interface IProductBadgeService
    {
        Task<OperationResult<ProductBadgeDto>> GetByProductAsync(string productId);
    }
}
