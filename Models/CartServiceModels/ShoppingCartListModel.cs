using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApi2.Models.CartServiceModels
{
    public class ShoppingCartListModel
    {
        //public int Id { get; set; }
        public int ProductId { get; set; }
        //public int ProductPrice { get; set; }
        public int Quantity { get; set; }
        //public int SubTotal { get; set; }
    }
}
