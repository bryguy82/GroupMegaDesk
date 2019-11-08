using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDeskWebApp.Data;
using MegaDeskWebApp.Models;

namespace MegaDeskWebApp.Pages.MyDesk
{
    public class CreateModel : PageModel
    {
        private readonly MegaDeskWebApp.Data.MegaDeskWebAppContext _context;

        public DateTime today { get; set; } = DateTime.Now.Date;

        public CreateModel(MegaDeskWebApp.Data.MegaDeskWebAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        [BindProperty]
        public Desk Desk { get; set; }

/*        [BindProperty]
        public Desk.DesktopMaterial enumDesktop { get; set; }*/

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DeskQuotes.Add(DeskQuote);
            _context.Desks.Add(Desk);

            calculations();

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public void calculations()
        {
            var area = Desk.getArea(Desk.width, Desk.depth);
            DeskQuote.totalCost = DeskQuote.calcCost(area, Desk.drawerNum, Desk.materialType);
            if(Desk.rushDays != 0)
            {
                DeskQuote.rushCost = DeskQuote.calcRush(area, Desk.rushDays);
            }
        }
    }
}