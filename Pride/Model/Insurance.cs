using System.ComponentModel.DataAnnotations;

namespace Pride.Model
{
    public class Insurance
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string InsuranceCompanyName { get; set; }
        [Required]
        [StringLength(200)]
        public string Address { get; set; }
        [Required]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Invalid Phone Number ")]
        public string ContactNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string WebsiteUrl { get; set; }
    }
}
