﻿using System.Threading.Tasks;

using AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.CouponCodes;
using AivenEcommerce.V1.Admin.Wasm.Domain.OperationResults;

namespace AivenEcommerce.V1.Admin.Wasm.Services.Interfaces
{
    public interface ICouponCodeService
    {
        Task<OperationResultEnumerable<CouponCodeDto>> GetCouponCodeAsync();
        Task<OperationResult<CouponCodeDto>> GetCouponCodeAsync(string code);
        Task<OperationResult<CouponCodeDto>> CreateCouponCodeAsync(CreateCouponCodeInput input);
        Task<OperationResult<CouponCodeDto>> UpdateCouponCodeAsync(UpdateCouponCodeInput input);
        Task<OperationResult> RemoveCouponCodeAsync(RemoveCouponCodeInput input);
    }
}
