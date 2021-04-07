using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroupAssignment.Data;
using GroupAssignment.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace GroupAssignment.Pages.ManageUsers
{
    public class IndexModel : PageModel
    {

        private readonly UserManager<MyUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly GroupAssignmentContext _groupAssignmentContext;

        public IEnumerable<MyUser> Users { get; set; }

        public IEnumerable<IdentityRole> Roles { get; set; }

        public Dictionary<MyUser, string> UserRoles { get; set; }
        public SelectList Options { get; set; }
        [BindProperty]
        public string SelectedRole { get; set; }


        public IndexModel(UserManager<MyUser> usermanager,
            RoleManager<IdentityRole> roleManager,
            GroupAssignmentContext groupAssignmentContext)
        {
            _userManager = usermanager;
            _roleManager = roleManager;
            _groupAssignmentContext = groupAssignmentContext;
            UserRoles = new Dictionary<MyUser, string>();
        }

        public async Task OnGetAsync()
        {
            Users = await _userManager.Users.ToListAsync();
            Roles = await _roleManager.Roles.ToListAsync();            
            

            var users = await _userManager.Users.ToListAsync();            
            foreach (var u in users)
            {
               
                var roles = await _userManager.GetRolesAsync(u);
                
                foreach (var r in roles)
                {
                    UserRoles.Add(u, r);
                }               
            }

            var selectList = new List<string>();

            foreach (var role in Roles)
            {
                selectList.Add(role.Name);
            }

            Options = new SelectList(selectList);

        }

        public async Task<IActionResult> OnPostAsync(string id)
        {           

            var user = await _userManager.FindByIdAsync(id);
            var userRole = await _userManager.GetRolesAsync(user);

            await _userManager.RemoveFromRoleAsync(user, userRole[0]);
            await _userManager.AddToRoleAsync(user, SelectedRole);

            await _groupAssignmentContext.SaveChangesAsync();

            return RedirectToPage("ManageUsers");

        }

    }
}
