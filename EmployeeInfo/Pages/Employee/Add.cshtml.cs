using EmployeeInfo.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeInfo.Pages.Employee
{
    public class AddModel : PageModel
    {
        IEmployeeRepository _employeeRepository;
        public AddModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [BindProperty]
        public Entity.Employee employee { get; set; }

        [TempData]
        public string Message { get; set; }
        public void OnGet()
        {

        }

        public PartialViewResult OnGetAddEditEmployee(string id)
        {
            Entity.Employee emp = new Entity.Employee();
            var depList = _employeeRepository.GetDepartmentList();

            if (id != "0")
            {
                emp = _employeeRepository.GetEmployee(Convert.ToInt32(id));
                emp.RequeststatusList = depList.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
                return Partial("_AddEditEmployee", emp);
            }
            emp.Id = Convert.ToInt32(id);
            emp.RequeststatusList = depList.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            return Partial("_AddEditEmployee", emp);
        }
        public IActionResult OnPost()
        {
            return Page();
        }

        public IActionResult OnPostAddEmployee([FromForm] Entity.Employee emp)
        {
            var count = _employeeRepository.Add(emp);
            if (count > 0)
            {
                Message = "New employee Added Successfully !";
                return new JsonResult(Message);
            }
            return Page();
        }
    }
}
