using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupAssignment.Data;
using GroupAssignment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GroupAssignment.Pages.Administration
{
    [Authorize(Roles = "Administrator")]
    public class ManageRolesModel : PageModel
    {
        private readonly GroupAssignmentContext context;
        private readonly UserManager<MyUser> userManager;

        public ManageRolesModel(GroupAssignmentContext context, UserManager<MyUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        [BindProperty]
        public IList<IdentityRole> Roles { get; set; }
        [BindProperty]
        public IdentityRole NewRole { get; set; }

        public async Task OnGetAsync()
        {
            Roles = await context.Roles.ToListAsync();
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            NewRole.NormalizedName = NewRole.Name.ToUpper();
            await context.Roles.AddAsync(NewRole);
            await context.SaveChangesAsync();
            return RedirectToPage("/Administration/ManageRoles");
        }

        public async Task<IActionResult> OnPostDelete(string id)
        {
            IdentityRole roleToRemove = await context.Roles.Where(r => r.Id == id).FirstOrDefaultAsync();
            context.Roles.Remove(roleToRemove);
            await context.SaveChangesAsync();
            return RedirectToPage("/Administration/ManageRoles");
        }
    }
}
