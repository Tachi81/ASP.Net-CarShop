using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CarShop.Service;
using CarWithWebApi2.Models;

namespace CarWithWebApi2.Controllers
{
    public class EmailController : ApiController
    {
        // GET: api/EmailApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/EmailApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/EmailApi
        [ResponseType(typeof(EmailApiModel))]
        public IHttpActionResult PostPerformance(EmailApiModel emailApiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = new EmailService();
            service.SendEmail(emailApiModel);


            return Ok();
        }

        // PUT: api/EmailApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EmailApi/5
        public void Delete(int id)
        {
        }
    }
}
