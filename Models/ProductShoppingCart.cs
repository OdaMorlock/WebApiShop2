using System;
using System.Collections.Generic;

#nullable disable

namespace WebShopApi2.Models
{
    public partial class ProductShoppingCart
    {
        public ProductShoppingCart()
        {
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductPrice { get; set; }
        public int Quantity { get; set; }
        public int SubTotal { get; set; }

        public virtual Product Product { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
