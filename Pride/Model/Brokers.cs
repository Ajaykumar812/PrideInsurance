using System.ComponentModel.DataAnnotations;

namespace Pride.Model
{
    public class Brokers
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string BrokerName { get; set; }
        [Required]
        [StringLength(200)]
        public string Address { get; set; }
        [Required]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Invalid Phone Number ")]
        public string PhoneNumber { get; set; }
        [Required ]
        public string CompanyName { get; set; }
    }
}
