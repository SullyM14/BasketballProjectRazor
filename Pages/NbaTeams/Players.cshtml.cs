using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BasketballProjectRazor.Models;

namespace BasketballProjectRazor.Pages.NBAPlayers
{
    public class IndexModel : PageModel
    {
        private readonly BasketballProjectRazor.Models.BasketballProjectContext _context;

        public IndexModel(BasketballProjectRazor.Models.BasketballProjectContext context)
        {
            _context = context;
        }

        public IList<Players> Players { get;set; }

        public async Task OnGetAsync(int? id)
        {
            Players = await _context.Players
                .Include(p => p.Team).Where(p=>p.TeamId == id).ToListAsync();
        }
    }
}
