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
    public class DeleteModel : PageModel
    {
        private readonly Pride.Model.DatabaseContext _context;

        public DeleteModel(Pride.Model.DatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StateList StateList { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statelist = await _context.TblStates.FirstOrDefaultAsync(m => m.StateID == id);

            if (statelist == null)
            {
                return NotFound();
            }
            else
            {
                StateList = statelist;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statelist = await _context.TblStates.FindAsync(id);
            if (statelist != null)
            {
                StateList = statelist;
                _context.TblStates.Remove(StateList);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
