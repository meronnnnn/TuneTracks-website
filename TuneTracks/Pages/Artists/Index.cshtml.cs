using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TuneTracks.Data;
using TuneTracks.Models;

namespace TuneTracks.Pages.Artists
{
    public class IndexModel : PageModel
    {
        private readonly TuneTracks.Data.TuneTracksContext _context;

        public IndexModel(TuneTracks.Data.TuneTracksContext context)
        {
            _context = context;
        }

        public IList<Artist> Artist { get;set; } = default!;

        public async Task OnGetAsync(string SearchString)
        {
            IQueryable<Artist> ArtistsIQ = from s in _context.Artists select s;
            if(!string.IsNullOrEmpty(SearchString))
            {
                ArtistsIQ = ArtistsIQ.Where(s => s.ArtistName.Contains(SearchString));
            }
            Artist = await ArtistsIQ.ToListAsync();
            //Artist = await _context.Artists.ToListAsync();
        }
    }
}
