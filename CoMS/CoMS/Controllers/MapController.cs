using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoMS.Models;
using CoMS.Resources;
using CoMS.Entities_Framework;

namespace CoMS.Controllers
{
    public class MapController : BaseController
    {
        [HttpGet]
        [Route("api/ListConferenceMap")]
        public HttpResponseMessage ListConferenceMap(decimal conferenceId)
        {
            var model = new ConferenceMapModel();
            var list = model.ListConfereceMap(conferenceId);
            return ResponseSuccess(StringResource.Success, list);
        }

        [HttpGet]
        [Route("api/ListConferenceLocation")]
        public HttpResponseMessage ListConferenceLocation(decimal conferenceMapId)
        {
            var model = new ConferenceMapModel();
            var list = model.ListConferenceLocation(conferenceMapId);
            return ResponseSuccess(StringResource.Success, list);
        }
    }
}
