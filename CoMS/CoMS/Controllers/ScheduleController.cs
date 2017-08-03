using CoMS.Entities_Framework;
using CoMS.Models;
using CoMS.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoMS.Controllers
{
    public class ScheduleController : ApiController
    {
        private DB db = new DB();
        [HttpPost]
        [Route("api/Schedule")]
        public HttpResponseMessage Schedule()
        {
            var result = from ds in db.CONFERENCE_ATTENDEE_IN_REGISTERED_CONFERENCE_SESSION
                         join conference_session in db.CONFERENCE_SESSION on ds.CONFERENCE_SESSION_ID equals conference_session.CONFERENCE_SESSION_ID
                         select new
                         {
                             ds.PERSON_ID,
                             ds.CONFERENCE_ID,
                             ds.CONFERENCE_SESSION_ID,
                             conference_session.CONFERENCE_SESSION_NAME,
                             conference_session.CONFERENCE_SESSION_NAME_EN,
                             ds.FROM_DATE,
                             ds.THRU_DATE
                         };
            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(0, StringResource.Success, result));
            }
            else { return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(404, StringResource.Username_or_password_incorrect, null)); }
        }

        [HttpPost]
        [Route("api/ScheduleInSession")]
        public HttpResponseMessage ScheduleInSession(int conference_id)
        {
            var result = from ds in db.CONFERENCE_SESSION
                             //join conference_session in db.CONFERENCE_SESSION on ds.CONFERENCE_SESSION_ID equals conference_session.CONFERENCE_SESSION_ID
                         where ds.CONFERENCE_SESSION_ID == conference_id
                         select new
                         {
                             ds.CONFERENCE_ID,
                             ds.CONFERENCE_SESSION_ID,
                             ds.CONFERENCE_SESSION_NAME,
                             ds.CONFERENCE_SESSION_NAME_EN,
                             ds.START_DATETIME,
                             ds.END_DATETIME,
                             ds.NUMBER_OF_PRESENTATION_SLOTS,
                             ds.PRESENTATION_SLOT_1_START_DATETIME,
                             ds.PRESENTATION_SLOT_1_END_DATETIME,
                             ds.PRESENTATION_SLOT_2_START_DATETIME,
                             ds.PRESENTATION_SLOT_2_END_DATETIME,
                             ds.PRESENTATION_SLOT_3_START_DATETIME,
                             ds.PRESENTATION_SLOT_3_END_DATETIME,
                             ds.PRESENTATION_SLOT_4_START_DATETIME,
                             ds.PRESENTATION_SLOT_4_END_DATETIME,
                             ds.PRESENTATION_SLOT_5_START_DATETIME,
                             ds.PRESENTATION_SLOT_5_END_DATETIME,
                             ds.PRESENTATION_SLOT_6_START_DATETIME,
                             ds.PRESENTATION_SLOT_6_END_DATETIME,
                             ds.PRESENTATION_SLOT_7_START_DATETIME,
                             ds.PRESENTATION_SLOT_7_END_DATETIME,
                             ds.PRESENTATION_SLOT_8_START_DATETIME,
                             ds.PRESENTATION_SLOT_8_END_DATETIME,
                             ds.PRESENTATION_SLOT_9_START_DATETIME,
                             ds.PRESENTATION_SLOT_9_END_DATETIME,
                             ds.PRESENTATION_SLOT_10_START_DATETIME,
                             ds.PRESENTATION_SLOT_10_END_DATETIME
                         };
            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(0, StringResource.Success, result));
            }
            else { return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(404, StringResource.Username_or_password_incorrect, null)); }
        }

        [HttpPost]
        [Route("api/MyScheduleInSession")]
        public HttpResponseMessage MyScheduleInSession(int conference_id)
        {
            var result = from ds in db.CONFERENCE_SESSION
                             //join conference_session in db.CONFERENCE_SESSION on ds.CONFERENCE_SESSION_ID equals conference_session.CONFERENCE_SESSION_ID
                         where ds.CONFERENCE_SESSION_ID == conference_id
                         select new { };
            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(0, StringResource.Success, result));
            }
            else { return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(404, StringResource.Username_or_password_incorrect, null)); }
        }
    }
}
