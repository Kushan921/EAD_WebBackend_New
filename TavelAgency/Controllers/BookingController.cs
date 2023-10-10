using Application.IServices;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace TavelAgency.Controllers
{
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _service;

        public BookingController(IBookingService service)
        {
            _service = service;
        }
        [Route("GetAlBookings")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bookings>>> GetAll()
        {
            var bookings = _service.Get();
            return Ok(bookings);
        }
        [Route("SaveBooking")]
        [HttpPost]
        public async Task<ActionResult> SaveBooking([FromBody] Bookings booking)
        {
           

            if (_service.IsBookingExists(booking.Date,booking.From,booking.To,booking.Train_Schedule,booking.User))
            {
                return Ok(new { message = "Booking Already Exists", code = 0 });
            }
            else 
            {
                _service.Create(booking);
                return Ok(new { message = "Successfully Saved Booking", code = 1 });
               
            }
         
        }

        [Route("UpdateBooking")]
        [HttpPut]
        public ActionResult UpdateBooking([FromQuery] string id, [FromBody] Bookings booking)
        {
            var existingbooking = _service.Get(id);

            if (existingbooking == null)
            {
                return Ok(new { message = "Booking Not Found", code = 0 });
            }

            _service.Update(id, booking);

            return Ok(new { message = "Successfully Updated Booking", code = 1, data = booking });
        }
        [Route("DeleteBooking")]
        [HttpDelete]
        public ActionResult DeleteBooking([FromQuery] string id)
        {
            var booking = _service.Get(id);

            if (booking == null)
            {
                return Ok(new { message = "Booking Not Found", code = 0 });
            }

            _service.Remove(booking.Id);

            return Ok(new { message = "Successfully Deleted Booking", code = 1, data = booking });
        }

        [Route("UserGetBooking")]
        [HttpGet]
        public ActionResult UserGetBooking([FromQuery] string id)
        {
            var bookings = _service.GetUserBookings(id);

            return Ok(bookings);
        }
    }
}
