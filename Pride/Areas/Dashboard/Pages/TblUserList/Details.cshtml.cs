using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pride.Model;


namespace Pride.Areas.Dashboard.Pages.TblUserList
{
    public class DetailsModel : PageModel
    {
        private readonly DatabaseContext _context;

        public DetailsModel(DatabaseContext context)
        {
            _context = context;
        }

        public TblUser TblUser { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbluser = await _context.TblUser.FirstOrDefaultAsync(m => m.Id == id);
            if (tbluser == null)
            {
                return NotFound();
            }
            else
            {
                TblUser = tbluser;
            }
            return Page();
        }
    }
}
