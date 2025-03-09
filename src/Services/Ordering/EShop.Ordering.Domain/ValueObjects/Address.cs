namespace EShop.Ordering.Domain.ValueObjects;

public record Address(
	string FirstName, 
	string LastName, 
	string? EmailAddress, 
	string AddressLine, 
	string City, 
	string State, 
	string Country, 
	string ZipCode);