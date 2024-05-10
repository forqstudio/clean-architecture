using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.Bookings.GetBooking;

sealed record GetBookingQuery(Guid BookingId) : IQuery<BookingResponse>;
