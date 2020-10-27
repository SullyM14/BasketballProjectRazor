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
    public class DeleteModel : PageModel
    {
        private readonly BasketballProjectRazor.Models.BasketballProjectContext _context;

        public DeleteModel(BasketballProjectRazor.Models.BasketballProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserTeamPlayers UserTeamPlayers { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserTeamPlayers = await _context.UserTeamPlayers
                .Include(u => u.Player)
                .Include(u => u.UserTeam).FirstOrDefaultAsync(m => m.Id == id);

            if (UserTeamPlayers == null)
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

            UserTeamPlayers = await _context.UserTeamPlayers.FindAsync(id);

            if (UserTeamPlayers != null)
            {
                _context.UserTeamPlayers.Remove(UserTeamPlayers);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
