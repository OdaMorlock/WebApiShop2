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
            var Result = (await _product.CreateBasicAsync(createBasicModel));
            if (Result.Result)
            {
                return new OkObjectResult($"{Result.Message}.  {createBasicModel.Destination}Name:{createBasicModel.Name}");
            }
            return new BadRequestObjectResult($"{Result.Message}. {createBasicModel.Destination}Name:{createBasicModel.Name}    : Try   Brand,   Category,    Size(Max 8 Char),    Tag");
        }

        [HttpPost("AddColor")]
        public async Task<IActionResult> CreateColorAsync([FromBody] CreateColorModel createColorModel)
        {
            var Result = (await _product.CreateColorAsync(createColorModel));
            if (Result.Result)
            {
                return new OkObjectResult($"{Result.Message}. ColorName:{createColorModel.ColorName}. ColorHex:{createColorModel.ColorHex} ");
            }

            return new BadRequestObjectResult($"{Result.Message} . ColorName:{createColorModel.ColorName} . ColorHex:{createColorModel.ColorHex} .");
        }



        [HttpPut("UpdateBasic")]
        public async Task<IActionResult> UpdateBasicAsync([FromBody] UpdateBasicModel updateBasicModel)
        {
            var Result = (await _product.UpdateBasicAsync(updateBasicModel));
            if (Result.Result)
            {
                return new OkObjectResult($"{Result.Message}. OldName:{updateBasicModel.CurrentName}.  NewName:{updateBasicModel.NewName} ");
            }
            return new BadRequestObjectResult($"{Result.Message}: Try Brand,  Category,  Size or Tag as Destination");
        }

        [HttpPut("UpdateColor")]
        public async Task<IActionResult> UpdateColorAsync([FromBody] UpdateColorModel updateColorModel)
        {
            var Result = (await _product.UpdateColorAsync(updateColorModel));
            if (Result.Result)
            {
                return new OkObjectResult($"{Result.Message}.   OldColorName:{updateColorModel.CurrentColorName}.  NewColorName:{updateColorModel.NewColorName}.");
            }
            return new BadRequestObjectResult($"{Result.Message} Failed to Updated");
        }



    }



}
