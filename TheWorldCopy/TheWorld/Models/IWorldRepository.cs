using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheWorld.Models
{
    public interface IWorldRepository
    {
        IEnumerable<Trip> GetAllTrips();
        IEnumerable<Trip> GetTripByUsername(string userName);
        Trip GetUserTripByName(string tripName, string userName);
        Trip GetTripByName(string tripName);
        void AddTrip(Trip trip);
        void AddStop(string tripName, Stop newStop,string userName);
        Task<bool> SaveChangesAsync();
       
    }
}   