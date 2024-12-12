using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TuneTracks.Data;
using TuneTracks.Models;

namespace TuneTracks.Pages.Songs
{
    public class EditModel : PageModel
    {
        private readonly TuneTracks.Data.TuneTracksContext _context;

        public EditModel(TuneTracks.Data.TuneTracksContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Song Song { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song =  await _context.Songs.FirstOrDefaultAsync(m => m.SongId == id);
            if (song == null)
            {
                return NotFound();
            }
            Song = song;
           ViewData["AlbumId"] = new SelectList(_context.Albums, "AlbumId", "Title");
           ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "ArtistName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Song).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(Song.SongId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SongExists(int id)
        {
            return _context.Songs.Any(e => e.SongId == id);
        }
    }
}
