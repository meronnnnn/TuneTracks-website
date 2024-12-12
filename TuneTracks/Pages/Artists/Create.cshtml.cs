using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TuneTracks.Data;
using TuneTracks.Models;

namespace TuneTracks.Pages.Artists
{
    public class CreateModel : PageModel
    {
        private readonly TuneTracks.Data.TuneTracksContext _context;

        public CreateModel(TuneTracks.Data.TuneTracksContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Artist Artist { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Artists.Add(Artist);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
