using AivenEcommerce.V1.Admin.Wasm.Services.Interfaces;
using AivenEcommerce.V1.Domain.Shared.Dtos.WishLists;
using AivenEcommerce.V1.Domain.Shared.OperationResults;

using System;
using System.Threading.Tasks;

namespace AivenEcommerce.V1.Admin.Wasm.Services
{
    public class WishListService : IWishListService
    {
        private readonly IApiClientService _apiClient;

        public WishListService(IApiClientService apiClient)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
        }

        public Task<OperationResult<WishListDto>> AddProductToWishListAsync(AddProductToWishListInput input)
        {
            return _apiClient.PostAsync<AddProductToWishListInput, OperationResult<WishListDto>>("api/v1/WishLists", input);
        }

        public Task<OperationResult<WishListDto>> GetWishListAsync(string customerEmail)
        {
            return _apiClient.GetAsync<OperationResult<WishListDto>>($"api/v1/WishLists/{customerEmail}");
        }

        public Task<OperationResult<WishListProductsDto>> GetWishListWithProductInfoAsync(string customerEmail)
        {
            return _apiClient.GetAsync<OperationResult<WishListProductsDto>>($"api/v1/WishLists/{customerEmail}/products");
        }

        public Task<OperationResult<WishListDto>> RemoveAllWishListAsync(RemoveAllWishListInput input)
        {
            return _apiClient.DeleteAsync<OperationResult<WishListDto>>($"api/v1/WishLists/{input.CustomerEmail}");
        }

        public Task<OperationResult<WishListDto>> RemoveProductToWishListAsync(RemoveProductToWishListInput input)
        {
            return _apiClient.DeleteAsync<OperationResult<WishListDto>>($"api/v1/WishLists/{input.CustomerEmail}/products/{input.ProductId}");
        }

        public Task<OperationResult<WishListDto>> UpdateWishListAsync(UpdateWishListInput input)
        {
            return _apiClient.PutAsync<UpdateWishListInput, OperationResult<WishListDto>>("api/v1/WishLists", input);
        }
    }
}
