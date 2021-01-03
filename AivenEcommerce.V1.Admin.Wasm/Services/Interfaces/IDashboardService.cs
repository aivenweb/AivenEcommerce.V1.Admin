using AivenEcommerce.V1.Domain.Shared.Dtos.Dashboards;
using AivenEcommerce.V1.Domain.Shared.OperationResults;

using System.Threading.Tasks;

namespace AivenEcommerce.V1.Admin.Wasm.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<OperationResult<DashboardDto>> GetDashboardAsync();
    }
}
