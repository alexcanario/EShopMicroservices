namespace EShop.Ordering.App.DataTransfers;

public record OrderItemDto(Guid OrderId, Guid ProductId, int Quantity, decimal Price);