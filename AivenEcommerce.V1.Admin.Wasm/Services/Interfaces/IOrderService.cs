using AivenEcommerce.V1.Domain.Shared.Dtos.Orders;
using AivenEcommerce.V1.Domain.Shared.OperationResults;
using AivenEcommerce.V1.Domain.Shared.Paginations;

using System.Threading.Tasks;

namespace AivenEcommerce.V1.Admin.Wasm.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OperationResult<OrderDto>> GetAsync(string id);
        Task<OperationResult> UpdateTotalAmountAsync(UpdateOrderTotalAmountInput input);
        Task<OperationResult<PagedResult<OrderDto>>> GetOrdersByCustomerAsync(string customerEmail);
    }
}
