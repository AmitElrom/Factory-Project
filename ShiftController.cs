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

    public class ShiftController : ApiController
    {
        private static ShiftBL BlShift = new ShiftBL();
        // GET: api/Shift
        public IEnumerable<ShiftExtended> Get()
        {
            return BlShift.GetShifts();
        }

        // GET: api/Shift/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Shift
        public string Post(Shift shift)
        {
            BlShift.AddShift(shift);

            return "Shift Created !";
        }

        // PUT: api/Shift/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Shift/5
        public void Delete(int id)
        {
        }
    }
}
