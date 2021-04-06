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

namespace GroupAssignment.Pages.MyEvents
{
    public class IndexModel : PageModel
    {
        private readonly GroupAssignmentContext _context;
        private readonly UserManager<MyUser> _userManager;

        public IndexModel(GroupAssignmentContext context, UserManager<MyUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        

        public IList<Event> Event { get;set; }

        public async Task OnGetAsync()
        {
            var thisUserId = _userManager.GetUserId(User);
            var thisUser = await _context.MyUser.Where(x => x.Id == thisUserId)
                .Include(z => z.JoinedEvents).FirstOrDefaultAsync();
            Event = thisUser.JoinedEvents;


            
        }
    }
}
