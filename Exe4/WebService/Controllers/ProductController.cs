using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClassLibrary;

namespace WebService.Controllers
{
    public class ProductController : ApiController
    {
        // GET api/<controller>
        [Route("api/product/{productName}")]
        public dynamic Get(string productName)
        {
            CafeteriaDB db = new CafeteriaDB();

            return db.Products.Where(x => x.name == productName).Select(y => new
            {
                number = y.number,
                inv = y.inv,
                price = y.price,
            }).ToList();
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
        [Route("api/product/{productInv}")]
        public void Put(int productInv, [FromBody]string productName)
        {

            CafeteriaDB db = new CafeteriaDB();
            Product p = db.Products.SingleOrDefault(x => x.name == productName);

            if (p != null)
            {
                p.inv = productInv;
                db.SaveChanges();
            }

        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}