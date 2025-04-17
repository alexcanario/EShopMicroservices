namespace EShop.Ordering.App.Dtos;

public record PaymentDto(string CardName, string CardNumber, string ExpirationDate, string Cvv, int PaymentMethod);