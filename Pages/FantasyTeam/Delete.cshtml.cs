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
    public class DeleteModel : PageModel
    {
        private readonly BasketballProjectRazor.Models.BasketballProjectContext _context;

        public DeleteModel(BasketballProjectRazor.Models.BasketballProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserTeams UserTeams { get; set; }
        public UserTeamPlayers UserTeamPlayers { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserTeams = await _context.UserTeams
                .Include(u => u.User).FirstOrDefaultAsync(m => m.UserTeamId == id);

            if (UserTeams == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserTeams = await _context.UserTeams.FindAsync(id);

            if (UserTeams != null)
            {
                _context.UserTeams.Remove(UserTeams);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
