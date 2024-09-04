using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pride.Model;


namespace Pride.Areas.Dashboard.Pages.LeadList
{
    public class EditModel : PageModel
    {
        private readonly DatabaseContext _context;

        public EditModel(DatabaseContext context)
        {

            _context = context;
        }

        [BindProperty]
        public Leads Leads { get; set; } = default!;
        public List<SelectListItem> StateList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leads =  await _context.TblLeads.FirstOrDefaultAsync(m => m.id == id);
            StateList = await _context.TblStates.Select(s => new SelectListItem { Text = s.StateName, Value = s.StateName }).ToListAsync();
            if (leads == null)
            {
                return NotFound();
            }
            Leads = leads;
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

            _context.Attach(Leads).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeadsExists(Leads.id))
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

        private bool LeadsExists(int id)
        {
            return _context.TblLeads.Any(e => e.id == id);
        }
    }
}
