using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopApi2.Data;

namespace WebShopApi2.Models.ProductServiceModels
{
    public class ResultWithMessagProductListModel
    {
        public ResultWithMessagProductListModel()
        {
        }





        public string Message { get; set; }
        public bool Result { get; set; }

        private List<Product> products;


        public List<Product> GetProducts()
        {
            return products;
        }

        public void SetProducts(List<Product> value)
        {
            products = value;
            
        }

                                        
    }
}
