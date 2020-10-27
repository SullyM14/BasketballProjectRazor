using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BasketballProjectRazor.Models;

namespace BasketballProjectRazor.Pages.FantasyPlayers
{
    public class IndexModel : PageModel
    {
        private readonly BasketballProjectRazor.Models.BasketballProjectContext _context;

        public IndexModel(BasketballProjectRazor.Models.BasketballProjectContext context)
        {
            _context = context;
        }

        public IList<UserTeamPlayers> UserTeamPlayers { get;set; }

        public async Task OnGetAsync(int? id)
        {
            UserTeamPlayers = await _context.UserTeamPlayers
                .Include(u => u.Player)
                .Include(u => u.UserTeam).Where(ut=>ut.UserTeamId == id).ToListAsync();

            ViewData["TeamName"] = _context.UserTeams.Where(ut => ut.UserTeamId == id).FirstOrDefault().TeamName;
            ViewData["UserTeamID"] = id;
            ViewData["Budget"] =$"£{_context.UserTeams.Where(ut => ut.UserTeamId == id).FirstOrDefault().Budget}0";


        }
    }
}
