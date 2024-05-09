using Bookify.Domain.Apartments;
using Bookify.Domain.Shared;

namespace Bookify.Domain.Bookings;

public class PricingService
{
    public PricingDetails CalculatePrice(Apartment apartment, DateRange duration)
    {
        var currency = apartment.Price.Currency;
        var priceForDuration = new Money(apartment.Price.Amount * duration.LengthInDays, currency);
        
        decimal percentageUpCharge = 0;
        foreach(var amenity in apartment.Amenities)
        {
            percentageUpCharge += amenity switch
            {
                Amenity.GardenView or Amenity.MountainView => 0.05m,
                Amenity.AirConditioning or Amenity.Parking => 0.01m,
                _ => 0
            };
        }

        var amenitiesUpcharge = Money.Zero(currency);
        if(percentageUpCharge > 0)
        {
            amenitiesUpcharge = new Money(priceForDuration.Amount * percentageUpCharge, currency);
        }

        var totalPrice = Money.Zero();
        totalPrice += priceForDuration;

        if (!apartment.CleaningFee.IsZero())
        {
            totalPrice += apartment.CleaningFee;
        }

        totalPrice += amenitiesUpcharge;

        return new PricingDetails(
            priceForDuration, 
            apartment.CleaningFee, 
            amenitiesUpcharge, 
            totalPrice);
    }
  
}
