using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApi2.Models.ServiceModels
{
    public class UpdateColorModel
    {
        public string CurrentColorName { get; set; }
        public string NewColorName { get; set; }
        public string NewColorHex { get; set; }
    }
}
