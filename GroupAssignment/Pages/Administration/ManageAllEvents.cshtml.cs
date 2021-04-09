using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupAssignment.Data;
using GroupAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GroupAssignment.Pages.Administration
{
    public class ManageAllEventsModel : PageModel
    {
        private readonly GroupAssignmentContext _context;

        public ManageAllEventsModel(GroupAssignmentContext context)
        {
            _context = context;
        }

        public IList<Event> Events { get; set; }
        public IList<Event> Test { get; set; }

        public async Task OnGetAsync()
        {
            Events = await _context.Event.ToListAsync();

            Test = await _context.Event.Include(o => o.Organizer).ToListAsync();
            
        }
    }
}
