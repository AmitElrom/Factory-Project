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

    public class DepartmentController : ApiController
    {
        private static DepartmentBL BlDepartment = new DepartmentBL();

        // GET: api/Department
        public IEnumerable<DepartmentExtended> Get()
        {
            return BlDepartment.GetDepartments();
        }

        // GET: api/Department/5
        public DepartmentExtended Get(int id)
        {
            return BlDepartment.GetDepartment(id);
        }

        // POST: api/Department
        public string Post(DepartmentExtended department)
        {
            BlDepartment.AddDepartment(department);

            return "Department Created !";
        }

        // PUT: api/Department/5
        public string Put(int id, DepartmentExtended department)
        {
            BlDepartment.UpdateDepartment(id, department);

            return "Department Updated !";
        }

        // DELETE: api/Department/5
        public string Delete(int id)
        {
            BlDepartment.DeleteDepartment(id);

            return "Department Deleted !";
        }
    }
}
