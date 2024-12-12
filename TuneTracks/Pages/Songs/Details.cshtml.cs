using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TuneTracks.Data;
using TuneTracks.Models;

namespace TuneTracks.Pages.Songs
{
    public class DetailsModel : PageModel
    {
        private readonly TuneTracks.Data.TuneTracksContext _context;

        public DetailsModel(TuneTracks.Data.TuneTracksContext context)
        {
            _context = context;
        }

        public Song Song { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Songs.FirstOrDefaultAsync(m => m.SongId == id);
            if (song == null)
            {
                return NotFound();
            }
            else
            {
                Song = song;
            }
            return Page();
        }
    }
}
