using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pride.Model;

namespace Pride.Areas.Dashboard.Pages.States
{
    public class IndexModel : PageModel
    {
        private readonly Pride.Model.DatabaseContext _context;

        public IndexModel(Pride.Model.DatabaseContext context)
        {
            _context = context;
        }

        public IList<StateList> StateList { get;set; } = default!;

        public async Task OnGetAsync()
        {
            StateList = await _context.TblStates.ToListAsync();
        }
    }
}
