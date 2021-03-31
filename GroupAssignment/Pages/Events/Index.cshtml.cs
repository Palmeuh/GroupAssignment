using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroupAssignment.Data;
using GroupAssignment.Models;
using Microsoft.AspNetCore.Authorization;

namespace GroupAssignment.Pages.Events
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly GroupAssignment.Data.GroupAssignmentContext _context;

        public IndexModel(GroupAssignment.Data.GroupAssignmentContext context)
        {
            _context = context;
        }

        public IList<Event> Event { get;set; }

        public async Task OnGetAsync()
        {
            Event = await _context.Event.ToListAsync();
        }
    }
}
