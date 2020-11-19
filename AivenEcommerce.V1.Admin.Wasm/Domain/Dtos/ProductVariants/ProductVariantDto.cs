using System;
using System.Collections.Generic;

namespace AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.ProductVariants
{
    public record ProductVariantDto(Guid Id, string ProductId, string Name, ICollection<string> Values);
}
