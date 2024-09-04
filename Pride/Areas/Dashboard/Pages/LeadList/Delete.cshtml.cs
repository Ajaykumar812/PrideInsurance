using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pride.Model;


namespace Pride.Areas.Dashboard.Pages.LeadList
{
    public class DeleteModel : PageModel
    {
        private readonly DatabaseContext _context;

        public DeleteModel(DatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Leads Leads { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leads = await _context.TblLeads.FirstOrDefaultAsync(m => m.id == id);

            if (leads == null)
            {
                return NotFound();
            }
            else
            {
                Leads = leads;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leads = await _context.TblLeads.FindAsync(id);
            if (leads != null)
            {
                Leads = leads;
                _context.TblLeads.Remove(Leads);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
