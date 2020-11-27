using System.Collections.Generic;

namespace AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.ProductCategories
{
    public record UpdateProductCategoryInput(string OldName, string NewName, IEnumerable<string> SubCategories);

}
