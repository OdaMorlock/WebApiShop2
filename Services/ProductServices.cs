using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WebShopApi2.Data;
using WebShopApi2.Models;
using WebShopApi2.Models.ProductServiceModels;

namespace WebShopApi2.Services
{
    public class ProductServices : IProductServices
    {

        private readonly SqlDbContext _context;

        public ProductServices(SqlDbContext context)
        {
            _context = context;
        }

        public async Task<ResultWithMessageModel> CreateBasicAsync(CreateBasicModel createBasicModel)
        {
            var Result = new ResultWithMessageModel();


            try
            {
                string titleCase = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(createBasicModel.Destination);
                if (titleCase == "Brand" )
                {
                    if (! _context.Brands.Any(brand => brand.BrandName == createBasicModel.Name))
                    {
                        try
                        {
                            var brand = new Brand()
                            {
                                BrandName = createBasicModel.Name
                            };

                            _context.Brands.Add(brand);
                            await _context.SaveChangesAsync();
                            Result.Result = true;
                            Result.Message = $"Succeded in Creating Brand";
                            return Result;
                        }
                        catch 
                        {

                            
                        }
                    }
                }
                if (titleCase == "Category" )
                {
                    if (!_context.Categories.Any(categories => categories.CategoryName == createBasicModel.Name))
                    {
                        try
                        {
                            var categories = new Category()
                            {
                                CategoryName = createBasicModel.Name
                            };

                            _context.Categories.Add(categories);
                            await _context.SaveChangesAsync();
                            Result.Result = true;
                            Result.Message = $"Succeded in creating Category";
                            return Result;
                        }
                        catch
                        {


                        }
                    }
                }
                if (titleCase == "Size" )
                {
                    if (!_context.Sizes.Any(size => size.SizeName == createBasicModel.Name))
                    {
                        try
                        {
                            var size = new Size()
                            {
                                SizeName = createBasicModel.Name
                            };

                            _context.Sizes.Add(size);
                            await _context.SaveChangesAsync();
                            Result.Result = true;
                            Result.Message = $"Succeded in creating Size ";
                            return Result;
                        }
                        catch
                        {


                        }
                    }
                }
                if (titleCase == "Tag" )
                {
                    if (!_context.Tags.Any(tag => tag.TagName == createBasicModel.Name))
                    {
                        try
                        {
                            var tag = new Tag()
                            {
                                TagName = createBasicModel.Name
                            };

                            _context.Tags.Add(tag);
                            await _context.SaveChangesAsync();
                            Result.Result = true;
                            Result.Message = $"Succeded in creating Tag ";
                            return Result;
                        }
                        catch
                        {


                        }
                    }
                }

                Result.Result = false;
                Result.Message = $"Failed If ";
                return Result;
            }
            catch 
            {
                

            }

            Result.Result = false;
            Result.Message = $"Failed Try/Catch ";
            return Result;
        }

        public async Task<ResultWithMessageModel> CreateColorAsync(CreateColorModel createColorModel)
        {
            var Result = new ResultWithMessageModel();


            if (!_context.Colors.Any(color => color.ColorName == createColorModel.ColorName))
            {
                try
                {
                    var color = new Color()
                    {
                        ColorName = createColorModel.ColorName,
                        ColorHex = createColorModel.ColorHex
                    };

                    _context.Colors.Add(color);
                    await _context.SaveChangesAsync();
                    Result.Result = true;
                    Result.Message = $"Succeded in creating Color";
                    return Result;
                }
                catch
                {


                }
            }
            Result.Result = true;
            Result.Message = $"Failed in creating Color: if(Condition) = False";
            return Result;
        }

        public async Task<ResultWithMessageModel> CreateProductAsync(CreateProductModel createProductModel)
        {
            var Result = new ResultWithMessageModel();


            
            if (!_context.Products.Any(products => products.ProductName == createProductModel.ProductName))
            {
                try
                {

                    var product = new Product()
                    {             
                        ColorId = createProductModel.ColorId,
                        BrandId = createProductModel.BrandId,
                        CategoryId = createProductModel.CategoryId,
                        SizeId = createProductModel.SizeId,
                        Price = createProductModel.Price,
                        OnSale = createProductModel.OnSale,
                        InStock = createProductModel.InStock,
                        Image = createProductModel.Image,
                        ProductName = createProductModel.ProductName,
                        AddedDate = DateTime.Now,
                         
                        
                    };
                    _context.Products.Add(product);
                    await _context.SaveChangesAsync();
                    Result.Result = true;
                    Result.Message = $"Succeded in creating Product";
                    return Result;
                }
                catch 
                {

                    
                }
            }
            Result.Result = true;
            Result.Message = $"Failed in creating Product: if(Condition) = false ";
            return Result;
        }




