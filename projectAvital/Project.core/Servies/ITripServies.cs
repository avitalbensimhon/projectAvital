using Project.core.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.core.Servies
{
    public interface ITripServies
    {
      
        public IEnumerable<Trip> GetTrip();
        public Trip GetTrip(string id);
        public Trip AddTrip(Trip trip);
        public void UpdateTrip(string TripId, Trip trip);
        public bool DeleteTrip(string tripId);

    }
}
