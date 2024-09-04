using System.ComponentModel.DataAnnotations;

namespace Pride.Models
{
    public class MenuList
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Menu { get; set; }
        [Required]
        [StringLength(50)]
        public string Url { get; set; }
        [Required]
        [StringLength(50)]
        public string Icon { get; set; }
    }
}
