using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pride.Model;

using Microsoft.EntityFrameworkCore;
using Pride.Models;

namespace Pride.Areas.Dashboard.Pages.TblUserList
{
    public class CreateModel : PageModel
    {
        private readonly DatabaseContext _context;
        [BindProperty]
        public List<MenuList> MenuList { get; set; }
        public CreateModel(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet()
        {
            MenuList = await _context.TblMenuList.ToListAsync();

            return Page();
        }

        [BindProperty]
        public TblUser TblUser { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(List<string> menu)
        {


            await _context.TblUser.AddAsync(TblUser);
            string MenuList = string.Empty;
            foreach (var item in menu)
            {
                MenuList = item;
                TblAssignRoleToUser user = new TblAssignRoleToUser();
                user.Role = Convert.ToInt32(MenuList);
                user.Email = TblUser.Email;
                await _context.TblAssignRoleToUser.AddAsync(user);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
