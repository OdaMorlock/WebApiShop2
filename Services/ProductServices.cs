using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopApi2.Data;
using WebShopApi2.Models;
using WebShopApi2.Models.ServiceModels;

namespace WebShopApi2.Services
{
    public class ProductServices : IProductServices
    {

        private readonly SqlDbContext _context;

        public ProductServices(SqlDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateBasicAsync(CreateBasicModel createBasicModel)
        {

            try
            {

                if (createBasicModel.Destination == "Brand")
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
                            return true;
                        }
                        catch 
                        {

                            
                        }
                    }
                }
                if (createBasicModel.Destination == "Category")
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
                            return true;
                        }
                        catch
                        {


                        }
                    }
                }
                if (createBasicModel.Destination == "Size")
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
                            return true;
                        }
                        catch
                        {


                        }
                    }
                }
                if (createBasicModel.Destination == "Tag")
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
                            return true;
                        }
                        catch
                        {


                        }
                    }
                }
               
            }
            catch 
            {
                

            }
            return false;
        }

        public async Task<bool> CreateColorAsync(CreateColorModel createColorModel)
        {
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
                    return true;
                }
                catch
                {


                }
            }
            return false;
        }

        public async Task<bool> CreateProductAsync(CreateProductModel createProductModel)
        {
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
                    return true;
                }
                catch 
                {

                    
                }
            }
            return false;
        }



        public async Task<bool> UpdateBasicAsync(UpdateBasicModel updateBasicModel)
        {
            if (updateBasicModel.Destination == "Brand")
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
                        return true;
                    }
                    catch 
                    {

                        
                    }
                }
              
            }
            if (updateBasicModel.Destination == "Category")
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
                        return true;
                    }
                    catch
                    {


                    }
                }

            }
            if (updateBasicModel.Destination == "Size")
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
                        return true;
                    }
                    catch
                    {


                    }
                }
            }
            if (updateBasicModel.Destination == "Tag")
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
                        return true;
                    }
                    catch
                    {


                    }
                }
            }
            return false;
        }

        public async Task<bool> UpdateColorAsync(UpdateColorModel updateColorModel)
        {
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
                        return true;
                    }

                }
                catch 
                {

                }
            }
            return false;
        }

        public async Task<bool> UpdatedProductAsync(UpdateProductModel updateProductModel)
        {
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

                return true;

            }
            return false;
        }

        public async Task<bool> UpdateProductStockSaleAsync(UpdateProductStockSaleModel updateProductStockSaleModel)
        {
            var updatedProductStockSale = _context.Products.FirstOrDefault(x => x.ProductName == updateProductStockSaleModel.CurrentProductName);

            if (updatedProductStockSale != null)
            {
                updatedProductStockSale.InStock = updateProductStockSaleModel.NewInStock;
                updatedProductStockSale.OnSale = updateProductStockSaleModel.NewOnSale;

                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }




        public async Task<bool> DeleteBasicAsync(DeleteBasicModel deleteBasicModel)
        {
            if (deleteBasicModel.Destination == "Brand")
            {
                try
                {
                    _context.Brands.Remove(_context.Brands.FirstOrDefault(x => x.BrandName == deleteBasicModel.DeleteName));
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch 
                {

                    
                }
                
                
            }
            if (deleteBasicModel.Destination == "Category")
            {
                try
                {
                    _context.Categories.Remove(_context.Categories.FirstOrDefault(x => x.CategoryName == deleteBasicModel.DeleteName));
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch 
                {

                    
                }
            }
            if (deleteBasicModel.Destination == "Size")
            {
                try
                {
                    _context.Sizes.Remove(_context.Sizes.FirstOrDefault(x => x.SizeName == deleteBasicModel.DeleteName));
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch 
                {
                    
                }
            }
            if (deleteBasicModel.Destination == "Tag")
            {
                try
                {
                    _context.Tags.Remove(_context.Tags.FirstOrDefault(x => x.TagName == deleteBasicModel.DeleteName));
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch
                {


                }
            }
            if (deleteBasicModel.Destination == "Color")
            {
                try
                {
                    if (_context.Colors.Any(color => color.ColorName == deleteBasicModel.DeleteName))
                    {
                        _context.Colors.Remove(_context.Colors.FirstOrDefault(x => x.ColorName == deleteBasicModel.DeleteName));
                        await _context.SaveChangesAsync();
                        return true;

                    }
                }
                catch 
                {

                    
                }
            }
            return false;
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
                result.Message = $"Failed Try Catch in if(Brand)";
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
                result.Message = $"Failed Try Catch in if(Category)";
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
                result.Message = $"Failed Try Catch in if(Size)";
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
                result.Message = $"Failed Try Catch in if(Tag)";
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
                result.Message = $"Failed Try Catch in if(Color)";
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
                result.Message = $"Failed Try Catch in if(Product)";
                result.Result = false;
                return result;
            }
            result.Message = $"{deleteBasicModel.Destination} Were not a vaild Destination try   Brand,  Category,  Size,  Tag,  Color,  Product";
            result.Result = false;
            return result;

        }
    }
}
