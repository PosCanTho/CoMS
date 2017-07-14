using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoMS.Entities_Framework;
using CoMS.Resources;
using CoMS.Models;

namespace CoMS.Controllers
{
    public class AccountController : ApiController
    {
        private DB db = new DB();
        [HttpPost]
        public HttpResponseMessage Login(string username, string password)
        {
            var result = db.ACCOUNTs.SingleOrDefault(a => a.UserName == username);
            if (result != null)
            {
                var user = new UserResponse();
                user.Username = result.UserName;
                user.Last = result.CURRENT_LAST_NAME;
                user.Email = result.Email;
                return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(0, StringResource.Success, user));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(404, StringResource.Username_or_password_incorrect, null));
            }
        }
    }

    class UserResponse
    {
        public string Username { get;set; }
        public string Last { get; set; }
        public string Email { get; set; }
    }
}
