using System;
using System.Collections.Generic;

#nullable disable

namespace WebShopApi2.Models
{
    public partial class CartNumber
    {
        public CartNumber()
        {
            ShoppingCartLists = new HashSet<ShoppingCartList>();
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ShoppingCartList> ShoppingCartLists { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
