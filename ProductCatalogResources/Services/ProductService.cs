using Newtonsoft.Json;
using ProductCatalogResources.Interfaces;
using ProductCatalogResources.Models;
using System.Diagnostics;

namespace ProductCatalogResources.Services;

public class ProductService
{
    private static readonly string _filePath = Path.Combine(AppContext.BaseDirectory, "file.json");
    private readonly FileService _fileService = new FileService(_filePath);
    public List<Product> _products = [];



    public ServiceRespons CreateProduct(Product product)
    {
        try
        {

            if (string.IsNullOrEmpty(product.ProductName))
            {
                return new ServiceRespons { Succeeded = false, Message = "No product name was provided" };
            }

            if (string.IsNullOrEmpty(product.ProductPrice))
            {
                return new ServiceRespons { Succeeded = false, Message = "No product price was provided" };
            }

            if (_products.Any(x => x.ProductName == product.ProductName))
            {
                return new ServiceRespons { Succeeded = false, Message = "Product with the same name already exists" };
            }

            _products.Add(product);

            var json = JsonConvert.SerializeObject(_products);
            var result = _fileService.SaveToFile(json);
            _fileService.SaveToFile(json);

            if (result.Succeeded)
                return new ServiceRespons { Succeeded = true, Message = "Product was added" };

            return new ServiceRespons { SucceededWithErrors = true, Message = "Product was created successfully but product list was not saved" };
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return new ServiceRespons { Succeeded = false, Message = ex.Message };
        }
    }

    public IEnumerable<Product> GetAllProducts()
    {

        try
        {
            var content = _fileService.GetFromFile();
            if (!string.IsNullOrEmpty(content))
                _products = JsonConvert.DeserializeObject<List<Product>>(content)!;
        }
        catch { }
        return _products;

    }

    public Product GetProduct(string ProductId)
    {
        GetProductsFromFile();

        try
        {
            var product = _products.FirstOrDefault(c => c.ProductId == ProductId);
            return product ?? null!;
        }
        catch
        {
            return null!;
        }
    }

    private void GetProductsFromFile()
    {
        try
        {
            var content = _fileService.GetFromFile();

            if (!string.IsNullOrEmpty(content))
                _products = JsonConvert.DeserializeObject<List<Product>>(content)!;
        }
        catch { }
    }


    public ServiceRespons RemoveProduct(string ProductId)
    {
        GetProductsFromFile();

        try
        {
            var productToDelete = GetProduct(ProductId);

            _products.Remove(productToDelete);

            var json = JsonConvert.SerializeObject(_products);
            _fileService.SaveToFile(json);

            return new ServiceRespons { Succeeded = true, Message = "Product was removed" };
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return new ServiceRespons { Succeeded = false, Message = ex.Message };
        }
    }


}


