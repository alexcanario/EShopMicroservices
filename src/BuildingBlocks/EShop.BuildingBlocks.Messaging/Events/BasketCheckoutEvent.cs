namespace EShop.BuildingBlocks.Messaging.Events;

public record BasketCheckoutEvent : IntegrationEvent
{
	public string UserName { get; set; } = string.Empty;
	public Guid CustomerId { get; set; }
	public decimal TotalPrice { get; set; } = default;

	public string FirstName { get; set; } = string.Empty;
	public string LastName { get; set; } = string.Empty;
	public string EmailAddress { get; set; } = string.Empty;
	public string AddressLine { get; set; } = string.Empty;
	public string Country { get; set; } = string.Empty;
	public string State { get; set; } = string.Empty;
	public string ZipCode { get; set; } = string.Empty;

	public string CardName { get; set; } = string.Empty;
	public string CardNumber { get; set; } = string.Empty;
	public string CardExpiration { get; set; } = string.Empty;
	public string CardSecurityNumber { get; set; } = string.Empty;
	public int PaymentMethod { get; set; } = default;
}