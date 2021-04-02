using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroupAssignment.Data;
using GroupAssignment.Models;
using Microsoft.AspNetCore.Identity;

namespace GroupAssignment.Pages.Events
{
    public class DetailsModel : PageModel
    {
        private readonly GroupAssignmentContext _context;
        private readonly UserManager<MyUser> _userManager;

        public DetailsModel(GroupAssignmentContext context, UserManager<MyUser> userManager)
        {
            _userManager = userManager;
            _context = context;
            
        }
        public MyUser user { get; set; }
        public Event Event { get; set; }
        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Event.FirstOrDefaultAsync(e => e.Id == id);

            if (Event == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            Event = await _context.Event.FirstOrDefaultAsync(e => e.Id == id);

            var thisUser = _userManager.GetUserId(User);

            user = await _context.MyUser.Where(x => x.Id == thisUser).
                Include(jo => jo.JoinedEvents).FirstOrDefaultAsync();

            if (user != null)
            {
                user.JoinedEvents.Add(Event);
                await _context.SaveChangesAsync();
            }
            
            return Page();
        }
    }
}
