using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Pride.Model
{
    public class StateList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StateID { get; set; }
        [Required]

        [MaxLength(50)]
        public string StateName { get; set; }
        [Required]

        [MaxLength(2)]
        public string StateAbbreviation { get; set; }
    }
}
