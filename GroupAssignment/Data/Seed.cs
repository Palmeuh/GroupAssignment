using GroupAssignment.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupAssignment.Data
{
    public static class Seed
    {
        public async static Task Seeding(IServiceProvider services)
        {           
            var context = services.GetRequiredService<GroupAssignmentContext>();

            context.Database.EnsureCreated();

            var userManager = services.GetRequiredService<UserManager<MyUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();


            //Create the roles
            var roles = new string[] { "Administrator", "Organizer", "Attendee" };

            foreach (var role in roles)
            {
                var newRole = new IdentityRole
                {
                    Name = role
                };
                await roleManager.CreateAsync(newRole);
            }

            

            //Create events

            Event[] events = new Event[]
           {
                new Event{Title="Bio", Description="Star Wars", Place="GBG", Address="Bergakungen, 30", Date=DateTime.Now, SpotsAvailable=11},
                new Event{Title="Middag", Description="Käka mat", Place="GBG", Address="Randomgata, 13", Date=DateTime.Now, SpotsAvailable=5}
           };
            context.Event.AddRange(events);

            //Create Joined or Organized lists

            var hasJoined = new List<Event>();
            hasJoined.AddRange(events);

            var hasOrganized = new List<Event>();
            hasOrganized.AddRange(events);
           
           

            //Create the users

            string password = "Passw0rd!#";

            MyUser[] users = new MyUser[]
            {
                new MyUser{FirstName = "Anders", LastName = "Andersson", Email = "Anders@Andersson.com", UserName = "Anders@Andersson.com", JoinedEvents = hasJoined},
                new MyUser{FirstName = "Bertil", LastName="Bertilsson", Email="Bertil@Bertilsson.com", UserName="Bertil@Bertilsson.com", HostedEvents = hasOrganized},
                new MyUser{FirstName = "Christer", LastName="Christersson", Email="Christer@Christersson.com", UserName="Christer@Christersson.com"}
            };

            var seedRole = 0;
            foreach (var user in users)
            {
                IdentityResult newUser = await userManager.CreateAsync(user, password);
                if (newUser.Succeeded)
                {
                    var giveUserRole = await userManager.AddToRoleAsync(user, roles[seedRole]);
                    seedRole++;
                }
            }

            //IdentityResult testUser = await userManager.CreateAsync(user, password);

            //if (testUser.Succeeded)
            //{
            //    var resultRole = await userManager.AddToRoleAsync(user, "Admin");
            //}

           
                
            

           
            context.SaveChanges();

        }
    }
}
