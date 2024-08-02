namespace WebUI.Dtos.BookingDto
{
    public class CreateBookingDtoUI
    {

        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int numberOfCustomers { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
