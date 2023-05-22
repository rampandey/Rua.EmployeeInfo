using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EmployeeInfo.Entity
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
