using Dapper;
using EmployeeInfo.Entity;
using System.Data.SqlClient;

namespace EmployeeInfo.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        IConfiguration _configuration;

        public EmployeeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int Add(Employee Employee)
        {
            var connectionString = this.GetConnection();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "INSERT INTO Employee(DepartmentId, Name, Address, Salary) VALUES(@DepartmentId, @Name, @Address, @Salary); SELECT CAST(SCOPE_IDENTITY() as INT);";
                    count = con.Execute(query, Employee);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return count;
            }
        }

        public int DeleteEmployee(int id)
        {
            var connectionString = this.GetConnection();
            var count = 0;

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "DELETE FROM Employee WHERE Id =" + id;
                    count = con.Execute(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return count;
            }
        }

        public int EditEmployee(Employee emp)
        {
            var connectionString = this.GetConnection();
            var count = 0;

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "UPDATE Employee SET DepartmentId = @DepartmentId, Name = @Name, Address = @Address, Salary = @Salary WHERE Id = @Id";
                    count = con.Execute(query, emp);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return count;
            }
        }

        public List<Employee> GetList()
        {
            var connectionString = this.GetConnection();
            List<Employee> emp = new List<Employee>();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Employee";
                    emp = con.Query<Employee>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return emp;
            }
        }

        public List<Department> GetDepartmentList()
        {
            var connectionString = this.GetConnection();
            List<Department> dep = new List<Department>();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Department";
                    dep = con.Query<Department>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return dep;
            }
        }

        public Employee GetEmployee(int id)
        {
            var connectionString = this.GetConnection();
            Employee emp = new Employee();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Employee WHERE Id =" + id;
                    emp = con.Query<Employee>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return emp;
            }
        }

        public List<Employee> GetEmpByName(string eName)
        {
            var connectionString = this.GetConnection();
            List<Employee> emp = new List<Employee>();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Employee WHERE Name LIKE '%" + eName + "%'";
                    emp = con.Query<Employee>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return emp;
            }
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("EmployeeContext").Value;
            return connection;
        }
    }
}
