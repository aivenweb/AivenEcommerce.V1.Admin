﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.Customers;
using AivenEcommerce.V1.Admin.Wasm.Domain.OperationResults;
using AivenEcommerce.V1.Admin.Wasm.Services.Interfaces;

namespace AivenEcommerce.V1.Admin.Wasm.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IApiClientService _apiClient;

        public CustomerService(IApiClientService apiClient)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
        }
        public Task<OperationResult<CustomerDto>> CreateAsync(CreateCustomerInput input)
        {
            return _apiClient.PostAsync<CreateCustomerInput, OperationResult<CustomerDto>>("api/v1/Customers", input);
        }

        public Task<OperationResult> DeleteAsync(DeleteCustomerInput input)
        {
            return _apiClient.DeleteAsync<OperationResult>($"api/v1/Customers/{input.Email}");
        }

        public Task<OperationResultEnumerable<CustomerDto>> GetAllAsync()
        {
            return _apiClient.GetAsync<OperationResultEnumerable<CustomerDto>>($"api/v1/Customers");
        }

        public Task<OperationResult<CustomerDto>> GetAsync(string email)
        {
            return _apiClient.GetAsync<OperationResult<CustomerDto>>($"api/v1/Customers/{email}");
        }

        public Task<OperationResult<CustomerDto>> UpdateAsync(UpdateCustomerInput input)
        {
            return _apiClient.PutAsync<UpdateCustomerInput, OperationResult<CustomerDto>>("api/v1/Customers", input);
        }
    }
}
