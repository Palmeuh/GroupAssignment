using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GroupAssignment.Data;
using GroupAssignment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GroupAssignment.Pages.Events
{
    [Authorize(Roles = "Organizer,Administrator")]
    public class CreateModel : PageModel
    {
        private readonly GroupAssignment.Data.GroupAssignmentContext _context;
        private readonly UserManager<MyUser> _userManager;

        public CreateModel(GroupAssignmentContext context, UserManager<MyUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Event Event { get; set; }
        public MyUser ThisUser { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var IdUser = _userManager.GetUserId(User);

            ThisUser = await _context.MyUser.Where(x => x.Id == IdUser).FirstOrDefaultAsync();

            Event.Organizer = ThisUser;
            _context.Event.Add(Event);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Organizer/OrganizedEvents");
        }
    }
}
