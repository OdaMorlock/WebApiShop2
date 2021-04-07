using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopApi2.Data;
using WebShopApi2.Models;
using WebShopApi2.Models.CartServiceModels;

namespace WebShopApi2.Services
{
    public class ShoppingCartServices : IShoppingCartServices
    {
        private readonly SqlDbContext _context;


        public ShoppingCartServices(SqlDbContext context)
        {
            _context = context;

        }

        public async Task<ResultWithMessage> CreateShoppingCartAsync(ShoppingCartListModel shoppingCartListModel)
        {
            var Result = new ResultWithMessage();


                try
                {
                    var product = _context.Products.FirstOrDefault(x => x.Id == shoppingCartListModel.ProductId);

                    var subTotal = product.Price * shoppingCartListModel.Quantity;

                    var cart = new ProductShoppingCart
                    {
                        ProductId = shoppingCartListModel.ProductId,
                        ProductPrice = product.Price,
                        Quantity = shoppingCartListModel.Quantity,
                        SubTotal = subTotal
                    };

                    _context.ProductShoppingCarts.Add(cart);
                    await _context.SaveChangesAsync();

                    Result.Message = $"Successfully Created ShoppingCart";
                    Result.Result = true;
                    return Result;

                }
                catch (Exception)
                {

                    
                }
                



                
            

            Result.Message = $"Failed On Creating ShoppingCart";
            Result.Result = false;
            return Result;
        }

        public Task<ResultWithMessage> CreateShoppingTotalAsync(ShoppingTotalModel shoppingTotalModel)
        {
            throw new NotImplementedException();
        }
    }
}
