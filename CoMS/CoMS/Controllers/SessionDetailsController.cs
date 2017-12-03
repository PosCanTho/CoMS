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
    public class SessionDetailsController : ApiController
    {
        private DB db = new DB();

        [HttpGet]
        [Route("api/PresenterSession")]
        public HttpResponseMessage PresenterSession(int conference_session_id, string user_name)
        {
            var listPresenter = new List<PresenterSession>();
            var query = (db.PRESENTER_CONFERENCE_SESSION_RELATIONSHIP
                        .Join(db.ACCOUNTs, relationship => relationship.PERSON_ID, ac => ac.PERSON_ID, (relationship, ac ) => new { relationship, ac }))
                        .Where(x => x.relationship.CONFERENCE_SESSION_ID == conference_session_id)
                        .AsEnumerable()
                        .Select(x => new PresenterSession
                        {
                            PERSON_ID = x.ac.PERSON_ID,
                            CURRENT_LAST_NAME = x.ac.CURRENT_LAST_NAME,
                            CURRENT_FIRST_NAME = x.ac.CURRENT_FIRST_NAME,
                            CURRENT_MIDDLE_NAME = x.ac.CURRENT_MIDDLE_NAME,
                            FULL_NAME = x.ac.CURRENT_LAST_NAME + " " + x.ac.CURRENT_MIDDLE_NAME + " " + x.ac.CURRENT_FIRST_NAME,
                            UserName = x.ac.UserName,
                            Email = x.ac.Email,
                            Image = x.ac.Image,
                            CURRENT_HOME_ORGANIZATION_ID = x.ac.CURRENT_HOME_ORGANIZATION_ID,
                            CURRENT_HOME_ORGANIZATION_NAME = x.ac.CURRENT_HOME_ORGANIZATION_NAME,
                            CURRENT_HOME_ORGANIZATION_NAME_EN = x.ac.CURRENT_HOME_ORGANIZATION_NAME_EN,
                            CONFERENCE_SESSION_ID = x.relationship.CONFERENCE_SESSION_ID,
                            IS_BOOKMARK = new FollowModel().CheckFollow(user_name, x.ac.UserName, Convert.ToInt32(x.relationship.CONFERENCE_ID))
                        });
            

            if (query != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(0, StringResource.Success, query));
            }
            else { return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(404, StringResource.Username_or_password_incorrect, null)); }
        }

        [HttpGet]
        [Route("api/FileDocuments")]
        public HttpResponseMessage FileDocuments(int conference_session_id)
        {
            var query1 = (db.CONFERENCE_SESSION_PAPER_PRESENTATION_SLOT
                        .Join(db.PAPER_ABSTRACT, session => session.PAPER_ID, paper => paper.PAPER_ID, (session, paper) => new { session, paper }))
                        .Where(x => x.session.CONFERENCE_SESSION_ID == conference_session_id)
                        .AsEnumerable()
                        .Select(x => new PaperFileName
                        {
                            PAPER_ID = x.paper.PAPER_ID,
                            PAPER_ABSTRACT_ATTACHED_FILENAME_1 = x.paper.PAPER_ABSTRACT_ATTACHED_FILENAME_1,
                            PAPER_ABSTRACT_ATTACHED_FILENAME_2 = x.paper.PAPER_ABSTRACT_ATTACHED_FILENAME_2,
                            PAPER_ABSTRACT_ATTACHED_FILENAME_3 = x.paper.PAPER_ABSTRACT_ATTACHED_FILENAME_3,
                            PAPER_ABSTRACT_ATTACHED_FILENAME_4 = x.paper.PAPER_ABSTRACT_ATTACHED_FILENAME_4,
                            PAPER_ABSTRACT_ATTACHED_FILENAME_5 = x.paper.PAPER_ABSTRACT_ATTACHED_FILENAME_5,
                            IS_PAPER_ABSTRACT = true
                        });
            var query2 = (db.CONFERENCE_SESSION_PAPER_PRESENTATION_SLOT
                        .Join(db.PAPER_TEXT, session => session.PAPER_ID, paper => paper.PAPER_ID, (session, paper) => new { session, paper }))
                        .Where(x => x.session.CONFERENCE_SESSION_ID == conference_session_id)
                        .AsEnumerable()
                        .Select(x => new PaperFileName
                        {
                            PAPER_ID = x.paper.PAPER_ID,
                            PAPER_ABSTRACT_ATTACHED_FILENAME_1 = x.paper.PAPER_TEXT_ATTACHED_FILENAME_1,
                            PAPER_ABSTRACT_ATTACHED_FILENAME_2 = x.paper.PAPER_TEXT_ATTACHED_FILENAME_2,
                            PAPER_ABSTRACT_ATTACHED_FILENAME_3 = x.paper.PAPER_TEXT_ATTACHED_FILENAME_3,
                            PAPER_ABSTRACT_ATTACHED_FILENAME_4 = x.paper.PAPER_TEXT_ATTACHED_FILENAME_4,
                            PAPER_ABSTRACT_ATTACHED_FILENAME_5 = x.paper.PAPER_TEXT_ATTACHED_FILENAME_5,
                            IS_PAPER_ABSTRACT = false
                        });
            var listResult = new List<PaperFileName>();
            foreach (PaperFileName item in query1)
            {
                listResult.Add(item);
            }
            foreach (PaperFileName item in query2)
            {
                listResult.Add(item);
            }
            if (listResult != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(0, StringResource.Success, listResult.OrderBy(x => x.PAPER_ID)));
            }
            else { return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(404, StringResource.Username_or_password_incorrect, null)); }
        }

        [HttpGet]
        [Route("api/Attending")]
        public HttpResponseMessage Attending(int conference_session_id) {

            var listResult = (db.CONFERENCE_ATTENDEE_IN_REGISTERED_CONFERENCE_SESSION
                        .Join(db.ACCOUNTs, attendee => attendee.PERSON_ID, acc => acc.PERSON_ID, (attendee, acc) => new { attendee, acc }))
                        .Where(x => x.attendee.CONFERENCE_SESSION_ID == conference_session_id)
                        .AsEnumerable()
                        .Select(x => new { x.acc.Image, x.acc.CURRENT_FIRST_NAME, x.acc.CURRENT_LAST_NAME });

            if (listResult != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(0, StringResource.Success, listResult));
            }
            else { return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(404, StringResource.Username_or_password_incorrect, null)); }
        }
    }
    public class PresenterSession {
        public decimal? PERSON_ID { get; set; }
        public string CURRENT_LAST_NAME { get; set; }
        public string CURRENT_FIRST_NAME { get; set; }
        public string CURRENT_MIDDLE_NAME { get; set; }
        public string FULL_NAME { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public decimal? CURRENT_HOME_ORGANIZATION_ID { get; set; }
        public string CURRENT_HOME_ORGANIZATION_NAME { get; set; }
        public string CURRENT_HOME_ORGANIZATION_NAME_EN { get; set; }
        public decimal? CONFERENCE_SESSION_ID { get; set; }
        public bool IS_BOOKMARK { get; set; }
    }
}
