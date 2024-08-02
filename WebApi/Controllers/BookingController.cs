using BusinessLayer.Abstract;
using DtoLayer.BookingDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList() 
        {
            var values = _bookingService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            Booking booking = new Booking()
            {
                BookingDate = createBookingDto.BookingDate,
                CustomerName = createBookingDto.CustomerName,
                Email = createBookingDto.Email,
                NumberOfCustomers = createBookingDto.numberOfCustomers,
                Phone = createBookingDto.Phone
            };

            _bookingService.TAdd(booking);

            return Ok("Rezervasyon ekleme başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var bookingToDel = _bookingService.TGetById(id);
            _bookingService.TDelete(bookingToDel);
            return Ok("Rezervasyon silme başarılı");
        }
        [HttpPut]
        public IActionResult UpdateBooking (UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking()
            {
                BookingId = updateBookingDto.BookingId,
                BookingDate = updateBookingDto.BookingDate,
                CustomerName = updateBookingDto.CustomerName,
                Email = updateBookingDto.Email,
                NumberOfCustomers = updateBookingDto.numberOfCustomers,
                Phone = updateBookingDto.Phone
            };

            _bookingService.TUpdate(booking);
            

            return Ok("Rezervasyon güncelleme başarılı");
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {

            return Ok(_bookingService.TGetById(id));
        }
        [HttpGet("ApproveBooking/{id}")]
        public IActionResult ApproveBooking(int id)
        {
            var bookingToApprove = _bookingService.TGetById(id);
            bookingToApprove.Status = BookingStatus.APPROVED;
            _bookingService.TUpdate(bookingToApprove);

            return Ok("Rezervasyon onaaylandı");
        }
        
        [HttpGet("CancelBooking/{id}")]
        public IActionResult CancelBooking(int id)
        {
            var bookingToApprove = _bookingService.TGetById(id);
            bookingToApprove.Status = BookingStatus.CANCELED;
            _bookingService.TUpdate(bookingToApprove);

            return Ok("Rezervasyon onaylandı");
        }
        
      


    }
}
