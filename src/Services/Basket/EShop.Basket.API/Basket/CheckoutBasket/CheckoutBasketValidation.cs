namespace EShop.Basket.API.Basket.CheckoutBasket;

public class CheckoutBasketValidation : AbstractValidator<CheckoutBasketCommand>
{
	public CheckoutBasketValidation()
	{
		RuleFor(x => x.BasketCheckoutDto).NotNull().WithMessage("BasketCheckoutDto can not be null!");
		RuleFor(x => x.BasketCheckoutDto.UserName).NotEmpty().WithMessage("Username is required");

        // Validações de pagamento
        RuleFor(x => x.BasketCheckoutDto.CardName).NotEmpty().WithMessage("Card name is required");
        RuleFor(x => x.BasketCheckoutDto.CardNumber).NotEmpty().WithMessage("Card number is required");
        RuleFor(x => x.BasketCheckoutDto.CardExpiration).NotEmpty().WithMessage("Card expiration is required");
        RuleFor(x => x.BasketCheckoutDto.CardSecurityNumber).NotEmpty().Length(3).WithMessage("CVV must be 3 digits");
    }
}