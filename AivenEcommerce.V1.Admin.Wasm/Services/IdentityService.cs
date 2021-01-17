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
        private readonly IJSRuntime _jsRuntime;

        public IdentityService(IApiClientService apiClient, IJSRuntime jsRuntime)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
            _jsRuntime = jsRuntime ?? throw new ArgumentNullException(nameof(jsRuntime));
        }

        public Task<OperationResult<JwtUserDto>> Login(LoginInput input)
        {
            return _apiClient.PostAsync<LoginInput, OperationResult<JwtUserDto>>($"api/v1/identity/login", input);
        }

    }
}
