using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BasketballProjectRazor.Models;

namespace BasketballProjectRazor.Pages.NbaTeams
{
    public class IndexModel : PageModel
    {
        private readonly BasketballProjectRazor.Models.BasketballProjectContext _context;

        public IndexModel(BasketballProjectRazor.Models.BasketballProjectContext context)
        {
            _context = context;
        }

        public IList<Nbateams> Nbateams { get;set; }

        public async Task OnGetAsync()
        {
            Nbateams = await _context.Nbateams.OrderByDescending(t=>t.Wins).ToListAsync();
        }
    }
}
