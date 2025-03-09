namespace EShop.Ordering.Domain.ValueObjects;

public record Payment(string? CardName, string CardNumber, string Expiration, string CVV, string PaymentMethod);