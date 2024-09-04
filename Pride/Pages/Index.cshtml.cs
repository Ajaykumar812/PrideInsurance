using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pride.Model;

namespace Pride.Pages
{
    public class IndexModel : PageModel
    {
		private readonly DatabaseContext _context;

		public IndexModel(DatabaseContext context)
		{
			_context = context;
		}

		public IActionResult OnGet()
		{
			return Page();
		}

		[BindProperty]
		public TblUser TblUser { get; set; } = default!;

		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
		public async Task<IActionResult> OnPostAsync()
		{
			if (TblUser.Email == null || TblUser.Password == null)
			{
				return Page();
			}
			var userType = await _context.TblUser.FirstOrDefaultAsync(x => x.Email == TblUser.Email && x.Password == TblUser.Password);
			if (userType != null)
			{
				HttpContext.Session.SetString("LoggedUser", userType.Email);
				HttpContext.Session.SetString("UserName", userType.UserName);
				HttpContext.Session.SetString("Role", userType.Role);
				if (userType.Role == "Admin")
				{
					return RedirectToPage("/AdminDashboard", new { area = "Dashboard" });
				}
				else
				{
					return RedirectToPage("/UserDashboard", new { area = "Dashboard" });
				}
			}
			return Page();
		}
	}
}