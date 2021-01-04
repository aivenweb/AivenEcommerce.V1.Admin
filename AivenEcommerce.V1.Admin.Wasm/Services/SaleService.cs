using AivenEcommerce.V1.Admin.Wasm.Services.Interfaces;
using AivenEcommerce.V1.Domain.Shared.Dtos.Sales;
using AivenEcommerce.V1.Domain.Shared.OperationResults;
using AivenEcommerce.V1.Domain.Shared.Paginations;

using System;
using System.Threading.Tasks;

namespace AivenEcommerce.V1.Admin.Wasm.Services
{
    public class SaleService : ISaleService
    {
        private readonly IApiClientService _apiClient;

        public SaleService(IApiClientService apiClient)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
        }

        public Task<OperationResult<PagedResult<SaleDto>>> GetAllAsync(SaleParameters parameters)
        {
            return _apiClient.GetAsync<OperationResult<PagedResult<SaleDto>>>("api/v1/sales");
        }

        public Task<OperationResult<PagedResult<SaleDto>>> GetAllAsync()
        {
            return _apiClient.GetAsync<OperationResult<PagedResult<SaleDto>>>("api/v1/sales");
        }

        public Task<OperationResult<SaleProductDto>> GetEarningsByProductAsync(string productId)
        {
            return _apiClient.GetAsync<OperationResult<SaleProductDto>>($"api/v1/Sales/GetEarningsByProduct/{productId}");
        }

        public Task<OperationResult<SaleDeliveryDto>> GetSaleDeliveryAsync(string orderId)
        {
            return _apiClient.GetAsync<OperationResult<SaleDeliveryDto>>($"api/v1/Sales/GetSaleDelivery/{orderId}");
        }
    }
}
