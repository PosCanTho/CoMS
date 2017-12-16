using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoMS.Entities_Framework;
using CoMS.Resources;
using CoMS.Models;
using System.Text;
using CoMS.Untils;
using System.Web.Http.Description;
using Newtonsoft.Json.Linq;

namespace CoMS.Controllers
{
    public class AuthorAbstractController : BaseController
    {
        private DB db = new DB();
        [HttpPost]
        [Route("api/List_PaperAbstract")]
        public HttpResponseMessage ListPaperAbstract([FromBody] UserAuthor user)
        {
            /*
             * Yêu c?u:
             * Ngu?i dùng tác gi? g?i username và pass, l?y t?t c? các bài paper abstract c?a tác gi? dó
             */
            if (user != null)
            {
                var query = from list_author_paper_abstract_relationship in db.AUTHOR_PAPER_ABSTRACT_RELATIONSHIP
                            join list_paper_abstarct in db.PAPER_ABSTRACT on list_author_paper_abstract_relationship.PAPER_ID equals list_paper_abstarct.PAPER_ID
                            join confer in db.CONFERENCEs on list_author_paper_abstract_relationship.CONFERENCE_ID equals confer.CONFERENCE_ID
                            where
                            list_author_paper_abstract_relationship.PERSON_ID == user.PERSON_ID
                            && list_author_paper_abstract_relationship.CONFERENCE_ID == user.CONFERENCE_ID
                            orderby list_author_paper_abstract_relationship.PAPER_ID descending
                            select
                            new
                            {
                                list_author_paper_abstract_relationship.PERSON_ID,
                                list_author_paper_abstract_relationship.CONFERENCE_ID,
                                list_author_paper_abstract_relationship.ORGANIZATION_ID_1,
                                list_author_paper_abstract_relationship.ORGANIZATION_NAME_1,
                                list_author_paper_abstract_relationship.ORGANIZATION_NAME_EN_1,
                                list_author_paper_abstract_relationship.ORGANIZATION_ID_2,
                                list_author_paper_abstract_relationship.ORGANIZATION_NAME_2,
                                list_author_paper_abstract_relationship.ORGANIZATION_ID_3,
                                list_author_paper_abstract_relationship.ORGANIZATION_NAME_3,
                                list_author_paper_abstract_relationship.ORGANIZATION_ID_4,
                                list_author_paper_abstract_relationship.ORGANIZATION_NAME_4,
                                list_author_paper_abstract_relationship.ORGANIZATION_ID_5,
                                list_author_paper_abstract_relationship.ORGANIZATION_NAME_5,
                                list_author_paper_abstract_relationship.CORRESPONDING_AUTHOR,
                                CONFERENCE_NAME1 = (confer.CONFERENCE_NAME + " - " + list_paper_abstarct.PAPER_ABSTRACT_TITLE_1),
                                confer.PAPER_ABSTRACT_DEADLINE_1,
                                confer.PAPER_TEXT_DEADLINE_1,
                                confer.FROM_DATE,
                                confer.THRU_DATE,
                                list_paper_abstarct.PAPER_ID,
                                list_paper_abstarct.PAPER_NUMBER_OR_CODE,

                                list_paper_abstarct.PAPER_ABSTRACT_TITLE_1,
                                list_paper_abstarct.PAPER_ABSTRACT_TITLE_EN_1,
                                list_paper_abstarct.CONFERENCE_SESSION_TOPIC_ID_1,
                                list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_1,
                                list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_EN_1,
                                list_paper_abstarct.PAPER_ABSTRACT_TEXT_1,
                                list_paper_abstarct.PAPER_ABSTRACT_TEXT_EN_1,
                                list_paper_abstarct.FULL_PAPER_OR_WORK_IN_PROGRESS_1,
                                list_paper_abstarct.TYPE_OF_STUDY_ID_1,
                                list_paper_abstarct.TYPE_OF_STUDY_NAME_1,
                                list_paper_abstarct.TYPE_OF_STUDY_NAME_EN_1,
                                list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_ID_1,
                                list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_NAME_1,
                                list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_NAME_EN_1,
                                list_paper_abstarct.FIRST_SUBMITTED_DATE_1,
                                list_paper_abstarct.LAST_REVISED_DATE_1,
                                list_paper_abstarct.PAPER_ABSTRACT_ATTACHED_FILENAME_1,

                                CONFERENCE_NAME2 = list_paper_abstarct.PAPER_ABSTRACT_TITLE_2 == null ? null : (confer.CONFERENCE_NAME + " - " + list_paper_abstarct.PAPER_ABSTRACT_TITLE_2),
                                confer.PAPER_ABSTRACT_DEADLINE_2,
                                confer.PAPER_TEXT_DEADLINE_2,
                                list_paper_abstarct.PAPER_ABSTRACT_TITLE_2,
                                list_paper_abstarct.PAPER_ABSTRACT_TITLE_EN_2,
                                list_paper_abstarct.CONFERENCE_SESSION_TOPIC_ID_2,
                                list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_2,
                                list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_EN_2,
                                list_paper_abstarct.PAPER_ABSTRACT_TEXT_2,
                                list_paper_abstarct.PAPER_ABSTRACT_TEXT_EN_2,
                                list_paper_abstarct.FULL_PAPER_OR_WORK_IN_PROGRESS_2,
                                list_paper_abstarct.TYPE_OF_STUDY_ID_2,
                                list_paper_abstarct.TYPE_OF_STUDY_NAME_2,
                                list_paper_abstarct.TYPE_OF_STUDY_NAME_EN_2,
                                list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_ID_2,
                                list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_NAME_2,
                                list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_NAME_EN_2,
                                list_paper_abstarct.FIRST_SUBMITTED_DATE_2,
                                list_paper_abstarct.LAST_REVISED_DATE_2,
                                list_paper_abstarct.PAPER_ABSTRACT_ATTACHED_FILENAME_2,


                                CONFERENCE_NAME3 = list_paper_abstarct.PAPER_ABSTRACT_TITLE_2 == null ? null : (confer.CONFERENCE_NAME + " - " + list_paper_abstarct.PAPER_ABSTRACT_TITLE_2),
                                confer.PAPER_ABSTRACT_DEADLINE_3,
                                confer.PAPER_TEXT_DEADLINE_3,
                                list_paper_abstarct.PAPER_ABSTRACT_TEXT_3,
                                list_paper_abstarct.PAPER_ABSTRACT_TEXT_EN_3,
                                list_paper_abstarct.FULL_PAPER_OR_WORK_IN_PROGRESS_3,
                                list_paper_abstarct.TYPE_OF_STUDY_ID_3,
                                list_paper_abstarct.TYPE_OF_STUDY_NAME_3,
                                list_paper_abstarct.TYPE_OF_STUDY_NAME_EN_3,
                                list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_ID_3,
                                list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_NAME_3,
                                list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_NAME_EN_3,
                                list_paper_abstarct.FIRST_SUBMITTED_DATE_3,
                                list_paper_abstarct.LAST_REVISED_DATE_3,
                                CONFERENCE_NAME4 = list_paper_abstarct.PAPER_ABSTRACT_TITLE_2 == null ? null : (confer.CONFERENCE_NAME + " - " + list_paper_abstarct.PAPER_ABSTRACT_TITLE_2),
                                CONFERENCE_SESSION_TOPIC_ID_3 = list_paper_abstarct.CONFERENCE_SESSION_TOPIC_ID_2 == null ? list_paper_abstarct.CONFERENCE_SESSION_TOPIC_ID_1 : list_paper_abstarct.CONFERENCE_SESSION_TOPIC_ID_2,
                                CONFERENCE_SESSION_TOPIC_NAME_3 = list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_2 == null ? list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_1 : list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_2,
                                CONFERENCE_SESSION_TOPIC_NAME_EN_3 = list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_EN_2 == null ? list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_EN_1 : list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_EN_2,
                                list_paper_abstarct.PAPER_ABSTRACT_ATTACHED_FILENAME_3,


                                confer.PAPER_ABSTRACT_DEADLINE_4,
                                confer.PAPER_TEXT_DEADLINE_4,
                                list_paper_abstarct.PAPER_ABSTRACT_TEXT_4,
                                list_paper_abstarct.PAPER_ABSTRACT_TEXT_EN_4,
                                list_paper_abstarct.FULL_PAPER_OR_WORK_IN_PROGRESS_4,
                                list_paper_abstarct.TYPE_OF_STUDY_ID_4,
                                list_paper_abstarct.TYPE_OF_STUDY_NAME_4,
                                list_paper_abstarct.TYPE_OF_STUDY_NAME_EN_4,
                                list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_ID_4,
                                list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_NAME_4,
                                list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_NAME_EN_4,
                                list_paper_abstarct.FIRST_SUBMITTED_DATE_4,
                                list_paper_abstarct.LAST_REVISED_DATE_4,
                                CONFERENCE_SESSION_TOPIC_ID_4 = list_paper_abstarct.CONFERENCE_SESSION_TOPIC_ID_2 == null ? list_paper_abstarct.CONFERENCE_SESSION_TOPIC_ID_1 : list_paper_abstarct.CONFERENCE_SESSION_TOPIC_ID_2,
                                CONFERENCE_SESSION_TOPIC_NAME_4 = list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_2 == null ? list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_1 : list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_2,
                                CONFERENCE_SESSION_TOPIC_NAME_EN_4 = list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_EN_2 == null ? list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_EN_1 : list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_EN_2,
                                list_paper_abstarct.PAPER_ABSTRACT_ATTACHED_FILENAME_4,


                                CONFERENCE_NAME5 = list_paper_abstarct.PAPER_ABSTRACT_TITLE_2 == null ? null : (confer.CONFERENCE_NAME + " - " + list_paper_abstarct.PAPER_ABSTRACT_TITLE_2),
                                confer.PAPER_ABSTRACT_DEADLINE_5,
                                confer.PAPER_TEXT_DEADLINE_5,
                                list_paper_abstarct.PAPER_ABSTRACT_TEXT_5,
                                list_paper_abstarct.PAPER_ABSTRACT_TEXT_EN_5,
                                list_paper_abstarct.FULL_PAPER_OR_WORK_IN_PROGRESS_5,
                                list_paper_abstarct.TYPE_OF_STUDY_ID_5,
                                list_paper_abstarct.TYPE_OF_STUDY_NAME_5,
                                list_paper_abstarct.TYPE_OF_STUDY_NAME_EN_5,
                                list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_ID_5,
                                list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_NAME_5,
                                list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_NAME_EN_5,
                                list_paper_abstarct.FIRST_SUBMITTED_DATE_5,
                                list_paper_abstarct.LAST_REVISED_DATE_5,
                                CONFERENCE_SESSION_TOPIC_ID_5 = list_paper_abstarct.CONFERENCE_SESSION_TOPIC_ID_2 == null ? list_paper_abstarct.CONFERENCE_SESSION_TOPIC_ID_1 : list_paper_abstarct.CONFERENCE_SESSION_TOPIC_ID_2,
                                CONFERENCE_SESSION_TOPIC_NAME_5 = list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_2 == null ? list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_1 : list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_2,
                                CONFERENCE_SESSION_TOPIC_NAME_EN_5 = list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_EN_2 == null ? list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_EN_1 : list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_EN_2,
                                list_paper_abstarct.PAPER_ABSTRACT_ATTACHED_FILENAME_5,


                                list_paper_abstarct.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT,
                                list_paper_abstarct.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_DATE,
                                list_paper_abstarct.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_REVIEWER_PERSON_ID,
                                list_paper_abstarct.PAPER_ABSTRACT_WITHDRAWN,
                                list_paper_abstarct.PAPER_ABSTRACT_WITHDRAWN_DATE
                            };
                if (query != null)
                {
                    var jsonArray = new JArray();
                    foreach (var q in query)
                    {
                        var json1 = new JObject();
                        var json2 = new JObject();
                        var json3 = new JObject();
                        var json4 = new JObject();
                        var json5 = new JObject();
                        int k = 0;

                        if (q.PAPER_ABSTRACT_TITLE_1 != null && q.PAPER_ABSTRACT_DEADLINE_1 != null)
                        {
                            json1 = new JObject(
                                            new JProperty("PERSON_ID", q.PERSON_ID),
                                            new JProperty("CONFERENCE_ID", q.CONFERENCE_ID),
                                            new JProperty("ORGANIZATION_NAME_1", q.ORGANIZATION_NAME_1),
                                            new JProperty("ORGANIZATION_NAME_2", q.ORGANIZATION_NAME_2),
                                            new JProperty("ORGANIZATION_NAME_3", q.ORGANIZATION_NAME_3),
                                            new JProperty("ORGANIZATION_NAME_4", q.ORGANIZATION_NAME_4),
                                            new JProperty("ORGANIZATION_NAME_5", q.ORGANIZATION_NAME_5),
                                            new JProperty("CORRESPONDING_AUTHOR", q.CORRESPONDING_AUTHOR),
                                            new JProperty("PAPER_ID", q.PAPER_ID),
                                            new JProperty("CONFERENCE_NAME", q.CONFERENCE_NAME1),
                                            new JProperty("PAPER_ABSTRACT_DEADLINE", q.PAPER_ABSTRACT_DEADLINE_1),
                                            new JProperty("PAPER_TEXT_DEADLINE", q.PAPER_TEXT_DEADLINE_1),
                                            new JProperty("PAPER_ABSTRACT_TITLE", q.PAPER_ABSTRACT_TITLE_1),
                                            new JProperty("PAPER_ABSTRACT_TITLE_EN", q.PAPER_ABSTRACT_TITLE_EN_1),
                                            new JProperty("CONFERENCE_SESSION_TOPIC_ID", q.CONFERENCE_SESSION_TOPIC_ID_1),
                                            new JProperty("CONFERENCE_SESSION_TOPIC_NAME", q.CONFERENCE_SESSION_TOPIC_NAME_1),
                                            new JProperty("CONFERENCE_SESSION_TOPIC_NAME_EN", q.CONFERENCE_SESSION_TOPIC_NAME_EN_1),
                                            new JProperty("PAPER_ABSTRACT_TEXT", q.PAPER_ABSTRACT_TEXT_1),
                                            new JProperty("PAPER_ABSTRACT_TEXT_EN", q.PAPER_ABSTRACT_TEXT_EN_1),
                                            new JProperty("FULL_PAPER_OR_WORK_IN_PROGRESS", q.FULL_PAPER_OR_WORK_IN_PROGRESS_1),
                                            new JProperty("TYPE_OF_STUDY_ID", q.TYPE_OF_STUDY_ID_1),
                                            new JProperty("TYPE_OF_STUDY_NAME", q.TYPE_OF_STUDY_NAME_1),
                                            new JProperty("TYPE_OF_STUDY_NAME_EN", q.TYPE_OF_STUDY_NAME_EN_1),
                                            new JProperty("CONFERENCE_PRESENTATION_TYPE_ID", q.CONFERENCE_PRESENTATION_TYPE_ID_1),
                                            new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME", q.CONFERENCE_PRESENTATION_TYPE_NAME_1),
                                            new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME_EN", q.CONFERENCE_PRESENTATION_TYPE_NAME_EN_1),
                                            new JProperty("FIRST_SUBMITTED_DATE", q.FIRST_SUBMITTED_DATE_1),
                                            new JProperty("LAST_REVISED_DATE", q.LAST_REVISED_DATE_1),
                                            new JProperty("PAPER_ABSTRACT_ATTACHED_FILENAME", q.PAPER_ABSTRACT_ATTACHED_FILENAME_1),
                                            new JProperty("FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT", q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT),
                                            new JProperty("FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_DATE", q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_DATE),
                                            new JProperty("FROM_DATE", q.FROM_DATE),
                                            new JProperty("THRU_DATE", q.THRU_DATE),
                                            new JProperty("PAPER_ABSTRACT_WITHDRAWN", q.PAPER_ABSTRACT_WITHDRAWN),
                                            new JProperty("PAPER_ABSTRACT_WITHDRAWN_DATE", q.PAPER_ABSTRACT_WITHDRAWN_DATE),
                                            new JProperty("POSITION", 1)
                                            );
                            k++;
                        }

                        if (q.PAPER_ABSTRACT_TITLE_2 != null && q.PAPER_ABSTRACT_DEADLINE_2 != null)
                        {
                            json2 = new JObject(
                                            new JProperty("PERSON_ID", q.PERSON_ID),
                                            new JProperty("CONFERENCE_ID", q.CONFERENCE_ID),
                                            new JProperty("ORGANIZATION_NAME_1", q.ORGANIZATION_NAME_1),
                                            new JProperty("ORGANIZATION_NAME_2", q.ORGANIZATION_NAME_2),
                                            new JProperty("ORGANIZATION_NAME_3", q.ORGANIZATION_NAME_3),
                                            new JProperty("ORGANIZATION_NAME_4", q.ORGANIZATION_NAME_4),
                                            new JProperty("ORGANIZATION_NAME_5", q.ORGANIZATION_NAME_5),
                                            new JProperty("CORRESPONDING_AUTHOR", q.CORRESPONDING_AUTHOR),
                                            new JProperty("PAPER_ID", q.PAPER_ID),
                                            new JProperty("CONFERENCE_NAME", q.CONFERENCE_NAME2),
                                            new JProperty("PAPER_ABSTRACT_DEADLINE", q.PAPER_ABSTRACT_DEADLINE_2),
                                            new JProperty("PAPER_TEXT_DEADLINE", q.PAPER_TEXT_DEADLINE_2),
                                            new JProperty("PAPER_ABSTRACT_TITLE", q.PAPER_ABSTRACT_TITLE_2),
                                            new JProperty("PAPER_ABSTRACT_TITLE_EN", q.PAPER_ABSTRACT_TITLE_EN_2),
                                            new JProperty("CONFERENCE_SESSION_TOPIC_ID", q.CONFERENCE_SESSION_TOPIC_ID_2),
                                            new JProperty("CONFERENCE_SESSION_TOPIC_NAME", q.CONFERENCE_SESSION_TOPIC_NAME_2),
                                            new JProperty("CONFERENCE_SESSION_TOPIC_NAME_EN", q.CONFERENCE_SESSION_TOPIC_NAME_EN_2),
                                            new JProperty("PAPER_ABSTRACT_TEXT", q.PAPER_ABSTRACT_TEXT_2),
                                            new JProperty("PAPER_ABSTRACT_TEXT_EN", q.PAPER_ABSTRACT_TEXT_EN_2),
                                            new JProperty("FULL_PAPER_OR_WORK_IN_PROGRESS", q.FULL_PAPER_OR_WORK_IN_PROGRESS_2),
                                            new JProperty("TYPE_OF_STUDY_ID", q.TYPE_OF_STUDY_ID_2),
                                            new JProperty("TYPE_OF_STUDY_NAME", q.TYPE_OF_STUDY_NAME_2),
                                            new JProperty("TYPE_OF_STUDY_NAME_EN", q.TYPE_OF_STUDY_NAME_EN_2),
                                            new JProperty("CONFERENCE_PRESENTATION_TYPE_ID", q.CONFERENCE_PRESENTATION_TYPE_ID_2),
                                            new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME", q.CONFERENCE_PRESENTATION_TYPE_NAME_2),
                                            new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME_EN", q.CONFERENCE_PRESENTATION_TYPE_NAME_EN_2),
                                            new JProperty("FIRST_SUBMITTED_DATE", q.FIRST_SUBMITTED_DATE_2),
                                            new JProperty("LAST_REVISED_DATE", q.LAST_REVISED_DATE_2),
                                            new JProperty("PAPER_ABSTRACT_ATTACHED_FILENAME", q.PAPER_ABSTRACT_ATTACHED_FILENAME_2),
                                            new JProperty("FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT", q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT),
                                            new JProperty("FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_DATE", q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_DATE),
                                            new JProperty("FROM_DATE", q.FROM_DATE),
                                            new JProperty("THRU_DATE", q.THRU_DATE),
                                            new JProperty("PAPER_ABSTRACT_WITHDRAWN", q.PAPER_ABSTRACT_WITHDRAWN),
                                            new JProperty("PAPER_ABSTRACT_WITHDRAWN_DATE", q.PAPER_ABSTRACT_WITHDRAWN_DATE),
                                            new JProperty("POSITION", 2)
                                            );
                            k++;
                        }

                        if (q.PAPER_ABSTRACT_DEADLINE_3 != null && q.PAPER_ABSTRACT_TEXT_3 != null)
                        {
                            json3 = new JObject(
                                            new JProperty("PERSON_ID", q.PERSON_ID),
                                            new JProperty("CONFERENCE_ID", q.CONFERENCE_ID),
                                            new JProperty("ORGANIZATION_NAME_1", q.ORGANIZATION_NAME_1),
                                            new JProperty("ORGANIZATION_NAME_2", q.ORGANIZATION_NAME_2),
                                            new JProperty("ORGANIZATION_NAME_3", q.ORGANIZATION_NAME_3),
                                            new JProperty("ORGANIZATION_NAME_4", q.ORGANIZATION_NAME_4),
                                            new JProperty("ORGANIZATION_NAME_5", q.ORGANIZATION_NAME_5),
                                            new JProperty("CORRESPONDING_AUTHOR", q.CORRESPONDING_AUTHOR),
                                            new JProperty("PAPER_ID", q.PAPER_ID),
                                            new JProperty("CONFERENCE_NAME", q.CONFERENCE_NAME3),
                                            new JProperty("PAPER_ABSTRACT_DEADLINE", q.PAPER_ABSTRACT_DEADLINE_3),
                                            new JProperty("PAPER_TEXT_DEADLINE", q.PAPER_TEXT_DEADLINE_3),
                                            new JProperty("PAPER_ABSTRACT_TEXT", q.PAPER_ABSTRACT_TEXT_3),
                                            new JProperty("PAPER_ABSTRACT_TEXT_EN", q.PAPER_ABSTRACT_TEXT_EN_3),
                                            new JProperty("FULL_PAPER_OR_WORK_IN_PROGRESS", q.FULL_PAPER_OR_WORK_IN_PROGRESS_3),
                                            new JProperty("CONFERENCE_SESSION_TOPIC_ID", q.CONFERENCE_SESSION_TOPIC_ID_3),
                                            new JProperty("CONFERENCE_SESSION_TOPIC_NAME", q.CONFERENCE_SESSION_TOPIC_NAME_3),
                                            new JProperty("CONFERENCE_SESSION_TOPIC_NAME_EN", q.CONFERENCE_SESSION_TOPIC_NAME_EN_3),
                                            new JProperty("TYPE_OF_STUDY_ID", q.TYPE_OF_STUDY_ID_3),
                                            new JProperty("TYPE_OF_STUDY_NAME", q.TYPE_OF_STUDY_NAME_3),
                                            new JProperty("TYPE_OF_STUDY_NAME_EN", q.TYPE_OF_STUDY_NAME_EN_3),
                                            new JProperty("CONFERENCE_PRESENTATION_TYPE_ID", q.CONFERENCE_PRESENTATION_TYPE_ID_3),
                                            new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME", q.CONFERENCE_PRESENTATION_TYPE_NAME_3),
                                            new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME_EN", q.CONFERENCE_PRESENTATION_TYPE_NAME_EN_3),
                                            new JProperty("FIRST_SUBMITTED_DATE", q.FIRST_SUBMITTED_DATE_3),
                                            new JProperty("LAST_REVISED_DATE", q.LAST_REVISED_DATE_3),
                                            new JProperty("PAPER_ABSTRACT_ATTACHED_FILENAME", q.PAPER_ABSTRACT_ATTACHED_FILENAME_3),
                                            new JProperty("FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT", q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT),
                                            new JProperty("FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_DATE", q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_DATE),
                                            new JProperty("FROM_DATE", q.FROM_DATE),
                                            new JProperty("THRU_DATE", q.THRU_DATE),
                                            new JProperty("PAPER_ABSTRACT_WITHDRAWN", q.PAPER_ABSTRACT_WITHDRAWN),
                                            new JProperty("PAPER_ABSTRACT_WITHDRAWN_DATE", q.PAPER_ABSTRACT_WITHDRAWN_DATE),
                                            new JProperty("POSITION", 3)
                                            );
                            k++;
                        }

                        if (q.PAPER_ABSTRACT_DEADLINE_4 != null && q.PAPER_ABSTRACT_TEXT_4 != null)
                        {
                            json4 = new JObject(
                                            new JProperty("PERSON_ID", q.PERSON_ID),
                                            new JProperty("CONFERENCE_ID", q.CONFERENCE_ID),
                                            new JProperty("ORGANIZATION_NAME_1", q.ORGANIZATION_NAME_1),
                                            new JProperty("ORGANIZATION_NAME_2", q.ORGANIZATION_NAME_2),
                                            new JProperty("ORGANIZATION_NAME_3", q.ORGANIZATION_NAME_3),
                                            new JProperty("ORGANIZATION_NAME_4", q.ORGANIZATION_NAME_4),
                                            new JProperty("ORGANIZATION_NAME_5", q.ORGANIZATION_NAME_5),
                                            new JProperty("CORRESPONDING_AUTHOR", q.CORRESPONDING_AUTHOR),
                                            new JProperty("PAPER_ID", q.PAPER_ID),
                                            new JProperty("CONFERENCE_NAME", q.CONFERENCE_NAME4),
                                            new JProperty("PAPER_ABSTRACT_DEADLINE", q.PAPER_ABSTRACT_DEADLINE_4),
                                            new JProperty("PAPER_TEXT_DEADLINE", q.PAPER_TEXT_DEADLINE_4),
                                            new JProperty("PAPER_ABSTRACT_TEXT", q.PAPER_ABSTRACT_TEXT_4),
                                            new JProperty("PAPER_ABSTRACT_TEXT_EN", q.PAPER_ABSTRACT_TEXT_EN_4),
                                            new JProperty("FULL_PAPER_OR_WORK_IN_PROGRESS", q.FULL_PAPER_OR_WORK_IN_PROGRESS_4),
                                            new JProperty("CONFERENCE_SESSION_TOPIC_ID", q.CONFERENCE_SESSION_TOPIC_ID_4),
                                            new JProperty("CONFERENCE_SESSION_TOPIC_NAME", q.CONFERENCE_SESSION_TOPIC_NAME_4),
                                            new JProperty("CONFERENCE_SESSION_TOPIC_NAME_EN", q.CONFERENCE_SESSION_TOPIC_NAME_EN_4),
                                            new JProperty("TYPE_OF_STUDY_ID", q.TYPE_OF_STUDY_ID_4),
                                            new JProperty("TYPE_OF_STUDY_NAME", q.TYPE_OF_STUDY_NAME_4),
                                            new JProperty("TYPE_OF_STUDY_NAME_EN", q.TYPE_OF_STUDY_NAME_EN_4),
                                            new JProperty("CONFERENCE_PRESENTATION_TYPE_ID", q.CONFERENCE_PRESENTATION_TYPE_ID_4),
                                            new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME", q.CONFERENCE_PRESENTATION_TYPE_NAME_4),
                                            new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME_EN", q.CONFERENCE_PRESENTATION_TYPE_NAME_EN_4),
                                            new JProperty("FIRST_SUBMITTED_DATE", q.FIRST_SUBMITTED_DATE_4),
                                            new JProperty("LAST_REVISED_DATE", q.LAST_REVISED_DATE_4),
                                            new JProperty("PAPER_ABSTRACT_ATTACHED_FILENAME", q.PAPER_ABSTRACT_ATTACHED_FILENAME_4),
                                            new JProperty("FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT", q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT),
                                            new JProperty("FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_DATE", q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_DATE),
                                            new JProperty("FROM_DATE", q.FROM_DATE),
                                            new JProperty("THRU_DATE", q.THRU_DATE),
                                            new JProperty("PAPER_ABSTRACT_WITHDRAWN", q.PAPER_ABSTRACT_WITHDRAWN),
                                            new JProperty("PAPER_ABSTRACT_WITHDRAWN_DATE", q.PAPER_ABSTRACT_WITHDRAWN_DATE),
                                            new JProperty("POSITION", 4)
                                            );
                            k++;
                        }

                        if (q.PAPER_ABSTRACT_DEADLINE_5 != null && q.PAPER_ABSTRACT_TEXT_5 != null)
                        {
                             json5 = new JObject(
                                            new JProperty("PERSON_ID", q.PERSON_ID),
                                            new JProperty("CONFERENCE_ID", q.CONFERENCE_ID),
                                            new JProperty("ORGANIZATION_NAME_1", q.ORGANIZATION_NAME_1),
                                            new JProperty("ORGANIZATION_NAME_2", q.ORGANIZATION_NAME_2),
                                            new JProperty("ORGANIZATION_NAME_3", q.ORGANIZATION_NAME_3),
                                            new JProperty("ORGANIZATION_NAME_4", q.ORGANIZATION_NAME_4),
                                            new JProperty("ORGANIZATION_NAME_5", q.ORGANIZATION_NAME_5),
                                            new JProperty("CORRESPONDING_AUTHOR", q.CORRESPONDING_AUTHOR),
                                            new JProperty("PAPER_ID", q.PAPER_ID),
                                            new JProperty("CONFERENCE_NAME", q.CONFERENCE_NAME5),
                                            new JProperty("PAPER_ABSTRACT_DEADLINE", q.PAPER_ABSTRACT_DEADLINE_5),
                                            new JProperty("PAPER_TEXT_DEADLINE", q.PAPER_TEXT_DEADLINE_5),
                                            new JProperty("PAPER_ABSTRACT_TEXT", q.PAPER_ABSTRACT_TEXT_5),
                                            new JProperty("PAPER_ABSTRACT_TEXT_EN", q.PAPER_ABSTRACT_TEXT_EN_5),
                                            new JProperty("FULL_PAPER_OR_WORK_IN_PROGRESS", q.FULL_PAPER_OR_WORK_IN_PROGRESS_5),
                                            new JProperty("CONFERENCE_SESSION_TOPIC_ID", q.CONFERENCE_SESSION_TOPIC_ID_5),
                                            new JProperty("CONFERENCE_SESSION_TOPIC_NAME", q.CONFERENCE_SESSION_TOPIC_NAME_5),
                                            new JProperty("CONFERENCE_SESSION_TOPIC_NAME_EN", q.CONFERENCE_SESSION_TOPIC_NAME_EN_5),
                                            new JProperty("TYPE_OF_STUDY_ID", q.TYPE_OF_STUDY_ID_5),
                                            new JProperty("TYPE_OF_STUDY_NAME", q.TYPE_OF_STUDY_NAME_5),
                                            new JProperty("TYPE_OF_STUDY_NAME_EN", q.TYPE_OF_STUDY_NAME_EN_5),
                                            new JProperty("CONFERENCE_PRESENTATION_TYPE_ID", q.CONFERENCE_PRESENTATION_TYPE_ID_5),
                                            new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME", q.CONFERENCE_PRESENTATION_TYPE_NAME_5),
                                            new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME_EN", q.CONFERENCE_PRESENTATION_TYPE_NAME_EN_5),
                                            new JProperty("FIRST_SUBMITTED_DATE", q.FIRST_SUBMITTED_DATE_5),
                                            new JProperty("LAST_REVISED_DATE", q.LAST_REVISED_DATE_5),
                                            new JProperty("PAPER_ABSTRACT_ATTACHED_FILENAME", q.PAPER_ABSTRACT_ATTACHED_FILENAME_5),
                                            new JProperty("FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT", q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT),
                                            new JProperty("FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_DATE", q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_DATE),
                                            new JProperty("FROM_DATE", q.FROM_DATE),
                                            new JProperty("THRU_DATE", q.THRU_DATE),
                                            new JProperty("PAPER_ABSTRACT_WITHDRAWN", q.PAPER_ABSTRACT_WITHDRAWN),
                                            new JProperty("PAPER_ABSTRACT_WITHDRAWN_DATE", q.PAPER_ABSTRACT_WITHDRAWN_DATE),
                                            new JProperty("POSITION", 5)
                                            );
                            k++;
                        }

                        if (k > 0)
                        {
                            switch (k)
                            {
                                case 1:
                                    jsonArray.Add(json1);
                                    break;
                                case 2:
                                    jsonArray.Add(json2);
                                    break;
                                case 3:
                                    jsonArray.Add(json3);
                                    break;
                                case 4:
                                    jsonArray.Add(json4);
                                    break;
                                case 5:
                                    jsonArray.Add(json5);
                                    break;
                            }
                        }
                        //end for

                    }

                    return ResponseSuccess(StringResource.Success, jsonArray);
                }
                else
                {
                    return ResponseFail(StringResource.Data_not_received);
                }


            }
            else
            {
                return ResponseFail(StringResource.Data_not_received);
            }
        }



