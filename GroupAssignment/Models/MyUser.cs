using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;

namespace GroupAssignment.Models
{
    public class MyUser : IdentityUser
    {
        public List<Event> Events { get; set; }
    }
}