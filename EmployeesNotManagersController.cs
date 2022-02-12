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

    public class EmployeesNotManagersController : ApiController
    {
        private static EmployeeBL BlEmployee = new EmployeeBL();

        // GET: api/EmployeesNotManagers
        public IEnumerable<EmployeeExtended> Get()
        {
            return BlEmployee.GetEmployeesNotManagers();
        }

        // GET: api/EmployeesNotManagers/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/EmployeesNotManagers
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/EmployeesNotManagers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EmployeesNotManagers/5
        public void Delete(int id)
        {
        }
    }
}
