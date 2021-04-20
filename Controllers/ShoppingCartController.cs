using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopApi2.Data;
using WebShopApi2.Models;
using WebShopApi2.Models.CartServiceModels;
using WebShopApi2.Services;

namespace WebShopApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly SqlDbContext _context;
        private readonly IShoppingCartServices _shopping;

        public ShoppingCartController(SqlDbContext context, IShoppingCartServices shopping)
        {
            _context = context;
            _shopping = shopping;
        }

        [HttpPost("CreateShoppingCart")]
        public async Task<IActionResult> CreateShoppingCartAsync([FromBody]ShoppingCartListModel shoppingCartListModel)
        {
            
            var Result = (await _shopping.CreateShoppingCartAsync(shoppingCartListModel));
            var Result2 = (await _shopping.CreateCartNumberAsync(shoppingCartListModel.CartName));
            var Result3 = (await _shopping.AddItemToCartAsync(shoppingCartListModel.ProductCartId, shoppingCartListModel.CartNumberId));
            if (Result.Result && Result2.Result && Result3.Result )
            {
                return new OkObjectResult($"{Result.Message},  {Result2.Message},  {Result3.Message}");
            }
            return new BadRequestObjectResult($"{Result.Message},  {Result2.Message},  {Result3.Message}");
        }


        [HttpPost("CreateShoppingTotal")]
        public async Task<IActionResult> CreateShoppingTotal([FromBody] ShoppingTotalModel shoppingTotalModel)
        {
            var Result = (await _shopping.CreateShoppingTotalAsync(shoppingTotalModel));
            if (Result.Result)
            {
                return new OkObjectResult($"{Result.Message},");
            }
            return new BadRequestObjectResult($"{Result.Message},");
        }

        [HttpPut("UpdateShopingCart")]
        public async Task<IActionResult> UpdateShopingCartAsync([FromBody] UpdateShopingCartListModel updateShopingCartListModel)
        {
            var Result = (await _shopping.UpdateShopingCart(updateShopingCartListModel));
            if (Result.Result)
            {
                return new OkObjectResult($"{Result.Message}");
            }
            return new BadRequestObjectResult($"{Result.Message}");
        }
    }
}
