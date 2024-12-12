using Project.core.model;
using Project.core.Reposetory;
using Project.core.Servies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Servies
{
    public class TripServies: ITripServies
    {
        ITripReposetory _tripReposetory;
        public TripServies(ITripReposetory tripReposetory)
        {
            _tripReposetory = tripReposetory;
        }
        public IEnumerable<Trip> GetTrip()
        {
            return _tripReposetory.GetTrip();
        }
        public Trip GetTrip(string id)
        {
            if (IsExist(id))
            {
                return _tripReposetory.GetTrip(id);
            }
            return null;
        }
        public Trip AddTrip(Trip trip)
        {
            if (IsExist(trip.code))
            {
                UpdateTrip(trip.code, trip);
                return trip;
            }
            _tripReposetory.AddTrip(trip);
            return trip;
        }
        public void UpdateTrip(string TripId, Trip trip)
        {
            if (IsExist(TripId))
            {
                _tripReposetory.UpdateTrip(TripId, trip);

            }
            _tripReposetory.AddTrip(trip);

        }
        public bool DeleteTrip(string tripId)
        {
            if (IsExist(tripId))
            { 
                _tripReposetory.DeleteTrip(tripId);
                return true;
            }
            return false;
        }
        public bool IsExist(string tripId)
        {
            var trips = _tripReposetory.GetTrip();
            var exist = trips.Any(trips => trips.code == trips.code);
            if (exist) { return true; }
            return false;
        }

    }
}
