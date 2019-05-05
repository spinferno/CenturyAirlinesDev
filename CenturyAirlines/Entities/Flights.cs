using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace CenturyAirlines.Entities
{
    [Table("RACS_Flights")]
    public class Flights
    {
        [Key]
        public int FlightID { get; set; }
        [Required]
        [StringLength(8)]
        public String FlightCode { get; set; }
        [Required]
        public DateTime DepartureTime { get; set; }
        [Required]
        public DateTime ArrivalTime { get; set; }

        public Boolean IsFull { get; set; }

        [Required]
        [Display(Name = "Departure City ID")]
        public int DepartureCityID { get; set; }

        [Required]
        [Display(Name = "Arrival City ID")]
        public int ArrivalCityID { get; set; }

        public virtual Cities DepartingFromCity { get; set; }
        public virtual Cities ArrivingToCity { get; set; }


    }
}