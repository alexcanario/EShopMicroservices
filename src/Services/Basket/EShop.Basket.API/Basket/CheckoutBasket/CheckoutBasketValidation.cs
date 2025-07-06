namespace EShop.Basket.API.Basket.CheckoutBasket;

public class CheckoutBasketValidation : AbstractValidator<CheckoutBasketCommand>
{
	public CheckoutBasketValidation()
	{
		RuleFor(x => x.BasketCheckoutDto).NotNull().WithMessage("BasketCheckoutDto can not be null!");
		RuleFor(x => x.BasketCheckoutDto.UserName).NotEmpty().WithMessage("Username is required");
	}
}