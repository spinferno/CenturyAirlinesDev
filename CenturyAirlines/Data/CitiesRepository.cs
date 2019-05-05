using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CenturyAirlines.Entities;

namespace CenturyAirlines.Data
{
    public class CitiesRepository
    {
        public IEnumerable<SelectListItem> GetCities()
        {
            using (var context = new ApplicationDBContext())
            {
                List<SelectListItem> cities = context.Cities.AsNoTracking()
                    .OrderBy(n => n.CityName)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.CityID.ToString(),
                            Text = n.CityName
                        }).ToList();
                var citytip = new SelectListItem()
                {
                    Value = null,
                    Text = "--- select city ---"
                };
                cities.Insert(0, citytip);
                return new SelectList(cities, "Value", "Text");
            }
        }

        public IEnumerable<SelectListItem> GetCities(string cityid)
        {
            if (!String.IsNullOrWhiteSpace(cityid))
            {
                using (var context = new ApplicationDBContext())
                {
                    IEnumerable<SelectListItem> cities = context.Cities.AsNoTracking()
                        .OrderBy(n => n.CityName)
                        .Where(n => n.CityID.ToString() == cityid)
                        .Select(n =>
                           new SelectListItem
                           {
                               Value = n.CityID.ToString(),
                               Text = n.CityName
                           }).ToList();
                    return new SelectList(cities, "Value", "Text");
                }
            }
            return null;
        }
    }
}