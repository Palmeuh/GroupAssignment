using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GroupAssignment.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GroupAssignment.Data
{
    public class GroupAssignmentContext : IdentityDbContext<MyUser>
    {
        public GroupAssignmentContext (DbContextOptions<GroupAssignmentContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Event { get; set; }
        public DbSet<MyUser> MyUser { get; set; }
        public DbSet<Organizer> Organizer { get; set; }


    }
}
