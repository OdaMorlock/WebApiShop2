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
    public class BasicAndColorController : ControllerBase
    {
        private readonly SqlDbContext _context;
        private readonly IProductServices _product;

        public BasicAndColorController(SqlDbContext context, IProductServices product)
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
            return new BadRequestObjectResult($"{createBasicModel.Destination} Unable too Create Try   Brand,   Category,    Size(Max 8 Char),    Tag");
        }

        [HttpPost("AddColor")]
        public async Task<IActionResult> CreateColorAsync([FromBody] CreateColorModel createColorModel)
        {
            if (await _product.CreateColorAsync(createColorModel))
            {
                return new OkObjectResult($"{createColorModel.ColorName} Created Successfully");
            }

            return new BadRequestObjectResult($"{createColorModel.ColorName} Unable too Create {createColorModel.ColorHex}");
        }



        [HttpPut("UpdateBasic")]
        public async Task<IActionResult> UpdateBasicAsync([FromBody] UpdateBasicModel updateBasicModel)
        {
            if (await _product.UpdateBasicAsync(updateBasicModel))
            {
                return new OkObjectResult($"{updateBasicModel.Destination} Successfully Updated");
            }
            return new BadRequestObjectResult($"{updateBasicModel.Destination} Failed too updated, Try Brand,  Category,  Size or Tag as Destination");
        }

        [HttpPut("UpdateColor")]
        public async Task<IActionResult> UpdateColorAsync([FromBody] UpdateColorModel updateColorModel)
        {
            if (await _product.UpdateColorAsync(updateColorModel))
            {
                return new OkObjectResult($"{updateColorModel.CurrentColorName} Updated with name {updateColorModel.NewColorName}");
            }
            return new BadRequestObjectResult($"{updateColorModel.CurrentColorName} Failed to Updated");
        }



    }



}
