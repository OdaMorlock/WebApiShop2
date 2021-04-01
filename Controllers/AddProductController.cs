using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopApi2.Data;
using WebShopApi2.Models.ServiceModels;
using WebShopApi2.Services;

namespace WebShopApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddProductController : ControllerBase
    {
        private readonly SqlDbContext _context;
        private readonly IProductServices _product;

        public AddProductController(SqlDbContext context, IProductServices product)
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
    }
}
