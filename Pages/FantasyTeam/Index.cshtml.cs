using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BasketballProjectRazor.Models;

namespace BasketballProjectRazor.Pages.FantasyTeam
{
    public class IndexModel : PageModel
    {
        private readonly BasketballProjectRazor.Models.BasketballProjectContext _context;

        public IndexModel(BasketballProjectRazor.Models.BasketballProjectContext context)
        {
            _context = context;
        }

        public IList<UserTeams> UserTeams { get;set; }

        public async Task OnGetAsync()
        {
            ViewData["UserName"] = _context.Users.Where(u => u.UserId == 1).FirstOrDefault().Username;
            UserTeams = await _context.UserTeams
                .Include(u => u.User).ToListAsync();
        }
    }
}
