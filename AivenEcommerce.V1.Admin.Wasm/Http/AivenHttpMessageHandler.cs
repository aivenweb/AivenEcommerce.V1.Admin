using AivenEcommerce.V1.Admin.Wasm.Extensions;
using AivenEcommerce.V1.Admin.Wasm.Services.ComponentServices;
using AivenEcommerce.V1.Domain.Shared.Dtos.Identity;
using AivenEcommerce.V1.Domain.Shared.OperationResults;
using AivenEcommerce.V1.Domain.Shared.OperationResults.Validations;

using Blazored.SessionStorage;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace AivenEcommerce.V1.Admin.Wasm.Http
{
    public class AivenHttpMessageHandler : DelegatingHandler
    {
        private readonly SpinnerComponentService _spinnerService;
        private readonly AlertComponentService _alertService;
        private readonly ISyncSessionStorageService _sessionStorage;

        public AivenHttpMessageHandler(SpinnerComponentService spinnerService, AlertComponentService alertService, ISyncSessionStorageService sessionStorage)
        {
            _spinnerService = spinnerService ?? throw new ArgumentNullException(nameof(spinnerService));
            _alertService = alertService ?? throw new ArgumentNullException(nameof(alertService));
            _sessionStorage = sessionStorage ?? throw new ArgumentNullException(nameof(sessionStorage));
            InnerHandler = new HttpClientHandler();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            _spinnerService.Show();

            var JwtUser = _sessionStorage.GetItem<JwtUserDto>("user-authenticated");

            if (JwtUser is not null and { AccessToken: not null })
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("bearer", JwtUser.AccessToken);
            }

            try
            {
                var response = await base.SendAsync(request, cancellationToken);
                return response;
            }
            catch (Exception ex)
            {
                _alertService.Show("Ocurrio un error inexperado.", "No se pudo realizar la operación. Vuelva a intentarlo más tarde.", "danger");


                var result = new HttpResponseMessage
                {
                    Content = new StringContent(OperationResult.Error(new() { Messages = new List<ValidationMessage>() { new ValidationMessage("fetch", ex.Message) } }).Serialize())
                };

                result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                return result;
            }
            finally
            {
                _spinnerService.Hide();
            }
        }
    }
}
