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

    public class EmployeeShiftController : ApiController
    {
        private static EmployeeShiftBL BlEmpShift = new EmployeeShiftBL();

        // GET: api/EmployeeShift
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/EmployeeShift/5

        // POST: api/EmployeeShift
        public string Post(EmployeeShift shift)
        {
            BlEmpShift.AddShiftToEmployee(shift);

            return "Shift Added To Employee";
        }

        // PUT: api/EmployeeShift/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EmployeeShift/5
        public void Delete(int id)
        {
        }
    }
}
