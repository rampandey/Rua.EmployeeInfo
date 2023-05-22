using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EmployeeInfo.Entity
{
    public class Employee
    {
        [Key]
        [Display(Name = "Employee Id")]
        public int Id { get; set; }

        public int DepartmentId { get; set; }

        [Required]
        [Display(Name = "Employee Name")]
        [StringLength(25, ErrorMessage = "Name should be 1 to 25 char in lenght")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Address")]
        [StringLength(50, ErrorMessage = "Name should be 1 to 50 char in lenght")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Salary")]
        public int Salary { get; set; }

        public List<SelectListItem> RequeststatusList { get; set; }
    }
}
