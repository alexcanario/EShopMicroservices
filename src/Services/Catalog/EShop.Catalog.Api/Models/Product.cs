namespace EShop.Catalog.Api.Models;

public sealed class Product
{
    public Guid Id { get; set; } = default;
    public string Name { get; set; } = default;
    public string Description { get; set; } = default;
    public string ImageFile { get; set; } = default;
    public decimal Price { get; set; }
    public IList<string> Category { get; set; } = [];
}