namespace EShop.Ordering.App.Exceptions;

public class OrderNotFoundException(Guid id) : NotFoundException("Order", id);