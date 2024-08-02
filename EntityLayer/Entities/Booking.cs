using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int  NumberOfCustomers { get; set; }
        public BookingStatus Status { get; set; }
        public DateTime BookingDate { get; set; }
    }

    public enum BookingStatus {
        PENDING,
        CANCELED,
        APPROVED
        
    }
}

