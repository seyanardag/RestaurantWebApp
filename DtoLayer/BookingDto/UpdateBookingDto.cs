using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.BookingDto
{
    public class UpdateBookingDto
    {
        public int BookingId { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int numberOfCustomers { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
