﻿namespace AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.ProductCategories
{
    public record UpdateProductSubCategoryNameInput(string CategoryName, string OldSubCategoryName, string NewSubCategoryName);
}