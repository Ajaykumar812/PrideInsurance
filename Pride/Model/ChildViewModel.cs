using Pride.Model;
using Pride.Storedprocedure;

namespace Pride.Models
{
    public class ChildViewModel
    {
       DatabaseContext _context;
        public List<SpUserMenu> SpUserMenu { get; set; }
        public ChildViewModel(DatabaseContext context)
        {
            _context = context;
        }
    }
}
