using System.ComponentModel.DataAnnotations;

namespace Pride.Model
{
    public class FinanceCompany
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FinanceCompanyName { get; set; }
            [Required]
        [StringLength(50)]
        public string Address { get; set; }
            [Required]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Invalid Phone Number ")]
        public string ContactNumber { get; set; }
    }
}
