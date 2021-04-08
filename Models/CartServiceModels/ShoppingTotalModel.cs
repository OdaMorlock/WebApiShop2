using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApi2.Models.CartServiceModels
{
    public class ShoppingTotalModel
    {
        public int ShoppingCartId { get; set; }
        public bool ShippingFree { get; set; }
        public bool ShippingLocalPickup { get; set; }      
        public bool? Coupon { get; set; }
    }
}
