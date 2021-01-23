using AivenEcommerce.V1.Admin.Wasm.Services.Interfaces;
using AivenEcommerce.V1.Domain.Shared.Dtos.Identity;
using AivenEcommerce.V1.Domain.Shared.OperationResults;

using Microsoft.JSInterop;

using System;
using System.Threading.Tasks;

namespace AivenEcommerce.V1.Admin.Wasm.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IApiClientService _apiClient;

        public IdentityService(IApiClientService apiClient)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
        }

        public Task<OperationResult<JwtUserDto>> GetStateAsync()
        {
            return _apiClient.GetAsync<OperationResult<JwtUserDto>>($"api/v1/Identity/GetState");
        }

        public Task<OperationResult<JwtUserDto>> LoginAsync(LoginInput input)
        {
            return _apiClient.PostAsync<LoginInput, OperationResult<JwtUserDto>>($"api/v1/identity/login", input);
        }

    }
}
