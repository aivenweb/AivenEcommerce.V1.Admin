using System.Collections.Generic;

namespace AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.ProductVariants
{
    public record CreateProductVariantInput(string ProductId, string Name, IEnumerable<string> Values);
}
