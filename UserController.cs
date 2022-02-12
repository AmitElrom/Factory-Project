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

    public class UserController : ApiController
    {
        private static UserBL BlUser = new UserBL();

        // GET: api/User
        public IEnumerable<User> Get()
        {
            return BlUser.GetUsers();
        }

        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public string Put(int id)
        {
            return BlUser.UpdateUser(id);
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
