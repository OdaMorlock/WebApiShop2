using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopApi2.Data;
using WebShopApi2.Models.ProductServiceModels;
using WebShopApi2.Services;

namespace WebShopApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly SqlDbContext _context;
        private readonly IProductServices _product;

        public SearchController(SqlDbContext context, IProductServices product)
        {
            _context = context;
            _product = product;
        }

        [HttpPost("SearchProduct")]
        public async Task<IActionResult> SearchProduct ([FromBody] SearchProductModel searchProductModel)
        {
            var Result = ( _product.SearchProductForContent(searchProductModel));
            if (Result.Result)
            {
                var productList = Result.GetProducts();
                var amountOfItems = productList.Count();
                return new OkObjectResult($"{Result.Message} ::  AmountOfItems : {amountOfItems}");

            }

            return new BadRequestObjectResult(Result.Message);
        }




    }
}
