using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApi2.Models.ServiceModels
{
    public class UpdateBasicModel
    {
        public string Destination { get; set; }
        public string CurrentName { get; set; }
        public string NewName { get; set; }

    }
}
