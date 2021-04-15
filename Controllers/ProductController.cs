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
    public class ProductController : ControllerBase
    {
        private readonly SqlDbContext _context;
        private readonly IProductServices _product;

        public ProductController(SqlDbContext context, IProductServices product)
        {
            _context = context;
            _product = product;
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductModel createProductModel)
        {
            var Result = (await _product.CreateProductAsync(createProductModel));
            if (Result.Result)
            {
                return new OkObjectResult($"{Result.Message}");
            }
            return new BadRequestObjectResult($"{Result.Message}");
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdatedProductAsync([FromBody] UpdateProductModel updateProductModel)
        {
            var Result = (await _product.UpdatedProductAsync(updateProductModel));
            if (Result.Result)
            {
                return new OkObjectResult($"{Result.Message}");
            }
            return new BadRequestObjectResult($"{Result.Message}");
        }

        [HttpPut("UpdateProductStockSale")]
        public async Task<IActionResult> UpdatedProductStockSaleAsync([FromBody] UpdateProductStockSaleModel updateProductStockSaleModel)
        {
            var Result = (await _product.UpdateProductStockSaleAsync(updateProductStockSaleModel));
            if (Result.Result)
            {
                return new OkObjectResult($"{Result.Message}");
            }
            return new BadRequestObjectResult($"{Result.Message}");
        }
    }
}
