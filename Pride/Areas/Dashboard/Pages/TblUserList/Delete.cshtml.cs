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
    public class DeleteModel : PageModel
    {
        private readonly DatabaseContext _context;

        public DeleteModel(DatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbluser = await _context.TblUser.FindAsync(id);
            if (tbluser != null)
            {
                TblUser = tbluser;
                _context.TblUser.Remove(TblUser);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
