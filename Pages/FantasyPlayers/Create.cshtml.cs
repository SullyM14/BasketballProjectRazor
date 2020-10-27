using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BasketballProjectRazor.Models;

namespace BasketballProjectRazor.Pages.FantasyPlayers
{
    public class CreateModel : PageModel
    {
        private readonly BasketballProjectRazor.Models.BasketballProjectContext _context;

        public CreateModel(BasketballProjectRazor.Models.BasketballProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? id)
        {
        ViewData["PlayerId"] = _context.Players.Select(p => new SelectListItem
            {
                Text = p.FirstName + " " + p.LastName + ": £" + p.Price + "0",
                Value = p.PlayerId.ToString()
            });
            ViewData["UserTeamId"] = new SelectList(_context.UserTeams.Where(ut=>ut.UserTeamId == id), "UserTeamId", "TeamName");
            return Page();
        }

        [BindProperty]
        public UserTeamPlayers UserTeamPlayers { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.UserTeamPlayers.Add(UserTeamPlayers);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
