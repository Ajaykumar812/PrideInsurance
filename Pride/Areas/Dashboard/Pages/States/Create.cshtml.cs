using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pride.Model;

namespace Pride.Areas.Dashboard.Pages.States
{
    public class CreateModel : PageModel
    {
        private readonly Pride.Model.DatabaseContext _context;

        public CreateModel(Pride.Model.DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StateList StateList { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TblStates.Add(StateList);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
