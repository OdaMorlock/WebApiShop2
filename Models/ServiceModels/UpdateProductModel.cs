using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApi2.Models.ServiceModels
{
    public class UpdateProductModel
    {
        public int? NewColorId { get; set; }
        public int? NewBrandId { get; set; }
        public int? NewCategoryId { get; set; }
        public int? NewSizeId { get; set; }
        public int NewPrice { get; set; }
        public string NewImage { get; set; }

        public string CurrentProductName { get; set; }
        public string NewProductName { get; set; }
    }
}
