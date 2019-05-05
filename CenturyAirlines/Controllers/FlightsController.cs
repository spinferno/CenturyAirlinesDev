using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CenturyAirlines.Data;
using CenturyAirlines.Entities;
using CenturyAirlines.ViewModels;

namespace CenturyAirlines.Controllers
{
    public class FlightsController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: Flights
        public ActionResult Index()
        {
            var repo = new FlightsRepository();
            var flightsList = repo.GetFlights();
            return PartialView(flightsList);
        }

        // GET: Flights/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flights flights = db.Flights.Find(id);
            if (flights == null)
            {
                return HttpNotFound();
            }
            return View(flights);
        }

        // GET: Flights/Create
        public ActionResult Create()
        {
            var repo = new FlightsRepository();
            var flight = repo.CreateFlight();
            return View(flight);      
        }

        // POST: Flights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FlightID,FlightCode,DepartureTime,ArrivalTime,IsFull,DepartureCityID,ArrivalCityID")] FlightsEditViewModel flight)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var repo = new FlightsRepository();
                    bool saved = repo.SaveFlight(flight);
                    if (saved)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        // GET: Flights/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Flights flightDatabaseEF = db.Flights.Find(id);

            var repo = new FlightsRepository();
            var flight = repo.GetFlight(flightDatabaseEF);
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind(Include = "FlightID,FlightCode,DepartureTime,ArrivalTime,IsFull,DepartureCityID,ArrivalCityID")] Flights flight)
        //public ActionResult Edit([Bind(Include = "FlightID,FlightCode,DepartureTime,ArrivalTime,IsFull,DepartureCityID,ArrivalCityID")] FlightsEditViewModel flight) //Flights flight)
        {
            if(id != flight.FlightID)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {
                using (var context = new ApplicationDBContext())
                {
                    flight.DepartingFromCity = context.Cities.Find(flight.DepartureCityID);
                    flight.ArrivingToCity = context.Cities.Find(flight.ArrivalCityID);

                    context.Entry(flight).State = EntityState.Modified;
                    context.SaveChanges();
                }    
                return RedirectToAction("Index");
            }
            return View(flight);           
        }

        // GET: Flights/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Flights flights = db.Flights.Find(id);

            if (flights == null)
            {
                return HttpNotFound();
            }
            return View(flights);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flights flights = db.Flights.Find(id);
            db.Flights.Remove(flights);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
