namespace EShop.Basket.API.Basket.StoreBasket;

public class StoreBasketValidation: AbstractValidator<StoreBasketCommand>
{
	public StoreBasketValidation()
	{
		RuleFor(x => x.Cart).NotNull().WithMessage("Cart can not be null!");
		RuleFor(x => x.Cart.Username).NotEmpty().WithMessage("Username is required");
		RuleFor(x => x.Cart.Items).Must(x => x.Count > 0).WithMessage("Cart should have at least one item");
	}
}