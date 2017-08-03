using CoMS.Entities_Framework;
using CoMS.Models;
using CoMS.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace CoMS.Controllers
{
    public class ConferenceController : BaseController
    {
        private DB db = new DB();
        [HttpPost]
        [Route("api/ListConference")]
        public HttpResponseMessage Conference(int conference_id)
        {
            var result = from ds in db.CONFERENCEs
                         select new
                         {
                             ds.CONFERENCE_ID,
                             ds.CONFERENCE_NAME,
                             ds.CONFERENCE_NAME_EN,
                             ds.CONFERENCE_TYPE_ID,
                             ds.CONFERENCE_TYPE_NAME,
                             ds.CONFERENCE_TYPE_NAME_EN,
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
        [Route("api/ListConferenceSession")]
        public HttpResponseMessage ConferenceSession(int conference_id)
        {
            var result = from ds in db.CONFERENCE_SESSION
                         select new
                         {
                             ds.CONFERENCE_SESSION_ID,
                             ds.WALK_IN_OR_REGISTERED_SESSION,
                             ds.CONFERENCE_SESSION_TOPIC_ID,
                             ds.CONFERENCE_SESSION_TOPIC_NAME,
                             ds.CONFERENCE_SESSION_TOPIC_NAME_EN,
                             ds.CONFERENCE_SESSION_NAME,
                             ds.CONFERENCE_SESSION_NAME_EN,
                             ds.START_DATETIME,
                             ds.END_DATETIME,
                             ds.FACILITY_ID,
                             ds.FACILITY_NAME,
                             ds.FACILITY_NAME_EN,
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
                             ds.PRESENTATION_SLOT_10_END_DATETIME,
                             ds.PRESENTATION_REVIEW_RATING_SCALE,
                             ds.PRESENTATION_REVIEW_RATING_SCALE_STEP,
                             ds.PRESENTATION_REVIEW_RATING_SCALE_START_POINT,
                             ds.PRESENTATION_REVIEW_RATING_SCALE_END_POINT
                         };
            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(0, StringResource.Success, result));
            }
            else { return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(404, StringResource.Username_or_password_incorrect, null)); }
        }

        [HttpPost]
        [Route("api/ListConferenceSessionPaperPresentationSlot")]
        public HttpResponseMessage ConferenceSessionPaperPresentationSlot()
        {
            var result = from presentation in db.PRESENTER_CONFERENCE_SESSION_RELATIONSHIP
                         join conference_session in db.CONFERENCE_SESSION on presentation.CONFERENCE_SESSION_ID equals conference_session.CONFERENCE_SESSION_ID
                         join person in db.People on presentation.PERSON_ID equals person.PERSON_ID
                         //where list_author_paper_text_relationship.PERSON_ID == idAuthor
                         select
                         new
                         {
                             presentation.PERSON_ID,
                             presentation.PAPER_ID,
                             presentation.CONFERENCE_ID,
                             presentation.CONFERENCE_SESSION_ID,
                             presentation.PRESENTATION_SLOT_NUMBER,
                             presentation.ACTUAL_PRESENTATION_SLOT_NUMBER,
                             presentation.ACTUAL_PRESENTATION_SLOT_START_DATETIME,
                             presentation.ACTUAL_PRESENTATION_SLOT_END_DATETIME,
                             presentation.ABSENT,
                             person.CURRENT_LAST_NAME,
                             person.CURRENT_FIRST_NAME,
                             person.CURRENT_MIDDLE_NAME
                         };
            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(0, StringResource.Success, result));
            }
            else { return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(404, StringResource.Username_or_password_incorrect, null)); }
        }

        [HttpPost]
        [Route("api/ListAttendee")]
        public HttpResponseMessage ListAttendee(int conference_id)
        {
            var result = (from ds in db.CONFERENCE_ATTENDEE
                         where ds.CONFERENCE_ID == conference_id
                         select new
                         {
                             ds.PERSON_ID,
                             ds.CURRENT_LAST_NAME,
                             ds.CURRENT_FIRST_NAME,
                             ds.CURRENT_MIDDLE_NAME,
                             ds.CURRENT_PERSONAL_TITLE,
                             ds.CURRENT_SUFFIX,
                             ds.CURRENT_HOME_ORGANIZATION_ID,
                             ds.CURRENT_HOME_ORGANIZATION_NAME,
                             ds.CURRENT_HOME_ORGANIZATION_NAME_EN,
                             ds.CONFERENCE_ID,
                             ds.CONFERENCE_NAME,
                             ds.CONFERENCE_NAME_EN,
                             ds.REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_1,
                             ds.REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_2,
                             ds.REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_3,
                             ds.REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_4,
                             ds.REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_5,
                             ds.REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_6,
                             ds.REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_7,
                             ds.REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_8,
                             ds.REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_9,
                             ds.REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_10
                         }).Distinct();
            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(0, StringResource.Success, result));
            }
            else { return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(404, StringResource.Username_or_password_incorrect, null)); }
        }
    }
}
