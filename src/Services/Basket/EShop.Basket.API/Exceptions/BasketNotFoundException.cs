namespace EShop.Basket.API.Exceptions;

public class BasketNotFoundException(string userName) : NotFoundException(userName) { }