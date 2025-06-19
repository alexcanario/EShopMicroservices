namespace EShop.Ordering.App.DataTransfers;

public record PaymentDto(string CardName, string CardNumber, string ExpirationDate, string Cvv, int PaymentMethod);