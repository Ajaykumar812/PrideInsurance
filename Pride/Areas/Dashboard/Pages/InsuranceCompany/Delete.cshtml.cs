using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pride.Model;


namespace Pride.Areas.Dashboard.Pages.InsuranceCompany
{
    public class DeleteModel : PageModel
    {
        private readonly DatabaseContext _context;

        public DeleteModel(DatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Insurance Insurance { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insurance = await _context.TblInsurance.FirstOrDefaultAsync(m => m.Id == id);

            if (insurance == null)
            {
                return NotFound();
            }
            else
            {
                Insurance = insurance;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insurance = await _context.TblInsurance.FindAsync(id);
            if (insurance != null)
            {
                Insurance = insurance;
                _context.TblInsurance.Remove(Insurance);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
