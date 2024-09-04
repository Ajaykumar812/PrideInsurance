using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Pride.Model;
using Pride.Models;
using Pride.Storedprocedure;

namespace Pride.ViewComponents
{
    [ViewComponent(Name = "Menu")]
    public class CategoryViewComponent : ViewComponent
    {
        DatabaseContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CategoryViewComponent(DatabaseContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        // public List<Menu> Menu { get; set; }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var UserEmail = new SqlParameter("@Email", HttpContext.Session.GetString("LoggedUser"));
            List<SpUserMenu> Main = await _context.SpUserMenu.FromSqlRaw("SpUserMenu @Email", UserEmail).ToListAsync();
            string url = Request.Path;
            ChildViewModel models = new ChildViewModel(_context)
            {
                SpUserMenu = Main
            };
            return View("/Menu", models);


        }
    }
}
