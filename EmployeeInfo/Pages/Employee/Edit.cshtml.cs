using EmployeeInfo.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace EmployeeInfo.Pages.Employee
{
    public class EditModel : PageModel
    {
        IEmployeeRepository _employeeRepository;
        public EditModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        [BindProperty]
        public Entity.Employee employee { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            return Page();
        }

        public IActionResult OnPostEditEmployee([FromForm] Entity.Employee emp)
        {
            var count = _employeeRepository.EditEmployee(emp);
            if (count > 0)
            {
                string Msg = "Employee Updated Successfully !";
                return new JsonResult(Msg);
            }
            return Page();
        }
    }
}
