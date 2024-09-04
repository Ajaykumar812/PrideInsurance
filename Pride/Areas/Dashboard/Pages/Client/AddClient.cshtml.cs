using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pride.Model;

namespace Pride.Areas.Dashboard.Pages.Client
{
    public class AddClientModel : PageModel
    {

        DatabaseContext _context;
        [BindProperty]
        public List<Clients> Clients { get; set; }

        public string Email { get; set; }

        public AddClientModel(DatabaseContext context)
        {
            _context = context;
        }
        public List<SelectListItem> BrokerList { get; set; }
        public List<SelectListItem> ClientInsuranceCompany { get; set; }
        public List<SelectListItem> financecompany { get; set; }

        public async Task<IActionResult> OnGet(string Emailid)
        {
            BrokerList = await _context.TblBrokers.Select(b => new SelectListItem { Text = b.BrokerName, Value = b.BrokerName }).ToListAsync();
            ClientInsuranceCompany = await _context.TblInsurance.Select(b => new SelectListItem { Text = b.InsuranceCompanyName, Value = b.InsuranceCompanyName }).ToListAsync();
            financecompany = await _context.TblFinanceCompany.Select(b => new SelectListItem { Text = b.FinanceCompanyName, Value = b.FinanceCompanyName }).ToListAsync();
            Email = Emailid;

            return Page();
        }
        public async Task<IActionResult> OnPost()
        {

            foreach (var Clients1 in Clients)
            {
                
                _context.TblClients.Add(Clients1);
            }

            await _context.SaveChangesAsync();



          

            return Page();
        }
    }
}






