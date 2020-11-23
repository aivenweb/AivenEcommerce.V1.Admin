using System.Collections.Generic;

using AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.ProductVariants;

namespace AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.Products
{
    public record ProductDefinitive(string ProductId, IEnumerable<ProductVariantPair> Variants, int Quantity);
}
