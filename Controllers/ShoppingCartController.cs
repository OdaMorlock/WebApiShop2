using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopApi2.Data;
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


    }
}
