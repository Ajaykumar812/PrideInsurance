using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pride.Model;


namespace Pride.Areas.Dashboard.Pages.Broker
{
    public class DeleteModel : PageModel
    {
        private readonly DatabaseContext _context;

        public DeleteModel(DatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Brokers Brokers { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brokers = await _context.TblBrokers.FirstOrDefaultAsync(m => m.Id == id);

            if (brokers == null)
            {
                return NotFound();
            }
            else
            {
                Brokers = brokers;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brokers = await _context.TblBrokers.FindAsync(id);
            if (brokers != null)
            {
                Brokers = brokers;
                _context.TblBrokers.Remove(Brokers);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
