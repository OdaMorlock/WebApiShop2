using System;
using System.Collections.Generic;

#nullable disable

namespace WebShopApi2.Models
{
    public partial class ShoppingCart
    {
        public int Id { get; set; }
        public int ShoppingListId { get; set; }
        public bool ShippingFree { get; set; }
        public bool ShippingLocalPickup { get; set; }
        public int Total { get; set; }
        public bool? Coupon { get; set; }

        public virtual ProductShoppingCart ShoppingList { get; set; }
    }
}
