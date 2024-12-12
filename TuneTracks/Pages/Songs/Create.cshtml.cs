using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TuneTracks.Data;
using TuneTracks.Models;

namespace TuneTracks.Pages.Songs
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
        ViewData["AlbumId"] = new SelectList(_context.Albums, "AlbumId", "Title");
        ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "ArtistName");
            return Page();
        }

        [BindProperty]
        public Song Song { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Songs.Add(Song);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
