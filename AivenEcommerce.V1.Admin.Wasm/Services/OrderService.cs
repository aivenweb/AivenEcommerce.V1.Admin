using AivenEcommerce.V1.Admin.Wasm.Services.Interfaces;
using AivenEcommerce.V1.Domain.Shared.Dtos.Orders;
using AivenEcommerce.V1.Domain.Shared.OperationResults;

using System;
using System.Threading.Tasks;

namespace AivenEcommerce.V1.Admin.Wasm.Services
{
    public class OrderService : IOrderService
    {
        private readonly IApiClientService _apiClient;

        public OrderService(IApiClientService apiClient)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
        }

        public Task<OperationResult<OrderDto>> GetAsync(string id)
        {
            return _apiClient.GetAsync<OperationResult<OrderDto>>($"api/v1/Orders/{id}");
        }

        public Task<OperationResult> UpdateTotalAmountAsync(UpdateOrderTotalAmountInput input)
        {
            return _apiClient.PutAsync<UpdateOrderTotalAmountInput, OperationResult>($"api/v1/Orders/UpdateTotalAmount", input);
        }
    }
}
