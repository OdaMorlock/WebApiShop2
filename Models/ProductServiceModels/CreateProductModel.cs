using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApi2.Models.ProductServiceModels
{
    public class CreateProductModel
    {

        public int ColorId { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int SizeId { get; set; }
        public int Price { get; set; }
        public bool OnSale { get; set; }
        public bool InStock { get; set; }
        public string Image { get; set; }
        public string ProductName { get; set; }


    }
}
