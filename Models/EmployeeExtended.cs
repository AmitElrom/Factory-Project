using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory_Project.Models
{
    public class EmployeeExtended
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StartWorkYear { get; set; }
        public string DepartmentName { get; set; }
        public List<Shift> Shifts { get; set; }

        //public EmployeeExtended EnployeeToDto(Employee employee)
        //{
        //    EmployeeExtended e = new EmployeeExtended();
        //    e.ID = employee.ID;
        //    e.FirstName = employee.FirstName;
        //    e.LastName = employee.LastName;
        //    e.StartWorkYear = employee.StartWorkYear;

        //    return e;
        //}
    }
}