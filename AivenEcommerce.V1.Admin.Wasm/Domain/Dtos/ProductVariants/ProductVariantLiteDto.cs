using System.Collections.Generic;

namespace AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.ProductVariants
{
    public record ProductVariantLiteDto(string Name, ICollection<string> Values);

}
