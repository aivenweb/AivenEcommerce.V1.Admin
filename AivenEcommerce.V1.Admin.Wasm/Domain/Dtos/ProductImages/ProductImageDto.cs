using System;

namespace AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.ProductImages
{
    public record ProductImageDto(Guid Id, string ProductId, Uri Image);
}
