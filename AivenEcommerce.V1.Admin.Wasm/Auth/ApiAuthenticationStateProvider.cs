using AivenEcommerce.V1.Admin.Wasm.Services.Interfaces;
using AivenEcommerce.V1.Domain.Shared.Dtos.Identity;
using AivenEcommerce.V1.Domain.Shared.Dtos.Users;
using AivenEcommerce.V1.Domain.Shared.OperationResults;

using Blazored.SessionStorage;

using Microsoft.AspNetCore.Components.Authorization;

using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AivenEcommerce.V1.Admin.Wasm.Auth
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IIdentityService _apiClient;
        private readonly ISyncSessionStorageService _sessionStorage;

        public ApiAuthenticationStateProvider(IIdentityService apiClient, ISyncSessionStorageService sessionStorage)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
            _sessionStorage = sessionStorage ?? throw new ArgumentNullException(nameof(sessionStorage));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var result = await _apiClient.GetStateAsync();

            if (result.IsSuccess)
            {
                _sessionStorage.SetItem("user-authenticated", result.Result);

                JwtUserDto jwtUserDto = result.Result;

                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(jwtUserDto.User), "jwt")));
            }
            else
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
        }

        public void MarkUserAsAuthenticated(string email)
        {
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, email) }, "apiauth"));
            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
            NotifyAuthenticationStateChanged(authState);
        }

        public void MarkUserAsLoggedOut()
        {
            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(anonymousUser));
            NotifyAuthenticationStateChanged(authState);
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(UserDto user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Thumbprint, user.Picture.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            return claims;
        }
    }
}
