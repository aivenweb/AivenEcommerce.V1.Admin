using System;
using System.Collections.Generic;

using AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.Products;

namespace AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.Baskets
{
    public record BasketDto(Guid Id, IEnumerable<ProductDefinitive> ProductDefinitives, string CustomerEmail);
}
