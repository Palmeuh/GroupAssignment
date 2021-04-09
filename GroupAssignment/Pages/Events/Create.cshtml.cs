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

namespace GroupAssignment.Pages.Events
{
    [Authorize(Roles = "Organizer,Administrator")]
    public class CreateModel : PageModel
    {
        private readonly GroupAssignment.Data.GroupAssignmentContext _context;

        public CreateModel(GroupAssignment.Data.GroupAssignmentContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Event Event { get; set; }
        public MyUser TheUser { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            TheUser =  _context.MyUser.Where(i => i.UserName == User.Identity.Name).FirstOrDefault();
            Event.Organizer = TheUser;
            
            _context.Event.Add(Event);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