        /*
         * Lấy thông tin chi tiết 1 bài abstract - chức năng xem
         * author_paper_abstract_relationship.PERSON_ID
         * join conference in db.CONFERENCEs on 
         */
        [HttpPost]
        [Route("api/SeeAbstract")]
        public HttpResponseMessage SeeAbstract([FromBody] SeePaper paper)
        {
            if (paper.Id > 0 && paper.position >= 0)
            {
                var paperAbstractModels = new AuthorAbstractModel();
                var paperAbs = paperAbstractModels.GetPaperAbstractById(paper.Id);
                var jsonArray = new JArray();
                try
                {
                    switch (paper.position)
                    {
                        case 1:
                            var json1 = new JObject(
                                                new JProperty("PAPER_ABSTRACT_TITLE", paperAbs.PAPER_ABSTRACT_TITLE_1),
                                                new JProperty("PAPER_ABSTRACT_TITLE_EN", paperAbs.PAPER_ABSTRACT_TITLE_EN_1),
                                                new JProperty("CONFERENCE_SESSION_TOPIC_NAME", paperAbs.CONFERENCE_SESSION_TOPIC_NAME_1),
                                                new JProperty("TYPE_OF_STUDY_NAME", paperAbs.TYPE_OF_STUDY_NAME_1),
                                                new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME", paperAbs.CONFERENCE_PRESENTATION_TYPE_NAME_1),
                                                new JProperty("PAPER_ABSTRACT_TEXT", paperAbs.PAPER_ABSTRACT_TEXT_1),
                                                new JProperty("PAPER_ABSTRACT_TEXT_EN", paperAbs.PAPER_ABSTRACT_TEXT_EN_1)
                                                );
                            jsonArray.Add(json1);
                            break;
                        case 2:
                            var json2 = new JObject(
                                                new JProperty("PAPER_ABSTRACT_TITLE", paperAbs.PAPER_ABSTRACT_TITLE_2),
                                                new JProperty("PAPER_ABSTRACT_TITLE_EN", paperAbs.PAPER_ABSTRACT_TITLE_EN_2),
                                                new JProperty("CONFERENCE_SESSION_TOPIC_NAME", paperAbs.CONFERENCE_SESSION_TOPIC_NAME_2),
                                                new JProperty("TYPE_OF_STUDY_NAME", paperAbs.TYPE_OF_STUDY_NAME_2),
                                                new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME", paperAbs.CONFERENCE_PRESENTATION_TYPE_NAME_2),
                                                new JProperty("PAPER_ABSTRACT_TEXT", paperAbs.PAPER_ABSTRACT_TEXT_2),
                                                new JProperty("PAPER_ABSTRACT_TEXT_EN", paperAbs.PAPER_ABSTRACT_TEXT_EN_2)
                                                );
                            jsonArray.Add(json2);
                            break;
                        case 3:
                            var json3 = new JObject(
                                                new JProperty("PAPER_ABSTRACT_TITLE", (paperAbs.PAPER_ABSTRACT_TITLE_2 == null) ? paperAbs.PAPER_ABSTRACT_TITLE_1 : paperAbs.PAPER_ABSTRACT_TITLE_2),
                                                new JProperty("PAPER_ABSTRACT_TITLE_EN", (paperAbs.PAPER_ABSTRACT_TITLE_EN_2 == null) ? paperAbs.PAPER_ABSTRACT_TITLE_EN_1 : paperAbs.PAPER_ABSTRACT_TITLE_EN_2),
                                                new JProperty("CONFERENCE_SESSION_TOPIC_NAME", (paperAbs.CONFERENCE_SESSION_TOPIC_NAME_2 == null) ? paperAbs.CONFERENCE_SESSION_TOPIC_NAME_1 : paperAbs.CONFERENCE_SESSION_TOPIC_NAME_2),
                                                new JProperty("TYPE_OF_STUDY_NAME", paperAbs.TYPE_OF_STUDY_NAME_3),
                                                new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME", paperAbs.CONFERENCE_PRESENTATION_TYPE_NAME_3),
                                                new JProperty("PAPER_ABSTRACT_TEXT", paperAbs.PAPER_ABSTRACT_TEXT_3),
                                                new JProperty("PAPER_ABSTRACT_TEXT_EN", paperAbs.PAPER_ABSTRACT_TEXT_EN_3)
                                                );
                            jsonArray.Add(json3);
                            break;
                        case 4:
                            var json4 = new JObject(
                                                new JProperty("PAPER_ABSTRACT_TITLE", (paperAbs.PAPER_ABSTRACT_TITLE_2 == null) ? paperAbs.PAPER_ABSTRACT_TITLE_1 : paperAbs.PAPER_ABSTRACT_TITLE_2),
                                                new JProperty("PAPER_ABSTRACT_TITLE_EN", (paperAbs.PAPER_ABSTRACT_TITLE_EN_2 == null) ? paperAbs.PAPER_ABSTRACT_TITLE_EN_1 : paperAbs.PAPER_ABSTRACT_TITLE_EN_2),
                                                new JProperty("CONFERENCE_SESSION_TOPIC_NAME", (paperAbs.CONFERENCE_SESSION_TOPIC_NAME_2 == null) ? paperAbs.CONFERENCE_SESSION_TOPIC_NAME_1 : paperAbs.CONFERENCE_SESSION_TOPIC_NAME_2),
                                                new JProperty("TYPE_OF_STUDY_NAME", paperAbs.TYPE_OF_STUDY_NAME_4),
                                                new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME", paperAbs.CONFERENCE_PRESENTATION_TYPE_NAME_4),
                                                new JProperty("PAPER_ABSTRACT_TEXT", paperAbs.PAPER_ABSTRACT_TEXT_4),
                                                new JProperty("PAPER_ABSTRACT_TEXT_EN", paperAbs.PAPER_ABSTRACT_TEXT_EN_4)
                                                );
                            jsonArray.Add(json4);
                            break;
                        case 5:
                            var json5 = new JObject(
                                                new JProperty("PAPER_ABSTRACT_TITLE", (paperAbs.PAPER_ABSTRACT_TITLE_2 == null) ? paperAbs.PAPER_ABSTRACT_TITLE_1 : paperAbs.PAPER_ABSTRACT_TITLE_2),
                                                new JProperty("PAPER_ABSTRACT_TITLE_EN", (paperAbs.PAPER_ABSTRACT_TITLE_EN_2 == null) ? paperAbs.PAPER_ABSTRACT_TITLE_EN_1 : paperAbs.PAPER_ABSTRACT_TITLE_EN_2),
                                                new JProperty("CONFERENCE_SESSION_TOPIC_NAME", (paperAbs.CONFERENCE_SESSION_TOPIC_NAME_2 == null) ? paperAbs.CONFERENCE_SESSION_TOPIC_NAME_1 : paperAbs.CONFERENCE_SESSION_TOPIC_NAME_2),
                                                new JProperty("TYPE_OF_STUDY_NAME", paperAbs.TYPE_OF_STUDY_NAME_5),
                                                new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME", paperAbs.CONFERENCE_PRESENTATION_TYPE_NAME_5),
                                                new JProperty("PAPER_ABSTRACT_TEXT", paperAbs.PAPER_ABSTRACT_TEXT_5),
                                                new JProperty("PAPER_ABSTRACT_TEXT_EN", paperAbs.PAPER_ABSTRACT_TEXT_EN_5)
                                                );
                            jsonArray.Add(json5);
                            break;
                    }
                    return ResponseSuccess(StringResource.Success, jsonArray);
                }
                catch (Exception)
                {
                    return ResponseFail(StringResource.Data_not_received);
                }



            }
            else
            {
                return ResponseFail(StringResource.Data_not_received);
            }
        }

