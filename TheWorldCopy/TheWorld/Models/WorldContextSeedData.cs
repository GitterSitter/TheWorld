using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWorld.Models
{
    public class WorldContextSeedData
    {
        private WorldContext _context;
        private UserManager<WorldUser> _userManager;

        public WorldContextSeedData(WorldContext context, UserManager<WorldUser> userManager)
        {
            _context = context;
            _userManager = userManager; 
        }

        public async Task EnsureSeedData()
        {

            if(await _userManager.FindByEmailAsync("test@me.com") == null)
            {
                var user = new WorldUser()
                {
                    UserName = "Trond",
                    Email = "test@me.com"
                };

                await _userManager.CreateAsync(user, "P@ssw0rd!");
            }


            if (!_context.Trips.Any())
            {
                var usTrip = new Trip()
                {
                    DateCreated = DateTime.Now,
                    Name = "Us Trip",
                    UserName = "",
                    Stops = new List<Stop>()
                    {
                        new Stop() { Name = "Atlanta, GA", Arrival= new DateTime(2014, 6, 4), Latitude=33.748995, Longitude= -84.387982, Order=0 },
                        new Stop() { Name = "New York, NY", Arrival= new DateTime(2014,6,9), Latitude=40.712784, Longitude = -74.005941, Order = 1 },
                        new Stop() { Name = "Boston, MA", Arrival= new DateTime(2014,7,1), Latitude= 42.360082, Longitude=-71.058880, Order = 2},
                        new Stop() { Name = "Chicago, IL", Arrival= new DateTime(2014, 7, 10), Latitude = 41.878114, Longitude = -87.629798, Order = 3 },
                        new Stop() { Name = "Seattle, WA", Arrival= new DateTime(2014, 8, 13), Latitude = 47.606209, Longitude = -122.332071, Order = 4},
                        new Stop() { Name = "Atlanta, GA", Arrival= new DateTime(2014, 8, 23), Latitude=33.748995, Longitude= -84.387982, Order=5 },

                        }

                };

                // Adds the object data to the database!
                _context.Trips.Add(usTrip);
                _context.Stops.AddRange(usTrip.Stops);


                var worldTrip = new Trip()
                {
                    DateCreated = DateTime.Now,
                    Name = "World Trip",
                    UserName = "Trond",
                    Stops = new List<Stop>()
                    {
                      // This dummy data is heavily abbreviated from the sample in the tutorial (which contained 50+ points)
                        new Stop() {Order = 0, Latitude = 33.748995, Longitude = -84.387982, Name = "Atlanta, Georgia" , Arrival = DateTime.Parse("June 3, 2014") },
                        new Stop() {Order = 1, Latitude = 48.856614 , Longitude = 2.352222, Name = "Paris, France", Arrival = DateTime.Parse("June 4, 2014") },
                        new Stop() {Order = 2, Latitude = 50.850000 , Longitude = 4.350000, Name = "Brussels, Belgium", Arrival = DateTime.Parse("June 25, 2014") },
                        new Stop() {Order = 3, Latitude = 51.209348 , Longitude = 3.224700, Name = "Bruges, Belgium", Arrival = DateTime.Parse("June 28, 2014") },
                        new Stop() {Order = 4, Latitude = 48.856614 , Longitude = 2.352222, Name = "Paris, France", Arrival = DateTime.Parse("June 20, 2014") },
                        new Stop() {Order = 5, Latitude = 51.508515, Longitude = -0.125487, Name = "London, UK", Arrival = DateTime.Parse("July 8, 2014") },
                        new Stop() {Order = 6, Latitude = 33.748995, Longitude = -84.387982, Name = "Atlanta, Georgia" , Arrival = DateTime.Parse("July 14, 2014") }

                    }
                };

                _context.Trips.Add(worldTrip);
                _context.Stops.AddRange(worldTrip.Stops);


                //pushes the data to the database!
                await _context.SaveChangesAsync();
            }
        }
    }

}
