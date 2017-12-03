using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoMS.Resources;
using System.IO;
using Newtonsoft.Json;
using CoMS.Models;
using CoMS.Untils;
using CoMS.Entities_Framework;
using PagedList;


namespace CoMS.Controllers
{
    public class SurveyController : BaseController
    {
        private DB db = new DB();

        [HttpPost]
        [Route("api/ListSurvey")]
        public HttpResponseMessage ListSurvey(string userName, int conferenceId, int conferenceSessionId = -1)
        {
            var account = db.ACCOUNTs.SingleOrDefault(x => x.UserName == userName);
            var conference = db.CONFERENCEs.SingleOrDefault(x => x.CONFERENCE_ID == conferenceId);
            var surveyModel = new ConferenceSurveyModel();
            if (account == null)
            {
                return ResponseFail(StringResource.Account_does_not_exist);
            }
            else if (conference == null)
            {
                return ResponseFail(StringResource.Conference_do_not_exist);
            }
            else
            {
                if (conferenceSessionId >= 0)
                {
                    var session = db.CONFERENCE_SESSION.SingleOrDefault(x => x.CONFERENCE_SESSION_ID == conferenceSessionId);
                    if (session == null)
                    {
                        return ResponseFail(StringResource.Conference_session_do_not_exist);
                    }
                    else
                    {
                        List<MESSAGING_GROUP> groups = new MessageGroup().getListMessageGroup(userName);
                        var surveys = db.CONFERENCE_SURVEY.AsEnumerable()
                       .Where(x => x.CONFERENCE_ID == conferenceId
                       && x.SURVEY_FOR_CONFERENCE_SESSION_ID == conferenceSessionId
                       && ((surveyModel.checkGroupsInSurvey(groups, x) || surveyModel.checkUserNameInSurvey(userName, x)) || x.PUBLIC_OR_PRIVATE_CONFERENCE_SURVEY == "PUBLIC CONFERENCE SURVEY")
                       && (x.DELETED == false || x.DELETED == null))
                       .ToList().AsEnumerable().Select(x => new
                       {
                           CONFERENCE_SURVEY_ID = x.CONFERENCE_SURVEY_ID,
                           CONFERENCE_SURVEY_NAME = x.CONFERENCE_SURVEY_NAME,
                           CONFERENCE_SURVEY_NAME_EN = x.CONFERENCE_SURVEY_NAME_EN,
                           DESCRIPTION = x.DESCRIPTION,
                           DESCRIPTION_EN = x.DESCRIPTION_EN,
                           CONFERENCE_ID = x.CONFERENCE_ID,
                           CONFERENCE_NAME = x.CONFERENCE_NAME,
                           CONFERENCE_NAME_EN = x.CONFERENCE_NAME_EN,
                           SAVED_UNCOMPLETED_ANSWERS = x.SAVED_UNCOMPLETED_ANSWERS,
                           PUBLIC_OR_PRIVATE_CONFERENCE_SURVEY = x.PUBLIC_OR_PRIVATE_CONFERENCE_SURVEY,
                           SURVEY_FOR_CONFERENCE_SESSION_ID = x.SURVEY_FOR_CONFERENCE_SESSION_ID,
                           COMPLETED_OR_UNCOMPLETED = surveyModel.completeOrUnComplete(userName, x.CONFERENCE_SURVEY_ID)
                       }).ToList();
                        return ResponseSuccess(StringResource.Success, surveys);
                    }
                }
                else
                {
                    List<MESSAGING_GROUP> groups = new MessageGroup().getListMessageGroup(userName);
                    var surveys = db.CONFERENCE_SURVEY.AsEnumerable()
                   .Where(x => x.CONFERENCE_ID == conferenceId
                   && ((surveyModel.checkGroupsInSurvey(groups, x) || surveyModel.checkUserNameInSurvey(userName, x)) || (x.PUBLIC_OR_PRIVATE_CONFERENCE_SURVEY == "PUBLIC CONFERENCE SURVEY" && x.SURVEY_FOR_CONFERENCE_SESSION_ID == null))
                   && (x.DELETED == false || x.DELETED == null))
                   .ToList().AsEnumerable().Distinct().Select(x => new
                   {
                       CONFERENCE_SURVEY_ID = x.CONFERENCE_SURVEY_ID,
                       CONFERENCE_SURVEY_NAME = x.CONFERENCE_SURVEY_NAME,
                       CONFERENCE_SURVEY_NAME_EN = x.CONFERENCE_SURVEY_NAME_EN,
                       DESCRIPTION = x.DESCRIPTION,
                       DESCRIPTION_EN = x.DESCRIPTION_EN,
                       CONFERENCE_ID = x.CONFERENCE_ID,
                       CONFERENCE_NAME = x.CONFERENCE_NAME,
                       CONFERENCE_NAME_EN = x.CONFERENCE_NAME_EN,
                       SAVED_UNCOMPLETED_ANSWERS = x.SAVED_UNCOMPLETED_ANSWERS,
                       PUBLIC_OR_PRIVATE_CONFERENCE_SURVEY = x.PUBLIC_OR_PRIVATE_CONFERENCE_SURVEY,
                       SURVEY_FOR_CONFERENCE_SESSION_ID = x.SURVEY_FOR_CONFERENCE_SESSION_ID,
                       COMPLETED_OR_UNCOMPLETED = surveyModel.completeOrUnComplete(userName, x.CONFERENCE_SURVEY_ID)

                   }).ToList();
                    return ResponseSuccess(StringResource.Success, surveys);
                }
            }
        }

