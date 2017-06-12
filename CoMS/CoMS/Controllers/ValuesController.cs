using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoMS.Models;
using System.Web.Http.Description;
using CoMS.Resources;

namespace CoMS.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        [ResponseType(typeof(GetValue))]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(0, StringResource.Success, null));
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5 kiet/dung
        public void Delete(int id)
        {
        }
    }

    public class GetValue
    {
        public int errorCode { get; set; }
        public string message { get; set; }
        public List<object> data { get; set; }
    }
}
