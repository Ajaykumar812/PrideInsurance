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
    public class DetailsModel : PageModel
    {
        private readonly Pride.Model.DatabaseContext _context;

        public DetailsModel(Pride.Model.DatabaseContext context)
        {
            _context = context;
        }

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
    }
}
