﻿using Bookify.Application.Abstractions.Email;
using Bookify.Domain.Bookings;
using Bookify.Domain.Bookings.Events;
using Bookify.Domain.Users;
using MediatR;

namespace Bookify.Application.Bookings.ReserveBooking;

internal sealed record BookingReservedDomainHandler : INotificationHandler<BookingReservedDomainEvent>
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IUserRepository _userRepository;
    private readonly IEmailService _emailService;

    public BookingReservedDomainHandler(
        IBookingRepository bookingRepository,
        IUserRepository userRepository,
        IEmailService emailService)
    {
        _bookingRepository = bookingRepository;
        _userRepository = userRepository;
        _emailService = emailService;
    }

    public async Task Handle(BookingReservedDomainEvent notification, CancellationToken cancellationToken)
    {
        var booking = await _bookingRepository.GetByIdAsync(notification.BookingId, cancellationToken);
        if(booking is null)
            return;

        var user = await _userRepository.GetByIdAsync(booking.UserId, cancellationToken);
        if(user is null)
            return;

        await _emailService.SendEmailAsync(
            user.Email, 
            "Booking Reserved", 
            "Your booking has been reserved. You have 10 minutes to confirm your booking");


    }

}
