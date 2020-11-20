using System;

namespace AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.Customers
{
    public record UpdateCustomerInput(Guid Id, string Name, string LastName, string Email, Uri Picture);
}
