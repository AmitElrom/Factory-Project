using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Factory_Project.Models;
using Factory_Project.Models.Business_Logics;

using System.Web.Http.Cors;

namespace Factory_Project.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class EmployeeController : ApiController
    {
        private static EmployeeBL BlEmployee = new EmployeeBL();

        // GET: api/Employee
        public IEnumerable<EmployeeExtended> Get(string fname = "", string lname = "", int department = 0)
        {
            return BlEmployee.GetEmployees(fname, lname, department);
        }

        // GET: api/Employee/5
        public EmployeeExtended Get(int id)
        {
            return BlEmployee.GetEmployee(id);
        }

        // POST: api/Employee
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Employee/5
        public string Put(int id, EmployeeExtended employee)
        {
            BlEmployee.UpdateEmployee(id, employee);

            return "Employee Updated !";
        }

        // DELETE: api/Employee/5
        public string Delete(int id)
        {
            BlEmployee.DeleteEmployee(id);

            return "Employee Deleted";
        }
    }
}
