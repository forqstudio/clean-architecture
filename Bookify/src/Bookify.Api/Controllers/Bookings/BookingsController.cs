using Bookify.Application.Bookings.GetBooking;
using Bookify.Application.Bookings.ReserveBooking;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Bookify.Api.Controllers.Bookings
{
    [ApiController]
    [Route("api/v1/bookings")]
    public class BookingsController : ControllerBase
    {
        private readonly ISender _sender;

        public BookingsController(ISender sender)
        {
            _sender = sender;                
        }

        [HttpGet]
        public async Task<IActionResult> GetBookingsAsync(
            Guid id,
            CancellationToken cancellationToken)
        {
            var result  = await _sender.Send(new GetBookingQuery(id), cancellationToken);
            return result.IsSuccess ? Ok(result.Value) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ReserveBooking(
            ReserveBookingRequest request,
            CancellationToken cancellationToken)
        {
            var command = new ReserveBookingCommand(
                request.UserId,
                request.ApartmentId,
                request.StartDate,
                request.EndDate);

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, result.Error);
            }

            return CreatedAtAction(nameof(GetBookingsAsync), new { id = result.Value }, result.Value);
        }
    }
}
