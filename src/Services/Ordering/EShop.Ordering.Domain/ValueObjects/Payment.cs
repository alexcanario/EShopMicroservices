using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Ordering.Domain.ValueObjects;

[ComplexType]
public record Payment
{
	private const int DefaultCvvLength = 3;

	public string CardName { get; } = string.Empty;
	public string CardNumber { get; } = string.Empty;
	public string Expiration { get; } = string.Empty;
	public string Cvv { get; } = string.Empty;
	public int PaymentMethod { get; }

	protected Payment() { }

	private Payment (string cardName, string cardNumber, string expiration, string cvv, int paymentMethod)
	{
		CardName = cardName;
		CardNumber = cardNumber;
		Expiration = expiration;
		Cvv = cvv;
		PaymentMethod = paymentMethod;
	}

	public static Payment Of(string cardName, string cardNumber, string expiration, string cvv, int paymentMethod)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(cardName, nameof(cardName));
		ArgumentException.ThrowIfNullOrWhiteSpace(cardNumber, nameof(cardNumber));
		ArgumentException.ThrowIfNullOrWhiteSpace(expiration, nameof(expiration));
		ArgumentException.ThrowIfNullOrWhiteSpace(cvv, nameof(cvv));
		ArgumentOutOfRangeException.ThrowIfNotEqual(cvv.Length, DefaultCvvLength, $"Cvv length must be {DefaultCvvLength} characters!");

		return new Payment(cardName, cardNumber, expiration, cvv, paymentMethod);
	}
}