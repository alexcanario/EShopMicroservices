namespace EShop.Basket.API.Basket.CheckoutBasket;

public sealed record CheckoutBasketCommand(BasketCheckoutDto BasketCheckoutDto) : ICommand<CheckoutBasketResult>;