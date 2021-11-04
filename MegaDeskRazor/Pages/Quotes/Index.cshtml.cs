using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskRazor.Data;
using MegaDeskRazor.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MegaDeskRazor.Pages.Quotes
{
    public class IndexModel : PageModel
    {
        private readonly MegaDeskRazor.Data.MegaDeskRazorContext _context;

        public IndexModel(MegaDeskRazor.Data.MegaDeskRazorContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList SurfaceMaterials { get; set; }
        [BindProperty(SupportsGet = true)]
        public string DeskSurfaceMaterial { get; set; }

        public IList<DeskQuote> DeskQuote { get;set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> surfaceMaterialQuery = from m in _context.Desk
                                            orderby m.SurfaceMaterial
                                            select m.SurfaceMaterial;

            var desks = from d in _context.DeskQuote
                         select d;

            if (!string.IsNullOrEmpty(DeskSurfaceMaterial))
            {
                desks = desks.Where(x => x.Desk.SurfaceMaterial == DeskSurfaceMaterial);
            }
            SurfaceMaterials = new SelectList(await surfaceMaterialQuery.Distinct().ToListAsync());
            DeskQuote = await desks
                .Include(d => d.Desk).ToListAsync();
        }
    }
}
