using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClassLibrary;

namespace WebService.Controllers
{
    public class StudentController : ApiController
    {
        // GET api/<controller>
        [Route("api/student/{studentName}/{studentId}")]
        public dynamic Get(string studentName, int studentId)
        {

            CafeteriaDB db = new CafeteriaDB();
            if(db.Students.Any(x => x.id == studentId && x.name == studentName))
                return Request.CreateResponse(HttpStatusCode.OK, true);
            return Request.CreateResponse(HttpStatusCode.NotFound, false);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}