using Project.core.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.core.Reposetory
{
    public interface ITripReposetory
    {
        public IEnumerable<Trip> GetTrip();
        public Trip GetTrip(string id);
        public Trip AddTrip(Trip trip);
        public void UpdateTrip(string TripId, Trip trip);
        public void DeleteTrip(string TripId);
    }
}
