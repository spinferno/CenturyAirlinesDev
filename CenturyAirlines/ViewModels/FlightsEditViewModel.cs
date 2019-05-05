using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CenturyAirlines.ViewModels
{
    public class FlightsEditViewModel
    {
        [Display(Name = "Flight Id")]
        public string FlightID { get; set; }

        [Required]
        [Display(Name = "Flight Code")]
        [StringLength(8)]
        public string FlightCode { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }
        [Required]
        public DateTime ArrivalTime { get; set; }

        public Boolean IsFull { get; set; }
        
        [Required]
        [Display(Name = "Departure City")]
        public int DepartureCityID { get; set; }

        [Required]
        [Display(Name = "Arrival City")]
        public int ArrivalCityID { get; set; }

        public IEnumerable<SelectListItem> Cities { get; set; }


    }
}