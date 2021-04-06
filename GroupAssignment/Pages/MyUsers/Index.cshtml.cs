using System;
using System.Collections.Generic;
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
using Microsoft.AspNetCore.Identity;

namespace GroupAssignment.Pages.MyUsers
{
    public class IndexModel : PageModel
    {

        private readonly UserManager<MyUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly GroupAssignmentContext _groupAssignmentContext;

        public IndexModel(UserManager<MyUser> usermanager,
            RoleManager<IdentityRole> roleManager,
            GroupAssignmentContext groupAssignmentContext)
        {
            _userManager = usermanager;
            _roleManager = roleManager;
            _groupAssignmentContext = groupAssignmentContext;
        }

        public IEnumerable<MyUser> Users { get; set; }

        public async Task OnGetAsync()
        {
            Users = await _userManager.Users.ToListAsync();

        }



    }
}
