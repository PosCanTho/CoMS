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
        private DB db = new DB();

        [HttpPost]
        [Route("api/ListConferenceSessionMap")]
        public HttpResponseMessage ListConferenceSessionMap(decimal conferenceId)
        {
            var result = db.CONFERENCE_SESSION.Join(db.FACILITies, cs => cs.FACILITY_ID, f => f.FACILITY_ID, (cs, f) => new { cs, f}).Where(x => x.cs.CONFERENCE_ID == conferenceId).Select(x => new
            {
                x.cs.CONFERENCE_SESSION_ID,
                x.cs.CONFERENCE_SESSION_NAME,
                x.cs.CONFERENCE_SESSION_NAME_EN,
                x.cs.FACILITY_ID,
                x.cs.FACILITY_NAME,
                x.cs.FACILITY_NAME_EN,

                x.f.FACILITY_FLOORPLAN_LAYOUT_FILENAME,
                x.f.FACILITY_DIRECTION_MAP_FILENAME,
                x.f.FACILITY_LONGITUDE,
                x.f.FACILITY_LATITUDE
            });
            return ResponseSuccess(StringResource.Success, result);
        }

        [HttpGet]
        [Route("api/ListConferenceSessionLocation")]
        public HttpResponseMessage ListConferenceSessionLocation(decimal rootFacilityId)
        {
            var result = db.FACILITies.Where(x => x.ROOT_FACILITY_ID == rootFacilityId).Select(x => new {
                x.FACILITY_ID,
                x.FACILITY_NAME,
                x.FACILITY_NAME_EN,
                x.FACILITY_TYPE_NAME,
                x.FACILITY_TYPE_NAME_EN,
                x.DESCRIPTION,
                x.ROOT_FACILITY_ID,
                x.FACILITY_USAGE_STATUS,
                x.FACILITY_FLOORPLAN_LAYOUT_FILENAME,
                x.FACILITY_DIRECTION_MAP_FILENAME,
                x.FACILITY_LONGITUDE,
                x.FACILITY_LATITUDE,
            });
            return ResponseSuccess(StringResource.Success, result);
        }
    }
}
