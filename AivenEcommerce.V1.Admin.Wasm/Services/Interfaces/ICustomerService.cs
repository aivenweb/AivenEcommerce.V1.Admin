using AivenEcommerce.V1.Domain.Shared.Dtos.Customers;
using AivenEcommerce.V1.Domain.Shared.OperationResults;

using System.Threading.Tasks;

namespace AivenEcommerce.V1.Admin.Wasm.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<OperationResult<CustomerDto>> GetAsync(string email);
        Task<OperationResultEnumerable<CustomerDto>> GetAllAsync();
        Task<OperationResult<CustomerDto>> CreateAsync(CreateCustomerInput input);
        Task<OperationResult<CustomerDto>> UpdateAsync(UpdateCustomerInput input);
        Task<OperationResult> DeleteAsync(DeleteCustomerInput input);
    }
}