        [HttpPost]
        [Route("api/ListQuestion")]
        public HttpResponseMessage ListQuestion(string userName, int CONFERENCE_SURVEY_ID)
        {
            var survey = db.CONFERENCE_SURVEY.SingleOrDefault(x => x.CONFERENCE_SURVEY_ID == CONFERENCE_SURVEY_ID);
            if (survey == null)
            {
                return ResponseFail(StringResource.Survey_do_not_exist);
            }
            else
            {
                if (survey.SAVED_UNCOMPLETED_ANSWERS == true)
                {
                    var model = new ConferenceSurveyModel();
                    var list = db.CONFERENCE_SURVEY_QUESTION.AsEnumerable().Where(x => x.CONFERENCE_SURVEY_ID == CONFERENCE_SURVEY_ID && !model.questionIsComplete(userName, x.CONFERENCE_SURVEY_QUESTION_ID) && (x.DELETED == false || x.DELETED == null))
                  .ToList()
                  .OrderBy(x => x.CONFERENCE_SURVEY_QUESTION_ORDER_NUMBER)
                   .Select(x => new
                   {
                       CONFERENCE_SURVEY_QUESTION_ID = x.CONFERENCE_SURVEY_QUESTION_ID,
                       CONFERENCE_SURVEY_QUESTION1 = x.CONFERENCE_SURVEY_QUESTION1,
                       CONFERENCE_SURVEY_QUESTION_EN = x.CONFERENCE_SURVEY_QUESTION_EN,
                       CONFERENCE_SURVEY_QUESTION_TYPE_NAME = x.CONFERENCE_SURVEY_QUESTION_TYPE_NAME,
                       CONFERENCE_SURVEY_QUESTION_TYPE_NAME_EN = x.CONFERENCE_SURVEY_QUESTION_TYPE_NAME_EN,
                       CONFERENCE_SURVEY_ID = x.CONFERENCE_SURVEY_ID,
                       CONFERENCE_SURVEY_NAME = x.CONFERENCE_SURVEY_NAME,
                       CONFERENCE_SURVEY_NAME_EN = x.CONFERENCE_SURVEY_NAME_EN,
                       CONFERENCE_SURVEY_QUESTION_ORDER_NUMBER = x.CONFERENCE_SURVEY_QUESTION_ORDER_NUMBER,
                       CONFERENCE_SURVEY_QUESTION_OPTION_A = x.CONFERENCE_SURVEY_QUESTION_OPTION_A,
                       CONFERENCE_SURVEY_QUESTION_POINT_A = x.CONFERENCE_SURVEY_QUESTION_POINT_A,
                       CONFERENCE_SURVEY_QUESTION_OPTION_B = x.CONFERENCE_SURVEY_QUESTION_OPTION_B,
                       CONFERENCE_SURVEY_QUESTION_POINT_B = x.CONFERENCE_SURVEY_QUESTION_POINT_B,
                       CONFERENCE_SURVEY_QUESTION_OPTION_C = x.CONFERENCE_SURVEY_QUESTION_OPTION_C,
                       CONFERENCE_SURVEY_QUESTION_POINT_C = x.CONFERENCE_SURVEY_QUESTION_POINT_C,
                       CONFERENCE_SURVEY_QUESTION_OPTION_D = x.CONFERENCE_SURVEY_QUESTION_OPTION_D,
                       CONFERENCE_SURVEY_QUESTION_POINT_D = x.CONFERENCE_SURVEY_QUESTION_POINT_D,
                       CONFERENCE_SURVEY_QUESTION_OPTION_E = x.CONFERENCE_SURVEY_QUESTION_OPTION_E,
                       CONFERENCE_SURVEY_QUESTION_POINT_E = x.CONFERENCE_SURVEY_QUESTION_POINT_E,
                       CONFERENCE_SURVEY_QUESTION_OPTION_F = x.CONFERENCE_SURVEY_QUESTION_OPTION_F,
                       CONFERENCE_SURVEY_QUESTION_POINT_F = x.CONFERENCE_SURVEY_QUESTION_POINT_F,
                       CONFERENCE_SURVEY_QUESTION_OPTION_G = x.CONFERENCE_SURVEY_QUESTION_OPTION_G,
                       CONFERENCE_SURVEY_QUESTION_POINT_G = x.CONFERENCE_SURVEY_QUESTION_POINT_G,
                       CONFERENCE_SURVEY_QUESTION_OPTION_H = x.CONFERENCE_SURVEY_QUESTION_OPTION_H,
                       CONFERENCE_SURVEY_QUESTION_POINT_H = x.CONFERENCE_SURVEY_QUESTION_POINT_H,
                       MAXIMUM_RATING_SCALE_VALUE = x.MAXIMUM_RATING_SCALE_VALUE,
                       MINIMUM_RATING_SCALE_VALUE = x.MINIMUM_RATING_SCALE_VALUE,
                       RATING_SCALE_STEP_VALUE = x.RATING_SCALE_STEP_VALUE,
                       CREATED_UserName = x.CREATED_UserName,
                       CREATED_DATETIME = x.CREATED_DATETIME,
                       LATEST_UPDATED_DATETIME = x.LATEST_UPDATED_DATETIME,
                       DELETED = x.DELETED,
                       DELETED_SCRIPT = x.DELETED_SCRIPT,
                       DELETED_DATETIME = x.DELETED_DATETIME,
                       DELETED_UserName = x.DELETED_UserName
                   });
                    return ResponseSuccess(StringResource.Success, list);
                }
                else
                {
                    var list = db.CONFERENCE_SURVEY_QUESTION.Where(x => x.CONFERENCE_SURVEY_ID == CONFERENCE_SURVEY_ID && (x.DELETED == false || x.DELETED == null))
                   .ToList()
                   .OrderBy(x => x.CONFERENCE_SURVEY_QUESTION_ORDER_NUMBER)
                   .Select(x => new
                   {
                       CONFERENCE_SURVEY_QUESTION_ID = x.CONFERENCE_SURVEY_QUESTION_ID,
                       CONFERENCE_SURVEY_QUESTION1 = x.CONFERENCE_SURVEY_QUESTION1,
                       CONFERENCE_SURVEY_QUESTION_EN = x.CONFERENCE_SURVEY_QUESTION_EN,
                       CONFERENCE_SURVEY_QUESTION_TYPE_NAME = x.CONFERENCE_SURVEY_QUESTION_TYPE_NAME,
                       CONFERENCE_SURVEY_QUESTION_TYPE_NAME_EN = x.CONFERENCE_SURVEY_QUESTION_TYPE_NAME_EN,
                       CONFERENCE_SURVEY_ID = x.CONFERENCE_SURVEY_ID,
                       CONFERENCE_SURVEY_NAME = x.CONFERENCE_SURVEY_NAME,
                       CONFERENCE_SURVEY_NAME_EN = x.CONFERENCE_SURVEY_NAME_EN,
                       CONFERENCE_SURVEY_QUESTION_ORDER_NUMBER = x.CONFERENCE_SURVEY_QUESTION_ORDER_NUMBER,
                       CONFERENCE_SURVEY_QUESTION_OPTION_A = x.CONFERENCE_SURVEY_QUESTION_OPTION_A,
                       CONFERENCE_SURVEY_QUESTION_POINT_A = x.CONFERENCE_SURVEY_QUESTION_POINT_A,
                       CONFERENCE_SURVEY_QUESTION_OPTION_B = x.CONFERENCE_SURVEY_QUESTION_OPTION_B,
                       CONFERENCE_SURVEY_QUESTION_POINT_B = x.CONFERENCE_SURVEY_QUESTION_POINT_B,
                       CONFERENCE_SURVEY_QUESTION_OPTION_C = x.CONFERENCE_SURVEY_QUESTION_OPTION_C,
                       CONFERENCE_SURVEY_QUESTION_POINT_C = x.CONFERENCE_SURVEY_QUESTION_POINT_C,
                       CONFERENCE_SURVEY_QUESTION_OPTION_D = x.CONFERENCE_SURVEY_QUESTION_OPTION_D,
                       CONFERENCE_SURVEY_QUESTION_POINT_D = x.CONFERENCE_SURVEY_QUESTION_POINT_D,
                       CONFERENCE_SURVEY_QUESTION_OPTION_E = x.CONFERENCE_SURVEY_QUESTION_OPTION_E,
                       CONFERENCE_SURVEY_QUESTION_POINT_E = x.CONFERENCE_SURVEY_QUESTION_POINT_E,
                       CONFERENCE_SURVEY_QUESTION_OPTION_F = x.CONFERENCE_SURVEY_QUESTION_OPTION_F,
                       CONFERENCE_SURVEY_QUESTION_POINT_F = x.CONFERENCE_SURVEY_QUESTION_POINT_F,
                       CONFERENCE_SURVEY_QUESTION_OPTION_G = x.CONFERENCE_SURVEY_QUESTION_OPTION_G,
                       CONFERENCE_SURVEY_QUESTION_POINT_G = x.CONFERENCE_SURVEY_QUESTION_POINT_G,
                       CONFERENCE_SURVEY_QUESTION_OPTION_H = x.CONFERENCE_SURVEY_QUESTION_OPTION_H,
                       CONFERENCE_SURVEY_QUESTION_POINT_H = x.CONFERENCE_SURVEY_QUESTION_POINT_H,
                       MINIMUM_RATING_SCALE_VALUE = x.MINIMUM_RATING_SCALE_VALUE,
                       RATING_SCALE_STEP_VALUE = x.RATING_SCALE_STEP_VALUE,
                       CREATED_UserName = x.CREATED_UserName,
                       CREATED_DATETIME = x.CREATED_DATETIME,
                       LATEST_UPDATED_DATETIME = x.LATEST_UPDATED_DATETIME,
                       DELETED = x.DELETED,
                       DELETED_SCRIPT = x.DELETED_SCRIPT,
                       DELETED_DATETIME = x.DELETED_DATETIME,
                       DELETED_UserName = x.DELETED_UserName
                   });
                    return ResponseSuccess(StringResource.Success, list);
                }

            }

        }


