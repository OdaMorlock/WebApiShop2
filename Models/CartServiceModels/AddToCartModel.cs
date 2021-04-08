using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApi2.Models.CartServiceModels
{
    public class AddToCartModel
    {
        public int ProductCartId { get; set; }
        public int CartNumberId { get; set; }

    }
}
