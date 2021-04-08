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

        Task<bool> UpdateBasicAsync(UpdateBasicModel updateBasicModel);
        Task<bool> UpdateColorAsync(UpdateColorModel updateColorModel);
        Task<bool> UpdatedProductAsync(UpdateProductModel updateProductModel);
        Task<bool> UpdateProductStockSaleAsync(UpdateProductStockSaleModel updateProductStockSaleModel);

        Task<ResultWithMessageModel> DeleteAsync(DeleteBasicModel deleteBasicModel);
    }
}