        [HttpPost]
        [Route("api/SaveSurvey")]
        public HttpResponseMessage SaveSurvey(string UserName, int CONFERENCE_SURVEY_ID, bool COMPLETED_OR_UNCOMPLETED)
        {
            var survey = db.CONFERENCE_SURVEY.SingleOrDefault(x => x.CONFERENCE_SURVEY_ID == CONFERENCE_SURVEY_ID);
            var account = db.ACCOUNTs.SingleOrDefault(x => x.UserName == UserName);
            if (survey == null)
            {
                return ResponseFail(StringResource.Survey_do_not_exist);
            }
            else if (account == null)
            {
                return ResponseFail(StringResource.Account_does_not_exist);
            }
            else
            {
                var accountDoing = db.ACCOUNT_DOING_CONFERENCE_SURVEY.SingleOrDefault(x => x.UserName == UserName && x.CONFERENCE_SURVEY_ID == CONFERENCE_SURVEY_ID);
                if (accountDoing != null)
                {
                    accountDoing.COMPLETED_OR_UNCOMPLETED = COMPLETED_OR_UNCOMPLETED ? "COMPLETED" : "UNCOMPLETED";
                    accountDoing.END_DATETIME = DateTime.Now;
                    db.SaveChanges();
                    return ResponseSuccess(StringResource.Success);
                }
                else
                {
                    var ad = new ACCOUNT_DOING_CONFERENCE_SURVEY();
                    ad.CONFERENCE_SURVEY_ID = CONFERENCE_SURVEY_ID;
                    ad.CONFERENCE_SURVEY_NAME = survey.CONFERENCE_SURVEY_NAME;
                    ad.CONFERENCE_SURVEY_NAME_EN = survey.CONFERENCE_SURVEY_NAME_EN;
                    ad.UserName = account.UserName;
                    ad.CURRENT_LAST_NAME = account.CURRENT_LAST_NAME;
                    ad.CURRENT_FIRST_NAME = account.CURRENT_FIRST_NAME;
                    ad.CURRENT_MIDDLE_NAME = account.CURRENT_MIDDLE_NAME;
                    ad.START_DATETIME = DateTime.Now;
                    ad.COMPLETED_OR_UNCOMPLETED = COMPLETED_OR_UNCOMPLETED ? "COMPLETED" : "UNCOMPLETED";
                    db.ACCOUNT_DOING_CONFERENCE_SURVEY.Add(ad);
                    db.SaveChanges();
                    return ResponseSuccess(StringResource.Success);
                }
            }
        }

