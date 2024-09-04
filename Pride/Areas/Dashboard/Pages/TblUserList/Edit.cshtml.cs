using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pride.Model;

using Microsoft.Data.SqlClient;
using Pride.StoredProcedure;

namespace Pride.Areas.Dashboard.Pages.TblUserList
{
    public class EditModel : PageModel
    {
        private readonly DatabaseContext _context;

        public EditModel(DatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblUser TblUser { get; set; } = default!;
        public List<SpAssignedRoleList> SpAssignedRoleList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            TblUser = await _context.TblUser.FirstOrDefaultAsync(m => m.Id == id);
            var User_email = new SqlParameter("@Email", TblUser.Email);
            SpAssignedRoleList = await _context.SpAssignedRoleList.FromSqlRaw("SpAssignedRoleList @Email", User_email).ToListAsync();

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

            _context.Attach(TblUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblUserExists(TblUser.Id))
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

        private bool TblUserExists(int id)
        {
            return _context.TblUser.Any(e => e.Id == id);
        }
    }
}
