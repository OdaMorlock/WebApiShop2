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
        public async Task<IActionResult> CreateShoppingCartAsync(ShoppingCartListModel shoppingCartListModel)
        {
            var Result = (await _shopping.CreateShoppingCartAsync(shoppingCartListModel));
            if (Result.Result)
            {
                return new OkObjectResult($"{Result.Message}");
            }
            return new BadRequestObjectResult($"{Result.Message}");
        }

    }
}
