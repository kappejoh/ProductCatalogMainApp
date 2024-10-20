using ProductCatalogResources.Models;
using ProductCatalogResources.Services;

namespace ProductCatalogResources.Tests;

public class ProductServiceTests
{
    [Fact]
    public void AddProductToList__Should_AddProductToListOfProducts__Return_ResponseResult_True()
    {
        // Arrange - förberedelser
        ProductService productService = new ProductService();
        Product product = new Product { ProductName = "Socker", ProductPrice = "25", ProductId = Guid.NewGuid().ToString()};

        // Act - utförandet
        ServiceRespons result = productService.CreateProduct(product);
        var productList = productService.GetAllProducts();

        // Assert - utvärdering av resulstatet
        Assert.NotNull(result);
        Assert.True(result.Succeeded);
        Assert.Single(productList);

    }
    [Fact]
    public void GetProductsFromList__ShouldGetAllProducts__Return_ResponseResultWithContent()
    {
        // Arrange - förberedelser
        ProductService productService = new ProductService();
        Product product = new Product { ProductName = "Socker", ProductPrice = "25", ProductId = Guid.NewGuid().ToString() };
        productService.CreateProduct(product);

        // Act - utförandet
        ServiceRespons result = (ServiceRespons)productService.GetAllProducts();

        // Assert - utvärdering av resulstatet
        Assert.NotNull(result);
        Assert.True(result.Succeeded);
        Assert.Single((List<Product>)result.Content!);

    }


}
