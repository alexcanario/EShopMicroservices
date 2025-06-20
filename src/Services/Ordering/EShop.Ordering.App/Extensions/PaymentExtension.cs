using EShop.Ordering.App.DataTransfers;

namespace EShop.Ordering.App.Extensions;

public static class PaymentExtension
{
    public static PaymentDto ToDto(this Payment payment)
    {
        return new PaymentDto(
            payment.CardName,
            payment.CardNumber,
            payment.Expiration,
            payment.Cvv,
            payment.PaymentMethod);
    }
}