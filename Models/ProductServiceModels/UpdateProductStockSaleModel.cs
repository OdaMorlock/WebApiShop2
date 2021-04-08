using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApi2.Models.ProductServiceModels
{
    public class UpdateProductStockSaleModel
    {
        public string CurrentProductName { get; set; }
        public bool NewOnSale { get; set; }
        public bool NewInStock { get; set; }
    }
}
