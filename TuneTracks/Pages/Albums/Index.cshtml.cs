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
    public class IndexModel : PageModel
    {
        private readonly TuneTracks.Data.TuneTracksContext _context;

        public IndexModel(TuneTracks.Data.TuneTracksContext context)
        {
            _context = context;
        }

        public IList<Album> Album { get;set; } = default!;

        public async Task OnGetAsync(string SearchString)
        {
            IQueryable<Album> AlbumsIQ = from s in _context.Albums select s;
            if (!string.IsNullOrEmpty(SearchString))
            {
                AlbumsIQ = AlbumsIQ.Where(s => s.Title.Contains(SearchString));
            }
           Album = await AlbumsIQ.Include(d => d.Artist)
            //Album = await _context.Albums
                .Include(a => a.Artist).ToListAsync();
        }
    }
}
