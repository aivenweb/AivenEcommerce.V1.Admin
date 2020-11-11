using System.Collections.Generic;

using AivenEcommerce.V1.Admin.Wasm.Domain.Enums;

namespace AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.Products
{
    public record UpdateProductBadgeInput(string ProductId, short PercentageOff, IEnumerable<ProductBadgeName> Badges);
}
