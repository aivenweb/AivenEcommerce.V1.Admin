using System.Threading.Tasks;

using AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.Customers;
using AivenEcommerce.V1.Admin.Wasm.Domain.OperationResults;

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
