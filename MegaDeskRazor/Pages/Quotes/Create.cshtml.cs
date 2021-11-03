using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDeskRazor.Data;
using MegaDeskRazor.Models;

namespace MegaDeskRazor.Pages.Quotes
{
    public class CreateModel : PageModel
    {
        private readonly MegaDeskRazor.Data.MegaDeskRazorContext _context;

        public CreateModel(MegaDeskRazor.Data.MegaDeskRazorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DeskId"] = new SelectList(_context.Set<Desk>(), "DeskId", "DeskId");
            return Page();
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) 
            {
                return Page();
            }
            int width = Convert.ToInt32(Request.Form["width"]);
            int depth = Convert.ToInt32(Request.Form["depth"]);
            int drawerNum = Convert.ToInt32(Request.Form["drawernum"]);

            String surfaceMaterial = Request.Form["surfaceMaterial"];
            DeskQuote.Date = DateTime.Now;
            DeskQuote.Desk = new Desk(width, depth, drawerNum, surfaceMaterial);
            DeskQuote.calcPrice();
           // int width, int depth, int drawerNum, string surfaceMaterial
            
            
            
            _context.Desk.Add(DeskQuote.Desk);

            _context.DeskQuote.Add(DeskQuote);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
