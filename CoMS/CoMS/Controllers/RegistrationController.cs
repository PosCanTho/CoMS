using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoMS.Entities_Framework;
using CoMS.Models;
using CoMS.Resources;

namespace CoMS.Controllers
{
    public class RegistrationController : BaseController
    {
        [Authorize]
        [HttpGet]
        [Route("api/ListPackage")]
        public HttpResponseMessage ListConferencePackage(int conferenceId)
        {
            var model = new RegistrationModel();
            return ResponseSuccess(StringResource.Success, model.ListConferencePackage(conferenceId));
        }
    }
}