        /*
         * cập nhật 1 bài abstract (từ chối, đang soạn) của 1 author
         */
        [HttpPost]
        [Route("api/UpdateAbstract")]
        public HttpResponseMessage UpdateAbstract([FromBody] Abstract abstracts)
        {


            if (abstracts.PAPER_ID >= 0)
            {

                var paperAbstractModels = new AuthorAbstractModel();
                var paperAbstract = paperAbstractModels.UpdateAbstractById(abstracts.PAPER_ID, abstracts.PAPER_ABSTRACT_TITLE, abstracts.PAPER_ABSTRACT_TITLE_EN, abstracts.CONFERENCE_SESSION_TOPIC_ID,
            abstracts.CONFERENCE_SESSION_TOPIC_NAME, abstracts.CONFERENCE_SESSION_TOPIC_NAME_EN, abstracts.PAPER_ABSTRACT_TEXT, abstracts.PAPER_ABSTRACT_TEXT_EN, abstracts.FULL_PAPER_OR_WORK_IN_PROGRESS,
            abstracts.TYPE_OF_STUDY_ID, abstracts.TYPE_OF_STUDY_NAME, abstracts.TYPE_OF_STUDY_NAME_EN, abstracts.CONFERENCE_PRESENTATION_TYPE_ID, abstracts.CONFERENCE_PRESENTATION_TYPE_NAME,
            abstracts.CONFERENCE_PRESENTATION_TYPE_NAME_EN, abstracts.POSITION, abstracts.PAPER_ABSTRACT_ATTACHED_FILENAME, abstracts.TRANGTHAI);
                if (paperAbstract == true)
                {
                    var result = new ResuleBoolean();
                    result.result = paperAbstract;
                    return ResponseSuccess(StringResource.Success, result);
                }
                else
                {
                    var result = new ResuleBoolean();
                    result.result = paperAbstract;
                    return ResponseSuccess(StringResource.Success, result);
                }
            }
            else
            {
                return ResponseFail(StringResource.Data_not_received);
            }
        }


