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
using PagedList;

namespace CoMS.Controllers
{
    public class ConferenceController : BaseController
    {
        private DB db = new DB();

        [HttpPost]
        [Route("api/ListConference")]
        public HttpResponseMessage Conference(int page = 1, int pageSize = 10)
        {
            var result = from ds in db.CONFERENCEs.OrderByDescending(x => x.CONFERENCE_ID).ToPagedList(page, pageSize)
                         select new
                         {
                             ds.CONFERENCE_ID,
                             ds.CONFERENCE_NAME,
                             ds.CONFERENCE_NAME_EN,
                             ds.CONFERENCE_TYPE_ID,
                             ds.CONFERENCE_TYPE_NAME,
                             ds.CONFERENCE_TYPE_NAME_EN,
                             ds.FROM_DATE,
                             ds.THRU_DATE,
                             ds.ORGANIZING_ORGANIZATION_ID_1,
                             ds.ORGANIZING_ORGANIZATION_NAME_1,
                             ds.ORGANIZING_ORGANIZATION_NAME_EN_1,
                             ds.ORGANIZING_ORGANIZATION_ID_2,
                             ds.ORGANIZING_ORGANIZATION_NAME_2,
                             ds.ORGANIZING_ORGANIZATION_NAME_EN_2,
                             ds.ORGANIZING_ORGANIZATION_ID_3,
                             ds.ORGANIZING_ORGANIZATION_NAME_3,
                             ds.ORGANIZING_ORGANIZATION_NAME_EN_3,
                             ds.ORGANIZING_ORGANIZATION_ID_4,
                             ds.ORGANIZING_ORGANIZATION_NAME_4,
                             ds.ORGANIZING_ORGANIZATION_NAME_EN_4,
                             ds.ORGANIZING_ORGANIZATION_ID_5,
                             ds.ORGANIZING_ORGANIZATION_NAME_5,
                             ds.ORGANIZING_ORGANIZATION_NAME_EN_5,
                             ds.ORGANIZING_ORGANIZATION_ID_6,
                             ds.ORGANIZING_ORGANIZATION_NAME_6,
                             ds.ORGANIZING_ORGANIZATION_NAME_EN_6,
                             ds.ORGANIZING_ORGANIZATION_ID_7,
                             ds.ORGANIZING_ORGANIZATION_NAME_7,
                             ds.ORGANIZING_ORGANIZATION_NAME_EN_7,
                             ds.ORGANIZING_ORGANIZATION_ID_8,
                             ds.ORGANIZING_ORGANIZATION_NAME_8,
                             ds.ORGANIZING_ORGANIZATION_NAME_EN_8,
                             ds.ORGANIZING_ORGANIZATION_ID_9,
                             ds.ORGANIZING_ORGANIZATION_NAME_9,
                             ds.ORGANIZING_ORGANIZATION_NAME_EN_9,
                             ds.ORGANIZING_ORGANIZATION_ID_10,
                             ds.ORGANIZING_ORGANIZATION_NAME_10,
                             ds.ORGANIZING_ORGANIZATION_NAME_EN_10,
                             ds.MAIN_FIELD_OF_STUDY_ID,
                             ds.MAIN_FIELD_OF_STUDY_NAME,
                             ds.MAIN_FIELD_OF_STUDY_NAME_EN,
                             ds.CONFERENCE_MAIN_THEME,
                             ds.CONFERENCE_MAIN_THEME_EN,
                             ds.NUMBER_OF_PAPER_ABSTRACT_SUBMISSION_DEADLINES,
                             ds.PAPER_ABSTRACT_DEADLINE_1,
                             ds.PAPER_ABSTRACT_DEADLINE_2,
                             ds.PAPER_ABSTRACT_DEADLINE_3,
                             ds.PAPER_ABSTRACT_DEADLINE_4,
                             ds.PAPER_ABSTRACT_DEADLINE_5,
                             ds.WORD_COUNT_LIMIT_OF_PAPER_ABSTRACT,
                             ds.NUMBER_OF_PAPER_TEXT_SUBMISSION_DEADLINES,
                             ds.PAPER_TEXT_DEADLINE_1,
                             ds.PAPER_TEXT_DEADLINE_2,
                             ds.PAPER_TEXT_DEADLINE_3,
                             ds.PAPER_TEXT_DEADLINE_4,
                             ds.PAPER_TEXT_DEADLINE_5,
                             ds.LIMIT_NUMBER_OF_PAGES_OF_PAPER_TEXT,
                             ds.SUGGESTED_PAPER_ABSTRACT_REVIEW_RATING_SCALE,
                             ds.SUGGESTED_PAPER_ABSTRACT_REVIEW_RATING_SCALE_STEP,
                             ds.SUGGESTED_PAPER_ABSTRACT_REVIEW_RATING_SCALE_START_POINT,
                             ds.SUGGESTED_PAPER_ABSTRACT_REVIEW_RATING_SCALE_END_POINT,
                             ds.SUGGESTED_PAPER_TEXT_REVIEW_RATING_SCALE,
                             ds.SUGGESTED_PAPER_TEXT_REVIEW_RATING_SCALE_STEP,
                             ds.SUGGESTED_PAPER_TEXT_REVIEW_RATING_SCALE_START_POINT,
                             ds.SUGGESTED_PAPER_TEXT_REVIEW_RATING_SCALE_END_POINT
                         };
            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(0, StringResource.Success, result));
            }
            else { return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(404, StringResource.Username_or_password_incorrect, null)); }
        }

        [HttpPost]
        [Route("api/ListOrganization")]
        public HttpResponseMessage ListOrganization(int organizing_organization_id)
        {
            var result = (from ds in db.ORGANIZATIONs
                          where ds.ORGANIZATION_ID == organizing_organization_id
                          select new
                          {
                              ds.ORGANIZATION_ID,
                              ds.ORGANIZATION_CODE,
                              ds.ORGANIZATION_NAME,
                              ds.ORGANIZATION_NAME_EN,
                              ds.ADDRESS,
                              ds.WARD,
                              ds.DISTRICT,
                              ds.CITY,
                              ds.STATE,
                              ds.COUNTRY,
                              ds.ORGANIZATION_TELEPHONE,
                              ds.ORGANIZATION_FAX,
                              ds.ORGANIZATION_EMAIL,
                              ds.ORGANIZATION_WEBSITE,
                              ds.ZIPCODE,
                              ds.POSTAL_CODE,
                              ds.DESCRIPTION,
                              ds.DESCRIPTION_EN,
                              ds.ESTABLISHED_DATE,
                              ds.ESTABLISHMENT_DOCUMENT_ID,
                              ds.ORGANIZATION_LOGO,
                              ds.ORGANIZATION_LOGO_FILE,
                              ds.ROOT_ORGANIZATION_ID,
                              ds.ORGANIZATION_ORDER_NUMBER,
                              ds.DELETED,
                              ds.DELETED_SCRIPT
                          }).Distinct();
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
                         join conference_session_topic in db.CONFERENCE_SESSION_TOPIC on ds.CONFERENCE_SESSION_TOPIC_ID equals conference_session_topic.CONFERENCE_SESSION_TOPIC_ID
                         //join conference_session_chair in db.CONFERENCE_SESSION_CHAIR on ds.CONFERENCE_ID equals conference_session_chair.CONFERENCE_ID
                         where ds.CONFERENCE_ID == conference_id
                         select new
                         {
                             ds.CONFERENCE_SESSION_ID,
                             ds.WALK_IN_OR_REGISTERED_SESSION,
                             ds.CONFERENCE_SESSION_TOPIC_ID,
                             ds.CONFERENCE_SESSION_TOPIC_NAME,
                             ds.CONFERENCE_SESSION_TOPIC_NAME_EN,
                             ds.CONFERENCE_SESSION_NAME,
                             ds.CONFERENCE_SESSION_NAME_EN,
                             ds.CONFERENCE_ID,
                             ds.CONFERENCE_NAME,
                             ds.CONFERENCE_NAME_EN,
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
                             ds.PRESENTATION_REVIEW_RATING_SCALE_END_POINT,
                             conference_session_topic.DESCRIPTION,
                             conference_session_topic.DESCRIPTION_EN,
                             conference_session_topic.CONFERENCE_MAIN_THEME,
                             conference_session_topic.CONFERENCE_MAIN_THEME_EN,
                             //conference_session_chair.CURRENT_FIRST_NAME,
                             //conference_session_chair.CURRENT_MIDDLE_NAME,
                             //conference_session_chair.CURRENT_LAST_NAME,
                             //conference_session_chair.CURRENT_PERSONAL_TITLE,
                             //conference_session_chair.CURRENT_SUFFIX
                         };
            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(0, StringResource.Success, result));
            }
            else { return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(404, StringResource.Username_or_password_incorrect, null)); }
        }

        [HttpPost]
        [Route("api/ListConferenceSessionPaperPresentationSlot")]
        public HttpResponseMessage ConferenceSessionPaperPresentationSlot(int conference_session_id)
        {
            var result = from presentation in db.PRESENTER_CONFERENCE_SESSION_RELATIONSHIP
                         join presenter in db.PRESENTERs on presentation.PERSON_ID equals presenter.PERSON_ID
                         join paper in db.PAPER_TEXT on presentation.PAPER_ID equals paper.PAPER_ID
                         join conference_session in db.CONFERENCE_SESSION on presentation.CONFERENCE_SESSION_ID equals conference_session.CONFERENCE_SESSION_ID
                         where presentation.CONFERENCE_SESSION_ID == conference_session_id
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

                             presenter.CURRENT_LAST_NAME,
                             presenter.CURRENT_FIRST_NAME,
                             presenter.CURRENT_MIDDLE_NAME,

                             paper.PAPER_TEXT_TITLE_1,
                             paper.PAPER_TEXT_TITLE_EN_1,
                             paper.PAPER_TEXT_TITLE_2,
                             paper.PAPER_TEXT_TITLE_EN_2,
                             paper.PAPER_TEXT_TITLE_3,
                             paper.PAPER_TEXT_TITLE_EN_3,
                             paper.PAPER_TEXT_TITLE_4,
                             paper.PAPER_TEXT_TITLE_EN_4,
                             paper.PAPER_TEXT_TITLE_5,
                             paper.PAPER_TEXT_TITLE_EN_5,

                             paper.PAPER_TEXT_WITHDRAWN,
                             paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT,
                             paper.FINAL_APPROVED_FULL_PAPER_OR_WORK_IN_PROGRESS,

                             conference_session.CONFERENCE_NAME,
                             conference_session.CONFERENCE_NAME_EN,
                             conference_session.CONFERENCE_SESSION_NAME,
                             conference_session.CONFERENCE_SESSION_NAME_EN,
                             conference_session.FACILITY_NAME,
                             conference_session.FACILITY_NAME_EN
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
            var result = (from at in db.CONFERENCE_ATTENDEE
                          join ac in db.ACCOUNTs on at.PERSON_ID equals ac.PERSON_ID
                          join ac_con in db.ACCOUNT_FOR_CONFERENCE on ac.UserName equals ac_con.UserName
                          where at.CONFERENCE_ID == conference_id
                          select new
                          {
                              at.PERSON_ID,
                              at.CURRENT_LAST_NAME,
                              at.CURRENT_FIRST_NAME,
                              at.CURRENT_MIDDLE_NAME,
                              at.CURRENT_PERSONAL_TITLE,
                              at.CURRENT_SUFFIX,
                              at.CURRENT_HOME_ORGANIZATION_ID,
                              at.CURRENT_HOME_ORGANIZATION_NAME,
                              at.CURRENT_HOME_ORGANIZATION_NAME_EN,
                              at.CONFERENCE_ID,
                              at.CONFERENCE_NAME,
                              at.CONFERENCE_NAME_EN,
                              at.REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_1,
                              at.REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_2,
                              at.REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_3,
                              at.REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_4,
                              at.REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_5,
                              at.REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_6,
                              at.REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_7,
                              at.REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_8,
                              at.REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_9,
                              at.REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_10,

                              ac_con.CONFERENCE_ADMIN_RIGHT,
                              ac_con.REVIEWER_RIGHT,
                              ac_con.CONFERENCE_BOARD_OF_REVIEW_CHAIR_RIGHT,
                              ac_con.AUTHOR_RIGHT,
                              ac_con.PRESENTER_RIGHT,
                              ac_con.CONFERENCE_ATTENDEE_RIGHT,
                              ac_con.SUPPORT_STAFF_RIGHT
                          }).Distinct();
            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(0, StringResource.Success, result));
            }
            else { return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(404, StringResource.Username_or_password_incorrect, null)); }
        }

        [HttpPost]
        [Route("api/ListPaperText")]
        public HttpResponseMessage ListPaperText(int conference_session_id)
        {
            var result = (from reviewer_text_relationship in db.REVIEWER_PAPER_TEXT_RELATIONSHIP
                          join ds in db.PAPER_TEXT on reviewer_text_relationship.PAPER_ID equals ds.PAPER_ID
                          join reviewer in db.REVIEWERs on reviewer_text_relationship.PERSON_ID equals reviewer.PERSON_ID
                          where ds.FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_ID == conference_session_id

                          select new
                          {
                              ds.PAPER_ID,
                              ds.PAPER_NUMBER_OR_CODE,
                              ds.PAPER_TEXT_TITLE_1,
                              ds.PAPER_TEXT_TITLE_EN_1,
                              ds.PAPER_TEXT_1,
                              ds.PAPER_TEXT_EN_1,
                              ds.PAPER_TEXT_ATTACHED_FILENAME_1,
                              ds.NUMBER_OF_PAGES_OF_PAPER_TEXT_1,
                              ds.FIRST_SUBMITTED_DATE_1,
                              ds.LAST_REVISED_DATE_1,

                              ds.PAPER_TEXT_TITLE_2,
                              ds.PAPER_TEXT_TITLE_EN_2,
                              ds.PAPER_TEXT_2,
                              ds.PAPER_TEXT_EN_2,
                              ds.PAPER_TEXT_ATTACHED_FILENAME_2,
                              ds.NUMBER_OF_PAGES_OF_PAPER_TEXT_2,
                              ds.FIRST_SUBMITTED_DATE_2,
                              ds.LAST_REVISED_DATE_2,

                              ds.PAPER_TEXT_TITLE_3,
                              ds.PAPER_TEXT_TITLE_EN_3,
                              ds.PAPER_TEXT_3,
                              ds.PAPER_TEXT_EN_3,
                              ds.PAPER_TEXT_ATTACHED_FILENAME_3,
                              ds.NUMBER_OF_PAGES_OF_PAPER_TEXT_3,
                              ds.FIRST_SUBMITTED_DATE_3,
                              ds.LAST_REVISED_DATE_3,

                              ds.PAPER_TEXT_TITLE_4,
                              ds.PAPER_TEXT_TITLE_EN_4,
                              ds.PAPER_TEXT_4,
                              ds.PAPER_TEXT_EN_4,
                              ds.PAPER_TEXT_ATTACHED_FILENAME_4,
                              ds.NUMBER_OF_PAGES_OF_PAPER_TEXT_4,
                              ds.FIRST_SUBMITTED_DATE_4,
                              ds.LAST_REVISED_DATE_4,

                              ds.PAPER_TEXT_TITLE_5,
                              ds.PAPER_TEXT_TITLE_EN_5,
                              ds.PAPER_TEXT_5,
                              ds.PAPER_TEXT_EN_5,
                              ds.PAPER_TEXT_ATTACHED_FILENAME_5,
                              ds.NUMBER_OF_PAGES_OF_PAPER_TEXT_5,
                              ds.FIRST_SUBMITTED_DATE_5,
                              ds.LAST_REVISED_DATE_5,

                              ds.PAPER_TEXT_WITHDRAWN,
                              ds.PAPER_TEXT_WITHDRAWN_SCRIPT,
                              ds.PAPER_TEXT_WITHDRAWN_DATE,
                              ds.PAPER_TEXT_WITHDRAWN_NOTE,
                              ds.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT,
                              ds.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT_SCRIPT,
                              ds.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT_DATE,
                              ds.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT_REVIEWER_PERSON_ID,
                              ds.FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_ID,
                              ds.FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_NAME,
                              ds.FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_NAME_EN,
                              ds.FINAL_APPROVED_FULL_PAPER_OR_WORK_IN_PROGRESS,
                              ds.FINAL_APPROVED_TYPE_OF_STUDY_ID,
                              ds.FINAL_APPROVED_TYPE_OF_STUDY_NAME,
                              ds.FINAL_APPROVED_TYPE_OF_STUDY_NAME_EN,
                              ds.FINAL_APPROVED_FOR_PRESENTATION,
                              ds.FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_ID,
                              ds.FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_NAME,
                              ds.FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_NAME_EN,

                              reviewer.PERSON_ID,
                              reviewer.CURRENT_LAST_NAME,
                              reviewer.CURRENT_MIDDLE_NAME,
                              reviewer.CURRENT_FIRST_NAME

                          }).Distinct();
            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(0, StringResource.Success, result));
            }
            else { return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(404, StringResource.Username_or_password_incorrect, null)); }
        }

        [HttpPost]
        [Route("api/ListPaperAbastract")]
        public HttpResponseMessage ListPaperAbastract(int paper_id)
        {
            var result = (from reviewer_abstract_relationship in db.REVIEWER_PAPER_ABSTRACT_RELATIONSHIP
                          join ds in db.PAPER_ABSTRACT on reviewer_abstract_relationship.PAPER_ID equals ds.PAPER_ID
                          join reviewer in db.REVIEWERs on reviewer_abstract_relationship.PERSON_ID equals reviewer.PERSON_ID
                          where ds.PAPER_ID == paper_id
                          select new
                          {
                              ds.PAPER_ID,
                              ds.PAPER_NUMBER_OR_CODE,
                              ds.PAPER_ABSTRACT_TITLE_1,
                              ds.PAPER_ABSTRACT_TITLE_EN_1,
                              ds.CONFERENCE_SESSION_TOPIC_ID_1,
                              ds.CONFERENCE_SESSION_TOPIC_NAME_1,
                              ds.CONFERENCE_SESSION_TOPIC_NAME_EN_1,
                              ds.PAPER_ABSTRACT_TEXT_1,
                              ds.PAPER_ABSTRACT_TEXT_EN_1,
                              ds.PAPER_ABSTRACT_ATTACHED_FILENAME_1,
                              ds.WORD_COUNT_OF_PAPER_ABSTRACT_1,
                              ds.KEYWORDS_1,
                              ds.FULL_PAPER_OR_WORK_IN_PROGRESS_1,
                              ds.TYPE_OF_STUDY_ID_1,
                              ds.TYPE_OF_STUDY_NAME_1,
                              ds.TYPE_OF_STUDY_NAME_EN_1,
                              ds.CONFERENCE_PRESENTATION_TYPE_ID_1,
                              ds.CONFERENCE_PRESENTATION_TYPE_NAME_1,
                              ds.CONFERENCE_PRESENTATION_TYPE_NAME_EN_1,
                              ds.FIRST_SUBMITTED_DATE_1,
                              ds.LAST_REVISED_DATE_1,
                              ds.PAPER_ABSTRACT_TITLE_2,
                              ds.PAPER_ABSTRACT_TITLE_EN_2,
                              ds.CONFERENCE_SESSION_TOPIC_ID_2,
                              ds.CONFERENCE_SESSION_TOPIC_NAME_2,
                              ds.CONFERENCE_SESSION_TOPIC_NAME_EN_2,
                              ds.PAPER_ABSTRACT_TEXT_2,
                              ds.PAPER_ABSTRACT_TEXT_EN_2,
                              ds.PAPER_ABSTRACT_ATTACHED_FILENAME_2,
                              ds.WORD_COUNT_OF_PAPER_ABSTRACT_2,
                              ds.KEYWORDS_2,
                              ds.FULL_PAPER_OR_WORK_IN_PROGRESS_2,
                              ds.TYPE_OF_STUDY_ID_2,
                              ds.TYPE_OF_STUDY_NAME_2,
                              ds.TYPE_OF_STUDY_NAME_EN_2,
                              ds.CONFERENCE_PRESENTATION_TYPE_ID_2,
                              ds.CONFERENCE_PRESENTATION_TYPE_NAME_2,
                              ds.CONFERENCE_PRESENTATION_TYPE_NAME_EN_2,
                              ds.FIRST_SUBMITTED_DATE_2,
                              ds.LAST_REVISED_DATE_2,
                              ds.LAST_REVISED_DATE_3,
                              ds.PAPER_ABSTRACT_TEXT_3,
                              ds.PAPER_ABSTRACT_TEXT_EN_3,
                              ds.PAPER_ABSTRACT_ATTACHED_FILENAME_3,
                              ds.WORD_COUNT_OF_PAPER_ABSTRACT_3,
                              ds.KEYWORDS_3,
                              ds.FULL_PAPER_OR_WORK_IN_PROGRESS_3,
                              ds.TYPE_OF_STUDY_ID_3,
                              ds.TYPE_OF_STUDY_NAME_3,
                              ds.TYPE_OF_STUDY_NAME_EN_3,
                              ds.CONFERENCE_PRESENTATION_TYPE_ID_3,
                              ds.CONFERENCE_PRESENTATION_TYPE_NAME_3,
                              ds.CONFERENCE_PRESENTATION_TYPE_NAME_EN_3,
                              ds.FIRST_SUBMITTED_DATE_3,
                              ds.LAST_REVISED_DATE_4,
                              ds.PAPER_ABSTRACT_TEXT_4,
                              ds.PAPER_ABSTRACT_TEXT_EN_4,
                              ds.PAPER_ABSTRACT_ATTACHED_FILENAME_4,
                              ds.WORD_COUNT_OF_PAPER_ABSTRACT_4,
                              ds.KEYWORDS_4,
                              ds.FULL_PAPER_OR_WORK_IN_PROGRESS_4,
                              ds.TYPE_OF_STUDY_ID_4,
                              ds.TYPE_OF_STUDY_NAME_4,
                              ds.TYPE_OF_STUDY_NAME_EN_4,
                              ds.CONFERENCE_PRESENTATION_TYPE_ID_4,
                              ds.CONFERENCE_PRESENTATION_TYPE_NAME_4,
                              ds.CONFERENCE_PRESENTATION_TYPE_NAME_EN_4,
                              ds.FIRST_SUBMITTED_DATE_4,
                              ds.LAST_REVISED_DATE_5,
                              ds.PAPER_ABSTRACT_TEXT_5,
                              ds.PAPER_ABSTRACT_TEXT_EN_5,
                              ds.PAPER_ABSTRACT_ATTACHED_FILENAME_5,
                              ds.WORD_COUNT_OF_PAPER_ABSTRACT_5,
                              ds.KEYWORDS_5,
                              ds.FULL_PAPER_OR_WORK_IN_PROGRESS_5,
                              ds.TYPE_OF_STUDY_ID_5,
                              ds.TYPE_OF_STUDY_NAME_5,
                              ds.TYPE_OF_STUDY_NAME_EN_5,
                              ds.CONFERENCE_PRESENTATION_TYPE_ID_5,
                              ds.CONFERENCE_PRESENTATION_TYPE_NAME_5,
                              ds.CONFERENCE_PRESENTATION_TYPE_NAME_EN_5,
                              ds.FIRST_SUBMITTED_DATE_5,
                              ds.PAPER_ABSTRACT_WITHDRAWN,
                              ds.PAPER_ABSTRACT_WITHDRAWN_SCRIPT,
                              ds.PAPER_ABSTRACT_WITHDRAWN_DATE,
                              ds.PAPER_ABSTRACT_WITHDRAWN_NOTE,
                              ds.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT,
                              ds.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_SCRIPT,
                              ds.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_DATE,
                              ds.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_REVIEWER_PERSON_ID,
                              ds.ASSIGNED_CONFERENCE_SESSION_TOPIC_ID,
                              ds.ASSIGNED_CONFERENCE_SESSION_TOPIC_NAME,
                              ds.ASSIGNED_CONFERENCE_SESSION_TOPIC_NAME_EN,

                              reviewer.PERSON_ID,
                              reviewer.CURRENT_LAST_NAME,
                              reviewer.CURRENT_MIDDLE_NAME,
                              reviewer.CURRENT_FIRST_NAME
                          }).Distinct();
            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(0, StringResource.Success, result));
            }
            else { return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(404, StringResource.Username_or_password_incorrect, null)); }
        }

        [HttpPost]
        [Route("api/ListSchedule")]
        public HttpResponseMessage ListSchedule(String username)
        {
            var result = (from ac in db.ACCOUNTs
                          join ac_con in db.ACCOUNT_FOR_CONFERENCE on ac.UserName equals ac_con.UserName
                          join con in db.CONFERENCEs on ac_con.CONFERENCE_ID equals con.CONFERENCE_ID
                          where ac.UserName == username
                          select new
                          {
                              con.CONFERENCE_ID,
                              con.CONFERENCE_NAME,
                              con.CONFERENCE_NAME_EN,
                              con.FROM_DATE,
                              con.THRU_DATE,
                          }).Distinct();
            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(0, StringResource.Success, result));
            }
            else { return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(404, StringResource.Username_or_password_incorrect, null)); }
        }
    }
}
