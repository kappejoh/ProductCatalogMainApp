namespace ProductCatalogResources.Models;

public class ServiceRespons
{
    public bool Succeeded { get; set; }
    public bool SucceededWithErrors { get; set; }
    public string? Message { get; set; }
    public object? Content { get; set; }
}
