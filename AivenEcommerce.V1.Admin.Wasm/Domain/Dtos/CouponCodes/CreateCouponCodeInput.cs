using System;
using System.Collections.Generic;

using AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.ProductCategories;
using AivenEcommerce.V1.Admin.Wasm.Domain.Enums;

namespace AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.CouponCodes
{
    public record CreateCouponCodeInput(
        string Code,
        CouponCodeOffType Type,
        decimal Value,
        int MinAmount,
        int? MaxAmount,
        IEnumerable<string> Categories,
        IEnumerable<ProductCategoryPair> SubCategories,
        IEnumerable<string> Products,
        IEnumerable<string> Customers,
        DateTime? DateStart,
        DateTime? DateExpire
        );
}
