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
    public class IndexModel : PageModel
    {
        private readonly DatabaseContext _context;

        public IndexModel(DatabaseContext context)
        {
            _context = context;
        }

        public IList<FinanceCompany> FinanceCompany { get;set; } = default!;

        public async Task OnGetAsync()
        {
            FinanceCompany = await _context.TblFinanceCompany.ToListAsync();
        }
    }
}
