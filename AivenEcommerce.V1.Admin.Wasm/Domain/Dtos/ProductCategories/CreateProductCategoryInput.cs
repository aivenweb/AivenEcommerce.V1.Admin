using System.Collections.Generic;

namespace AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.ProductCategories
{
    public record CreateProductCategoryInput(string Name, IEnumerable<string> SubCategories);
}
