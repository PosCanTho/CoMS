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
        private MYDB myDB = new MYDB();

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
        [Route("api/ConferenceUser")]
        public HttpResponseMessage ConferenceUser(String username)
        {
            var result = from ds in db.CONFERENCEs
                         join ac_con in db.ACCOUNT_FOR_CONFERENCE on ds.CONFERENCE_ID equals ac_con.CONFERENCE_ID
                         where ac_con.UserName == username
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
        [Route("api/PresentationSlotInSession")]
        public HttpResponseMessage PresentationSlotInSession(int conference_session_id)
        {
            var result = from slot in db.CONFERENCE_SESSION_PAPER_PRESENTATION_SLOT
                         join paper in db.PAPER_TEXT on slot.PAPER_ID equals paper.PAPER_ID
                         join consess in db.CONFERENCE_SESSION on slot.CONFERENCE_SESSION_ID equals consess.CONFERENCE_SESSION_ID
                         where slot.CONFERENCE_SESSION_ID == conference_session_id
                         select new
                         {
                             slot.PAPER_ID,
                             slot.CONFERENCE_SESSION_ID,
                             slot.PRESENTATION_SLOT_NUMBER,
                             slot.ON_SCHEDULE_OR_CANCELLED_OR_MOVED_PRESENTATION_SLOT,
                             slot.PRESENTATION_SLOT_ACTUAL_START_DATETIME,
                             slot.PRESENTATION_SLOT_ACTUAL_END_DATETIME,
                             slot.ON_TIME_START_OR_EARLY_START_OR_LATE_START,
                             slot.ON_TIME_END_OR_EARLY_END_OR_LATE_END,
                             slot.MOVED_TO_CONFERENCE_SESSION_ID,
                             slot.MOVED_TO_PRESENTATION_SLOT_NUMBER,
                             slot.NOTE,

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

                             consess.CONFERENCE_SESSION_NAME,
                             consess.CONFERENCE_SESSION_NAME_EN,
                             consess.FACILITY_ID,
                             consess.FACILITY_NAME,
                             consess.FACILITY_NAME_EN
                         };
            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(0, StringResource.Success, result.Distinct()));
            }
            else { return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(404, StringResource.Username_or_password_incorrect, null)); }
        }

        [HttpPost]
        [Route("api/ListAttendee")]
        public HttpResponseMessage ListAttendee(int conference_id, decimal personId)
        {
            var result = (from ac_con in db.ACCOUNT_FOR_CONFERENCE
                          join ac in db.ACCOUNTs on ac_con.UserName equals ac.UserName
                          join per in db.People on ac.PERSON_ID equals per.PERSON_ID
                          where ac_con.CONFERENCE_ID == conference_id && ac_con.CONFERENCE_ATTENDEE_RIGHT == true && ac.PERSON_ID != personId
                          select new
                           Presenter()
                          {
                              PERSON_ID = ac.PERSON_ID,
                              CURRENT_LAST_NAME = ac.CURRENT_LAST_NAME,
                              CURRENT_FIRST_NAME = ac.CURRENT_FIRST_NAME,
                              CURRENT_MIDDLE_NAME = ac.CURRENT_MIDDLE_NAME,
                              UserName = ac.UserName,
                              Email = ac.Email,
                              Image = ac.Image,
                              CURRENT_HOME_ORGANIZATION_ID = ac.CURRENT_HOME_ORGANIZATION_ID,
                              CURRENT_HOME_ORGANIZATION_NAME = ac.CURRENT_HOME_ORGANIZATION_NAME,
                              CURRENT_HOME_ORGANIZATION_NAME_EN = ac.CURRENT_HOME_ORGANIZATION_NAME_EN,
                              CURRENT_PHONE_NUMBER = per.CURRENT_PHONE_NUMBER,
                              BIRTH_DATE = per.BIRTH_DATE,
                              CURRENT_GENDER = per.CURRENT_GENDER,
                              CONFERENCE_ADMIN_RIGHT = ac_con.CONFERENCE_ADMIN_RIGHT,
                              REVIEWER_RIGHT = ac_con.REVIEWER_RIGHT,
                              CONFERENCE_BOARD_OF_REVIEW_CHAIR_RIGHT = ac_con.CONFERENCE_BOARD_OF_REVIEW_CHAIR_RIGHT,
                              AUTHOR_RIGHT = ac_con.AUTHOR_RIGHT,
                              PRESENTER_RIGHT = ac_con.PRESENTER_RIGHT,
                              CONFERENCE_ATTENDEE_RIGHT = ac_con.CONFERENCE_ATTENDEE_RIGHT,
                              SUPPORT_STAFF_RIGHT = ac_con.SUPPORT_STAFF_RIGHT,
                              CONFERENCE_ID = ac_con.CONFERENCE_ID,
                              CONFERENCE_NAME = ac_con.CONFERENCE_NAME,
                              FULL_NAME = ac.CURRENT_LAST_NAME + " " + ac.CURRENT_MIDDLE_NAME + " " + ac.CURRENT_FIRST_NAME
                          }).Distinct().ToList();
            if (result != null)
            {
                var bookmarkModel = new BookmarkModel();

                foreach (Presenter item in result)
                {
                    item.IS_BOOKMARK = bookmarkModel.CheckBookmark(personId, item.PERSON_ID.Value);
                }
                return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(0, StringResource.Success, result));
            }
            else { return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(404, StringResource.Username_or_password_incorrect, null)); }
        }

        [HttpPost]
        [Route("api/ListPresenter")]
        public HttpResponseMessage ListPresenter(int conference_id, decimal personId)
        {
            var result = (from ac_con in db.ACCOUNT_FOR_CONFERENCE
                          join ac in db.ACCOUNTs on ac_con.UserName equals ac.UserName
                          join per in db.People on ac.PERSON_ID equals per.PERSON_ID
                          where ac_con.CONFERENCE_ID == conference_id && ac_con.PRESENTER_RIGHT == true && ac.PERSON_ID != personId
                          select new
                           Presenter(){
                              PERSON_ID = ac.PERSON_ID,
                              CURRENT_LAST_NAME = ac.CURRENT_LAST_NAME,
                              CURRENT_FIRST_NAME = ac.CURRENT_FIRST_NAME,
                              CURRENT_MIDDLE_NAME = ac.CURRENT_MIDDLE_NAME,
                              UserName = ac.UserName,
                              Email = ac.Email,
                              Image = ac.Image,
                              CURRENT_HOME_ORGANIZATION_ID = ac.CURRENT_HOME_ORGANIZATION_ID,
                              CURRENT_HOME_ORGANIZATION_NAME = ac.CURRENT_HOME_ORGANIZATION_NAME,
                              CURRENT_HOME_ORGANIZATION_NAME_EN = ac.CURRENT_HOME_ORGANIZATION_NAME_EN,
                              CURRENT_PHONE_NUMBER = per.CURRENT_PHONE_NUMBER,
                              BIRTH_DATE = per.BIRTH_DATE,
                              CURRENT_GENDER = per.CURRENT_GENDER,
                              CONFERENCE_ADMIN_RIGHT = ac_con.CONFERENCE_ADMIN_RIGHT,
                              REVIEWER_RIGHT = ac_con.REVIEWER_RIGHT,
                              CONFERENCE_BOARD_OF_REVIEW_CHAIR_RIGHT = ac_con.CONFERENCE_BOARD_OF_REVIEW_CHAIR_RIGHT,
                              AUTHOR_RIGHT = ac_con.AUTHOR_RIGHT,
                              PRESENTER_RIGHT = ac_con.PRESENTER_RIGHT,
                              CONFERENCE_ATTENDEE_RIGHT = ac_con.CONFERENCE_ATTENDEE_RIGHT,
                              SUPPORT_STAFF_RIGHT = ac_con.SUPPORT_STAFF_RIGHT,
                              CONFERENCE_ID = ac_con.CONFERENCE_ID,
                              CONFERENCE_NAME = ac_con.CONFERENCE_NAME,
                              FULL_NAME = ac.CURRENT_LAST_NAME + " " + ac.CURRENT_MIDDLE_NAME + " " + ac.CURRENT_FIRST_NAME
                          }).Distinct().ToList();
            if (result != null)
            {
                var bookmarkModel = new BookmarkModel();

                foreach (Presenter item in result) {
                    item.IS_BOOKMARK = bookmarkModel.CheckBookmark(personId, item.PERSON_ID.Value);
                }
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

        [HttpPost]
        [Route("api/iOSMenuPlatform")]
        public HttpResponseMessage Conference(string user_name, int conference_id)
        {
            var result = from ac in db.MOBILEFORM_GROUP_ACCOUNT_FOR_CONFERENCE
                         join gro in db.MOBILEFORM_GROUP_MENU_FOR_CONFERENCE on ac.GROUP_ID equals gro.GROUP_ID
                         join menu in db.MOBILEFORM_MENU on gro.MENU_ID equals menu.MENU_ID
                         where ac.GROUP_ID == gro.GROUP_ID
                         && ac.CONFERENCE_ID == gro.CONFERENCE_ID
                         && gro.MENU_ID == menu.MENU_ID
                         && ac.UserName == user_name
                         && ac.CONFERENCE_ID == conference_id
                         && menu.MOBILE_PLATFORM_NAME.ToLower() == "iOS".ToLower()
                         select new
                         {
                             menu.MENU_ID,
                             menu.MENU_NAME,
                             menu.MENU_NAME_EN,
                             menu.MENU_ICON,
                             menu.MENU_ORDER_NUMBER

                         };

            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(0, StringResource.Success, result.Distinct().OrderBy(x => x.MENU_ORDER_NUMBER)));
            }
            else { return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(404, StringResource.Username_or_password_incorrect, null)); }
        }

        [HttpPost]
        [Route("api/CheckUserIsPresenter")]
        public HttpResponseMessage CheckUserIsPresenter(int personId, int conferenceId)
        {
            var result = from ac in db.ACCOUNT_FOR_CONFERENCE
                         join a in db.ACCOUNTs on ac.UserName equals a.UserName
                         where ac.CONFERENCE_ID == conferenceId && a.PERSON_ID == personId && ac.PRESENTER_RIGHT == true
                         select new {
                             ac.CONFERENCE_ID,
                             ac.UserName,
                             ac.CURRENT_FIRST_NAME,
                             ac.CURRENT_LAST_NAME,
                             ac.CURRENT_MIDDLE_NAME
                         };

            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(0, StringResource.Success, result));
            }
            else { return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(404, StringResource.Username_or_password_incorrect, null)); }
        }

        [HttpGet]
        [Route("api/ListOrganizationForConference")]
        public HttpResponseMessage ListOrganizationForConference (int conferenceId)
        {
            var listOrganization = new List<ORGANIZATION>();
            var conference = db.CONFERENCEs.SingleOrDefault(x => x.CONFERENCE_ID == conferenceId);
            if (conference.ORGANIZING_ORGANIZATION_ID_1 != null)
            {
                var or = db.ORGANIZATIONs.SingleOrDefault(x => x.ORGANIZATION_ID == conference.ORGANIZING_ORGANIZATION_ID_1);
                if (or != null)
                {
                    listOrganization.Add(or);
                }
            }
            if (conference.ORGANIZING_ORGANIZATION_ID_2 != null)
            {
                var or = db.ORGANIZATIONs.SingleOrDefault(x => x.ORGANIZATION_ID == conference.ORGANIZING_ORGANIZATION_ID_2);
                if (or != null)
                {
                    listOrganization.Add(or);
                }
            }
            if (conference.ORGANIZING_ORGANIZATION_ID_3 != null)
            {
                var or = db.ORGANIZATIONs.SingleOrDefault(x => x.ORGANIZATION_ID == conference.ORGANIZING_ORGANIZATION_ID_3);
                if (or != null)
                {
                    listOrganization.Add(or);
                }
            }
            if (conference.ORGANIZING_ORGANIZATION_ID_4 != null)
            {
                var or = db.ORGANIZATIONs.SingleOrDefault(x => x.ORGANIZATION_ID == conference.ORGANIZING_ORGANIZATION_ID_4);
                if (or != null)
                {
                    listOrganization.Add(or);
                }
            }
            if (conference.ORGANIZING_ORGANIZATION_ID_5 != null)
            {
                var or = db.ORGANIZATIONs.SingleOrDefault(x => x.ORGANIZATION_ID == conference.ORGANIZING_ORGANIZATION_ID_5);
                if (or != null)
                {
                    listOrganization.Add(or);
                }
            }
            if (conference.ORGANIZING_ORGANIZATION_ID_6 != null)
            {
                var or = db.ORGANIZATIONs.SingleOrDefault(x => x.ORGANIZATION_ID == conference.ORGANIZING_ORGANIZATION_ID_6);
                if (or != null)
                {
                    listOrganization.Add(or);
                }
            }
            if (conference.ORGANIZING_ORGANIZATION_ID_7 != null)
            {
                var or = db.ORGANIZATIONs.SingleOrDefault(x => x.ORGANIZATION_ID == conference.ORGANIZING_ORGANIZATION_ID_7);
                if (or != null)
                {
                    listOrganization.Add(or);
                }
            }
            if (conference.ORGANIZING_ORGANIZATION_ID_8 != null)
            {
                var or = db.ORGANIZATIONs.SingleOrDefault(x => x.ORGANIZATION_ID == conference.ORGANIZING_ORGANIZATION_ID_8);
                if (or != null)
                {
                    listOrganization.Add(or);
                }
            }
            if (conference.ORGANIZING_ORGANIZATION_ID_9 != null)
            {
                var or = db.ORGANIZATIONs.SingleOrDefault(x => x.ORGANIZATION_ID == conference.ORGANIZING_ORGANIZATION_ID_9);
                if (or != null)
                {
                    listOrganization.Add(or);
                }
            }
            if (conference.ORGANIZING_ORGANIZATION_ID_10 != null)
            {
                var or = db.ORGANIZATIONs.SingleOrDefault(x => x.ORGANIZATION_ID == conference.ORGANIZING_ORGANIZATION_ID_10);
                if (or != null)
                {
                    listOrganization.Add(or);
                }
            }

            var listResult = new List<Organization>();
            foreach (ORGANIZATION item in listOrganization)
            {
                var organization = new Organization();
                var id = item.ORGANIZATION_ID;
                organization.ORGANIZATION_ID = item.ORGANIZATION_ID;
                var name = item.ORGANIZATION_NAME;
                organization.ORGANIZATION_NAME = item.ORGANIZATION_NAME;
                organization.ORGANIZATION_NAME_EN = item.ORGANIZATION_NAME_EN;
                organization.ADDRESS = item.ADDRESS;
                organization.ORGANIZATION_WEBSITE = item.ORGANIZATION_WEBSITE;
                listResult.Add(organization);
            }
            

            return ResponseSuccess(StringResource.Success, listOrganization);
        }

        [HttpPost]
        [Route("api/ListPresentationSlotOfPresenter")]
        public HttpResponseMessage ListPresentationSlotOfPresenter(int person_id, int conference_id)
        {
            var result = from presentation in db.PRESENTER_CONFERENCE_SESSION_RELATIONSHIP
                         join paper in db.PAPER_TEXT on presentation.PAPER_ID equals paper.PAPER_ID
                         join conference_ss in db.CONFERENCE_SESSION on presentation.CONFERENCE_SESSION_ID equals conference_ss.CONFERENCE_SESSION_ID
                         join con_ss_paper in db.CONFERENCE_SESSION_PAPER_PRESENTATION_SLOT on paper.PAPER_ID equals con_ss_paper.PAPER_ID
                         where presentation.CONFERENCE_ID == conference_id && presentation.PERSON_ID == person_id
                         select
                         new
                         {
                             paper.PAPER_ID,
                             paper.PAPER_TEXT_TITLE_1,
                             paper.PAPER_TEXT_TITLE_2,
                             paper.PAPER_TEXT_TITLE_3,
                             paper.PAPER_TEXT_TITLE_4,
                             paper.PAPER_TEXT_TITLE_5,

                             paper.PAPER_TEXT_TITLE_EN_1,
                             paper.PAPER_TEXT_TITLE_EN_2,
                             paper.PAPER_TEXT_TITLE_EN_3,
                             paper.PAPER_TEXT_TITLE_EN_4,
                             paper.PAPER_TEXT_TITLE_EN_5,
                             paper.PAPER_TEXT_ATTACHED_FILENAME_1,
                             paper.PAPER_TEXT_ATTACHED_FILENAME_2,
                             paper.PAPER_TEXT_ATTACHED_FILENAME_3,
                             paper.PAPER_TEXT_ATTACHED_FILENAME_4,
                             paper.PAPER_TEXT_ATTACHED_FILENAME_5,

                             conference_ss.CONFERENCE_SESSION_ID,
                             conference_ss.CONFERENCE_SESSION_NAME,
                             conference_ss.CONFERENCE_SESSION_NAME_EN,
                             conference_ss.FACILITY_ID,
                             conference_ss.FACILITY_NAME,
                             conference_ss.FACILITY_NAME_EN,

                             con_ss_paper.PRESENTATION_SLOT_NUMBER,
                             con_ss_paper.PRESENTATION_SLOT_ACTUAL_START_DATETIME,
                             con_ss_paper.PRESENTATION_SLOT_ACTUAL_END_DATETIME,

                         };

            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(0, StringResource.Success, result.Distinct()));
            }
            else { return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(404, StringResource.Username_or_password_incorrect, null)); }

        }

        [HttpPost]
        [Route("api/GetFileName")]
        public HttpResponseMessage GetFileName(int conference_id)
        {
            var result = from authorPapaer in db.AUTHOR_PAPER_ABSTRACT_RELATIONSHIP

                         join paperAbstract in db.PAPER_ABSTRACT on authorPapaer.PAPER_ID equals paperAbstract.PAPER_ID

                         where authorPapaer.CONFERENCE_ID == conference_id

                         select
                         new
                         PaperFileName()
                         {
                             PAPER_ID = authorPapaer.PAPER_ID,
                             PAPER_ABSTRACT_ATTACHED_FILENAME_1 = paperAbstract.PAPER_ABSTRACT_ATTACHED_FILENAME_1,
                             PAPER_ABSTRACT_ATTACHED_FILENAME_2 = paperAbstract.PAPER_ABSTRACT_ATTACHED_FILENAME_2,
                             PAPER_ABSTRACT_ATTACHED_FILENAME_3 = paperAbstract.PAPER_ABSTRACT_ATTACHED_FILENAME_3,
                             PAPER_ABSTRACT_ATTACHED_FILENAME_4 = paperAbstract.PAPER_ABSTRACT_ATTACHED_FILENAME_4,
                             PAPER_ABSTRACT_ATTACHED_FILENAME_5 = paperAbstract.PAPER_ABSTRACT_ATTACHED_FILENAME_5,
                             IS_PAPER_ABSTRACT = true

                         };
            var result2 = from authorPaper in db.AUTHOR_PAPER_TEXT_RELATIONSHIP
                          join paperText in db.PAPER_TEXT on authorPaper.PAPER_ID equals paperText.PAPER_ID
                          where authorPaper.CONFERENCE_ID == conference_id
                          select
                          new
                           PaperFileName()
                          {
                              PAPER_ID = authorPaper.PAPER_ID,
                              PAPER_ABSTRACT_ATTACHED_FILENAME_1 = paperText.PAPER_TEXT_ATTACHED_FILENAME_1,
                              PAPER_ABSTRACT_ATTACHED_FILENAME_2 = paperText.PAPER_TEXT_ATTACHED_FILENAME_2,
                              PAPER_ABSTRACT_ATTACHED_FILENAME_3 = paperText.PAPER_TEXT_ATTACHED_FILENAME_3,
                              PAPER_ABSTRACT_ATTACHED_FILENAME_4 = paperText.PAPER_TEXT_ATTACHED_FILENAME_4,
                              PAPER_ABSTRACT_ATTACHED_FILENAME_5 = paperText.PAPER_TEXT_ATTACHED_FILENAME_5,
                              IS_PAPER_ABSTRACT = false

                          };

            if (result != null && result2 != null)
            {
                var listResult = new List<PaperFileName>();
                foreach (PaperFileName item in result)
                {
                    listResult.Add(item);
                }
                foreach (PaperFileName item in result2)
                {
                    listResult.Add(item);
                }
                return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(0, StringResource.Success, listResult.Distinct()));
            }
            else { return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(404, StringResource.Username_or_password_incorrect, null)); }
        }
    }

  
    class Presenter
    {
        public decimal? PERSON_ID { get; set; }
        public string CURRENT_LAST_NAME { get; set; }
        public string CURRENT_FIRST_NAME { get; set; }
        public string CURRENT_MIDDLE_NAME { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public decimal? CURRENT_HOME_ORGANIZATION_ID { get; set; }
        public string CURRENT_HOME_ORGANIZATION_NAME { get; set; }
        public string CURRENT_HOME_ORGANIZATION_NAME_EN { get; set; }
        public string CURRENT_PHONE_NUMBER { get; set; }
        public DateTime? BIRTH_DATE { get; set; }
        public decimal? CURRENT_GENDER { get; set; }
        public bool? CONFERENCE_ADMIN_RIGHT { get; set; }
        public bool? REVIEWER_RIGHT { get; set; }
        public bool? CONFERENCE_BOARD_OF_REVIEW_CHAIR_RIGHT { get; set; }
        public bool? AUTHOR_RIGHT { get; set; }
        public bool? PRESENTER_RIGHT { get; set; }
        public bool? CONFERENCE_ATTENDEE_RIGHT { get; set; }
        public bool? SUPPORT_STAFF_RIGHT { get; set; }
        public decimal? CONFERENCE_ID { get; set; }
        public string CONFERENCE_NAME { get; set; }
        public string CONFERENCE_NAME_EN { get; set; }
        public string FULL_NAME { get; set; }
        public bool IS_BOOKMARK { get; set; }
    }

    class Organization
    {
        public decimal ORGANIZATION_ID { get; set; }
        public string ORGANIZATION_NAME { get; set; }
        public string ORGANIZATION_NAME_EN { get; set; }
        public string ADDRESS { get; set; }
        public string ORGANIZATION_WEBSITE { get; set; }
    }

    class PaperFileName
    {
        public decimal PAPER_ID { get; set; }
        public string PAPER_ABSTRACT_ATTACHED_FILENAME_1 { get; set; }
        public string PAPER_ABSTRACT_ATTACHED_FILENAME_2 { get; set; }
        public string PAPER_ABSTRACT_ATTACHED_FILENAME_3 { get; set; }
        public string PAPER_ABSTRACT_ATTACHED_FILENAME_4 { get; set; }
        public string PAPER_ABSTRACT_ATTACHED_FILENAME_5 { get; set; }
        public bool IS_PAPER_ABSTRACT { get; set; }
    }
}
