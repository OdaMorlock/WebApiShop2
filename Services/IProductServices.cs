using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopApi2.Models.ServiceModels;

namespace WebShopApi2.Services
{
    public interface IProductServices
    {
        Task<bool> CreateBasicAsync(CreateBasicModel createBasicModel);
        Task<bool> CreateColorAsync(CreateColorModel createColorModel);
        Task<bool> CreateProductAsync(CreateProductModel createProductModel);
    }
}
