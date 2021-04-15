using Microsoft.EntityFrameworkCore;
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


        public async Task<ResultWithMessage> CreateCartNumberAsync(string CartName)
        {
            var Result = new ResultWithMessage();

            if (CartName != null)
            {
                try
                {
                    if (!_context.CartNumbers.Any(x => x.Name == CartName))
                    {
                        var cartNumber = new CartNumber
                        {
                            Name = CartName
                        };
                        _context.CartNumbers.Add(cartNumber);
                        await _context.SaveChangesAsync();
                        Result.Message = $"Successfully Created CartNumber";
                        Result.Result = true;
                        return Result;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            if (CartName == null)
            {
                Result.Message = $"CartName=Null";
                Result.Result = true;
                return Result;
            }
            
            Result.Message = $"Failed Created CartNumber";
            Result.Result = false;
            return Result;
        }

        public async Task<ResultWithMessage> CreateShoppingCartAsync(ShoppingCartListModel shoppingCartListModel)
        {
            var Result = new ResultWithMessage();

            if (shoppingCartListModel.ProductId != 0)
            {
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
            }
            if (shoppingCartListModel.ProductId == 0)
            {
                Result.Message = $"ProductId = 0";
                Result.Result = false;
                return Result;
            }
                
                



                
            

            Result.Message = $"Failed On Creating ShoppingCart";
            Result.Result = false;
            return Result;
        }

        public async Task<ResultWithMessage> CreateShoppingTotalAsync(ShoppingTotalModel shoppingTotalModel)
        {
            var Result = new ResultWithMessage();

            try
            {
                int total = 0;

                var shoppingCartList = _context.ShoppingCartLists.ToList();

                var prodcutCartList = _context.ProductShoppingCarts.ToList();

                var cartContent = shoppingCartList.FindAll(x => x.CartNumberId == shoppingTotalModel.ShoppingCartId);

                foreach (var item in cartContent)
                {
                   total = item.ProductShoppingCart.SubTotal + total;
                }



                if (shoppingTotalModel.Coupon == true)
                {
                    double discount = total / 1.20;
                    total = Convert.ToInt32(discount);
                    
                }

                if (!shoppingTotalModel.ShippingFree)
                {
                    total = total + 20;

                    if (shoppingTotalModel.ShippingLocalPickup)
                    {
                        total = total + 25;
                    }
                }

                var cartTotal = new ShoppingCart
                    {
                        ShoppingCartId = shoppingTotalModel.ShoppingCartId,
                        ShippingFree = shoppingTotalModel.ShippingFree,
                        ShippingLocalPickup = shoppingTotalModel.ShippingLocalPickup,
                        Coupon = shoppingTotalModel.Coupon,
                        Total = total
                    };

                _context.ShoppingCarts.Add(cartTotal);
                await _context.SaveChangesAsync();
                Result.Message = $"Succeded On Creating ShoppingCartTotal ({total})";
                Result.Result = true;
                return Result;
            }
            catch (Exception)
            {

                
            }

            Result.Message = $"Failed On Creating ShoppingCartTotal";
            Result.Result = false;
            return Result;
        }


        public async Task<ResultWithMessage> AddItemToCartAsync(int ProductCartId, int CartNumberId)
        {
            var Result = new ResultWithMessage();

            if (ProductCartId != 0 && CartNumberId != 0)
            {
                try
                {
                    var shopingCartList = new ShoppingCartList
                    {
                        ProductShoppingCartId = ProductCartId,
                        CartNumberId = CartNumberId
                    };

                    await _context.ShoppingCartLists.AddAsync(shopingCartList);
                    await _context.SaveChangesAsync();

                    Result.Result = true;
                    Result.Message = $"Succeded in adding Product too Cart";
                    return Result;

                }
                catch (Exception)
                {


                }
            }
            if (ProductCartId == 0 && CartNumberId == 0)
            {
                Result.Result = false;
                Result.Message = $"ProductCartId = {ProductCartId}  &&  CartNumberId = {CartNumberId}";
                return Result;
            }
            if (ProductCartId == 0 | CartNumberId == 0)
            {
                Result.Result = false;
                Result.Message = $"ProductCartId = {ProductCartId}  |  CartNumberId = {CartNumberId}";
                return Result;
            }


            Result.Result = false;
            Result.Message = $"Failed in adding Product too Cart";
            return Result;
        }

        public async Task<ResultWithMessage> UpdateShopingCart(UpdateShopingCartListModel updateShopingCartListModel)
        {

            var Result = new ResultWithMessage();

            var productShoppingList = _context.ProductShoppingCarts.FirstOrDefault(x => x.Id == updateShopingCartListModel.IdOfList);

            if (productShoppingList != null)
            {
                if (updateShopingCartListModel.Quantity != 0)
                {
                    productShoppingList.Quantity = updateShopingCartListModel.Quantity;

                    await _context.SaveChangesAsync();

                    Result.Result = true;
                    Result.Message = $"{productShoppingList.Quantity} Changed too {updateShopingCartListModel.Quantity}";
                    return Result;
                }
                Result.Result = false;
                Result.Message = $"new Qunatity = {updateShopingCartListModel.Quantity} and cannot be 0 must be < 0";
                return Result;
            }
            Result.Result = false;
            Result.Message = $"{updateShopingCartListModel.IdOfList} do not match any Id in ProductShoppingCarts";
            return Result;
        }

    }
}
