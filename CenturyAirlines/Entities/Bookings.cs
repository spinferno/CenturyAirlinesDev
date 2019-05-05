using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CenturyAirlines.Entities
{
    [Table("RACS_Bookings")]
    public class Bookings
    {
        [Key]
        public int BookingID { get; set; }
        public string BookingCode { get; set; }

        //[ForeignKey("FlightBookings")]
        //public virtual Flight BookedFlight { get; set; }
    }
}