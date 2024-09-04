using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pride.Model;

namespace Pride.Areas.Dashboard.Pages.Client
{
    public class DeleteModel : PageModel
    {
        private readonly Pride.Model.DatabaseContext _context;

        public DeleteModel(Pride.Model.DatabaseContext context)
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

            var clients = await _context.TblClients.FirstOrDefaultAsync(m => m.id == id);

            if (clients == null)
            {
                return NotFound();
            }
            else
            {
                Clients = clients;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clients = await _context.TblClients.FindAsync(id);
            if (clients != null)
            {
                Clients = clients;
                _context.TblClients.Remove(Clients);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
