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
    public class DetailsModel : PageModel
    {
        private readonly BasketballProjectRazor.Models.BasketballProjectContext _context;

        public DetailsModel(BasketballProjectRazor.Models.BasketballProjectContext context)
        {
            _context = context;
        }

        public Players Players { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Players = await _context.Players
                .Include(p => p.Team).FirstOrDefaultAsync(m => m.PlayerId == id);

            if (Players == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