        [HttpPost]
        [Route("api/CheckReviewAbstract")]
        public HttpResponseMessage CheckReviewAbstract(int PERSON_ID, int PAPER_ID)
        {
            var query = from REVIEWER_PAPER_ABSTRACT_RELATIONSHIP in db.REVIEWER_PAPER_ABSTRACT_RELATIONSHIP
                        where REVIEWER_PAPER_ABSTRACT_RELATIONSHIP.PERSON_ID == PERSON_ID &&
                        REVIEWER_PAPER_ABSTRACT_RELATIONSHIP.PAPER_ID == PAPER_ID
                        group REVIEWER_PAPER_ABSTRACT_RELATIONSHIP by new { REVIEWER_PAPER_ABSTRACT_RELATIONSHIP.PAPER_ID } into g
                        select new {
                            NUMBER = g.Max(i => i.PAPER_ABSTRACT_SUBMISSION_DEADLINE_ORDER_NUMBER)
                        };
            ResuleBoolean kq = new ResuleBoolean();
            if (query.Count() > 0)
            {
                // đa có nguoi danh giá
                int max = 0;
                foreach (var item in query)
                {
                    max = item.NUMBER;
                }
                if (max == 0)
                {
                    // chua ai danh gia
                    kq.result = true;
                    return ResponseSuccess(StringResource.Success, kq);
                } else
                {
                    // da danh gia
                    kq.result = false;
                    return ResponseSuccess(StringResource.Success, kq);
                }
                
            } else
            {
                // chua ai danh gia
                kq.result = true;
                return ResponseSuccess(StringResource.Success, kq);
            }


            
        }

        public class UserAuthor
        {
            public int PERSON_ID { get; set; }
            public int CONFERENCE_ID { get; set; }
        }



        /*
         * Rút bài báo tóm tắt
         */
        [HttpPost]
        [Route("api/WithDrawnAbstract")]
        public HttpResponseMessage WithDrawnAbstract([FromBody] WithDrawn paper)
        {
            int value;
            var paperAbstractModels = new AuthorAbstractModel();
            var paperAbstract = paperAbstractModels.WithdrawnPaperAbstract(paper.Id);
            if (paperAbstract == null)
            {
                return ResponseFail(StringResource.Data_not_received);
            }
            else if (int.TryParse(paper.Id + "", out value))
            {
                if (paperAbstract == true)
                {
                    var result = new ResuleBoolean();
                    result.result = paperAbstract;

                    return ResponseSuccess(StringResource.Success, result);
                }
                else
                {
                    var result = new ResuleBoolean();
                    result.result = paperAbstract;
                    return ResponseSuccess(StringResource.Success, result);
                }
            }
            else
            {
                return ResponseFail(StringResource.Data_not_received);
            }

        }

        /*
         * Danh sách chủ đề
         */
        [HttpPost]
        [Route("api/Session_topic")]
        public HttpResponseMessage Session_topic(int conference_id)
        {
            var item = from sesion_topic in db.CONFERENCE_SESSION_TOPIC
                       where sesion_topic.CONFERENCE_ID == conference_id
                       select new { sesion_topic.CONFERENCE_SESSION_TOPIC_ID, sesion_topic.CONFERENCE_SESSION_TOPIC_NAME, sesion_topic.CONFERENCE_SESSION_TOPIC_NAME_EN };
            if (item != null)
            {
                return ResponseSuccess(StringResource.Success, item);
            }
            else
            {
                return ResponseFail(StringResource.Data_not_received);
            }
        }


        /*
         * Danh sách loại hình nghiên cứu
         */
        [HttpPost]
        [Route("api/Type_of_study")]
        public HttpResponseMessage Type_of_study(int conference_id)
        {
            var item = (from type_of_study in db.TYPE_OF_STUDY
                        join cf_type in db.CONFERENCE_TYPE_OF_STUDY_RELATIONSHIP on type_of_study.TYPE_OF_STUDY_ID equals cf_type.TYPE_OF_STUDY_ID
                        where cf_type.CONFERENCE_ID == conference_id
                        select new { type_of_study.TYPE_OF_STUDY_ID, type_of_study.TYPE_OF_STUDY_NAME, type_of_study.TYPE_OF_STUDY_NAME_EN })
                       .Distinct();
            if (item != null)
            {
                return ResponseSuccess(StringResource.Success, item);
            }
            else
            {
                return ResponseFail(StringResource.Data_not_received);
            }
        }


        /*
         * Danh sách loại hình trình bày
         */
        [HttpPost]
        [Route("api/Conference_presentation_type")]
        public HttpResponseMessage Conference_presentation_type(int conference_id)
        {
            var item = (from conference_presentation in db.CONFERENCE_PRESENTATION_TYPE
                        join cf in db.SESSION_TOPIC_CONFERENCE_PRESENTATION_TYPE on conference_presentation.CONFERENCE_PRESENTATION_TYPE_ID equals cf.CONFERENCE_PRESENTATION_TYPE_ID
                        where cf.CONFERENCE_ID == conference_id
                        select new
                        {
                            conference_presentation.CONFERENCE_PRESENTATION_TYPE_ID,
                            conference_presentation.CONFERENCE_PRESENTATION_TYPE_NAME,
                            conference_presentation.CONFERENCE_PRESENTATION_TYPE_NAME_EN
                        }).Distinct();
            if (item != null)
            {
                return ResponseSuccess(StringResource.Success, item);
            }
            else
            {
                return ResponseFail(StringResource.Data_not_received);
            }
        }



        [HttpPost]
        [Route("api/getFileNamePaperAbstract")]
        public HttpResponseMessage getFileNamePaperAbstract([FromBody] ItemPaper2 paper)
        {

            var result = from item in db.PAPER_ABSTRACT
                         where item.PAPER_ID == paper.PAPER_ID
                         select new
                         {
                             item.PAPER_ABSTRACT_ATTACHED_FILENAME_1,
                             item.PAPER_ABSTRACT_ATTACHED_FILENAME_2,
                             item.PAPER_ABSTRACT_ATTACHED_FILENAME_3,
                             item.PAPER_ABSTRACT_ATTACHED_FILENAME_4,
                             item.PAPER_ABSTRACT_ATTACHED_FILENAME_5
                         };
            return ResponseSuccess(StringResource.Success, result);
        }




