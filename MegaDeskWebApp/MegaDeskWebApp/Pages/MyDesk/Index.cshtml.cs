using System;
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
    public class IndexModel : PageModel
    {
        private readonly MegaDeskWebApp.Data.MegaDeskWebAppContext _context;

        public IndexModel(MegaDeskWebApp.Data.MegaDeskWebAppContext context)
        {
            _context = context;
        }

        public IList<DeskQuote> DeskQuote { get;set; }

        [BindProperty(SupportsGet = true)]
        public String CustomerName { get; set; }
        public String FirstSort { get; set; }
        public String LastSort { get; set; }
        public String DateSort { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {

            var customerNames = from m in _context.DeskQuotes select m;

            FirstSort = sortOrder == "first_asc" ? "first_desc" : "first_asc";
            LastSort = sortOrder == "last_asc" ? "last_desc" : "last_asc";
            DateSort = sortOrder == "date_asc" ? "date_desc" : "date_asc";

            switch(sortOrder)
            {
                case "first_asc":
                    customerNames = customerNames.OrderBy(c => c.firstName);
                    break;
                case "first_desc":
                    customerNames = customerNames.OrderByDescending(c => c.firstName);
                    break;
                case "last_asc":
                    customerNames = customerNames.OrderBy(c => c.lastName);
                    break;
                case "last_desc":
                    customerNames = customerNames.OrderByDescending(c => c.lastName);
                    break;
                case "date_asc":
                    customerNames = customerNames.OrderBy(c => c.purchaseDate);
                    break;
                case "date_desc":
                    customerNames = customerNames.OrderByDescending(c => c.purchaseDate);
                    break;
            }

            if (!string.IsNullOrEmpty(CustomerName))
            {
                customerNames = customerNames.Where(c => c.firstName.Contains(CustomerName) | c.lastName.Contains(CustomerName));
                
            }

            DeskQuote = await customerNames.ToListAsync();
            foreach (var quote in DeskQuote)
            {
                quote.desk = _context.Desks.Find(quote.deskID);
            }
        }
    }
}
