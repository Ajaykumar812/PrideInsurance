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
    public class DetailsModel : PageModel
    {
        private readonly DatabaseContext _context;

        public DetailsModel(DatabaseContext context)
        {
            _context = context;
        }

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
    }
}