        /*
         * Lấy 1 bài báo theo trạng thái review
         */
        [HttpPost]
        [Route("api/getItemAbstractforReview")]
        public HttpResponseMessage getItemAbstractforReview([FromBody] Param_getItemAbstractforReview item)
        {
            try
            {
                Boolean trangthai = true;
                var jsonArray = new JArray();

                switch (item.statusReview)
                {
                    case 1:
                        trangthai = false; // từ chối
                        break;
                    case 2:
                        trangthai = true; // đồng ý
                        break;
                }

                if (item.statusReview == 3)
                {
                    var query = (from list_author_paper_abstract_relationship in db.AUTHOR_PAPER_ABSTRACT_RELATIONSHIP
                                 join list_paper_abstarct in db.PAPER_ABSTRACT on list_author_paper_abstract_relationship.PAPER_ID equals list_paper_abstarct.PAPER_ID
                                 join confer in db.CONFERENCEs on list_author_paper_abstract_relationship.CONFERENCE_ID equals confer.CONFERENCE_ID
                                 where list_paper_abstarct.PAPER_ID == item.idPaper && list_paper_abstarct.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT == null
                                        && list_paper_abstarct.PAPER_ABSTRACT_WITHDRAWN == null
                                 select
                                 new
                                 {
                                     list_author_paper_abstract_relationship.PERSON_ID,
                                     list_author_paper_abstract_relationship.CONFERENCE_ID,
                                     list_author_paper_abstract_relationship.ORGANIZATION_ID_1,
                                     list_author_paper_abstract_relationship.ORGANIZATION_NAME_1,
                                     list_author_paper_abstract_relationship.ORGANIZATION_NAME_EN_1,
                                     list_author_paper_abstract_relationship.ORGANIZATION_ID_2,
                                     list_author_paper_abstract_relationship.ORGANIZATION_NAME_2,
                                     list_author_paper_abstract_relationship.ORGANIZATION_ID_3,
                                     list_author_paper_abstract_relationship.ORGANIZATION_NAME_3,
                                     list_author_paper_abstract_relationship.ORGANIZATION_ID_4,
                                     list_author_paper_abstract_relationship.ORGANIZATION_NAME_4,
                                     list_author_paper_abstract_relationship.ORGANIZATION_ID_5,
                                     list_author_paper_abstract_relationship.ORGANIZATION_NAME_5,
                                     list_author_paper_abstract_relationship.CORRESPONDING_AUTHOR,
                                     CONFERENCE_NAME1 = (confer.CONFERENCE_NAME + " - " + list_paper_abstarct.PAPER_ABSTRACT_TITLE_1),
                                     confer.PAPER_ABSTRACT_DEADLINE_1,
                                     confer.FROM_DATE,
                                     confer.THRU_DATE,
                                     list_paper_abstarct.PAPER_ID,
                                     list_paper_abstarct.PAPER_NUMBER_OR_CODE,

                                     list_paper_abstarct.PAPER_ABSTRACT_TITLE_1,
                                     list_paper_abstarct.PAPER_ABSTRACT_TITLE_EN_1,
                                     list_paper_abstarct.CONFERENCE_SESSION_TOPIC_ID_1,
                                     list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_1,
                                     list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_EN_1,
                                     list_paper_abstarct.PAPER_ABSTRACT_TEXT_1,
                                     list_paper_abstarct.FULL_PAPER_OR_WORK_IN_PROGRESS_1,
                                     list_paper_abstarct.TYPE_OF_STUDY_ID_1,
                                     list_paper_abstarct.TYPE_OF_STUDY_NAME_1,
                                     list_paper_abstarct.TYPE_OF_STUDY_NAME_EN_1,
                                     list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_ID_1,
                                     list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_NAME_1,
                                     list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_NAME_EN_1,
                                     list_paper_abstarct.FIRST_SUBMITTED_DATE_1,
                                     list_paper_abstarct.LAST_REVISED_DATE_1,


                                     CONFERENCE_NAME2 = list_paper_abstarct.PAPER_ABSTRACT_TITLE_2 == null ? null : (confer.CONFERENCE_NAME + " - " + list_paper_abstarct.PAPER_ABSTRACT_TITLE_2),
                                     confer.PAPER_ABSTRACT_DEADLINE_2,
                                     list_paper_abstarct.PAPER_ABSTRACT_TITLE_2,
                                     list_paper_abstarct.PAPER_ABSTRACT_TITLE_EN_2,
                                     list_paper_abstarct.CONFERENCE_SESSION_TOPIC_ID_2,
                                     list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_2,
                                     list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_EN_2,
                                     list_paper_abstarct.PAPER_ABSTRACT_TEXT_2,
                                     list_paper_abstarct.FULL_PAPER_OR_WORK_IN_PROGRESS_2,
                                     list_paper_abstarct.TYPE_OF_STUDY_ID_2,
                                     list_paper_abstarct.TYPE_OF_STUDY_NAME_2,
                                     list_paper_abstarct.TYPE_OF_STUDY_NAME_EN_2,
                                     list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_ID_2,
                                     list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_NAME_2,
                                     list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_NAME_EN_2,
                                     list_paper_abstarct.FIRST_SUBMITTED_DATE_2,
                                     list_paper_abstarct.LAST_REVISED_DATE_2,


                                     CONFERENCE_NAME3 = list_paper_abstarct.PAPER_ABSTRACT_TITLE_2 == null ? null : (confer.CONFERENCE_NAME + " - " + list_paper_abstarct.PAPER_ABSTRACT_TITLE_2),
                                     confer.PAPER_ABSTRACT_DEADLINE_3,
                                     list_paper_abstarct.PAPER_ABSTRACT_TEXT_3,
                                     list_paper_abstarct.FULL_PAPER_OR_WORK_IN_PROGRESS_3,
                                     list_paper_abstarct.TYPE_OF_STUDY_ID_3,
                                     list_paper_abstarct.TYPE_OF_STUDY_NAME_3,
                                     list_paper_abstarct.TYPE_OF_STUDY_NAME_EN_3,
                                     list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_ID_3,
                                     list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_NAME_3,
                                     list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_NAME_EN_3,
                                     list_paper_abstarct.FIRST_SUBMITTED_DATE_3,
                                     list_paper_abstarct.LAST_REVISED_DATE_3,
                                     CONFERENCE_NAME4 = list_paper_abstarct.PAPER_ABSTRACT_TITLE_2 == null ? null : (confer.CONFERENCE_NAME + " - " + list_paper_abstarct.PAPER_ABSTRACT_TITLE_2),
                                     CONFERENCE_SESSION_TOPIC_ID_3 = list_paper_abstarct.CONFERENCE_SESSION_TOPIC_ID_2 == null ? list_paper_abstarct.CONFERENCE_SESSION_TOPIC_ID_1 : list_paper_abstarct.CONFERENCE_SESSION_TOPIC_ID_2,
                                     CONFERENCE_SESSION_TOPIC_NAME_3 = list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_2 == null ? list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_1 : list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_2,
                                     CONFERENCE_SESSION_TOPIC_NAME_EN_3 = list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_EN_2 == null ? list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_EN_1 : list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_EN_2,


                                     confer.PAPER_ABSTRACT_DEADLINE_4,
                                     list_paper_abstarct.PAPER_ABSTRACT_TEXT_4,
                                     list_paper_abstarct.FULL_PAPER_OR_WORK_IN_PROGRESS_4,
                                     list_paper_abstarct.TYPE_OF_STUDY_ID_4,
                                     list_paper_abstarct.TYPE_OF_STUDY_NAME_4,
                                     list_paper_abstarct.TYPE_OF_STUDY_NAME_EN_4,
                                     list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_ID_4,
                                     list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_NAME_4,
                                     list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_NAME_EN_4,
                                     list_paper_abstarct.FIRST_SUBMITTED_DATE_4,
                                     list_paper_abstarct.LAST_REVISED_DATE_4,
                                     CONFERENCE_SESSION_TOPIC_ID_4 = list_paper_abstarct.CONFERENCE_SESSION_TOPIC_ID_2 == null ? list_paper_abstarct.CONFERENCE_SESSION_TOPIC_ID_1 : list_paper_abstarct.CONFERENCE_SESSION_TOPIC_ID_2,
                                     CONFERENCE_SESSION_TOPIC_NAME_4 = list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_2 == null ? list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_1 : list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_2,
                                     CONFERENCE_SESSION_TOPIC_NAME_EN_4 = list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_EN_2 == null ? list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_EN_1 : list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_EN_2,


                                     CONFERENCE_NAME5 = list_paper_abstarct.PAPER_ABSTRACT_TITLE_2 == null ? null : (confer.CONFERENCE_NAME + " - " + list_paper_abstarct.PAPER_ABSTRACT_TITLE_2),
                                     confer.PAPER_ABSTRACT_DEADLINE_5,
                                     list_paper_abstarct.PAPER_ABSTRACT_TEXT_5,
                                     list_paper_abstarct.FULL_PAPER_OR_WORK_IN_PROGRESS_5,
                                     list_paper_abstarct.TYPE_OF_STUDY_ID_5,
                                     list_paper_abstarct.TYPE_OF_STUDY_NAME_5,
                                     list_paper_abstarct.TYPE_OF_STUDY_NAME_EN_5,
                                     list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_ID_5,
                                     list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_NAME_5,
                                     list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_NAME_EN_5,
                                     list_paper_abstarct.FIRST_SUBMITTED_DATE_5,
                                     list_paper_abstarct.LAST_REVISED_DATE_5,
                                     CONFERENCE_SESSION_TOPIC_ID_5 = list_paper_abstarct.CONFERENCE_SESSION_TOPIC_ID_2 == null ? list_paper_abstarct.CONFERENCE_SESSION_TOPIC_ID_1 : list_paper_abstarct.CONFERENCE_SESSION_TOPIC_ID_2,
                                     CONFERENCE_SESSION_TOPIC_NAME_5 = list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_2 == null ? list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_1 : list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_2,
                                     CONFERENCE_SESSION_TOPIC_NAME_EN_5 = list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_EN_2 == null ? list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_EN_1 : list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_EN_2,


                                     list_paper_abstarct.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT,
                                     list_paper_abstarct.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_REVIEWER_PERSON_ID,
                                     list_paper_abstarct.PAPER_ABSTRACT_WITHDRAWN
                                 }).Take(1);
                    if (query != null)
                    {

                        foreach (var q in query)
                        {
                            int k = 0;
                            var json1 = new JObject();
                            var json2 = new JObject();
                            var json3 = new JObject();
                            var json4 = new JObject();
                            var json5 = new JObject();
                            if ((q.PAPER_ABSTRACT_TITLE_1 != null || q.PAPER_ABSTRACT_DEADLINE_1 != null)
                                && (q.FULL_PAPER_OR_WORK_IN_PROGRESS_1 == "FULL_PAPER" || q.FULL_PAPER_OR_WORK_IN_PROGRESS_1 == "FULL PAPER" ||
                                q.FULL_PAPER_OR_WORK_IN_PROGRESS_1 == "full_paper" || q.FULL_PAPER_OR_WORK_IN_PROGRESS_1 == "full paper" ||
                                q.FULL_PAPER_OR_WORK_IN_PROGRESS_1 == "fullpaper" || q.FULL_PAPER_OR_WORK_IN_PROGRESS_1 == "FULLPAPER")
                                )
                            {
                                json1 = new JObject(
                                               new JProperty("PERSON_ID", q.PERSON_ID),
                                               new JProperty("CONFERENCE_ID", q.CONFERENCE_ID),
                                               new JProperty("ORGANIZATION_NAME_1", q.ORGANIZATION_NAME_1),
                                               new JProperty("ORGANIZATION_NAME_2", q.ORGANIZATION_NAME_2),
                                               new JProperty("ORGANIZATION_NAME_3", q.ORGANIZATION_NAME_3),
                                               new JProperty("ORGANIZATION_NAME_4", q.ORGANIZATION_NAME_4),
                                               new JProperty("ORGANIZATION_NAME_5", q.ORGANIZATION_NAME_5),
                                               new JProperty("CORRESPONDING_AUTHOR", q.CORRESPONDING_AUTHOR),
                                               new JProperty("PAPER_ID", q.PAPER_ID),
                                               new JProperty("CONFERENCE_NAME", q.CONFERENCE_NAME1),
                                               new JProperty("PAPER_ABSTRACT_DEADLINE", q.PAPER_ABSTRACT_DEADLINE_1),
                                               new JProperty("PAPER_ABSTRACT_TITLE", q.PAPER_ABSTRACT_TITLE_1),
                                               new JProperty("PAPER_ABSTRACT_TITLE_EN", q.PAPER_ABSTRACT_TITLE_EN_1),
                                               new JProperty("CONFERENCE_SESSION_TOPIC_ID", q.CONFERENCE_SESSION_TOPIC_ID_1),
                                               new JProperty("CONFERENCE_SESSION_TOPIC_NAME", q.CONFERENCE_SESSION_TOPIC_NAME_1),
                                               new JProperty("CONFERENCE_SESSION_TOPIC_NAME_EN", q.CONFERENCE_SESSION_TOPIC_NAME_EN_1),
                                               new JProperty("PAPER_ABSTRACT_TEXT", q.PAPER_ABSTRACT_TEXT_1),
                                               new JProperty("FULL_PAPER_OR_WORK_IN_PROGRESS", q.FULL_PAPER_OR_WORK_IN_PROGRESS_1),
                                               new JProperty("TYPE_OF_STUDY_ID", q.TYPE_OF_STUDY_ID_1),
                                               new JProperty("TYPE_OF_STUDY_NAME", q.TYPE_OF_STUDY_NAME_1),
                                               new JProperty("TYPE_OF_STUDY_NAME_EN", q.TYPE_OF_STUDY_NAME_EN_1),
                                               new JProperty("CONFERENCE_PRESENTATION_TYPE_ID", q.CONFERENCE_PRESENTATION_TYPE_ID_1),
                                               new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME", q.CONFERENCE_PRESENTATION_TYPE_NAME_1),
                                               new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME_EN", q.CONFERENCE_PRESENTATION_TYPE_NAME_EN_1),
                                               new JProperty("FIRST_SUBMITTED_DATE", q.FIRST_SUBMITTED_DATE_1),
                                               new JProperty("LAST_REVISED_DATE", q.LAST_REVISED_DATE_1),
                                               new JProperty("FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT", q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT),
                                               new JProperty("FROM_DATE", q.FROM_DATE),
                                               new JProperty("THRU_DATE", q.THRU_DATE),
                                               new JProperty("PAPER_ABSTRACT_WITHDRAWN", q.PAPER_ABSTRACT_WITHDRAWN),
                                               new JProperty("POSITION", 1)
                                               );
                                k++;
                            }

                            if ((q.PAPER_ABSTRACT_TITLE_2 != null || q.PAPER_ABSTRACT_DEADLINE_2 != null)
                                && (q.FULL_PAPER_OR_WORK_IN_PROGRESS_2 == "FULL_PAPER" || q.FULL_PAPER_OR_WORK_IN_PROGRESS_2 == "FULL PAPER" ||
                                q.FULL_PAPER_OR_WORK_IN_PROGRESS_2 == "full_paper" || q.FULL_PAPER_OR_WORK_IN_PROGRESS_2 == "full paper" ||
                                q.FULL_PAPER_OR_WORK_IN_PROGRESS_2 == "fullpaper" || q.FULL_PAPER_OR_WORK_IN_PROGRESS_2 == "FULLPAPER"))
                            {
                                json2 = new JObject(
                                               new JProperty("PERSON_ID", q.PERSON_ID),
                                               new JProperty("CONFERENCE_ID", q.CONFERENCE_ID),
                                               new JProperty("ORGANIZATION_NAME_1", q.ORGANIZATION_NAME_1),
                                               new JProperty("ORGANIZATION_NAME_2", q.ORGANIZATION_NAME_2),
                                               new JProperty("ORGANIZATION_NAME_3", q.ORGANIZATION_NAME_3),
                                               new JProperty("ORGANIZATION_NAME_4", q.ORGANIZATION_NAME_4),
                                               new JProperty("ORGANIZATION_NAME_5", q.ORGANIZATION_NAME_5),
                                               new JProperty("CORRESPONDING_AUTHOR", q.CORRESPONDING_AUTHOR),
                                               new JProperty("PAPER_ID", q.PAPER_ID),
                                               new JProperty("CONFERENCE_NAME", q.CONFERENCE_NAME2),
                                               new JProperty("PAPER_ABSTRACT_DEADLINE", q.PAPER_ABSTRACT_DEADLINE_2),
                                               new JProperty("PAPER_ABSTRACT_TITLE", q.PAPER_ABSTRACT_TITLE_2),
                                               new JProperty("PAPER_ABSTRACT_TITLE_EN", q.PAPER_ABSTRACT_TITLE_EN_2),
                                               new JProperty("CONFERENCE_SESSION_TOPIC_ID", q.CONFERENCE_SESSION_TOPIC_ID_2),
                                               new JProperty("CONFERENCE_SESSION_TOPIC_NAME", q.CONFERENCE_SESSION_TOPIC_NAME_2),
                                               new JProperty("CONFERENCE_SESSION_TOPIC_NAME_EN", q.CONFERENCE_SESSION_TOPIC_NAME_EN_2),
                                               new JProperty("PAPER_ABSTRACT_TEXT", q.PAPER_ABSTRACT_TEXT_2),
                                               new JProperty("FULL_PAPER_OR_WORK_IN_PROGRESS", q.FULL_PAPER_OR_WORK_IN_PROGRESS_2),
                                               new JProperty("TYPE_OF_STUDY_ID", q.TYPE_OF_STUDY_ID_2),
                                               new JProperty("TYPE_OF_STUDY_NAME", q.TYPE_OF_STUDY_NAME_2),
                                               new JProperty("TYPE_OF_STUDY_NAME_EN", q.TYPE_OF_STUDY_NAME_EN_2),
                                               new JProperty("CONFERENCE_PRESENTATION_TYPE_ID", q.CONFERENCE_PRESENTATION_TYPE_ID_2),
                                               new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME", q.CONFERENCE_PRESENTATION_TYPE_NAME_2),
                                               new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME_EN", q.CONFERENCE_PRESENTATION_TYPE_NAME_EN_2),
                                               new JProperty("FIRST_SUBMITTED_DATE", q.FIRST_SUBMITTED_DATE_2),
                                               new JProperty("LAST_REVISED_DATE", q.LAST_REVISED_DATE_2),
                                               new JProperty("FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT", q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT),
                                               new JProperty("FROM_DATE", q.FROM_DATE),
                                               new JProperty("THRU_DATE", q.THRU_DATE),
                                               new JProperty("PAPER_ABSTRACT_WITHDRAWN", q.PAPER_ABSTRACT_WITHDRAWN),
                                               new JProperty("POSITION", 2)
                                               );
                                k++;
                            }

                            if (q.PAPER_ABSTRACT_DEADLINE_3 != null &&
                                (q.FULL_PAPER_OR_WORK_IN_PROGRESS_3 == "FULL_PAPER" || q.FULL_PAPER_OR_WORK_IN_PROGRESS_3 == "FULL PAPER" ||
                                q.FULL_PAPER_OR_WORK_IN_PROGRESS_3 == "full_paper" || q.FULL_PAPER_OR_WORK_IN_PROGRESS_3 == "full paper" ||
                                q.FULL_PAPER_OR_WORK_IN_PROGRESS_3 == "fullpaper" || q.FULL_PAPER_OR_WORK_IN_PROGRESS_3 == "FULLPAPER"))
                            {
                                json3 = new JObject(
                                               new JProperty("PERSON_ID", q.PERSON_ID),
                                               new JProperty("CONFERENCE_ID", q.CONFERENCE_ID),
                                               new JProperty("ORGANIZATION_NAME_1", q.ORGANIZATION_NAME_1),
                                               new JProperty("ORGANIZATION_NAME_2", q.ORGANIZATION_NAME_2),
                                               new JProperty("ORGANIZATION_NAME_3", q.ORGANIZATION_NAME_3),
                                               new JProperty("ORGANIZATION_NAME_4", q.ORGANIZATION_NAME_4),
                                               new JProperty("ORGANIZATION_NAME_5", q.ORGANIZATION_NAME_5),
                                               new JProperty("CORRESPONDING_AUTHOR", q.CORRESPONDING_AUTHOR),
                                               new JProperty("PAPER_ID", q.PAPER_ID),
                                               new JProperty("CONFERENCE_NAME", q.CONFERENCE_NAME3),
                                               new JProperty("PAPER_ABSTRACT_DEADLINE", q.PAPER_ABSTRACT_DEADLINE_3),
                                               new JProperty("PAPER_ABSTRACT_TEXT", q.PAPER_ABSTRACT_TEXT_3),
                                               new JProperty("FULL_PAPER_OR_WORK_IN_PROGRESS", q.FULL_PAPER_OR_WORK_IN_PROGRESS_3),
                                               new JProperty("CONFERENCE_SESSION_TOPIC_ID", q.CONFERENCE_SESSION_TOPIC_ID_3),
                                               new JProperty("CONFERENCE_SESSION_TOPIC_NAME", q.CONFERENCE_SESSION_TOPIC_NAME_3),
                                               new JProperty("CONFERENCE_SESSION_TOPIC_NAME_EN", q.CONFERENCE_SESSION_TOPIC_NAME_EN_3),
                                               new JProperty("TYPE_OF_STUDY_ID", q.TYPE_OF_STUDY_ID_3),
                                               new JProperty("TYPE_OF_STUDY_NAME", q.TYPE_OF_STUDY_NAME_3),
                                               new JProperty("TYPE_OF_STUDY_NAME_EN", q.TYPE_OF_STUDY_NAME_EN_3),
                                               new JProperty("CONFERENCE_PRESENTATION_TYPE_ID", q.CONFERENCE_PRESENTATION_TYPE_ID_3),
                                               new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME", q.CONFERENCE_PRESENTATION_TYPE_NAME_3),
                                               new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME_EN", q.CONFERENCE_PRESENTATION_TYPE_NAME_EN_3),
                                               new JProperty("FIRST_SUBMITTED_DATE", q.FIRST_SUBMITTED_DATE_3),
                                               new JProperty("LAST_REVISED_DATE", q.LAST_REVISED_DATE_3),
                                               new JProperty("FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT", q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT),
                                               new JProperty("FROM_DATE", q.FROM_DATE),
                                               new JProperty("THRU_DATE", q.THRU_DATE),
                                               new JProperty("PAPER_ABSTRACT_WITHDRAWN", q.PAPER_ABSTRACT_WITHDRAWN),
                                               new JProperty("POSITION", 3)
                                               );
                                k++;
                            }

                            if (q.PAPER_ABSTRACT_DEADLINE_4 != null
                                && (q.FULL_PAPER_OR_WORK_IN_PROGRESS_4 == "FULL_PAPER" || q.FULL_PAPER_OR_WORK_IN_PROGRESS_4 == "FULL PAPER" ||
                                q.FULL_PAPER_OR_WORK_IN_PROGRESS_4 == "full_paper" || q.FULL_PAPER_OR_WORK_IN_PROGRESS_4 == "full paper" ||
                                q.FULL_PAPER_OR_WORK_IN_PROGRESS_4 == "fullpaper" || q.FULL_PAPER_OR_WORK_IN_PROGRESS_4 == "FULLPAPER"))
                            {
                                json4 = new JObject(
                                               new JProperty("PERSON_ID", q.PERSON_ID),
                                               new JProperty("CONFERENCE_ID", q.CONFERENCE_ID),
                                               new JProperty("ORGANIZATION_NAME_1", q.ORGANIZATION_NAME_1),
                                               new JProperty("ORGANIZATION_NAME_2", q.ORGANIZATION_NAME_2),
                                               new JProperty("ORGANIZATION_NAME_3", q.ORGANIZATION_NAME_3),
                                               new JProperty("ORGANIZATION_NAME_4", q.ORGANIZATION_NAME_4),
                                               new JProperty("ORGANIZATION_NAME_5", q.ORGANIZATION_NAME_5),
                                               new JProperty("CORRESPONDING_AUTHOR", q.CORRESPONDING_AUTHOR),
                                               new JProperty("PAPER_ID", q.PAPER_ID),
                                               new JProperty("CONFERENCE_NAME", q.CONFERENCE_NAME4),
                                               new JProperty("PAPER_ABSTRACT_DEADLINE", q.PAPER_ABSTRACT_DEADLINE_4),
                                               new JProperty("PAPER_ABSTRACT_TEXT", q.PAPER_ABSTRACT_TEXT_4),
                                               new JProperty("FULL_PAPER_OR_WORK_IN_PROGRESS", q.FULL_PAPER_OR_WORK_IN_PROGRESS_4),
                                               new JProperty("CONFERENCE_SESSION_TOPIC_ID", q.CONFERENCE_SESSION_TOPIC_ID_4),
                                               new JProperty("CONFERENCE_SESSION_TOPIC_NAME", q.CONFERENCE_SESSION_TOPIC_NAME_4),
                                               new JProperty("CONFERENCE_SESSION_TOPIC_NAME_EN", q.CONFERENCE_SESSION_TOPIC_NAME_EN_4),
                                               new JProperty("TYPE_OF_STUDY_ID", q.TYPE_OF_STUDY_ID_4),
                                               new JProperty("TYPE_OF_STUDY_NAME", q.TYPE_OF_STUDY_NAME_4),
                                               new JProperty("TYPE_OF_STUDY_NAME_EN", q.TYPE_OF_STUDY_NAME_EN_4),
                                               new JProperty("CONFERENCE_PRESENTATION_TYPE_ID", q.CONFERENCE_PRESENTATION_TYPE_ID_4),
                                               new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME", q.CONFERENCE_PRESENTATION_TYPE_NAME_4),
                                               new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME_EN", q.CONFERENCE_PRESENTATION_TYPE_NAME_EN_4),
                                               new JProperty("FIRST_SUBMITTED_DATE", q.FIRST_SUBMITTED_DATE_4),
                                               new JProperty("LAST_REVISED_DATE", q.LAST_REVISED_DATE_4),
                                               new JProperty("FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT", q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT),
                                               new JProperty("FROM_DATE", q.FROM_DATE),
                                               new JProperty("THRU_DATE", q.THRU_DATE),
                                               new JProperty("PAPER_ABSTRACT_WITHDRAWN", q.PAPER_ABSTRACT_WITHDRAWN),
                                               new JProperty("POSITION", 4)
                                               );
                                k++;
                            }

                            if (q.PAPER_ABSTRACT_DEADLINE_5 != null
                                && (q.FULL_PAPER_OR_WORK_IN_PROGRESS_5 == "FULL_PAPER" || q.FULL_PAPER_OR_WORK_IN_PROGRESS_5 == "FULL PAPER" ||
                                q.FULL_PAPER_OR_WORK_IN_PROGRESS_5 == "full_paper" || q.FULL_PAPER_OR_WORK_IN_PROGRESS_5 == "full paper" ||
                                q.FULL_PAPER_OR_WORK_IN_PROGRESS_5 == "fullpaper" || q.FULL_PAPER_OR_WORK_IN_PROGRESS_5 == "FULLPAPER"))
                            {
                                json5 = new JObject(
                                               new JProperty("PERSON_ID", q.PERSON_ID),
                                               new JProperty("CONFERENCE_ID", q.CONFERENCE_ID),
                                               new JProperty("ORGANIZATION_NAME_1", q.ORGANIZATION_NAME_1),
                                               new JProperty("ORGANIZATION_NAME_2", q.ORGANIZATION_NAME_2),
                                               new JProperty("ORGANIZATION_NAME_3", q.ORGANIZATION_NAME_3),
                                               new JProperty("ORGANIZATION_NAME_4", q.ORGANIZATION_NAME_4),
                                               new JProperty("ORGANIZATION_NAME_5", q.ORGANIZATION_NAME_5),
                                               new JProperty("CORRESPONDING_AUTHOR", q.CORRESPONDING_AUTHOR),
                                               new JProperty("PAPER_ID", q.PAPER_ID),
                                               new JProperty("CONFERENCE_NAME", q.CONFERENCE_NAME5),
                                               new JProperty("PAPER_ABSTRACT_DEADLINE", q.PAPER_ABSTRACT_DEADLINE_5),
                                               new JProperty("PAPER_ABSTRACT_TEXT", q.PAPER_ABSTRACT_TEXT_5),
                                               new JProperty("FULL_PAPER_OR_WORK_IN_PROGRESS", q.FULL_PAPER_OR_WORK_IN_PROGRESS_5),
                                               new JProperty("CONFERENCE_SESSION_TOPIC_ID", q.CONFERENCE_SESSION_TOPIC_ID_5),
                                               new JProperty("CONFERENCE_SESSION_TOPIC_NAME", q.CONFERENCE_SESSION_TOPIC_NAME_5),
                                               new JProperty("CONFERENCE_SESSION_TOPIC_NAME_EN", q.CONFERENCE_SESSION_TOPIC_NAME_EN_5),
                                               new JProperty("TYPE_OF_STUDY_ID", q.TYPE_OF_STUDY_ID_5),
                                               new JProperty("TYPE_OF_STUDY_NAME", q.TYPE_OF_STUDY_NAME_5),
                                               new JProperty("TYPE_OF_STUDY_NAME_EN", q.TYPE_OF_STUDY_NAME_EN_5),
                                               new JProperty("CONFERENCE_PRESENTATION_TYPE_ID", q.CONFERENCE_PRESENTATION_TYPE_ID_5),
                                               new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME", q.CONFERENCE_PRESENTATION_TYPE_NAME_5),
                                               new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME_EN", q.CONFERENCE_PRESENTATION_TYPE_NAME_EN_5),
                                               new JProperty("FIRST_SUBMITTED_DATE", q.FIRST_SUBMITTED_DATE_5),
                                               new JProperty("LAST_REVISED_DATE", q.LAST_REVISED_DATE_5),
                                               new JProperty("FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT", q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT),
                                               new JProperty("FROM_DATE", q.FROM_DATE),
                                               new JProperty("THRU_DATE", q.THRU_DATE),
                                               new JProperty("PAPER_ABSTRACT_WITHDRAWN", q.PAPER_ABSTRACT_WITHDRAWN),
                                               new JProperty("POSITION", 5)
                                               );
                                k++;
                            }

                            if (k > 0)
                            {
                                switch (k)
                                {
                                    case 1:
                                        jsonArray.Add(json1);
                                        break;
                                    case 2:
                                        jsonArray.Add(json2);
                                        break;
                                    case 3:
                                        jsonArray.Add(json3);
                                        break;
                                    case 4:
                                        jsonArray.Add(json4);
                                        break;
                                    case 5:
                                        jsonArray.Add(json5);
                                        break;
                                }
                            }
                        }

                        return ResponseSuccess(StringResource.Success, jsonArray);
                    }
                    else
                    {
                        return ResponseFail(StringResource.Data_not_received);
                    }
                    //end nha
                }
                else
                {
                    var query = (from list_author_paper_abstract_relationship in db.AUTHOR_PAPER_ABSTRACT_RELATIONSHIP
                                 join list_paper_abstarct in db.PAPER_ABSTRACT on list_author_paper_abstract_relationship.PAPER_ID equals list_paper_abstarct.PAPER_ID
                                 join confer in db.CONFERENCEs on list_author_paper_abstract_relationship.CONFERENCE_ID equals confer.CONFERENCE_ID
                                 where list_paper_abstarct.PAPER_ID == item.idPaper && list_paper_abstarct.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT == trangthai
                                 select
                                 new
                                 {
                                     list_author_paper_abstract_relationship.PERSON_ID,
                                     list_author_paper_abstract_relationship.CONFERENCE_ID,
                                     list_author_paper_abstract_relationship.ORGANIZATION_ID_1,
                                     list_author_paper_abstract_relationship.ORGANIZATION_NAME_1,
                                     list_author_paper_abstract_relationship.ORGANIZATION_NAME_EN_1,
                                     list_author_paper_abstract_relationship.ORGANIZATION_ID_2,
                                     list_author_paper_abstract_relationship.ORGANIZATION_NAME_2,
                                     list_author_paper_abstract_relationship.ORGANIZATION_ID_3,
                                     list_author_paper_abstract_relationship.ORGANIZATION_NAME_3,
                                     list_author_paper_abstract_relationship.ORGANIZATION_ID_4,
                                     list_author_paper_abstract_relationship.ORGANIZATION_NAME_4,
                                     list_author_paper_abstract_relationship.ORGANIZATION_ID_5,
                                     list_author_paper_abstract_relationship.ORGANIZATION_NAME_5,
                                     list_author_paper_abstract_relationship.CORRESPONDING_AUTHOR,
                                     CONFERENCE_NAME1 = (confer.CONFERENCE_NAME + " - " + list_paper_abstarct.PAPER_ABSTRACT_TITLE_1),
                                     confer.PAPER_ABSTRACT_DEADLINE_1,
                                     confer.FROM_DATE,
                                     confer.THRU_DATE,
                                     list_paper_abstarct.PAPER_ID,
                                     list_paper_abstarct.PAPER_NUMBER_OR_CODE,

                                     list_paper_abstarct.PAPER_ABSTRACT_TITLE_1,
                                     list_paper_abstarct.PAPER_ABSTRACT_TITLE_EN_1,
                                     list_paper_abstarct.CONFERENCE_SESSION_TOPIC_ID_1,
                                     list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_1,
                                     list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_EN_1,
                                     list_paper_abstarct.PAPER_ABSTRACT_TEXT_1,
                                     list_paper_abstarct.FULL_PAPER_OR_WORK_IN_PROGRESS_1,
                                     list_paper_abstarct.TYPE_OF_STUDY_ID_1,
                                     list_paper_abstarct.TYPE_OF_STUDY_NAME_1,
                                     list_paper_abstarct.TYPE_OF_STUDY_NAME_EN_1,
                                     list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_ID_1,
                                     list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_NAME_1,
                                     list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_NAME_EN_1,
                                     list_paper_abstarct.FIRST_SUBMITTED_DATE_1,
                                     list_paper_abstarct.LAST_REVISED_DATE_1,


                                     CONFERENCE_NAME2 = list_paper_abstarct.PAPER_ABSTRACT_TITLE_2 == null ? null : (confer.CONFERENCE_NAME + " - " + list_paper_abstarct.PAPER_ABSTRACT_TITLE_2),
                                     confer.PAPER_ABSTRACT_DEADLINE_2,
                                     list_paper_abstarct.PAPER_ABSTRACT_TITLE_2,
                                     list_paper_abstarct.PAPER_ABSTRACT_TITLE_EN_2,
                                     list_paper_abstarct.CONFERENCE_SESSION_TOPIC_ID_2,
                                     list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_2,
                                     list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_EN_2,
                                     list_paper_abstarct.PAPER_ABSTRACT_TEXT_2,
                                     list_paper_abstarct.FULL_PAPER_OR_WORK_IN_PROGRESS_2,
                                     list_paper_abstarct.TYPE_OF_STUDY_ID_2,
                                     list_paper_abstarct.TYPE_OF_STUDY_NAME_2,
                                     list_paper_abstarct.TYPE_OF_STUDY_NAME_EN_2,
                                     list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_ID_2,
                                     list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_NAME_2,
                                     list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_NAME_EN_2,
                                     list_paper_abstarct.FIRST_SUBMITTED_DATE_2,
                                     list_paper_abstarct.LAST_REVISED_DATE_2,


                                     CONFERENCE_NAME3 = list_paper_abstarct.PAPER_ABSTRACT_TITLE_2 == null ? null : (confer.CONFERENCE_NAME + " - " + list_paper_abstarct.PAPER_ABSTRACT_TITLE_2),
                                     confer.PAPER_ABSTRACT_DEADLINE_3,
                                     list_paper_abstarct.PAPER_ABSTRACT_TEXT_3,
                                     list_paper_abstarct.FULL_PAPER_OR_WORK_IN_PROGRESS_3,
                                     list_paper_abstarct.TYPE_OF_STUDY_ID_3,
                                     list_paper_abstarct.TYPE_OF_STUDY_NAME_3,
                                     list_paper_abstarct.TYPE_OF_STUDY_NAME_EN_3,
                                     list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_ID_3,
                                     list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_NAME_3,
                                     list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_NAME_EN_3,
                                     list_paper_abstarct.FIRST_SUBMITTED_DATE_3,
                                     list_paper_abstarct.LAST_REVISED_DATE_3,
                                     CONFERENCE_NAME4 = list_paper_abstarct.PAPER_ABSTRACT_TITLE_2 == null ? null : (confer.CONFERENCE_NAME + " - " + list_paper_abstarct.PAPER_ABSTRACT_TITLE_2),
                                     CONFERENCE_SESSION_TOPIC_ID_3 = list_paper_abstarct.CONFERENCE_SESSION_TOPIC_ID_2 == null ? list_paper_abstarct.CONFERENCE_SESSION_TOPIC_ID_1 : list_paper_abstarct.CONFERENCE_SESSION_TOPIC_ID_2,
                                     CONFERENCE_SESSION_TOPIC_NAME_3 = list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_2 == null ? list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_1 : list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_2,
                                     CONFERENCE_SESSION_TOPIC_NAME_EN_3 = list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_EN_2 == null ? list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_EN_1 : list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_EN_2,


                                     confer.PAPER_ABSTRACT_DEADLINE_4,
                                     list_paper_abstarct.PAPER_ABSTRACT_TEXT_4,
                                     list_paper_abstarct.FULL_PAPER_OR_WORK_IN_PROGRESS_4,
                                     list_paper_abstarct.TYPE_OF_STUDY_ID_4,
                                     list_paper_abstarct.TYPE_OF_STUDY_NAME_4,
                                     list_paper_abstarct.TYPE_OF_STUDY_NAME_EN_4,
                                     list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_ID_4,
                                     list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_NAME_4,
                                     list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_NAME_EN_4,
                                     list_paper_abstarct.FIRST_SUBMITTED_DATE_4,
                                     list_paper_abstarct.LAST_REVISED_DATE_4,
                                     CONFERENCE_SESSION_TOPIC_ID_4 = list_paper_abstarct.CONFERENCE_SESSION_TOPIC_ID_2 == null ? list_paper_abstarct.CONFERENCE_SESSION_TOPIC_ID_1 : list_paper_abstarct.CONFERENCE_SESSION_TOPIC_ID_2,
                                     CONFERENCE_SESSION_TOPIC_NAME_4 = list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_2 == null ? list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_1 : list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_2,
                                     CONFERENCE_SESSION_TOPIC_NAME_EN_4 = list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_EN_2 == null ? list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_EN_1 : list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_EN_2,


                                     CONFERENCE_NAME5 = list_paper_abstarct.PAPER_ABSTRACT_TITLE_2 == null ? null : (confer.CONFERENCE_NAME + " - " + list_paper_abstarct.PAPER_ABSTRACT_TITLE_2),
                                     confer.PAPER_ABSTRACT_DEADLINE_5,
                                     list_paper_abstarct.PAPER_ABSTRACT_TEXT_5,
                                     list_paper_abstarct.FULL_PAPER_OR_WORK_IN_PROGRESS_5,
                                     list_paper_abstarct.TYPE_OF_STUDY_ID_5,
                                     list_paper_abstarct.TYPE_OF_STUDY_NAME_5,
                                     list_paper_abstarct.TYPE_OF_STUDY_NAME_EN_5,
                                     list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_ID_5,
                                     list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_NAME_5,
                                     list_paper_abstarct.CONFERENCE_PRESENTATION_TYPE_NAME_EN_5,
                                     list_paper_abstarct.FIRST_SUBMITTED_DATE_5,
                                     list_paper_abstarct.LAST_REVISED_DATE_5,
                                     CONFERENCE_SESSION_TOPIC_ID_5 = list_paper_abstarct.CONFERENCE_SESSION_TOPIC_ID_2 == null ? list_paper_abstarct.CONFERENCE_SESSION_TOPIC_ID_1 : list_paper_abstarct.CONFERENCE_SESSION_TOPIC_ID_2,
                                     CONFERENCE_SESSION_TOPIC_NAME_5 = list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_2 == null ? list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_1 : list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_2,
                                     CONFERENCE_SESSION_TOPIC_NAME_EN_5 = list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_EN_2 == null ? list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_EN_1 : list_paper_abstarct.CONFERENCE_SESSION_TOPIC_NAME_EN_2,


                                     list_paper_abstarct.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT,
                                     list_paper_abstarct.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_REVIEWER_PERSON_ID,
                                     list_paper_abstarct.PAPER_ABSTRACT_WITHDRAWN
                                 }).Take(1);
                    if (query != null)
                    {

                        foreach (var q in query)
                        {
                            int k = 0;
                            var json1 = new JObject();
                            var json2 = new JObject();
                            var json3 = new JObject();
                            var json4 = new JObject();
                            var json5 = new JObject();
                            if (q.PAPER_ABSTRACT_TITLE_1 != null || q.PAPER_ABSTRACT_DEADLINE_1 != null)
                            {
                                json1 = new JObject(
                                               new JProperty("PERSON_ID", q.PERSON_ID),
                                               new JProperty("CONFERENCE_ID", q.CONFERENCE_ID),
                                               new JProperty("ORGANIZATION_NAME_1", q.ORGANIZATION_NAME_1),
                                               new JProperty("ORGANIZATION_NAME_2", q.ORGANIZATION_NAME_2),
                                               new JProperty("ORGANIZATION_NAME_3", q.ORGANIZATION_NAME_3),
                                               new JProperty("ORGANIZATION_NAME_4", q.ORGANIZATION_NAME_4),
                                               new JProperty("ORGANIZATION_NAME_5", q.ORGANIZATION_NAME_5),
                                               new JProperty("CORRESPONDING_AUTHOR", q.CORRESPONDING_AUTHOR),
                                               new JProperty("PAPER_ID", q.PAPER_ID),
                                               new JProperty("CONFERENCE_NAME", q.CONFERENCE_NAME1),
                                               new JProperty("PAPER_ABSTRACT_DEADLINE", q.PAPER_ABSTRACT_DEADLINE_1),
                                               new JProperty("PAPER_ABSTRACT_TITLE", q.PAPER_ABSTRACT_TITLE_1),
                                               new JProperty("PAPER_ABSTRACT_TITLE_EN", q.PAPER_ABSTRACT_TITLE_EN_1),
                                               new JProperty("CONFERENCE_SESSION_TOPIC_ID", q.CONFERENCE_SESSION_TOPIC_ID_1),
                                               new JProperty("CONFERENCE_SESSION_TOPIC_NAME", q.CONFERENCE_SESSION_TOPIC_NAME_1),
                                               new JProperty("CONFERENCE_SESSION_TOPIC_NAME_EN", q.CONFERENCE_SESSION_TOPIC_NAME_EN_1),
                                               new JProperty("PAPER_ABSTRACT_TEXT", q.PAPER_ABSTRACT_TEXT_1),
                                               new JProperty("FULL_PAPER_OR_WORK_IN_PROGRESS", q.FULL_PAPER_OR_WORK_IN_PROGRESS_1),
                                               new JProperty("TYPE_OF_STUDY_ID", q.TYPE_OF_STUDY_ID_1),
                                               new JProperty("TYPE_OF_STUDY_NAME", q.TYPE_OF_STUDY_NAME_1),
                                               new JProperty("TYPE_OF_STUDY_NAME_EN", q.TYPE_OF_STUDY_NAME_EN_1),
                                               new JProperty("CONFERENCE_PRESENTATION_TYPE_ID", q.CONFERENCE_PRESENTATION_TYPE_ID_1),
                                               new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME", q.CONFERENCE_PRESENTATION_TYPE_NAME_1),
                                               new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME_EN", q.CONFERENCE_PRESENTATION_TYPE_NAME_EN_1),
                                               new JProperty("FIRST_SUBMITTED_DATE", q.FIRST_SUBMITTED_DATE_1),
                                               new JProperty("LAST_REVISED_DATE", q.LAST_REVISED_DATE_1),
                                               new JProperty("FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT", q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT),
                                               new JProperty("FROM_DATE", q.FROM_DATE),
                                               new JProperty("THRU_DATE", q.THRU_DATE),
                                               new JProperty("PAPER_ABSTRACT_WITHDRAWN", q.PAPER_ABSTRACT_WITHDRAWN),
                                               new JProperty("POSITION", 1)
                                               );
                                k++;
                            }

                            if (q.PAPER_ABSTRACT_TITLE_2 != null || q.PAPER_ABSTRACT_DEADLINE_2 != null)
                            {
                                json2 = new JObject(
                                               new JProperty("PERSON_ID", q.PERSON_ID),
                                               new JProperty("CONFERENCE_ID", q.CONFERENCE_ID),
                                               new JProperty("ORGANIZATION_NAME_1", q.ORGANIZATION_NAME_1),
                                               new JProperty("ORGANIZATION_NAME_2", q.ORGANIZATION_NAME_2),
                                               new JProperty("ORGANIZATION_NAME_3", q.ORGANIZATION_NAME_3),
                                               new JProperty("ORGANIZATION_NAME_4", q.ORGANIZATION_NAME_4),
                                               new JProperty("ORGANIZATION_NAME_5", q.ORGANIZATION_NAME_5),
                                               new JProperty("CORRESPONDING_AUTHOR", q.CORRESPONDING_AUTHOR),
                                               new JProperty("PAPER_ID", q.PAPER_ID),
                                               new JProperty("CONFERENCE_NAME", q.CONFERENCE_NAME2),
                                               new JProperty("PAPER_ABSTRACT_DEADLINE", q.PAPER_ABSTRACT_DEADLINE_2),
                                               new JProperty("PAPER_ABSTRACT_TITLE", q.PAPER_ABSTRACT_TITLE_2),
                                               new JProperty("PAPER_ABSTRACT_TITLE_EN", q.PAPER_ABSTRACT_TITLE_EN_2),
                                               new JProperty("CONFERENCE_SESSION_TOPIC_ID", q.CONFERENCE_SESSION_TOPIC_ID_2),
                                               new JProperty("CONFERENCE_SESSION_TOPIC_NAME", q.CONFERENCE_SESSION_TOPIC_NAME_2),
                                               new JProperty("CONFERENCE_SESSION_TOPIC_NAME_EN", q.CONFERENCE_SESSION_TOPIC_NAME_EN_2),
                                               new JProperty("PAPER_ABSTRACT_TEXT", q.PAPER_ABSTRACT_TEXT_2),
                                               new JProperty("FULL_PAPER_OR_WORK_IN_PROGRESS", q.FULL_PAPER_OR_WORK_IN_PROGRESS_2),
                                               new JProperty("TYPE_OF_STUDY_ID", q.TYPE_OF_STUDY_ID_2),
                                               new JProperty("TYPE_OF_STUDY_NAME", q.TYPE_OF_STUDY_NAME_2),
                                               new JProperty("TYPE_OF_STUDY_NAME_EN", q.TYPE_OF_STUDY_NAME_EN_2),
                                               new JProperty("CONFERENCE_PRESENTATION_TYPE_ID", q.CONFERENCE_PRESENTATION_TYPE_ID_2),
                                               new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME", q.CONFERENCE_PRESENTATION_TYPE_NAME_2),
                                               new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME_EN", q.CONFERENCE_PRESENTATION_TYPE_NAME_EN_2),
                                               new JProperty("FIRST_SUBMITTED_DATE", q.FIRST_SUBMITTED_DATE_2),
                                               new JProperty("LAST_REVISED_DATE", q.LAST_REVISED_DATE_2),
                                               new JProperty("FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT", q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT),
                                               new JProperty("FROM_DATE", q.FROM_DATE),
                                               new JProperty("THRU_DATE", q.THRU_DATE),
                                               new JProperty("PAPER_ABSTRACT_WITHDRAWN", q.PAPER_ABSTRACT_WITHDRAWN),
                                               new JProperty("POSITION", 2)
                                               );
                                k++;
                            }

                            if (q.PAPER_ABSTRACT_DEADLINE_3 != null)
                            {
                                json3 = new JObject(
                                               new JProperty("PERSON_ID", q.PERSON_ID),
                                               new JProperty("CONFERENCE_ID", q.CONFERENCE_ID),
                                               new JProperty("ORGANIZATION_NAME_1", q.ORGANIZATION_NAME_1),
                                               new JProperty("ORGANIZATION_NAME_2", q.ORGANIZATION_NAME_2),
                                               new JProperty("ORGANIZATION_NAME_3", q.ORGANIZATION_NAME_3),
                                               new JProperty("ORGANIZATION_NAME_4", q.ORGANIZATION_NAME_4),
                                               new JProperty("ORGANIZATION_NAME_5", q.ORGANIZATION_NAME_5),
                                               new JProperty("CORRESPONDING_AUTHOR", q.CORRESPONDING_AUTHOR),
                                               new JProperty("PAPER_ID", q.PAPER_ID),
                                               new JProperty("CONFERENCE_NAME", q.CONFERENCE_NAME3),
                                               new JProperty("PAPER_ABSTRACT_DEADLINE", q.PAPER_ABSTRACT_DEADLINE_3),
                                               new JProperty("PAPER_ABSTRACT_TEXT", q.PAPER_ABSTRACT_TEXT_3),
                                               new JProperty("FULL_PAPER_OR_WORK_IN_PROGRESS", q.FULL_PAPER_OR_WORK_IN_PROGRESS_3),
                                               new JProperty("CONFERENCE_SESSION_TOPIC_ID", q.CONFERENCE_SESSION_TOPIC_ID_3),
                                               new JProperty("CONFERENCE_SESSION_TOPIC_NAME", q.CONFERENCE_SESSION_TOPIC_NAME_3),
                                               new JProperty("CONFERENCE_SESSION_TOPIC_NAME_EN", q.CONFERENCE_SESSION_TOPIC_NAME_EN_3),
                                               new JProperty("TYPE_OF_STUDY_ID", q.TYPE_OF_STUDY_ID_3),
                                               new JProperty("TYPE_OF_STUDY_NAME", q.TYPE_OF_STUDY_NAME_3),
                                               new JProperty("TYPE_OF_STUDY_NAME_EN", q.TYPE_OF_STUDY_NAME_EN_3),
                                               new JProperty("CONFERENCE_PRESENTATION_TYPE_ID", q.CONFERENCE_PRESENTATION_TYPE_ID_3),
                                               new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME", q.CONFERENCE_PRESENTATION_TYPE_NAME_3),
                                               new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME_EN", q.CONFERENCE_PRESENTATION_TYPE_NAME_EN_3),
                                               new JProperty("FIRST_SUBMITTED_DATE", q.FIRST_SUBMITTED_DATE_3),
                                               new JProperty("LAST_REVISED_DATE", q.LAST_REVISED_DATE_3),
                                               new JProperty("FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT", q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT),
                                               new JProperty("FROM_DATE", q.FROM_DATE),
                                               new JProperty("THRU_DATE", q.THRU_DATE),
                                               new JProperty("PAPER_ABSTRACT_WITHDRAWN", q.PAPER_ABSTRACT_WITHDRAWN),
                                               new JProperty("POSITION", 3)
                                               );
                                k++;
                            }

                            if (q.PAPER_ABSTRACT_DEADLINE_4 != null)
                            {
                                json4 = new JObject(
                                               new JProperty("PERSON_ID", q.PERSON_ID),
                                               new JProperty("CONFERENCE_ID", q.CONFERENCE_ID),
                                               new JProperty("ORGANIZATION_NAME_1", q.ORGANIZATION_NAME_1),
                                               new JProperty("ORGANIZATION_NAME_2", q.ORGANIZATION_NAME_2),
                                               new JProperty("ORGANIZATION_NAME_3", q.ORGANIZATION_NAME_3),
                                               new JProperty("ORGANIZATION_NAME_4", q.ORGANIZATION_NAME_4),
                                               new JProperty("ORGANIZATION_NAME_5", q.ORGANIZATION_NAME_5),
                                               new JProperty("CORRESPONDING_AUTHOR", q.CORRESPONDING_AUTHOR),
                                               new JProperty("PAPER_ID", q.PAPER_ID),
                                               new JProperty("CONFERENCE_NAME", q.CONFERENCE_NAME4),
                                               new JProperty("PAPER_ABSTRACT_DEADLINE", q.PAPER_ABSTRACT_DEADLINE_4),
                                               new JProperty("PAPER_ABSTRACT_TEXT", q.PAPER_ABSTRACT_TEXT_4),
                                               new JProperty("FULL_PAPER_OR_WORK_IN_PROGRESS", q.FULL_PAPER_OR_WORK_IN_PROGRESS_4),
                                               new JProperty("CONFERENCE_SESSION_TOPIC_ID", q.CONFERENCE_SESSION_TOPIC_ID_4),
                                               new JProperty("CONFERENCE_SESSION_TOPIC_NAME", q.CONFERENCE_SESSION_TOPIC_NAME_4),
                                               new JProperty("CONFERENCE_SESSION_TOPIC_NAME_EN", q.CONFERENCE_SESSION_TOPIC_NAME_EN_4),
                                               new JProperty("TYPE_OF_STUDY_ID", q.TYPE_OF_STUDY_ID_4),
                                               new JProperty("TYPE_OF_STUDY_NAME", q.TYPE_OF_STUDY_NAME_4),
                                               new JProperty("TYPE_OF_STUDY_NAME_EN", q.TYPE_OF_STUDY_NAME_EN_4),
                                               new JProperty("CONFERENCE_PRESENTATION_TYPE_ID", q.CONFERENCE_PRESENTATION_TYPE_ID_4),
                                               new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME", q.CONFERENCE_PRESENTATION_TYPE_NAME_4),
                                               new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME_EN", q.CONFERENCE_PRESENTATION_TYPE_NAME_EN_4),
                                               new JProperty("FIRST_SUBMITTED_DATE", q.FIRST_SUBMITTED_DATE_4),
                                               new JProperty("LAST_REVISED_DATE", q.LAST_REVISED_DATE_4),
                                               new JProperty("FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT", q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT),
                                               new JProperty("FROM_DATE", q.FROM_DATE),
                                               new JProperty("THRU_DATE", q.THRU_DATE),
                                               new JProperty("PAPER_ABSTRACT_WITHDRAWN", q.PAPER_ABSTRACT_WITHDRAWN),
                                               new JProperty("POSITION", 4)
                                               );
                                k++;
                            }

                            if (q.PAPER_ABSTRACT_DEADLINE_5 != null)
                            {
                                json5 = new JObject(
                                               new JProperty("PERSON_ID", q.PERSON_ID),
                                               new JProperty("CONFERENCE_ID", q.CONFERENCE_ID),
                                               new JProperty("ORGANIZATION_NAME_1", q.ORGANIZATION_NAME_1),
                                               new JProperty("ORGANIZATION_NAME_2", q.ORGANIZATION_NAME_2),
                                               new JProperty("ORGANIZATION_NAME_3", q.ORGANIZATION_NAME_3),
                                               new JProperty("ORGANIZATION_NAME_4", q.ORGANIZATION_NAME_4),
                                               new JProperty("ORGANIZATION_NAME_5", q.ORGANIZATION_NAME_5),
                                               new JProperty("CORRESPONDING_AUTHOR", q.CORRESPONDING_AUTHOR),
                                               new JProperty("PAPER_ID", q.PAPER_ID),
                                               new JProperty("CONFERENCE_NAME", q.CONFERENCE_NAME5),
                                               new JProperty("PAPER_ABSTRACT_DEADLINE", q.PAPER_ABSTRACT_DEADLINE_5),
                                               new JProperty("PAPER_ABSTRACT_TEXT", q.PAPER_ABSTRACT_TEXT_5),
                                               new JProperty("FULL_PAPER_OR_WORK_IN_PROGRESS", q.FULL_PAPER_OR_WORK_IN_PROGRESS_5),
                                               new JProperty("CONFERENCE_SESSION_TOPIC_ID", q.CONFERENCE_SESSION_TOPIC_ID_5),
                                               new JProperty("CONFERENCE_SESSION_TOPIC_NAME", q.CONFERENCE_SESSION_TOPIC_NAME_5),
                                               new JProperty("CONFERENCE_SESSION_TOPIC_NAME_EN", q.CONFERENCE_SESSION_TOPIC_NAME_EN_5),
                                               new JProperty("TYPE_OF_STUDY_ID", q.TYPE_OF_STUDY_ID_5),
                                               new JProperty("TYPE_OF_STUDY_NAME", q.TYPE_OF_STUDY_NAME_5),
                                               new JProperty("TYPE_OF_STUDY_NAME_EN", q.TYPE_OF_STUDY_NAME_EN_5),
                                               new JProperty("CONFERENCE_PRESENTATION_TYPE_ID", q.CONFERENCE_PRESENTATION_TYPE_ID_5),
                                               new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME", q.CONFERENCE_PRESENTATION_TYPE_NAME_5),
                                               new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME_EN", q.CONFERENCE_PRESENTATION_TYPE_NAME_EN_5),
                                               new JProperty("FIRST_SUBMITTED_DATE", q.FIRST_SUBMITTED_DATE_5),
                                               new JProperty("LAST_REVISED_DATE", q.LAST_REVISED_DATE_5),
                                               new JProperty("FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT", q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT),
                                               new JProperty("FROM_DATE", q.FROM_DATE),
                                               new JProperty("THRU_DATE", q.THRU_DATE),
                                               new JProperty("PAPER_ABSTRACT_WITHDRAWN", q.PAPER_ABSTRACT_WITHDRAWN),
                                               new JProperty("POSITION", 5)
                                               );
                                k++;
                            }

                            if (k > 0)
                            {
                                switch (k)
                                {
                                    case 1:
                                        jsonArray.Add(json1);
                                        break;
                                    case 2:
                                        jsonArray.Add(json2);
                                        break;
                                    case 3:
                                        jsonArray.Add(json3);
                                        break;
                                    case 4:
                                        jsonArray.Add(json4);
                                        break;
                                    case 5:
                                        jsonArray.Add(json5);
                                        break;
                                }
                            }
                        }

                        return ResponseSuccess(StringResource.Success, jsonArray);
                    }
                    else
                    {
                        return ResponseFail(StringResource.Data_not_received);
                    }
                }

                //end nha

            }
            catch (Exception)
            {
                return ResponseFail(StringResource.Data_not_received);
            }

        }

