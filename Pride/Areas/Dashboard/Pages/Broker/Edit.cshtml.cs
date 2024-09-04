using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pride.Model;


namespace Pride.Areas.Dashboard.Pages.Broker
{
    public class EditModel : PageModel
    {
        private readonly DatabaseContext _context;

        public EditModel(DatabaseContext context)
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

            var brokers =  await _context.TblBrokers.FirstOrDefaultAsync(m => m.Id == id);
            if (brokers == null)
            {
                return NotFound();
            }
            Brokers = brokers;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Brokers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrokersExists(Brokers.Id))
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

        private bool BrokersExists(int id)
        {
            return _context.TblBrokers.Any(e => e.Id == id);
        }
    }
}
