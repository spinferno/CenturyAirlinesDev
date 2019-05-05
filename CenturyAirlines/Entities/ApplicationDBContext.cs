using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CenturyAirlines.Entities
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base("ApplicationDBContext")
        {

        }

        //public DbSet<Employee> Employees{ get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<Flights> Flights { get; set; }
        public DbSet<Cities> Cities { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}