namespace EShop.Ordering.Domain.ValueObjects;

public record Payment
{
	private const int DefaultCVVLength = 3;

	public string CardName { get; } = string.Empty;
	public string CardNumber { get; } = string.Empty;
	public string Expiration { get; } = string.Empty;
	public string CVV { get; } = string.Empty;
	public string PaymentMethod { get; } = string.Empty;

	protected Payment() { }

	private Payment (string cardName, string cardNumber, string expiration, string cvv, string paymentMethod)
	{
		CardName = cardName;
		CardNumber = cardNumber;
		Expiration = expiration;
		CVV = cvv;
		PaymentMethod = paymentMethod;
	}

	public static Payment Of(string cardName, string cardNumber, string expiration, string cvv, string paymentMethod)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(cardName, nameof(cardName));
		ArgumentException.ThrowIfNullOrWhiteSpace(cardNumber, nameof(cardNumber));
		ArgumentException.ThrowIfNullOrWhiteSpace(expiration, nameof(expiration));
		ArgumentException.ThrowIfNullOrWhiteSpace(cvv, nameof(cvv));
		ArgumentOutOfRangeException.ThrowIfNotEqual(cvv.Length, DefaultCVVLength, $"CVV length must be {DefaultCVVLength} characters!");
		ArgumentException.ThrowIfNullOrWhiteSpace(paymentMethod, nameof(paymentMethod));

		return new Payment(cardName, cardNumber, expiration, cvv, paymentMethod);
	}
}