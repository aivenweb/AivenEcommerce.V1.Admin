using AivenEcommerce.V1.Admin.Wasm.Services.Interfaces;
using AivenEcommerce.V1.Domain.Shared.Dtos.Dashboards;
using AivenEcommerce.V1.Domain.Shared.OperationResults;

using System;
using System.Threading.Tasks;

namespace AivenEcommerce.V1.Admin.Wasm.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IApiClientService _apiClient;

        public DashboardService(IApiClientService apiClient)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
        }

        public Task<OperationResult<DashboardDto>> GetDashboardAsync()
        {
            return _apiClient.GetAsync<OperationResult<DashboardDto>>($"api/v1/Dashboard");
        }
    }
}
