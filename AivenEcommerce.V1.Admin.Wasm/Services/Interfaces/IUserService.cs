using AivenEcommerce.V1.Domain.Shared.Dtos.Users;
using AivenEcommerce.V1.Domain.Shared.OperationResults;

using System.Threading.Tasks;

namespace AivenEcommerce.V1.Admin.Wasm.Services.Interfaces
{
    public interface IUserService
    {
        Task<OperationResult<UserDto>> GetAsync(string email);
        Task<OperationResultEnumerable<UserDto>> GetAllAsync();
        Task<OperationResult<UserDto>> CreateAsync(CreateUserInput input);
        Task<OperationResult<UserDto>> UpdateAsync(UpdateUserInput input);
        Task<OperationResult> DeleteAsync(DeleteUserInput input);
    }
}
