using AivenEcommerce.V1.Domain.Shared.Dtos.Sales;
using AivenEcommerce.V1.Domain.Shared.OperationResults;
using AivenEcommerce.V1.Domain.Shared.Paginations;

using System.Threading.Tasks;

namespace AivenEcommerce.V1.Admin.Wasm.Services.Interfaces
{
    public interface ISaleService
    {
        Task<OperationResult<PagedResult<SaleDto>>> GetAllAsync();
        Task<OperationResult<PagedResult<SaleDto>>> GetAllAsync(SaleParameters parameters);
        Task<OperationResult<SaleProductDto>> GetEarningsByProductAsync(string productId);
        Task<OperationResult<SaleDeliveryDto>> GetSaleDeliveryAsync(string orderId);
        Task<OperationResult> UpdateSaleDaliveryStatusAsync(UpdateSaleDaliveryStatusInput input);
        Task<OperationResultEnumerable<SaleOrderDto>> GetSaleByCouponAsync(string couponCode);

    }
}
