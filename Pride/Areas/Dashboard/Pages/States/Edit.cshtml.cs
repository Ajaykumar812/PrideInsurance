using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pride.Model;

namespace Pride.Areas.Dashboard.Pages.States
{
    public class EditModel : PageModel
    {
        private readonly Pride.Model.DatabaseContext _context;

        public EditModel(Pride.Model.DatabaseContext context)
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

            var statelist =  await _context.TblStates.FirstOrDefaultAsync(m => m.StateID == id);
            if (statelist == null)
            {
                return NotFound();
            }
            StateList = statelist;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(StateList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StateListExists(StateList.StateID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StateListExists(int id)
        {
            return _context.TblStates.Any(e => e.StateID == id);
        }
    }
}
