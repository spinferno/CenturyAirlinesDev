using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CenturyAirlines.Entities;
using CenturyAirlines.ViewModels;

namespace CenturyAirlines.Data
{
    public class FlightsRepository
    {
        public List<FlightsDisplayViewModel> GetFlights()
        {
            using (var context = new ApplicationDBContext())
            {
                List<Flights> flights = new List<Flights>();
                flights = context.Flights.AsNoTracking()
                    .Include(x => x.DepartingFromCity)
                    .Include(x => x.ArrivingToCity)
                    .ToList();

                if (flights != null)
                {
                    List<FlightsDisplayViewModel> flightsDisplay = new List<FlightsDisplayViewModel>();
                    foreach (var x in flights)
                    {
                        var customerDisplay = new FlightsDisplayViewModel()
                        {
                            FlightID = x.FlightID,
                            FlightCode = x.FlightCode,
                            DepartureTime = x.DepartureTime,
                            ArrivalTime = x.ArrivalTime,

                            DepartureCityCode = x.DepartingFromCity.CityName,
                            ArrivalCityCode = x.ArrivingToCity.CityName
                        };
                        flightsDisplay.Add(customerDisplay);
                    }
                    return flightsDisplay;
                }
                return null;
            }
        }
        public FlightsEditViewModel CreateFlight()
        {
            var cRepo = new CitiesRepository();
            var flight = new FlightsEditViewModel()
            {
                Cities = cRepo.GetCities()
            };
            return flight;
        }

        public FlightsEditViewModel GetFlight(Flights flightFromEF )
        {
            var cRepo = new CitiesRepository();
            var flight = new FlightsEditViewModel()
            {
                FlightID = flightFromEF.FlightID.ToString(),
                FlightCode = flightFromEF.FlightCode,
                DepartureTime = flightFromEF.DepartureTime,
                ArrivalTime = flightFromEF.ArrivalTime,
                IsFull = flightFromEF.IsFull,

                DepartureCityID = flightFromEF.DepartureCityID, //cRepo.GetCities().                

                ArrivalCityID = flightFromEF.ArrivalCityID,
                Cities = cRepo.GetCities()
            };

            return flight;
        }

        public bool SaveFlight(FlightsEditViewModel flightedit)
        {
            if (flightedit != null)
            {
                using (var context = new ApplicationDBContext())
                {
                    var flight = new Flights()
                    {
                        FlightCode = flightedit.FlightCode,
                        DepartureCityID = flightedit.DepartureCityID,
                        ArrivalCityID = flightedit.ArrivalCityID,
                        DepartureTime = flightedit.DepartureTime,
                        ArrivalTime = flightedit.ArrivalTime,
                        IsFull = flightedit.IsFull
                    };
                    flight.DepartingFromCity = context.Cities.Find(flightedit.DepartureCityID);
                    flight.ArrivingToCity = context.Cities.Find(flightedit.ArrivalCityID);

                    context.Flights.Add(flight);
                    context.SaveChanges();
                    return true;
                   
                }
            }

            return false;
        }
    }
}