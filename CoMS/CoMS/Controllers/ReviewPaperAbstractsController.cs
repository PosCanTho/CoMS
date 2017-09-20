﻿using System;
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
    public class ReviewPaperAbstractsController : BaseController
    {
        private DB db = new DB();

        // Danh sách chờ duyệt
        [HttpPost]
        [Route("api/Review/ListAbstractPebding")]
        public HttpResponseMessage ListAbstractPebding([FromBody] PERSON person)
        {
            var t = (from paper in db.AUTHOR_PAPER_ABSTRACT_RELATIONSHIP
                    where paper.PERSON_ID == person.Id
                    select new { paper.PAPER_ID }).Distinct();
            var jsonArray = new JArray();
            foreach (var item in t)
            {
                var query = from list_author_paper_abstract_relationship in db.AUTHOR_PAPER_ABSTRACT_RELATIONSHIP
                            join list_paper_abstarct in db.PAPER_ABSTRACT on list_author_paper_abstract_relationship.PAPER_ID equals list_paper_abstarct.PAPER_ID
                            join confer in db.CONFERENCEs on list_author_paper_abstract_relationship.CONFERENCE_ID equals confer.CONFERENCE_ID
                            where list_author_paper_abstract_relationship.PERSON_ID == person.Id
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
                            };
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
                        if ( (q.PAPER_ABSTRACT_TITLE_1 != null || q.PAPER_ABSTRACT_DEADLINE_1 != null) &&
                            q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT == null)
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

                        if ( (q.PAPER_ABSTRACT_TITLE_2 != null || q.PAPER_ABSTRACT_DEADLINE_2 != null) &&
                            q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT == null)
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
                            q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT == null)
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

                        if (q.PAPER_ABSTRACT_DEADLINE_4 != null &&
                            q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT == null)
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

                        if (q.PAPER_ABSTRACT_DEADLINE_5 != null &&
                            q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT == null)
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
                        if (k>0)
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
                    

                }
            }
            return ResponseSuccess(StringResource.Success, jsonArray);

        }


        // danh sách bài báo reviewer đã duyệt
        [HttpPost]
        [Route("api/Review/ListAbstractApproved")]
        public HttpResponseMessage ListAbstractApproved([FromBody] PERSON person)
        {
            var t = (from paper in db.AUTHOR_PAPER_ABSTRACT_RELATIONSHIP
                     where paper.PERSON_ID == person.Id
                     select new { paper.PAPER_ID }).Distinct();
            var jsonArray = new JArray();
            foreach (var item in t)
            {
                var query = from list_author_paper_abstract_relationship in db.AUTHOR_PAPER_ABSTRACT_RELATIONSHIP
                            join list_paper_abstarct in db.PAPER_ABSTRACT on list_author_paper_abstract_relationship.PAPER_ID equals list_paper_abstarct.PAPER_ID
                            join confer in db.CONFERENCEs on list_author_paper_abstract_relationship.CONFERENCE_ID equals confer.CONFERENCE_ID
                            where list_author_paper_abstract_relationship.PERSON_ID == person.Id
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
                            };
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
                        if ((q.PAPER_ABSTRACT_TITLE_1 != null || q.PAPER_ABSTRACT_DEADLINE_1 != null) &&
                            q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT == true)
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

                        if ((q.PAPER_ABSTRACT_TITLE_2 != null || q.PAPER_ABSTRACT_DEADLINE_2 != null) &&
                            q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT == true)
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
                            q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT == true)
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

                        if (q.PAPER_ABSTRACT_DEADLINE_4 != null &&
                            q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT == true)
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

                        if (q.PAPER_ABSTRACT_DEADLINE_5 != null &&
                            q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT == true)
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


                }
            }
            return ResponseSuccess(StringResource.Success, jsonArray);

        }

        //danh sách bài tóm tắt reviewer từ chối
        [HttpPost]
        [Route("api/Review/ListAbstractReject")]
        public HttpResponseMessage ListAbstractReject([FromBody] PERSON person)
        {
            var t = (from paper in db.AUTHOR_PAPER_ABSTRACT_RELATIONSHIP
                     where paper.PERSON_ID == person.Id
                     select new { paper.PAPER_ID }).Distinct();
            var jsonArray = new JArray();
            foreach (var item in t)
            {
                var query = from list_author_paper_abstract_relationship in db.AUTHOR_PAPER_ABSTRACT_RELATIONSHIP
                            join list_paper_abstarct in db.PAPER_ABSTRACT on list_author_paper_abstract_relationship.PAPER_ID equals list_paper_abstarct.PAPER_ID
                            join confer in db.CONFERENCEs on list_author_paper_abstract_relationship.CONFERENCE_ID equals confer.CONFERENCE_ID
                            where list_author_paper_abstract_relationship.PERSON_ID == person.Id
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
                            };
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
                        if ((q.PAPER_ABSTRACT_TITLE_1 != null || q.PAPER_ABSTRACT_DEADLINE_1 != null) &&
                            q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT == false)
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

                        if ((q.PAPER_ABSTRACT_TITLE_2 != null || q.PAPER_ABSTRACT_DEADLINE_2 != null) &&
                            q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT == false)
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
                            q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT == false)
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

                        if (q.PAPER_ABSTRACT_DEADLINE_4 != null &&
                            q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT == false)
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

                        if (q.PAPER_ABSTRACT_DEADLINE_5 != null &&
                            q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT == false)
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


                }
            }
            return ResponseSuccess(StringResource.Success, jsonArray);

        }

        // lấy thang điểm đánh bài tóm tắt
        [HttpPost]
        [Route("api/Review/PaperAbstractRatingScale_BoardOfReview")]
        public HttpResponseMessage PaperAbstractRatingScale_BoardOfReview([FromBody] RatingScale paper)
        {
            try
            {
                var result = (from ratingScale in db.AUTHOR_PAPER_ABSTRACT_RELATIONSHIP
                              where ratingScale.PAPER_ID == paper.IdAbstract && ratingScale.PERSON_ID == paper.IdPerson
                              select new { ratingScale.CONFERENCE_ID }).Distinct();
                foreach (var item in result)
                {
                    var result2 = (from review in db.REVIEWERs
                                   where review.PERSON_ID == paper.IdPerson && review.CONFERENCE_ID == item.CONFERENCE_ID
                                   select new { review.CONFERENCE_BOARD_OF_REVIEW_ID }).Distinct();
                    if (result2.Count() >= 2)
                    {
                        foreach (var item2 in result2)
                        {
                            var rating = from conference_board_of_review in db.CONFERENCE_BOARD_OF_REVIEW
                                         where conference_board_of_review.ROOT_CONFERENCE_BOARD_OF_REVIEW_ID != null &&
                                         conference_board_of_review.ROOT_CONFERENCE_BOARD_OF_REVIEW_ID == item2.CONFERENCE_BOARD_OF_REVIEW_ID
                                         select new {
                                             conference_board_of_review.CONFERENCE_BOARD_OF_REVIEW_ID,
                                             conference_board_of_review.CONFERENCE_ID,
                                             conference_board_of_review.PAPER_ABSTRACT_REVIEW_DEADLINE_1,
                                             conference_board_of_review.PAPER_ABSTRACT_REVIEW_DEADLINE_2,
                                             conference_board_of_review.PAPER_ABSTRACT_REVIEW_RATING_SCALE_STEP,
                                             conference_board_of_review.PAPER_ABSTRACT_REVIEW_RATING_SCALE_START_POINT,
                                             conference_board_of_review.PAPER_ABSTRACT_REVIEW_RATING_SCALE_END_POINT
                                         };
                            return ResponseSuccess(StringResource.Success, rating);
                            break;
                        }
                    }
                    else
                    {
                        foreach (var item2 in result2)
                        {
                            var rating = from conference_board_of_review in db.CONFERENCE_BOARD_OF_REVIEW
                                         where conference_board_of_review.ROOT_CONFERENCE_BOARD_OF_REVIEW_ID == null &&
                                         conference_board_of_review.ROOT_CONFERENCE_BOARD_OF_REVIEW_ID == item2.CONFERENCE_BOARD_OF_REVIEW_ID
                                         select new
                                         {
                                             conference_board_of_review.CONFERENCE_BOARD_OF_REVIEW_ID,
                                             conference_board_of_review.CONFERENCE_ID,
                                             conference_board_of_review.PAPER_ABSTRACT_REVIEW_DEADLINE_1,
                                             conference_board_of_review.PAPER_ABSTRACT_REVIEW_DEADLINE_2,
                                             conference_board_of_review.PAPER_ABSTRACT_REVIEW_RATING_SCALE_STEP,
                                             conference_board_of_review.PAPER_ABSTRACT_REVIEW_RATING_SCALE_START_POINT,
                                             conference_board_of_review.PAPER_ABSTRACT_REVIEW_RATING_SCALE_END_POINT
                                         };
                            return ResponseSuccess(StringResource.Success, rating);
                            break;
                        }
                    }
                    
                    return ResponseSuccess(StringResource.Success, result2);
                }
                return ResponseSuccess(StringResource.Success, null);
            }
            catch (Exception)
            {
                return ResponseFail(StringResource.Data_not_received);
            }
            
            
        }

        //lưu đánh giá bài tóm tắt
        [HttpPost]
        [Route("api/Review/ReviewPaperAbstract")]
        public HttpResponseMessage ReviewPaperAbstract([FromBody] ReviewAbstract paper)
        {
            try
            {


                var idx = (from review in db.REVIEWER_PAPER_ABSTRACT_RELATIONSHIP
                          where review.PERSON_ID == paper.PERSON_ID &&
                            review.CONFERENCE_BOARD_OF_REVIEW_ID == paper.CONFERENCE_BOARD_OF_REVIEW_ID &&
                            review.CONFERENCE_ID == paper.CONFERENCE_ID
                            orderby review.PAPER_ABSTRACT_SUBMISSION_DEADLINE_ORDER_NUMBER descending
                          select new { review.PAPER_ABSTRACT_SUBMISSION_DEADLINE_ORDER_NUMBER }).Take(1);

                if (idx == null)
                {
                var item = new REVIEWER_PAPER_ABSTRACT_RELATIONSHIP();
                item.PERSON_ID = paper.PERSON_ID;
                item.CONFERENCE_BOARD_OF_REVIEW_ID = paper.CONFERENCE_BOARD_OF_REVIEW_ID;
                item.CONFERENCE_ID = paper.CONFERENCE_ID;
                item.PAPER_ABSTRACT_SUBMISSION_DEADLINE_ORDER_NUMBER = 1;
                item.REVIEWED_DATE = DateTime.Now;
                item.PROPOSED_CONFERENCE_SESSION_TOPIC_ID = paper.PROPOSED_CONFERENCE_SESSION_TOPIC_ID;
                item.PROPOSED_CONFERENCE_SESSION_TOPIC_NAME = paper.PROPOSED_CONFERENCE_SESSION_TOPIC_NAME;
                item.PROPOSED_CONFERENCE_SESSION_TOPIC_NAME_EN = paper.PROPOSED_CONFERENCE_SESSION_TOPIC_NAME_EN;
                item.PROPOSED_TYPE_OF_STUDY_ID = paper.PROPOSED_TYPE_OF_STUDY_ID;
                item.PROPOSED_TYPE_OF_STUDY_NAME = paper.PROPOSED_TYPE_OF_STUDY_NAME;
                item.PROPOSED_TYPE_OF_STUDY_NAME_EN = paper.PROPOSED_TYPE_OF_STUDY_NAME_EN;
                if (paper.PROPOSED_FOR_PRESENTATION == true)
                {
                    item.PROPOSED_CONFERENCE_PRESENTATION_TYPE_ID = paper.PROPOSED_CONFERENCE_PRESENTATION_TYPE_ID;
                    item.PROPOSED_CONFERENCE_PRESENTATION_TYPE_NAME = paper.PROPOSED_CONFERENCE_PRESENTATION_TYPE_NAME;
                    item.PROPOSED_CONFERENCE_PRESENTATION_TYPE_NAME_EN = paper.PROPOSED_CONFERENCE_PRESENTATION_TYPE_NAME_EN;
                }
                item.PAPER_ABSTRACT_REVIEW_RATING_POINT = paper.PAPER_ABSTRACT_REVIEW_RATING_POINT;
                item.SIGNIFICANT_REVISION_OR_MINIMAL_REVISION_OR_REVISION_NEEDED_OR_NO_REVISION_NEEDED = paper.SIGNIFICANT_REVISION_OR_MINIMAL_REVISION_OR_REVISION_NEEDED_OR_NO_REVISION_NEEDED;
                item.REVIEW_TEXT = paper.REVIEW_TEXT;
                item.REVIEW_TEXT_EN = paper.REVIEW_TEXT_EN;
                item.APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT = paper.APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT;
                item.APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_DATE = DateTime.Now;

                    //db.REVIEWER_PAPER_ABSTRACT_RELATIONSHIP.Add(item);
                    
                    db.SaveChanges();

                    PAPER_ABSTRACT paper1 = db.PAPER_ABSTRACT.Find(paper.PAPER_ID);
                    paper1.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT = paper.APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT;
                    paper1.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_DATE = DateTime.Now;
                    paper1.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_REVIEWER_PERSON_ID = paper.PERSON_ID;
                    db.SaveChanges();

                    var result = new ResuleBoolean();
                    result.result = true;
                    return ResponseSuccess(StringResource.Success, result);
                }
                else
                {
                foreach (var t in idx)
                {
                    var item = new REVIEWER_PAPER_ABSTRACT_RELATIONSHIP();
                    item.PERSON_ID = paper.PERSON_ID;
                    item.CONFERENCE_BOARD_OF_REVIEW_ID = paper.CONFERENCE_BOARD_OF_REVIEW_ID;
                    item.CONFERENCE_ID = paper.CONFERENCE_ID;
                    item.PAPER_ABSTRACT_SUBMISSION_DEADLINE_ORDER_NUMBER = Convert.ToInt16(t.PAPER_ABSTRACT_SUBMISSION_DEADLINE_ORDER_NUMBER + 1);
                    item.REVIEWED_DATE = DateTime.Now;
                    item.PROPOSED_CONFERENCE_SESSION_TOPIC_ID = paper.PROPOSED_CONFERENCE_SESSION_TOPIC_ID;
                    item.PROPOSED_CONFERENCE_SESSION_TOPIC_NAME = paper.PROPOSED_CONFERENCE_SESSION_TOPIC_NAME;
                    item.PROPOSED_CONFERENCE_SESSION_TOPIC_NAME_EN = paper.PROPOSED_CONFERENCE_SESSION_TOPIC_NAME_EN;
                    item.PROPOSED_TYPE_OF_STUDY_ID = paper.PROPOSED_TYPE_OF_STUDY_ID;
                    item.PROPOSED_TYPE_OF_STUDY_NAME = paper.PROPOSED_TYPE_OF_STUDY_NAME;
                    item.PROPOSED_TYPE_OF_STUDY_NAME_EN = paper.PROPOSED_TYPE_OF_STUDY_NAME_EN;
                    if (paper.PROPOSED_FOR_PRESENTATION == true)
                    {
                        item.PROPOSED_CONFERENCE_PRESENTATION_TYPE_ID = paper.PROPOSED_CONFERENCE_PRESENTATION_TYPE_ID;
                        item.PROPOSED_CONFERENCE_PRESENTATION_TYPE_NAME = paper.PROPOSED_CONFERENCE_PRESENTATION_TYPE_NAME;
                        item.PROPOSED_CONFERENCE_PRESENTATION_TYPE_NAME_EN = paper.PROPOSED_CONFERENCE_PRESENTATION_TYPE_NAME_EN;
                    }
                    item.PAPER_ABSTRACT_REVIEW_RATING_POINT = paper.PAPER_ABSTRACT_REVIEW_RATING_POINT;
                    item.SIGNIFICANT_REVISION_OR_MINIMAL_REVISION_OR_REVISION_NEEDED_OR_NO_REVISION_NEEDED = paper.SIGNIFICANT_REVISION_OR_MINIMAL_REVISION_OR_REVISION_NEEDED_OR_NO_REVISION_NEEDED;
                    item.REVIEW_TEXT = paper.REVIEW_TEXT;
                    item.REVIEW_TEXT_EN = paper.REVIEW_TEXT_EN;
                    item.APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT = paper.APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT;
                    item.APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_DATE = DateTime.Now;

                        //db.REVIEWER_PAPER_ABSTRACT_RELATIONSHIP.Add(item);
                        
                        db.SaveChanges();

                        
                    }
                var result = new ResuleBoolean();
                    result.result = true;
                    return ResponseSuccess(StringResource.Success, result);

                }


            //end nha
        }
            catch (Exception)
            {
                return ResponseFail(StringResource.Data_not_received);
    }

}
        // Cập nhật trạng thái đánh giá
        [HttpPost]
        [Route("api/Review/UpdateReviewPaperAbstract")]
        public HttpResponseMessage UpdateReviewPaperAbstract([FromBody] UPDATE_ABSTRACT_REVIEW paper)
        {
            try
            {
                PAPER_ABSTRACT paper1 = db.PAPER_ABSTRACT.Find(paper.PAPER_ID);
                paper1.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT = paper.APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT;
                paper1.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_DATE = DateTime.Now;
                paper1.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_REVIEWER_PERSON_ID = paper.PERSON_ID;
                db.SaveChanges();
                var result = new ResuleBoolean();
                result.result = true;
                return ResponseSuccess(StringResource.Success, result);
            }
            catch (Exception)
            {
                return ResponseFail(StringResource.Data_not_received);
            }
            
        }




        //Xem đánh giá bài tóm tắt
        [HttpPost]
        [Route("api/Review/SeeReviewPaperAbstract")]
        public HttpResponseMessage SeeReviewPaperAbstract([FromBody] SeeReviewAbstract paper)
        {
            try
            {
                var review = (from review_paper_abstract in db.REVIEWER_PAPER_ABSTRACT_RELATIONSHIP
                             where review_paper_abstract.PERSON_ID == paper.PERSON_ID &&
                             review_paper_abstract.CONFERENCE_BOARD_OF_REVIEW_ID == paper.CONFERENCE_BOARD_OF_REVIEW_ID &&
                             review_paper_abstract.CONFERENCE_ID == paper.CONFERENCE_ID &&
                             review_paper_abstract.APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT == paper.APPROVED
                             orderby review_paper_abstract.PAPER_ABSTRACT_SUBMISSION_DEADLINE_ORDER_NUMBER descending
                              select new
                             {
                                 review_paper_abstract.REVIEWED_DATE,
                                 review_paper_abstract.PAPER_ABSTRACT_SUBMISSION_DEADLINE_ORDER_NUMBER,
                                 review_paper_abstract.PROPOSED_CONFERENCE_SESSION_TOPIC_ID,
                                 review_paper_abstract.PROPOSED_CONFERENCE_SESSION_TOPIC_NAME,
                                 review_paper_abstract.PROPOSED_CONFERENCE_SESSION_TOPIC_NAME_EN,
                                 review_paper_abstract.PROPOSED_TYPE_OF_STUDY_ID,
                                 review_paper_abstract.PROPOSED_TYPE_OF_STUDY_NAME,
                                 review_paper_abstract.PROPOSED_TYPE_OF_STUDY_NAME_EN,
                                 review_paper_abstract.PROPOSED_FOR_PRESENTATION,
                                 review_paper_abstract.PROPOSED_CONFERENCE_PRESENTATION_TYPE_ID,
                                 review_paper_abstract.PROPOSED_CONFERENCE_PRESENTATION_TYPE_NAME,
                                 review_paper_abstract.PROPOSED_CONFERENCE_PRESENTATION_TYPE_NAME_EN,
                                 review_paper_abstract.PAPER_ABSTRACT_REVIEW_RATING_POINT,
                                 review_paper_abstract.SIGNIFICANT_REVISION_OR_MINIMAL_REVISION_OR_REVISION_NEEDED_OR_NO_REVISION_NEEDED,
                                 review_paper_abstract.REVIEW_TEXT,
                                 review_paper_abstract.REVIEW_TEXT_EN,
                                 review_paper_abstract.APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT,
                                 review_paper_abstract.APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_DATE
                             }).Take(1);
                return ResponseSuccess(StringResource.Success, review);
            }
            catch (Exception)
            {
                return ResponseFail(StringResource.Data_not_received);
            }
            
        }

        //Xem đánh giá bài paper text
        /*
        [HttpPost]
        [Route("api/Review/SeeReviewPaperText")]
        public HttpResponseMessage SeeReviewPaperText([FromBody] SeeReviewAbstract paper)
        {
            try
            {
                var review = (from review_paper_paper in db.REVIEWER_PAPER_ABSTRACT_RELATIONSHIP
                              where review_paper_abstract.PERSON_ID == paper.PERSON_ID &&
                              review_paper_abstract.CONFERENCE_BOARD_OF_REVIEW_ID == paper.CONFERENCE_BOARD_OF_REVIEW_ID &&
                              review_paper_abstract.CONFERENCE_ID == paper.CONFERENCE_ID &&
                              review_paper_abstract.APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT == paper.APPROVED
                              orderby review_paper_abstract.PAPER_ABSTRACT_SUBMISSION_DEADLINE_ORDER_NUMBER descending
                              select new
                              {
                                  review_paper_abstract.REVIEWED_DATE,
                                  review_paper_abstract.PAPER_ABSTRACT_SUBMISSION_DEADLINE_ORDER_NUMBER,
                                  review_paper_abstract.PROPOSED_CONFERENCE_SESSION_TOPIC_ID,
                                  review_paper_abstract.PROPOSED_CONFERENCE_SESSION_TOPIC_NAME,
                                  review_paper_abstract.PROPOSED_CONFERENCE_SESSION_TOPIC_NAME_EN,
                                  review_paper_abstract.PROPOSED_TYPE_OF_STUDY_ID,
                                  review_paper_abstract.PROPOSED_TYPE_OF_STUDY_NAME,
                                  review_paper_abstract.PROPOSED_TYPE_OF_STUDY_NAME_EN,
                                  review_paper_abstract.PROPOSED_FOR_PRESENTATION,
                                  review_paper_abstract.PROPOSED_CONFERENCE_PRESENTATION_TYPE_ID,
                                  review_paper_abstract.PROPOSED_CONFERENCE_PRESENTATION_TYPE_NAME,
                                  review_paper_abstract.PROPOSED_CONFERENCE_PRESENTATION_TYPE_NAME_EN,
                                  review_paper_abstract.PAPER_ABSTRACT_REVIEW_RATING_POINT,
                                  review_paper_abstract.SIGNIFICANT_REVISION_OR_MINIMAL_REVISION_OR_REVISION_NEEDED_OR_NO_REVISION_NEEDED,
                                  review_paper_abstract.REVIEW_TEXT,
                                  review_paper_abstract.REVIEW_TEXT_EN,
                                  review_paper_abstract.APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT,
                                  review_paper_abstract.APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_DATE
                              }).Take(1);
                return ResponseSuccess(StringResource.Success, review);
            }
            catch (Exception)
            {
                return ResponseFail(StringResource.Data_not_received);
            }
        }*/




        //Thông tin người Review
        [HttpPost]
        [Route("api/Review/InfomationReview")]
        public HttpResponseMessage InfomationReview([FromBody] PERSON person)
        {
            try
            {
                var item = (from p in db.REVIEWERs
                           where p.PERSON_ID == person.Id
                           select new
                           {
                               p.PERSON_ID,
                               p.CURRENT_LAST_NAME,
                               p.CURRENT_FIRST_NAME,
                               p.CURRENT_MIDDLE_NAME,
                           }).Take(1);
                return ResponseSuccess(StringResource.Success, item);
            }
            catch (Exception)
            {
                return ResponseFail(StringResource.Data_not_received);
            }
            
        }



        public class UPDATE_ABSTRACT_REVIEW
        {
            public int PAPER_ID { get; set; }
            public bool APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT { get; set; }
            public int PERSON_ID { get; set; }
        }

        public class PERSON
        {
            public int Id { get; set; }
        }

        public class RatingScale
        {
            public int IdAbstract { get; set; }
            public int IdPerson { get; set; }
        }

        public class ResuleBoolean
        {
            public bool result { get; set; }
        }

        public class ReviewAbstract
        {
            public int PERSON_ID { get; set; }
            public int CONFERENCE_BOARD_OF_REVIEW_ID { get; set; }
            public int CONFERENCE_ID { get; set; }
            public int PAPER_ID { get; set; }
            public int PROPOSED_CONFERENCE_SESSION_TOPIC_ID { get; set; }
            public String PROPOSED_CONFERENCE_SESSION_TOPIC_NAME { get; set; }
            public String PROPOSED_CONFERENCE_SESSION_TOPIC_NAME_EN { get; set; }
            public int PROPOSED_TYPE_OF_STUDY_ID { get; set;}
            public String PROPOSED_TYPE_OF_STUDY_NAME { get; set; }
            public String PROPOSED_TYPE_OF_STUDY_NAME_EN { get; set; }
            public Boolean PROPOSED_FOR_PRESENTATION { get; set; }
            public int PROPOSED_CONFERENCE_PRESENTATION_TYPE_ID { get; set; }
            public String PROPOSED_CONFERENCE_PRESENTATION_TYPE_NAME { get; set; }
            public String PROPOSED_CONFERENCE_PRESENTATION_TYPE_NAME_EN { get; set; }
            public int PAPER_ABSTRACT_REVIEW_RATING_POINT { get; set; }
            public String SIGNIFICANT_REVISION_OR_MINIMAL_REVISION_OR_REVISION_NEEDED_OR_NO_REVISION_NEEDED { get; set; }
            public String REVIEW_TEXT { get; set; }
            public String REVIEW_TEXT_EN { get; set; }
            public bool APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT { get; set; }
        }

        public class SeeReviewAbstract
        {
            public int PERSON_ID { get; set; }
            public int CONFERENCE_BOARD_OF_REVIEW_ID { get; set; }
            public int CONFERENCE_ID { get; set; }
            public int PAPER_ID { get; set; }
            public bool APPROVED { get; set; }
        }
    }
}
