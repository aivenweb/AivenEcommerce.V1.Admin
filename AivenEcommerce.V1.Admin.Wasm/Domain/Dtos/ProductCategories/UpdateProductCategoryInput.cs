using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.ProductCategories
{
    public record UpdateProductCategoryInput(string OldName, string NewName, IEnumerable<string> SubCategories);

}
