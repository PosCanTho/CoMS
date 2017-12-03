using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoMS.Resources;
using System.IO;
using Newtonsoft.Json;
using CoMS.Models;
using CoMS.Untils;
using CoMS.Entities_Framework;
using PagedList;

namespace CoMS.Models
{
    public class ConferenceSurveyModel
    {
        private DB db;
        public ConferenceSurveyModel()
        {
            db = new DB();
        }

        public bool checkUserNameInSurvey(string userName, CONFERENCE_SURVEY survey)
        {
            if (userName == null || survey == null)
            {
                return false;
            }
            if (survey.CONFERENCE_SURVEY_UserName_1 == userName
                || survey.CONFERENCE_SURVEY_UserName_2 == userName
                || survey.CONFERENCE_SURVEY_UserName_3 == userName
                || survey.CONFERENCE_SURVEY_UserName_4 == userName
                || survey.CONFERENCE_SURVEY_UserName_5 == userName
                || survey.CONFERENCE_SURVEY_UserName_6 == userName
                || survey.CONFERENCE_SURVEY_UserName_7 == userName
                || survey.CONFERENCE_SURVEY_UserName_8 == userName
                || survey.CONFERENCE_SURVEY_UserName_9 == userName
                || survey.CONFERENCE_SURVEY_UserName_10 == userName
                || survey.CONFERENCE_SURVEY_UserName_11 == userName
                || survey.CONFERENCE_SURVEY_UserName_12 == userName
                || survey.CONFERENCE_SURVEY_UserName_13 == userName
                || survey.CONFERENCE_SURVEY_UserName_14 == userName
                || survey.CONFERENCE_SURVEY_UserName_15 == userName
                || survey.CONFERENCE_SURVEY_UserName_16 == userName
                || survey.CONFERENCE_SURVEY_UserName_17 == userName
                || survey.CONFERENCE_SURVEY_UserName_18 == userName
                || survey.CONFERENCE_SURVEY_UserName_19 == userName
                || survey.CONFERENCE_SURVEY_UserName_20 == userName)
            {
                return true;
            }
            return false;
        }

        public bool checkGroupIdInSurvey(decimal groupId, CONFERENCE_SURVEY survey)
        {
            if (survey == null)
            {
                return false;
            }
            if (survey.CONFERENCE_SURVEY_GROUP_ID_1 == groupId
                || survey.CONFERENCE_SURVEY_GROUP_ID_2 == groupId
                || survey.CONFERENCE_SURVEY_GROUP_ID_3 == groupId
                || survey.CONFERENCE_SURVEY_GROUP_ID_4 == groupId
                || survey.CONFERENCE_SURVEY_GROUP_ID_5 == groupId
                || survey.CONFERENCE_SURVEY_GROUP_ID_6 == groupId
                || survey.CONFERENCE_SURVEY_GROUP_ID_7 == groupId
                || survey.CONFERENCE_SURVEY_GROUP_ID_8 == groupId
                || survey.CONFERENCE_SURVEY_GROUP_ID_9 == groupId
                || survey.CONFERENCE_SURVEY_GROUP_ID_10 == groupId)
            {
                return true;
            }
            return false;
        }

        public bool checkGroupsInSurvey(List<MESSAGING_GROUP> groups, CONFERENCE_SURVEY survey)
        {
            
            foreach (MESSAGING_GROUP group in groups){
                if (checkGroupIdInSurvey(group.MESSAGING_GROUP_ID, survey))
                {
                    return true;
                }
            }
            return false;
        }

        public bool completeOrUnComplete(string userName, decimal CONFERENCE_SURVEY_ID)
        {
            try
            {
                var result = db.ACCOUNT_DOING_CONFERENCE_SURVEY.Where(x => x.UserName == userName && x.CONFERENCE_SURVEY_ID == CONFERENCE_SURVEY_ID && x.COMPLETED_OR_UNCOMPLETED == "COMPLETED").ToList();
                if (result.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool questionIsComplete(string userName, decimal CONFERENCE_SURVEY_QUESTION_ID)
        {
            try
            {
                var result = db.ANSWER_TO_CONFERENCE_SURVEY_QUESTION.Where(x => x.UserName == userName && x.CONFERENCE_SURVEY_QUESTION_ID == CONFERENCE_SURVEY_QUESTION_ID).ToList();
                if (result.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

    }
}