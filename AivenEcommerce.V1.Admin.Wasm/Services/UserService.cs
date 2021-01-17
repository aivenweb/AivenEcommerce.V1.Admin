using AivenEcommerce.V1.Admin.Wasm.Services.Interfaces;
using AivenEcommerce.V1.Domain.Shared.Dtos.Users;
using AivenEcommerce.V1.Domain.Shared.OperationResults;

using System;
using System.Threading.Tasks;

namespace AivenEcommerce.V1.Admin.Wasm.Services
{
    public class UserService : IUserService
    {
        private readonly IApiClientService _apiClient;

        public UserService(IApiClientService apiClient)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
        }
        public Task<OperationResult<UserDto>> CreateAsync(CreateUserInput input)
        {
            return _apiClient.PostAsync<CreateUserInput, OperationResult<UserDto>>("api/v1/Users", input);
        }

        public Task<OperationResult> DeleteAsync(DeleteUserInput input)
        {
            return _apiClient.DeleteAsync<OperationResult>($"api/v1/Users/{input.Email}");
        }

        public Task<OperationResultEnumerable<UserDto>> GetAllAsync()
        {
            return _apiClient.GetAsync<OperationResultEnumerable<UserDto>>($"api/v1/Users");
        }

        public Task<OperationResult<UserDto>> GetAsync(string email)
        {
            return _apiClient.GetAsync<OperationResult<UserDto>>($"api/v1/Users/{email}");
        }

        public Task<OperationResult<UserDto>> UpdateAsync(UpdateUserInput input)
        {
            return _apiClient.PutAsync<UpdateUserInput, OperationResult<UserDto>>("api/v1/Users", input);
        }
    }
}
