using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

using AivenEcommerce.V1.Domain.Shared.OperationResults;
using AivenEcommerce.V1.Admin.Wasm.Extensions;
using AivenEcommerce.V1.Admin.Wasm.Services.ComponentServices;

namespace AivenEcommerce.V1.Admin.Wasm.Http
{
    public class AivenHttpMessageHandler : DelegatingHandler
    {
        private readonly SpinnerComponentService _spinnerService;
        private readonly AlertComponentService _alertService;

        public AivenHttpMessageHandler(SpinnerComponentService spinnerService, AlertComponentService alertService)
        {
            _spinnerService = spinnerService ?? throw new ArgumentNullException(nameof(spinnerService));
            _alertService = alertService ?? throw new ArgumentNullException(nameof(alertService));
            InnerHandler = new HttpClientHandler();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            _spinnerService.Show();
            try
            {
                var response = await base.SendAsync(request, cancellationToken);
                return response;
            }
            catch (Exception)
            {
                _alertService.Show("Ocurrio un error inexperado.", "No se pudo realizar la operación. Vuelva a intentarlo más tarde.", "danger");

                var result = new HttpResponseMessage();
                result.Content = new StringContent(OperationResult.Error().Serialize());
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
