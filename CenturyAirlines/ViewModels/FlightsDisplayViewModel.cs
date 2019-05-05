using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CenturyAirlines.ViewModels
{
    public class FlightsDisplayViewModel
    {
        [Key]
        [Display(Name = "Flight ID")]
        public int FlightID { get; set; }

        [Display(Name = "Flight Code")]
        public string FlightCode { get; set; }

        [Display(Name = "Departure Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}",
        ApplyFormatInEditMode = true)]
        public DateTime DepartureTime { get; set; }

        [Display(Name = "Arrival Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}",
        ApplyFormatInEditMode = true)]
        public DateTime ArrivalTime { get; set; }
              
        [Display(Name = "Departure City")]
        public string DepartureCityCode { get; set; }

        [Display(Name = "Arrival City")]
        public string ArrivalCityCode { get; set; }
    }
}