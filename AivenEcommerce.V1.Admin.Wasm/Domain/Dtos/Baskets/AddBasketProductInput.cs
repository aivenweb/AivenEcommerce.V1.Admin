using AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.Products;

namespace AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.Baskets
{
    public record AddBasketProductInput(ProductDefinitive Product, string CustomerEmail);
}
