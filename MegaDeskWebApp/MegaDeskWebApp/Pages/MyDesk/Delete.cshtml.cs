﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskWebApp.Data;
using MegaDeskWebApp.Models;

namespace MegaDeskWebApp.Pages.MyDesk
{
    public class DeleteModel : PageModel
    {
        private readonly MegaDeskWebApp.Data.MegaDeskWebAppContext _context;

        public DeleteModel(MegaDeskWebApp.Data.MegaDeskWebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DeskQuote = await _context.DeskQuote.FirstOrDefaultAsync(m => m.DeskQuoteID == id);

            if (DeskQuote == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DeskQuote = await _context.DeskQuote.FindAsync(id);

            if (DeskQuote != null)
            {
                _context.DeskQuote.Remove(DeskQuote);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
