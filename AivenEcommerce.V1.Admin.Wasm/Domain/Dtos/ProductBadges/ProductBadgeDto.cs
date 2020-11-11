using System;
using System.Collections.Generic;

using AivenEcommerce.V1.Admin.Wasm.Domain.Enums;

namespace AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.ProductBadges
{
    public record ProductBadgeDto(Guid Id, string ProductId, IEnumerable<ProductBadgeName> Badges);
}
