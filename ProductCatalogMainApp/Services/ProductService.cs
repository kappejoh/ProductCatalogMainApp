using ProductCatalogMainApp.Models;
using ProductCatalogMainApp.Menus;
using System.Diagnostics;

namespace ProductCatalogMainApp.Services;

public class ProductService
{
    public List<Product> _products = [];

    public ServiceRespons CreateProduct(Product product)
    {
        try
        {
            if (string.IsNullOrEmpty(product.ProductName))
            {
                return new ServiceRespons { Succeded = false, Message = "No product name was provided" };
            }

            if (string.IsNullOrEmpty(product.ProductPrice))
            {
                return new ServiceRespons { Succeded = false, Message = "No product price was provided" };
            }

            if (_products.Any(x => x.ProductName == product.ProductName))
            {
                return new ServiceRespons { Succeded = false, Message = "Product with the same name already exists" };
            }

            _products.Add(product);
            return new ServiceRespons { Succeded = false, Message = "Product was added" };
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return new ServiceRespons { Succeded = false, Message = ex.Message };
        }
    }

    public IEnumerable<Product> GetAllProducts()
    {
        try
        {
            return _products;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }


    public Product GetProduct(string ProductName)
    {
        try
        {
            var user = _products.FirstOrDefault(x => x.ProductName == ProductName);
            if (user != null)
                return user;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }


    public ServiceRespons RemoveProduct(Product product)
    {
        try
        {
            _products.Remove(product);
            return new ServiceRespons { Succeded = false, Message = "Product was removed" };
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return new ServiceRespons { Succeded = false, Message = ex.Message };
        }
    }


}
