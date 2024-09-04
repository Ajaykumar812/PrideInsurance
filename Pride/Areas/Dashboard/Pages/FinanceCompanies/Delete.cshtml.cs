using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pride.Model;


namespace Pride.Areas.Dashboard.Pages.FinanceCompanies
{
    public class DeleteModel : PageModel
    {
        private readonly DatabaseContext _context;

        public DeleteModel(DatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FinanceCompany FinanceCompany { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financecompany = await _context.TblFinanceCompany.FirstOrDefaultAsync(m => m.Id == id);

            if (financecompany == null)
            {
                return NotFound();
            }
            else
            {
                FinanceCompany = financecompany;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financecompany = await _context.TblFinanceCompany.FindAsync(id);
            if (financecompany != null)
            {
                FinanceCompany = financecompany;
                _context.TblFinanceCompany.Remove(FinanceCompany);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
