using EmployeeInfo.Entity;

namespace EmployeeInfo.Repository
{
    public interface IEmployeeRepository
    {
        int Add(Employee employee);

        List<Employee> GetList();

        Employee GetEmployee(int id);

        int EditEmployee(Employee employee);

        int DeleteEmployee(int id);

        List<Employee> GetEmpByName(string eName);

        List<Department> GetDepartmentList();
    }
}