        public async Task<ResultWithMessageModel> UpdateBasicAsync(UpdateBasicModel updateBasicModel)
        {
            var Result = new ResultWithMessageModel();


            string titleCase = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(updateBasicModel.Destination);
            if (titleCase == "Brand")
            {
                if (_context.Brands.Any(brands => brands.BrandName == updateBasicModel.CurrentName))
                {
                    try
                    {
                        var updatebrand = _context.Brands.FirstOrDefault(x => x.BrandName == updateBasicModel.CurrentName);

                        if (updatebrand != null)
                        {
                            updatebrand.BrandName = updateBasicModel.NewName;
                            await _context.SaveChangesAsync();
                        }
                        Result.Result = true;
                        Result.Message = $"Succeded in Updateing Brand";
                        return Result;
                    }
                    catch 
                    {

                        
                    }
                }
              
            }
            if (titleCase == "Category")
            {

                if (_context.Categories.Any(category => category.CategoryName == updateBasicModel.CurrentName))
                {
                    try
                    {
                        var updatecategory = _context.Categories.FirstOrDefault(x => x.CategoryName == updateBasicModel.CurrentName);

                        if (updatecategory != null)
                        {
                            updatecategory.CategoryName = updateBasicModel.NewName;
                            await _context.SaveChangesAsync();
                        }
                        Result.Result = true;
                        Result.Message = $"Succeded in Updating Category";
                        return Result;
                    }
                    catch
                    {


                    }
                }

            }
            if (titleCase == "Size")
            {
                if (_context.Sizes.Any( size => size.SizeName == updateBasicModel.CurrentName))
                {
                    try
                    {
                        var updatesize = _context.Sizes.FirstOrDefault(x => x.SizeName == updateBasicModel.CurrentName);

                        if (updatesize != null)
                        {
                            updatesize.SizeName = updateBasicModel.NewName;
                            await _context.SaveChangesAsync();
                        }
                        Result.Result = true;
                        Result.Message = $"Succeded in Updateing Size";
                        return Result;
                    }
                    catch
                    {


                    }
                }
            }
            if (titleCase == "Tag")
            {
                if (_context.Tags.Any(tag => tag.TagName == updateBasicModel.CurrentName))
                {
                    try
                    {
                        var updatetag = _context.Tags.FirstOrDefault(x => x.TagName == updateBasicModel.CurrentName);

                        if (updatetag != null)
                        {
                            updatetag.TagName = updateBasicModel.NewName;
                            await _context.SaveChangesAsync();
                        }
                        Result.Result = true;
                        Result.Message = $"Succeded in Updating Tag ";
                        return Result;
                    }
                    catch
                    {


                    }
                }
            }

            Result.Result = false;
            Result.Message = $"if(Condition) = false";
            return Result;
        }

        public async Task<ResultWithMessageModel> UpdateColorAsync(UpdateColorModel updateColorModel)
        {

            var Result = new ResultWithMessageModel();


            if (_context.Colors.Any(color => color.ColorName == updateColorModel.CurrentColorName))
            {
                try
                {

                    var updatecolor = _context.Colors.FirstOrDefault(x => x.ColorName == updateColorModel.CurrentColorName);

                    if (updatecolor != null)
                    {
                        if (updateColorModel.NewColorName!= null)
                        {
                            updatecolor.ColorName = updateColorModel.NewColorName;

                        }
                        if (updateColorModel.NewColorHex != null)
                        {
                            updatecolor.ColorHex = updateColorModel.NewColorHex;
                        }

                        await _context.SaveChangesAsync();
                        Result.Result = true;
                        Result.Message = $"Succeded in Updating Color ";
                        return Result;
                    }

                }
                catch 
                {

                }
            }

            Result.Result = false;
            Result.Message = $"Failed in UpdateingColor: if(condition) = false";
            return Result;
        }

        public async Task<ResultWithMessageModel> UpdatedProductAsync(UpdateProductModel updateProductModel)
        {
            var Result = new ResultWithMessageModel();


            var updateproduct = _context.Products.FirstOrDefault(x => x.ProductName == updateProductModel.CurrentProductName);
            if (updateproduct != null)
            {
                if (updateProductModel.NewBrandId != null)
                {
                    updateproduct.BrandId = updateProductModel.NewBrandId;
                }
                if (updateProductModel.NewCategoryId != null)
                {
                    updateproduct.CategoryId = updateProductModel.NewCategoryId;
                }
                if (updateProductModel.NewColorId != null)
                {
                    updateproduct.CategoryId = updateProductModel.NewColorId;
                }
                if (updateProductModel.NewSizeId != null)
                {
                    updateproduct.SizeId = updateProductModel.NewSizeId;
                }
                if (updateProductModel.NewPrice != 0)
                {
                    updateproduct.Price = updateProductModel.NewPrice;
                }
                if (updateProductModel.NewProductName != null)
                {
                    updateproduct.ProductName = updateProductModel.NewProductName;
                }
                await _context.SaveChangesAsync();

                Result.Result = true;
                Result.Message = $"Succeded in Updateing Product";
                return Result;

            }

            Result.Result = false;
            Result.Message = $"Failed in Updateing Product";
            return Result;
        }

