using System;

namespace AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.Products
{
    public record UpdateProductMainImageInput(string ProductId, Uri Image);
}
