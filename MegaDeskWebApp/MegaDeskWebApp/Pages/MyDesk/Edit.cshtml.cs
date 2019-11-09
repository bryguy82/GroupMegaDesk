using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MegaDeskWebApp.Data;
using MegaDeskWebApp.Models;

namespace MegaDeskWebApp.Pages.MyDesk
{
    public class EditModel : PageModel
    {
        private readonly MegaDeskWebApp.Data.MegaDeskWebAppContext _context;

        public EditModel(MegaDeskWebApp.Data.MegaDeskWebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }
        
        [BindProperty]
        public Desk Desk { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DeskQuote = await _context.DeskQuotes.FirstOrDefaultAsync(m => m.DeskQuoteID == id);
            Desk = _context.Desks.Find(DeskQuote.deskID);
            DeskQuote.desk = Desk;

            if (DeskQuote == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Desk).State = EntityState.Modified;            
            _context.Attach(DeskQuote).State = EntityState.Modified;
            DeskQuote.deskID = Desk.ID;
            calculations();

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeskQuoteExists(DeskQuote.DeskQuoteID))
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

        private bool DeskQuoteExists(int id)
        {
            return _context.DeskQuotes.Any(e => e.DeskQuoteID == id);
        }

        public void calculations()
        {
            var area = Desk.getArea(Desk.width, Desk.depth);
            DeskQuote.totalCost = DeskQuote.calcCost(area, Desk.drawerNum, Desk.materialType);
            if (Desk.rushDays != 0)
            {
                DeskQuote.rushCost = DeskQuote.calcRush(area, Desk.rushDays);
            }
        }
    }
}