        public async Task<ResultWithMessageModel> UpdateProductStockSaleAsync(UpdateProductStockSaleModel updateProductStockSaleModel)
        {

            var Result = new ResultWithMessageModel();


            var updatedProductStockSale = _context.Products.FirstOrDefault(x => x.ProductName == updateProductStockSaleModel.CurrentProductName);

            if (updatedProductStockSale != null)
            {
                updatedProductStockSale.InStock = updateProductStockSaleModel.NewInStock;
                updatedProductStockSale.OnSale = updateProductStockSaleModel.NewOnSale;

                await _context.SaveChangesAsync();
                Result.Result = true;
                Result.Message = $"Succeded in Updateing ProdcutStockSale";
                return Result;
            }

            Result.Result = false;
            Result.Message = $"Failed in Updateing ProdcutStockSale: if(Condition) = null";
            return Result;
        }




        public async Task<ResultWithMessageModel> DeleteAsync(DeleteBasicModel deleteBasicModel)
        {

            var result = new ResultWithMessageModel();

            if (deleteBasicModel.Destination == "Brand")
            {
                try
                {
                    _context.Brands.Remove(_context.Brands.FirstOrDefault(x => x.BrandName == deleteBasicModel.DeleteName));
                    await _context.SaveChangesAsync();
                    result.Message = $"{deleteBasicModel.DeleteName} Succesfully Deleted";
                    result.Result = true;
                    return result;
                }
                catch
                {


                }
                result.Message = $"Failed Try Catch in if(Brand) Cannot delete if connected too Product";
                result.Result = false;
                return result;

            }
            if (deleteBasicModel.Destination == "Category")
            {
                try
                {
                    _context.Categories.Remove(_context.Categories.FirstOrDefault(x => x.CategoryName == deleteBasicModel.DeleteName));
                    await _context.SaveChangesAsync();
                    result.Message = $"{deleteBasicModel.DeleteName} Succesfully Deleted";
                    result.Result = true;
                    return result;
                }
                catch
                {


                }
                result.Message = $"Failed Try Catch in if(Category) Cannot delete if connected too Product";
                result.Result = false;
                return result;
            }
            if (deleteBasicModel.Destination == "Size")
            {
                try
                {
                    _context.Sizes.Remove(_context.Sizes.FirstOrDefault(x => x.SizeName == deleteBasicModel.DeleteName));
                    await _context.SaveChangesAsync();
                    result.Message = $"{deleteBasicModel.DeleteName} Succesfully Deleted";
                    result.Result = true;
                    return result;
                }
                catch
                {

                }
                result.Message = $"Failed Try Catch in if(Size) Cannot delete if connected too Product";
                result.Result = false;
                return result;
            }
            if (deleteBasicModel.Destination == "Tag")
            {
                try
                {
                    _context.Tags.Remove(_context.Tags.FirstOrDefault(x => x.TagName == deleteBasicModel.DeleteName));
                    await _context.SaveChangesAsync();
                    result.Message = $"{deleteBasicModel.DeleteName} Succesfully Deleted";
                    result.Result = true;
                    return result;
                }
                catch
                {


                }
                result.Message = $"Failed Try Catch in if(Tag) Cannot delete if connected too Product";
                result.Result = false;
                return result;
            }
            if (deleteBasicModel.Destination == "Color")
            {
                try
                {
                    if (_context.Colors.Any(color => color.ColorName == deleteBasicModel.DeleteName))
                    {
                        _context.Colors.Remove(_context.Colors.FirstOrDefault(x => x.ColorName == deleteBasicModel.DeleteName));
                        await _context.SaveChangesAsync();
                        result.Message = $"{deleteBasicModel.DeleteName} Succesfully Deleted";
                        result.Result = true;
                        return result;

                    }
                }
                catch
                {


                }
                result.Message = $"Failed Try Catch in if(Color) Cannot delete if connected too Product";
                result.Result = false;
                return result;
            }
            if (deleteBasicModel.Destination == "Product")
            {
                try
                {
                    if (_context.Products.Any(x => x.ProductName == deleteBasicModel.DeleteName))
                    {
                        _context.Products.Remove(_context.Products.FirstOrDefault(x => x.ProductName == deleteBasicModel.DeleteName));
                        await _context.SaveChangesAsync();
                        result.Message = $"{deleteBasicModel.DeleteName} Succesfully Deleted";
                        result.Result = true;
                        return result;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                result.Message = $"Failed Try Catch in if(Product) ";
                result.Result = false;
                return result;
            }
            result.Message = $"{deleteBasicModel.Destination} Were not a vaild Destination try   Brand,  Category,  Size,  Tag,  Color,  Product";
            result.Result = false;
            return result;

        }

        public ResultWithMessagProductListModel SearchProductForContent(SearchProductModel searchProductModel)
        {
            var Result = new ResultWithMessagProductListModel();

            var produtList = _context.Products.ToList();

            
            
            
            try
            {

                string titleCase = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(searchProductModel.Destination);
                if (titleCase == "Brand")
                {
                    if (_context.Brands.Any(x => x.BrandName  == searchProductModel.Target))
                    {
                        var matched = _context.Brands.FirstOrDefault(x => x.BrandName == searchProductModel.Target);

                        var productList = _context.Products.ToList();

                        var listOfMatchedProducts = productList.FindAll(x => x.BrandId == matched.Id);

                        Result.SetProducts(listOfMatchedProducts);
                        Result.Result = true;
                        Result.Message = $"Succeded in finding  Destination:{searchProductModel.Destination} and getting list of Id for Brands Matching {searchProductModel.Target}  ID:{matched.Id}. ";
                        return Result;

                    }

                    Result.Result = false;
                    Result.Message = $"Failed if( name exist in DataBase on Brand).     Destination:{searchProductModel.Destination}.  Target:{searchProductModel.Target} ";
                    return Result;

                    
                }
                if (titleCase == "Category")
                {
                    if (_context.Categories.Any(x => x.CategoryName  == searchProductModel.Target))
                    {
                        var matched = _context.Categories.FirstOrDefault(x => x.CategoryName == searchProductModel.Target);

                        var productlist = _context.Products.ToList();

                        var listOfMatchedProducts = productlist.FindAll(x => x.CategoryId == matched.Id);



                        Result.SetProducts(listOfMatchedProducts);
                        Result.Result = true;
                        Result.Message = $"Succeded in finding  Destination:{searchProductModel.Destination} and getting list of Id for Category Matching {searchProductModel.Target}  ID:{matched.Id}. ";
                        return Result;

                    }

                    Result.Result = false;
                    Result.Message = $"Failed if( name exist in DataBase on Category).     Destination:{searchProductModel.Destination}.  Target:{searchProductModel.Target} ";
                    return Result;

                    
                }
                if (titleCase == "Color")
                {
                    if (_context.Colors.Any(x => x.ColorName == searchProductModel.Target))
                    {
                        var matched = _context.Colors.FirstOrDefault(x => x.ColorName == searchProductModel.Target);

                        var productlist = _context.Products.ToList();

                        var listOfMatchedProducts = productlist.FindAll(x => x.ColorId == matched.Id);

                        Result.SetProducts(listOfMatchedProducts);
                        Result.Result = true;
                        Result.Message = $"Succeded in finding  Destination:{searchProductModel.Destination} and getting list of Id for Color Matching {searchProductModel.Target}  ID:{matched.Id}. ";
                        return Result;
                    }


                    Result.Result = false;
                    Result.Message = $"Failed if( name exist in DataBase on Color).     Destination:{searchProductModel.Destination}.  Target:{searchProductModel.Target} ";
                    return Result;
                }
                if (titleCase == "Size")
                {

                    if (_context.Sizes.Any(x => x.SizeName == searchProductModel.Target))
                    {

                        var matched = _context.Sizes.FirstOrDefault(x => x.SizeName == searchProductModel.Target);

                        var productlist = _context.Products.ToList();

                        var listOfMatchedProducts = productlist.FindAll(x => x.SizeId == matched.Id);

                        Result.SetProducts(listOfMatchedProducts);
                        Result.Result = true;
                        Result.Message = $"Succeded in finding  Destination:{searchProductModel.Destination} and getting list of Id for Size Matching {searchProductModel.Target}  ID:{matched.Id}. ";
                        return Result;
                    }

                    Result.Result = false;
                    Result.Message = $"Failed if( name exist in DataBase on Size).     Destination:{searchProductModel.Destination}.  Target:{searchProductModel.Target} ";
                    return Result;

                }
               

                Result.Result = false;
                Result.Message = $"Failed all if().     Destination:{searchProductModel.Destination}: try Brand or Category Or Color Or Size First letter needs to be Capital";
                return Result;

            }
            catch (Exception)
            {

                
            }         
            Result.Result = false;
            Result.Message = $"Failed try/catch.     Destination:{searchProductModel.Destination}.   Target:{searchProductModel.Target}.  ColorHex:{searchProductModel.ColorHex} ";
            return Result;
        }
    }
}
