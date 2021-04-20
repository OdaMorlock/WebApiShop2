using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopApi2.Models.ProductServiceModels;

namespace WebShopApi2.Services
{
    public interface IProductServices
    {
        Task<ResultWithMessageModel> CreateBasicAsync(CreateBasicModel createBasicModel);
        Task<ResultWithMessageModel> CreateColorAsync(CreateColorModel createColorModel);
        Task<ResultWithMessageModel> CreateProductAsync(CreateProductModel createProductModel);

        Task<ResultWithMessageModel> UpdateBasicAsync(UpdateBasicModel updateBasicModel);
        Task<ResultWithMessageModel> UpdateColorAsync(UpdateColorModel updateColorModel);
        Task<ResultWithMessageModel> UpdatedProductAsync(UpdateProductModel updateProductModel);
        Task<ResultWithMessageModel> UpdateProductStockSaleAsync(UpdateProductStockSaleModel updateProductStockSaleModel);

        Task<ResultWithMessageModel> DeleteAsync(DeleteBasicModel deleteBasicModel);

        ResultWithMessagProductListModel SearchProductForContent(SearchProductModel searchProductModel);

        Task<IEnumerable<GetCategoriesModel>> GetCategoriesAsync();
    }
}
