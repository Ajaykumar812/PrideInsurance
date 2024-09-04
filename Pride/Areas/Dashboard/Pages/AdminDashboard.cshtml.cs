using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pride.Model;


namespace Pride.Areas.Dashboard.Pages
{
    public class AdminDashboardModel : PageModel
    {
        private readonly DatabaseContext _context;
        public int TotalCustomers { get; set; }
        public int Leads { get; set; }

        public List<Leads> LeadsList { get; set; }
        public AdminDashboardModel(DatabaseContext context)
        {
            _context = context;
        }

        public IList<TblUser> TblUser { get;set; } = default!;

        public async Task OnGetAsync()
        {
            TblUser = await _context.TblUser.ToListAsync();
            TotalCustomers= TblUser.Count;
            Leads=await _context.TblLeads.CountAsync();
            LeadsList=await _context.TblLeads.OrderByDescending(e=>e.id).Take(5).ToListAsync();
        }
    }
}
