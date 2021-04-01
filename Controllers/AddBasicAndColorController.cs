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
    public class AddBasicAndColorController : ControllerBase
    {
        private readonly SqlDbContext _context;
        private readonly IProductServices _product;

        public AddBasicAndColorController(SqlDbContext context, IProductServices product)
        {
            _context = context;
            _product = product;
        }

        [HttpPost("AddBasic")]
        public async Task<IActionResult> CreateBasicAsync([FromBody] CreateBasicModel createBasicModel)
        {
            if (await _product.CreateBasicAsync(createBasicModel))
            {
                return new OkObjectResult($"{createBasicModel.Destination} Created Successfully");
            }
            return new BadRequestObjectResult($"{createBasicModel.Destination} Unable too Create Try   Brand,   Category,    Size,    Tag");
        }

        [HttpPost("AddColor")]
        public async Task<IActionResult> CreateColorAsync ([FromBody] CreateColorModel createColorModel)
        {
            if (await _product.CreateColorAsync(createColorModel))
            {
                return new OkObjectResult($"{createColorModel.ColorName} Created Successfully");
            }

            return new BadRequestObjectResult($"{createColorModel.ColorName} Unable too Create {createColorModel.ColorHex}");
        }
    }
}
