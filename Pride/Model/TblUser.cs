using System.ComponentModel.DataAnnotations;

namespace Pride.Model
{
    public class TblUser
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Invalid Phone Number ")]

        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(50)]

        public string Role { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
   

    }
}
