using System.ComponentModel.DataAnnotations;

namespace Pride.Model
{
    public class Leads
    {
        public int id { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Company { get; set; }
        [Required]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Invalid Phone Number ")]
        public string ContactNo { get; set; }
        [Required]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email address format")]

        public string EMail { get; set; }
        [Required]
        [StringLength(50)]
        public string LeadStatus { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; }
        [Required]
        [StringLength(50)]
        public string EmpyeeName { get; set; }
        [Required]
        [StringLength(50)]
        public bool IsDeleted { get; set; }
        [Required]
        [StringLength(50)]
        public string ContactPerson { get; set; }
        [Required]
        [StringLength(50)]
        public string State { get; set; }
        [Required]
        [StringLength(50)]
        public string PowerUnit { get; set; }
        [Required]
       
        public DateTime EffectiveDate { get; set; }
        [Required]
        [StringLength(50)]
        public string TypeofPolicy { get; set; }
        [Required]
        [StringLength(50)]
        public string Dotno { get; set; }
    }
}