using Microsoft.EntityFrameworkCore;
using Project.core.model;
using Project.core.Reposetory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Reposetory
{
    public class TripReposetory:ITripReposetory
    {
        private Datacontext _context;
        public TripReposetory(Datacontext context)
        {
            _context = context;
        }
        public IEnumerable<Trip> GetTrip()
        {
            return _context.trips.Include(g=>g.guide).Include(r=>r.registeres);
        }
        public Trip GetTrip(string id)
        {
            //נשלח את התז רק לאחר בדיקה בסרויס שזה לא שווה מינוס אחד

            var index = _context.trips.ToList().FindIndex(e => e.idGuide.Equals(id));
            return _context.trips.Include(g=>g.guide).Include(r=>r.registeres).ToList()[index];
        }
        public Trip AddTrip(Trip trip)
        {
            _context.trips.Add(trip);
            return trip;
        }
        public void UpdateTrip(string TripId, Trip trip)
        {
            var index = _context.trips.ToList().FindIndex(e => e.code.Equals(TripId));
            _context.trips.ToList()[index].code = trip.code;
            _context.trips.ToList()[index].location = trip.location;
            _context.trips.ToList()[index].date = trip.date;
            _context.trips.ToList()[index].numRegisteres = trip.numRegisteres;
            _context.trips.ToList()[index].idGuide = trip.idGuide;

        }
        public void DeleteTrip(string tripId)
        {
            var index = _context.trips.ToList().FindIndex(e => e.code.Equals(tripId));
            _context.trips.ToList().RemoveAt(index);
        }
    }
}
