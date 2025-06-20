namespace EShop.Ordering.App.DataTransfers;

public record AddressDto(string FirstName, string LastName, string EmailAddress, string AddressLine, string Country, string State, string ZipCode);