using System.Threading.Tasks;

using AivenEcommerce.V1.Admin.Wasm.Domain.Dtos.WishLists;
using AivenEcommerce.V1.Admin.Wasm.Domain.OperationResults;

namespace AivenEcommerce.V1.Admin.Wasm.Services.Interfaces
{
    public interface IWishListService
    {
        Task<OperationResult<WishListDto>> GetWishListAsync(string customerEmail);
        Task<OperationResult<WishListProductsDto>> GetWishListWithProductInfoAsync(string customerEmail);
        Task<OperationResult<WishListDto>> AddProductToWishListAsync(AddProductToWishListInput input);
        Task<OperationResult<WishListDto>> RemoveProductToWishListAsync(RemoveProductToWishListInput input);
        Task<OperationResult<WishListDto>> RemoveAllWishListAsync(RemoveAllWishListInput input);
        Task<OperationResult<WishListDto>> UpdateWishListAsync(UpdateWishListInput input);
    }
}
