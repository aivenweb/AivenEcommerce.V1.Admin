namespace AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.Products
{
    public record UpdateProductAvailabilityInput(string ProductId, int Stock, bool IsActive);

}
