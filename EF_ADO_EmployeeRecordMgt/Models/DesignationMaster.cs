using System.ComponentModel.DataAnnotations;

namespace EF_ADO_EmployeeRecordMgt.Models
{
    public class DesignationMaster
    {
        [Key]
        public int DesignId { get; set; }
        [Required(ErrorMessage = "please enter Designation Name")]
        [Display(Name = "Designation Name")]
        [StringLength(32, MinimumLength = 3, ErrorMessage = "String length must be in between 3 to 20")]
        public string DesignName { get; set; }
    }
}
