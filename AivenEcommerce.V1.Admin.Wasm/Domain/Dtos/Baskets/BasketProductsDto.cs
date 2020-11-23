using System;
using System.Collections.Generic;

using AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.Products;

namespace AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.Baskets
{
    public record BasketProductsDto(Guid Id, IEnumerable<ProductDefinitive> ProductDefinitives, IEnumerable<ProductDto> Products, string CustomerEmail);
}
