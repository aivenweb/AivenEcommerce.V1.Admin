using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.ProductOverViews;
using AivenEcommerce.V1.Admin.Wasm.Domain.OperationResults;

namespace AivenEcommerce.V1.Admin.Wasm.Services.Interfaces
{
    public interface IProductOverviewService
    {
        Task<OperationResult<ProductOverviewDto>> GetByProductAsync(string productId);
    }
}
