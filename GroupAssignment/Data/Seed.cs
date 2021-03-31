using GroupAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupAssignment.Data
{
    public static class Seed
    {
        public static void Seeding(GroupAssignmentContext context)
        {
            
            context.Database.EnsureCreated();

            Event[] events = new Event[]
            {
                new Event{Title="Bio", Description="Star Wars", Place="GBG", Address="Bergakungen, 30", Date=DateTime.Now, SpotsAvailable=11},
                new Event{Title="Middag", Description="Käka mat", Place="GBG", Address="Randomgata, 13", Date=DateTime.Now, SpotsAvailable=5}
            };
            context.Event.AddRange(events);
            context.SaveChanges();

        }
    }
}
