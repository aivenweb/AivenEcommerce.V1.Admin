﻿using System;
using System.Threading.Tasks;

using AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.ProductOverViews;
using AivenEcommerce.V1.Admin.Wasm.Domain.OperationResults;
using AivenEcommerce.V1.Admin.Wasm.Services.Interfaces;

namespace AivenEcommerce.V1.Admin.Wasm.Services
{
    public class ProductOverviewService : IProductOverviewService
    {
        private readonly IApiClientService _apiClient;

        public ProductOverviewService(IApiClientService apiClient)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
        }

        public Task<OperationResult<ProductOverviewDto>> GetByProductAsync(string productId)
        {
            return _apiClient.GetAsync<OperationResult<ProductOverviewDto>>($"api/v1/ProductOverviews/product/{productId}");
        }
    }
}