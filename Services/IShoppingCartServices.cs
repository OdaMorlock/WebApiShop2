using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopApi2.Models.CartServiceModels;

namespace WebShopApi2.Services
{
    public interface IShoppingCartServices
    {
        Task<ResultWithMessage> CreateShoppingCartAsync(ShoppingCartListModel shoppingCartListModel);

        Task<ResultWithMessage> CreateShoppingTotalAsync(ShoppingTotalModel  shoppingTotalModel);

        Task<ResultWithMessage> CreateCartNumberAsync(string CartName);

        Task<ResultWithMessage> AddItemToCartAsync(int ProductCartId, int CartNumberId);
    }
}