        public class Param_getItemAbstractforReview
        {
            public int idPaper { get; set; }
            public int statusReview { get; set; }
        }


        public class SeePaper
        {
            public int Id { get; set; }
            public int position { get; set; }
        }

        public class WithDrawn
        {
            public int Id { get; set; }
        }

        public class ResuleBoolean
        {
            public bool result { get; set; }
        }

        public class Abstract
        {

            public int PAPER_ID { get; set; }
            public String PAPER_ABSTRACT_TITLE { get; set; }
            public String PAPER_ABSTRACT_TITLE_EN { get; set; }
            public int CONFERENCE_SESSION_TOPIC_ID { get; set; }
            public String CONFERENCE_SESSION_TOPIC_NAME { get; set; }
            public String CONFERENCE_SESSION_TOPIC_NAME_EN { get; set; }
            public String PAPER_ABSTRACT_TEXT { get; set; }
            public String PAPER_ABSTRACT_TEXT_EN { get; set; }
            public String FULL_PAPER_OR_WORK_IN_PROGRESS { get; set; }
            public int TYPE_OF_STUDY_ID { get; set; }
            public String TYPE_OF_STUDY_NAME { get; set; }
            public String TYPE_OF_STUDY_NAME_EN { get; set; }
            public int CONFERENCE_PRESENTATION_TYPE_ID { get; set; }
            public String CONFERENCE_PRESENTATION_TYPE_NAME { get; set; }
            public String CONFERENCE_PRESENTATION_TYPE_NAME_EN { get; set; }
            public int POSITION { get; set; }
            public String PAPER_ABSTRACT_ATTACHED_FILENAME { get; set; }
            public int TRANGTHAI { get; set; }
        }


        public class ItemPaper2
        {
            public int PAPER_ID { get; set; }

        }

        //end

    }
}
