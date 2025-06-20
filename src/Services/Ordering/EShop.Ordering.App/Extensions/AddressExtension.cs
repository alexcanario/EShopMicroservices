using EShop.Ordering.App.DataTransfers;

namespace EShop.Ordering.App.Extensions;

public static class AddressExtension
{
    public static AddressDto ToDto(this Address address)
    {
        return new AddressDto(
            address.FirstName,
            address.LastName,
            address.EmailAddress,
            address.AddressLine,
            address.Country,
            address.State,
            address.ZipCode);
    }
}