using System;
using System.Collections.Generic;

#nullable disable

namespace WebShopApi2.Models
{
    public partial class ShoppingCartList
    {
        public int Id { get; set; }
        public int CartNumberId { get; set; }
        public int ProductShoppingCartId { get; set; }

        public virtual CartNumber CartNumber { get; set; }
        public virtual ProductShoppingCart ProductShoppingCart { get; set; }
    }
}
