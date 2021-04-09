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

namespace GroupAssignment.Pages.Organizer
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
        public MyUser ThisUser { get; set; }
        public async Task OnGetAsync()
        {
            var IdUser = _userManager.GetUserId(User);
            var UserOrg = await _context.MyUser.Where(x => x.Id == IdUser)
                .Include(z => z.HostedEvents).FirstOrDefaultAsync();
            Event = UserOrg.HostedEvents;
        }
    }
}
