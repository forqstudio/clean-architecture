using Bookify.Domain.Shared;

namespace Bookify.Domain.Bookings
{
    public record PricingDetails(
        Money PriceForDuration,
        Money CleaningFee,
        Money AmenitiesUpCharge,
        Money TotalPrice);
}