        [HttpPost]
        [Route("api/SaveAnswerToSurvey")]
        public HttpResponseMessage SaveAnswerToSurvey([FromBody]AnswerToSurvey body)
        {
            var question = db.CONFERENCE_SURVEY_QUESTION.SingleOrDefault(x => x.CONFERENCE_SURVEY_QUESTION_ID == body.CONFERENCE_SURVEY_QUESTION_ID);
            var account = db.ACCOUNTs.SingleOrDefault(x => x.UserName == body.UserName);
            if (question == null)
            {
                return ResponseFail(StringResource.Conference_survey_question_do_not_exist);
            }
            else if (account == null)
            {
                return ResponseFail(StringResource.Account_does_not_exist);
            }
            else
            {
                var answer = db.ANSWER_TO_CONFERENCE_SURVEY_QUESTION.SingleOrDefault(x => x.UserName == body.UserName && x.CONFERENCE_SURVEY_QUESTION_ID == body.CONFERENCE_SURVEY_QUESTION_ID);
                if (answer != null)
                {
                    answer.END_DATETIME = DateTime.Now;
                    answer.CONFERENCE_SURVEY_QUESTION_ANSWER = body.CONFERENCE_SURVEY_QUESTION_ANSWER;
                    db.SaveChanges();
                    return ResponseSuccess(StringResource.Success);
                }
                else
                {
                    var ans = new ANSWER_TO_CONFERENCE_SURVEY_QUESTION();
                    ans.UserName = body.UserName;
                    ans.CONFERENCE_SURVEY_QUESTION_ID = body.CONFERENCE_SURVEY_QUESTION_ID;
                    ans.START_DATETIME = DateTime.Now;
                    ans.CONFERENCE_SURVEY_QUESTION_ANSWER = body.CONFERENCE_SURVEY_QUESTION_ANSWER;
                    db.ANSWER_TO_CONFERENCE_SURVEY_QUESTION.Add(ans);
                    db.SaveChanges();
                    return ResponseSuccess(StringResource.Success);
                }
            }
        }

        [HttpPost]
        [Route("api/ResetQuestion")]
        public HttpResponseMessage ResetQuestion()
        {
            var result = db.ANSWER_TO_CONFERENCE_SURVEY_QUESTION.ToList();
            db.ANSWER_TO_CONFERENCE_SURVEY_QUESTION.RemoveRange(result);
            db.SaveChanges();
            return ResponseSuccess(StringResource.Success);
        }


        [HttpPost]
        [Route("api/ListAnswer")]
        public HttpResponseMessage ListAnswer()
        {
            var result = db.ANSWER_TO_CONFERENCE_SURVEY_QUESTION.Select(x => new  {
                x.UserName,
                x.CONFERENCE_SURVEY_QUESTION_ID,
                x.START_DATETIME,
                x.END_DATETIME,
                x.CONFERENCE_SURVEY_QUESTION_ANSWER
            });
            return ResponseSuccess(StringResource.Success, result);
        }
    }

    public class AnswerToSurvey
    {
        public string UserName { get; set; }
        public int CONFERENCE_SURVEY_QUESTION_ID { get; set; }
        public string CONFERENCE_SURVEY_QUESTION_ANSWER { get; set; }

    }
}
