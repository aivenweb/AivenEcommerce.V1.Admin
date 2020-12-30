using AivenEcommerce.V1.Admin.Wasm.Services.Interfaces;
using AivenEcommerce.V1.Domain.Shared.Dtos.Dashboards;
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

        public Task<OperationResult<DashboardDto>> GetDashboardAsync()
        {
            return _apiClient.GetAsync<OperationResult<DashboardDto>>($"api/v1/Sales/Dashboard");
        }

        public Task<OperationResult<SaleProductDto>> GetEarningsByProductAsync(string productId)
        {
            return _apiClient.GetAsync<OperationResult<SaleProductDto>>($"api/v1/Sales/GetEarningsByProduct/{productId}");
        }
    }
}
