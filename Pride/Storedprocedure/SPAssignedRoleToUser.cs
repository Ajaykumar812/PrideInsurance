using System.ComponentModel.DataAnnotations;

namespace Pride.Storedprocedure
{
    public class SPAssignedRoleToUser
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Menu  { get; set; }
        [Required]
        [StringLength(50)]
        public string Url  { get; set; }
        [Required]
        [StringLength(50)]
        public string Role { get; set; }
    }
}
