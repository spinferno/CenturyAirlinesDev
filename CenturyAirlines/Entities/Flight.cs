using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCSimpleApp.Entities
{
    [Table("RACS_Flights")]
    public class Flight
    {
        [Key]
        public int FlightID { get; set; }
        public string FlightCode { get; set; }
        [Required]
        public DateTime DepatureTime { get; set; }
        [Required]
        public DateTime ArrivalTime { get; set; }

        public Boolean IsFull { get; set; }

        //[ForeignKey("CityID")]
        //public virtual Cities DepartingFromFlights { get; set; }
        [ForeignKey("DepartingFromFlights")]
        public virtual ICollection<Cities> DepartingFromFlights { get; set; }
        
        public virtual ICollection<Cities> ArrivingToFlights { get; set; }
        //[ForeignKey("ArrivingToFlights")]
        //public virtual Cities ArrivingToFlights { get; set; }

        //[InverseProperty("BookedFlight")]
        //public virtual ICollection<Bookings> FlightBookings { get; set; }
    }
}