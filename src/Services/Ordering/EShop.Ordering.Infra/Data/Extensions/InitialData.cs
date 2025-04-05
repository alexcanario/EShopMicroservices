namespace EShop.Ordering.Infra.Data.Extensions;

public class InitialData
{
    public static IEnumerable<Customer> Customers =>
    new List<Customer>
    {
        Customer.Create(CustomerId.Of(Guid.NewGuid()), "Alex Canario", "alexcanario@gmail.com"),
        Customer.Create(CustomerId.Of(Guid.NewGuid()), "Fernanda Canario", "nandacanario@gmail.com"),
    };
}