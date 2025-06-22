namespace EShop.Ordering.App.DataTransfers;

public record PaymentDto(string CardName, string CardNumber, string Expiration, string Cvv, int PaymentMethod);