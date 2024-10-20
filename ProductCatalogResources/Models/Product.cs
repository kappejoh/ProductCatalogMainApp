namespace ProductCatalogResources.Models;

public class Product
{
    public string ProductId { get; set; } = Guid.NewGuid().ToString();
    public string ProductName { get; set; } = null!;
    public string? ProductPrice { get; set; }
}
