using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BasketballProjectRazor.Models;

namespace BasketballProjectRazor.Pages.FantasyTeam
{
    public class CreateModel : PageModel
    {
        private readonly BasketballProjectRazor.Models.BasketballProjectContext _context;

        public CreateModel(BasketballProjectRazor.Models.BasketballProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["UserId"] = new SelectList(_context.Users, "UserId", "FirstName");
            return Page();
        }

        [BindProperty]
        public UserTeams UserTeams { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            UserTeams.Budget = 100;
            _context.UserTeams.Add(UserTeams);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
