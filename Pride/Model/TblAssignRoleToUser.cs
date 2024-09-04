using System.ComponentModel.DataAnnotations;

namespace Pride.Model
{
    public class TblAssignRoleToUser
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email address format")]

        public string   Email { get; set; }
        [Required]
        [StringLength(50)]
        public int Role { get; set; }
    }
}