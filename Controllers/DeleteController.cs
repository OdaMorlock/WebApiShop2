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
    public class DeleteController : ControllerBase
    {
        private readonly SqlDbContext _context;
        private readonly IProductServices _product;

        public DeleteController(SqlDbContext context, IProductServices product)
        {
            _context = context;
            _product = product;
        }



        [HttpDelete("DeleteBasic")]
        public async Task<IActionResult> DeleteBasicAsync([FromBody] DeleteBasicModel deleteBasicModel)
        {
            var Result = (await _product.DeleteAsync(deleteBasicModel));
            if (Result.Result)
            {
                return new OkObjectResult($"{Result.Message} ");
            }
            return new BadRequestObjectResult($"{Result.Message}");
        }
    }
}
