using System.ComponentModel.DataAnnotations;

namespace EF_ADO_EmployeeRecordMgt.Models
{
    public class DepartmentMaster
    {
        [Key]
        public int DeptId { get; set; }

        [Required(ErrorMessage = "please enter department Name")]
        [StringLength(32, MinimumLength = 3, ErrorMessage = "String length must be in between 3 to 20")]
        [Display(Name = "Department Name")]
        public string DeptName { get; set; }
    }
}
