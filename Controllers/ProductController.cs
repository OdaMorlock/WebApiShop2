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
            if (await _product.CreateProductAsync(createProductModel))
            {
                return new OkObjectResult($"{createProductModel.ProductName} Successfully Created");
            }
            return new BadRequestObjectResult($"{createProductModel.ProductName} Failed too be Created");
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdatedProductAsync([FromBody] UpdateProductModel updateProductModel)
        {
            if (await _product.UpdatedProductAsync(updateProductModel))
            {
                return new OkObjectResult($"{updateProductModel.CurrentProductName} Uppdated too {updateProductModel.NewProductName}");
            }
            return new BadRequestObjectResult($"Failed too Updated {updateProductModel.CurrentProductName}");
        }

        [HttpPut("UpdateProductStockSale")]
        public async Task<IActionResult> UpdatedProductStockSaleAsync([FromBody] UpdateProductStockSaleModel updateProductStockSaleModel)
        {
            if (await _product.UpdateProductStockSaleAsync(updateProductStockSaleModel))
            {
                return new OkObjectResult($"{updateProductStockSaleModel.CurrentProductName} Succesfully Updated");
            }
            return new BadRequestObjectResult($"Failed to Updated {updateProductStockSaleModel.CurrentProductName}");
        }
    }
}
