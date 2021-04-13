using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApi2.Models.ProductServiceModels
{
    public class SearchProductModel
    {
        public string Destination { get; set; }
        public string Target { get; set; }
        public string ColorHex { get; set; }
    }
}
