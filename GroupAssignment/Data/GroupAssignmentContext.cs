using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GroupAssignment.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GroupAssignment.Data
{
    public class GroupAssignmentContext : IdentityDbContext
    {
        public GroupAssignmentContext (DbContextOptions<GroupAssignmentContext> options)
            : base(options)
        {
        }

        public DbSet<GroupAssignment.Models.Event> Event { get; set; }
    }
}
