using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;

namespace GroupAssignment.Models
{
    public class MyUser : IdentityUser
    {       

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Event> JoinedEvents { get; set; }
        public List<Event> HostedEvents { get; set; }
    }
}