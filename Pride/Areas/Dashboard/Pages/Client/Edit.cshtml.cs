using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pride.Model;

namespace Pride.Areas.Dashboard.Pages.Client
{
    public class EditModel : PageModel
    {
        private readonly Pride.Model.DatabaseContext _context;

        public EditModel(Pride.Model.DatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Clients Clients { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clients =  await _context.TblClients.FirstOrDefaultAsync(m => m.id == id);
            if (clients == null)
            {
                return NotFound();
            }
            Clients = clients;
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

            _context.Attach(Clients).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientsExists(Clients.id))
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

        private bool ClientsExists(int id)
        {
            return _context.TblClients.Any(e => e.id == id);
        }
    }
}
