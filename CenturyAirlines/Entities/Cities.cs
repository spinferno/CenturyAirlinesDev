using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CenturyAirlines.Entities
{
    [Table("RACS_Cities")]
    public class Cities
    {
        [Key]
        public int CityID { get; set; }

        [Required]
        public String CityName { get; set; }

        [Required]
        [MaxLength(3)]
        public String CityCode { get; set; }

        [InverseProperty("DepartingFromCity")]
        public virtual ICollection<Flights> DepartingFromFlights { get; set; }

        [InverseProperty("ArrivingToCity")]
        public virtual ICollection<Flights> ArrivingToFlights { get; set; }

    }
}