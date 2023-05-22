using EmployeeInfo.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace EmployeeInfo.Pages.Employee
{
    public class IndexModel : PageModel
    {
        IEmployeeRepository _employeeRepository;
        public IndexModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [BindProperty]
        public List<Entity.Employee> employeeList { get; set; }

        [BindProperty]
        public Entity.Employee employee { get; set; }

        [TempData]
        public string Message { get; set; }
        public void OnGet()
        {
           
        }

        public  PartialViewResult OnGetEmployeeListPartial()
        {
            employeeList = _employeeRepository.GetList();
            
            return new PartialViewResult
            {
                ViewName = "_EmployeeList",
                ViewData = new ViewDataDictionary<List<Entity.Employee>>(ViewData, employeeList)
            };
        }

        public PartialViewResult OnGetSearchEmp(string eName)
        {
            employeeList = _employeeRepository.GetEmpByName(eName);

            return new PartialViewResult
            {
                ViewName = "_EmployeeList",
                ViewData = new ViewDataDictionary<List<Entity.Employee>>(ViewData, employeeList)
            };
        }

        public IActionResult OnPostDelete(int id)
        {
            if (id > 0)
            {
                var count = _employeeRepository.DeleteEmployee(id);
                if (count > 0)
                {
                    Message = "Employee Deleted Successfully !";
                    return RedirectToPage("/Employee/Index");
                }
            }
            return Page();
        }
    }
}
