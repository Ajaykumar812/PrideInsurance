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
    public class CreateModel : PageModel
    {
        private readonly DatabaseContext _context;
        public List<SelectListItem> StateList { get; set; }

        public CreateModel(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet()
        {
            StateList=await _context.TblStates.Select(s=>new SelectListItem { Text=s.StateName,Value=s.StateName}).ToListAsync();
            return Page();
        }

        [BindProperty]
        public Leads Leads { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TblLeads.Add(Leads);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
