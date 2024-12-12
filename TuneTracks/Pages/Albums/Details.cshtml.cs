using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TuneTracks.Data;
using TuneTracks.Models;

namespace TuneTracks.Pages.Albums
{
    public class DetailsModel : PageModel
    {
        private readonly TuneTracks.Data.TuneTracksContext _context;

        public DetailsModel(TuneTracks.Data.TuneTracksContext context)
        {
            _context = context;
        }

        public Album Album { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums.FirstOrDefaultAsync(m => m.AlbumId == id);
            if (album == null)
            {
                return NotFound();
            }
            else
            {
                Album = album;
            }
            return Page();
        }
    }
}
