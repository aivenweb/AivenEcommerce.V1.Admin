using AivenEcommerce.V1.Domain.Shared.Dtos.Identity;
using AivenEcommerce.V1.Domain.Shared.OperationResults;

using System.Threading.Tasks;

namespace AivenEcommerce.V1.Admin.Wasm.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<OperationResult<JwtUserDto>> LoginAsync(LoginInput input);
        Task<OperationResult<JwtUserDto>> GetStateAsync();
    }
}
