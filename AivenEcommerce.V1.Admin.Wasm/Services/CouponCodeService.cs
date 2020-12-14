using System;
using System.Threading.Tasks;

using AivenEcommerce.V1.Domain.Shared.Dtos.CouponCodes;
using AivenEcommerce.V1.Domain.Shared.OperationResults;
using AivenEcommerce.V1.Admin.Wasm.Services.Interfaces;

namespace AivenEcommerce.V1.Admin.Wasm.Services
{
    public class CouponCodeService : ICouponCodeService
    {
        private readonly IApiClientService _apiClient;

        public CouponCodeService(IApiClientService apiClient)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
        }

        public Task<OperationResult<CouponCodeDto>> CreateCouponCodeAsync(CreateCouponCodeInput input)
        {
            return _apiClient.PostAsync<CreateCouponCodeInput, OperationResult<CouponCodeDto>>("api/v1/CouponCodes", input);
        }

        public Task<OperationResultEnumerable<CouponCodeDto>> GetCouponCodeAsync()
        {
            return _apiClient.GetAsync<OperationResultEnumerable<CouponCodeDto>>($"api/v1/CouponCodes");
        }

        public Task<OperationResult<CouponCodeDto>> GetCouponCodeAsync(string code)
        {
            return _apiClient.GetAsync<OperationResult<CouponCodeDto>>($"api/v1/CouponCodes/{code}");
        }

        public Task<OperationResult> RemoveCouponCodeAsync(RemoveCouponCodeInput input)
        {
            return _apiClient.DeleteAsync<OperationResult>($"api/v1/CouponCodes/{input.Code}");
        }

        public Task<OperationResult<CouponCodeDto>> UpdateCouponCodeAsync(UpdateCouponCodeInput input)
        {
            return _apiClient.PutAsync<UpdateCouponCodeInput, OperationResult<CouponCodeDto>>("api/v1/CouponCodes", input);
        }
    }
}
