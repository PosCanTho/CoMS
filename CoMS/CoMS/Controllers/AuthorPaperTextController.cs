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
    public class AuthorPaperTextController : BaseController
    {
        private DB db = new DB();

        [HttpPost]
        [Route("api/RegisterPaperText")]
        public HttpResponseMessage RegisterPaperText([FromBody] SavePaperText paper)
        {
            var model = new AuthorPaperTextModel();
            var result = model.GetPaperTextById(paper.PAPER_ID);
            if (result == null)
            {
                //insert
                var item = new SavePaperText();
                item.PAPER_ID = paper.PAPER_ID;
                item.PAPER_TEXT_TITLE = paper.PAPER_TEXT_TITLE;
                item.PAPER_TEXT_TITLE_EN = paper.PAPER_TEXT_TITLE_EN;
                item.PAPER_TEXT = paper.PAPER_TEXT;
                item.FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_ID = paper.FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_ID;
                item.FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_NAME = paper.FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_NAME;
                item.FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_NAME_EN = paper.FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_NAME_EN;
                item.FINAL_APPROVED_FULL_PAPER_OR_WORK_IN_PROGRESS = paper.FINAL_APPROVED_FULL_PAPER_OR_WORK_IN_PROGRESS;
                item.FINAL_APPROVED_TYPE_OF_STUDY_ID = paper.FINAL_APPROVED_TYPE_OF_STUDY_ID;
                item.FINAL_APPROVED_TYPE_OF_STUDY_NAME = paper.FINAL_APPROVED_TYPE_OF_STUDY_NAME;
                item.FINAL_APPROVED_TYPE_OF_STUDY_NAME_EN = paper.FINAL_APPROVED_TYPE_OF_STUDY_NAME_EN;
                item.FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_ID = paper.FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_ID;
                item.FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_NAME = paper.FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_NAME;
                item.FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_NAME_EN = paper.FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_NAME_EN;
                item.POSITION = paper.POSITION;

                var result2 = model.SavePaper(
                    paper.PAPER_ID,
                    paper.PAPER_TEXT_TITLE,
                    paper.PAPER_TEXT_TITLE_EN,
                    paper.PAPER_TEXT,
                    paper.FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_ID,
                    paper.FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_NAME,
                    paper.FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_NAME_EN,
                    paper.FINAL_APPROVED_FULL_PAPER_OR_WORK_IN_PROGRESS,
                    paper.FINAL_APPROVED_TYPE_OF_STUDY_ID,
                    paper.FINAL_APPROVED_TYPE_OF_STUDY_NAME,
                    paper.FINAL_APPROVED_TYPE_OF_STUDY_NAME_EN,
                    paper.FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_ID,
                    paper.FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_NAME,
                    paper.FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_NAME_EN,
                    1
                    );
                if (result2 == true)
                {
                    var t = new ResuleBoolean();
                    t.result = result2;
                    return ResponseSuccess(StringResource.Success, t);
                }
                else
                {
                    var t = new ResuleBoolean();
                    t.result = result2;
                    return ResponseSuccess(StringResource.Success, t);
                }
                
            }
            else
            {
                var t = new ResuleBoolean();
                t.result = false;
                return ResponseSuccess(StringResource.Success, t);
            }
        }

        //Update paper text
        [HttpPost]
        [Route("api/Update_PaperText")]
        public HttpResponseMessage Update_PaperText([FromBody] UpdatePaperText paper)
        {
            try
            {
                var model = new AuthorPaperTextModel();
                var result = model.UpdateItemPaperText(paper.PAPER_ID, paper.PAPER_TEXT_TITLE, paper.PAPER_TEXT_TITLE_EN, paper.CONFERENCE_ID);
                if (result == true)
                {
                    var t = new ResuleBoolean();
                    t.result = true;
                    return ResponseSuccess(StringResource.Success, t);
                }
                else
                {
                    var t = new ResuleBoolean();
                    t.result = false;
                    return ResponseSuccess(StringResource.Success, t);
                }
            }
            catch (Exception)
            {
                return ResponseFail(StringResource.Data_not_received);
            }
        }

        //Rút bài
        [HttpPost]
        [Route("api/WithDrawnPaperText")]
        public HttpResponseMessage WithDrawnPaperText([FromBody] WithDrawnAbs paper)
        {
            try
            {
                int value;
                var model = new AuthorPaperTextModel();
                var paperText = model.WithdrawnPaperText(paper.Id);
                if (paperText == null)
                {
                    return ResponseFail(StringResource.Data_not_received);
                }
                else if(int.TryParse(paper.Id + "", out value))
                {
                    if (paperText == true)
                    {
                        var result = new ResuleBoolean();
                        result.result = paperText;

                        return ResponseSuccess(StringResource.Success, result);
                    }
                    else
                    {
                        var result = new ResuleBoolean();
                        result.result = paperText;
                        return ResponseSuccess(StringResource.Success, result);
                    }
                }else
                {
                    return ResponseFail(StringResource.Data_not_received);
                }
                
            }
            catch (Exception)
            {
                return ResponseFail(StringResource.Data_not_received);
            }

            
            
        }

        //Xem đánh giá
        //[HttpPost]
        //[Route("api/WithDrawnPaperText")]
        //public HttpResponseMessage WithDrawnPaperText([FromBody] See_Paper paper)
        //{

        //}

        //see paper text

        [HttpPost]
        [Route("api/See_PaperText")]
        public HttpResponseMessage See_PaperText([FromBody] See_Paper paper)
        {
            if (paper.Id > 0 && paper.position >= 0)
            {
                var papertext = new AuthorPaperTextModel();
                var paperAbs = papertext.GetPaperTextById(paper.Id);
                var jsonArray = new JArray();
                try
                {
                    switch (paper.position)
                    {
                        case 1:
                            var json1 = new JObject(
                                                new JProperty("PAPER_TEXT_TITLE", paperAbs.PAPER_TEXT_TITLE_1),
                                                new JProperty("PAPER_TEXT_TITLE_EN", paperAbs.PAPER_TEXT_TITLE_EN_1)
                                                );
                            jsonArray.Add(json1);
                            break;
                        case 2:
                            var json2 = new JObject(
                                                new JProperty("PAPER_TEXT_TITLE", paperAbs.PAPER_TEXT_TITLE_2),
                                                new JProperty("PAPER_TEXT_TITLE_EN", paperAbs.PAPER_TEXT_TITLE_EN_2)
                                                );
                            jsonArray.Add(json2);
                            break;
                        case 3:
                            var json3 = new JObject(
                                                new JProperty("PAPER_TEXT_TITLE", paperAbs.PAPER_TEXT_TITLE_3),
                                                new JProperty("PAPER_TEXT_TITLE_EN", paperAbs.PAPER_TEXT_TITLE_EN_3)
                                                );
                            jsonArray.Add(json3);
                            break;
                        case 4:
                            var json4 = new JObject(
                                                new JProperty("PAPER_TEXT_TITLE", paperAbs.PAPER_TEXT_TITLE_4),
                                                new JProperty("PAPER_TEXT_TITLE_EN", paperAbs.PAPER_TEXT_TITLE_EN_4)
                                                );
                            jsonArray.Add(json4);
                            break;
                        case 5:
                            var json5 = new JObject(
                                                new JProperty("PAPER_TEXT_TITLE", paperAbs.PAPER_TEXT_TITLE_5),
                                                new JProperty("PAPER_TEXT_TITLE_EN", paperAbs.PAPER_TEXT_TITLE_EN_5)
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

        
        

        //list paper text
        [HttpPost]
        [Route("api/List_PaperText")]
        public HttpResponseMessage ListPaperText([FromBody] InfoUserAuthor user)
        {
            try
            {
                var query = from AUTHOR_PAPER_TEXT_RELATIONSHIP in db.AUTHOR_PAPER_TEXT_RELATIONSHIP
                            join PAPER_ABSTRACT in db.PAPER_ABSTRACT on AUTHOR_PAPER_TEXT_RELATIONSHIP.PAPER_ID equals PAPER_ABSTRACT.PAPER_ID
                            join confer in db.CONFERENCEs on AUTHOR_PAPER_TEXT_RELATIONSHIP.CONFERENCE_ID equals confer.CONFERENCE_ID
                            join paper_text in db.PAPER_TEXT on PAPER_ABSTRACT.PAPER_ID equals paper_text.PAPER_ID
                            where AUTHOR_PAPER_TEXT_RELATIONSHIP.PERSON_ID == user.idAuthor
                            select
                            new
                            {
                                AUTHOR_PAPER_TEXT_RELATIONSHIP.PERSON_ID,
                                AUTHOR_PAPER_TEXT_RELATIONSHIP.CONFERENCE_ID,
                                AUTHOR_PAPER_TEXT_RELATIONSHIP.ORGANIZATION_ID_1,
                                AUTHOR_PAPER_TEXT_RELATIONSHIP.ORGANIZATION_NAME_1,
                                AUTHOR_PAPER_TEXT_RELATIONSHIP.ORGANIZATION_NAME_EN_1,
                                AUTHOR_PAPER_TEXT_RELATIONSHIP.ORGANIZATION_ID_2,
                                AUTHOR_PAPER_TEXT_RELATIONSHIP.ORGANIZATION_NAME_2,
                                AUTHOR_PAPER_TEXT_RELATIONSHIP.ORGANIZATION_ID_3,
                                AUTHOR_PAPER_TEXT_RELATIONSHIP.ORGANIZATION_NAME_3,
                                AUTHOR_PAPER_TEXT_RELATIONSHIP.ORGANIZATION_ID_4,
                                AUTHOR_PAPER_TEXT_RELATIONSHIP.ORGANIZATION_NAME_4,
                                AUTHOR_PAPER_TEXT_RELATIONSHIP.ORGANIZATION_ID_5,
                                AUTHOR_PAPER_TEXT_RELATIONSHIP.ORGANIZATION_NAME_5,
                                AUTHOR_PAPER_TEXT_RELATIONSHIP.CORRESPONDING_AUTHOR,
                                CONFERENCE_NAME1 = (confer.CONFERENCE_NAME + " - " + paper_text.PAPER_TEXT_TITLE_1),
                                confer.PAPER_TEXT_DEADLINE_1,
                                confer.FROM_DATE,
                                confer.THRU_DATE,
                                PAPER_ABSTRACT.PAPER_ID,
                                PAPER_ABSTRACT.PAPER_NUMBER_OR_CODE,

                                paper_text.PAPER_TEXT_TITLE_1,
                                paper_text.PAPER_TEXT_TITLE_EN_1,
                                PAPER_ABSTRACT.CONFERENCE_SESSION_TOPIC_ID_1,
                                PAPER_ABSTRACT.CONFERENCE_SESSION_TOPIC_NAME_1,
                                PAPER_ABSTRACT.CONFERENCE_SESSION_TOPIC_NAME_EN_1,
                                paper_text.PAPER_TEXT_1,
                                paper_text.FINAL_APPROVED_FULL_PAPER_OR_WORK_IN_PROGRESS,
                                PAPER_ABSTRACT.TYPE_OF_STUDY_ID_1,
                                PAPER_ABSTRACT.TYPE_OF_STUDY_NAME_1,
                                PAPER_ABSTRACT.TYPE_OF_STUDY_NAME_EN_1,
                                PAPER_ABSTRACT.CONFERENCE_PRESENTATION_TYPE_ID_1,
                                PAPER_ABSTRACT.CONFERENCE_PRESENTATION_TYPE_NAME_1,
                                PAPER_ABSTRACT.CONFERENCE_PRESENTATION_TYPE_NAME_EN_1,
                                paper_text.FIRST_SUBMITTED_DATE_1,
                                paper_text.LAST_REVISED_DATE_1,
                                paper_text.PAPER_TEXT_ATTACHED_FILENAME_1,


                                CONFERENCE_NAME2 = confer.CONFERENCE_NAME + " - " + paper_text.PAPER_TEXT_TITLE_2,
                                confer.PAPER_TEXT_DEADLINE_2,
                                paper_text.PAPER_TEXT_TITLE_2,
                                paper_text.PAPER_TEXT_TITLE_EN_2,
                                PAPER_ABSTRACT.CONFERENCE_SESSION_TOPIC_ID_2,
                                PAPER_ABSTRACT.CONFERENCE_SESSION_TOPIC_NAME_2,
                                PAPER_ABSTRACT.CONFERENCE_SESSION_TOPIC_NAME_EN_2,
                                paper_text.PAPER_TEXT_2,
                                PAPER_ABSTRACT.TYPE_OF_STUDY_ID_2,
                                PAPER_ABSTRACT.TYPE_OF_STUDY_NAME_2,
                                PAPER_ABSTRACT.TYPE_OF_STUDY_NAME_EN_2,
                                PAPER_ABSTRACT.CONFERENCE_PRESENTATION_TYPE_ID_2,
                                PAPER_ABSTRACT.CONFERENCE_PRESENTATION_TYPE_NAME_2,
                                PAPER_ABSTRACT.CONFERENCE_PRESENTATION_TYPE_NAME_EN_2,
                                paper_text.FIRST_SUBMITTED_DATE_2,
                                paper_text.LAST_REVISED_DATE_2,
                                paper_text.PAPER_TEXT_ATTACHED_FILENAME_2,


                                CONFERENCE_NAME3 = confer.CONFERENCE_NAME + " - " + paper_text.PAPER_TEXT_TITLE_3,
                                confer.PAPER_TEXT_DEADLINE_3,
                                paper_text.PAPER_TEXT_3,
                                PAPER_ABSTRACT.TYPE_OF_STUDY_ID_3,
                                PAPER_ABSTRACT.TYPE_OF_STUDY_NAME_3,
                                PAPER_ABSTRACT.TYPE_OF_STUDY_NAME_EN_3,
                                PAPER_ABSTRACT.CONFERENCE_PRESENTATION_TYPE_ID_3,
                                PAPER_ABSTRACT.CONFERENCE_PRESENTATION_TYPE_NAME_3,
                                PAPER_ABSTRACT.CONFERENCE_PRESENTATION_TYPE_NAME_EN_3,
                                paper_text.FIRST_SUBMITTED_DATE_3,
                                paper_text.LAST_REVISED_DATE_3,
                                paper_text.PAPER_TEXT_ATTACHED_FILENAME_3,

                                CONFERENCE_NAME4 = confer.CONFERENCE_NAME + " - " + paper_text.PAPER_TEXT_TITLE_4,
                                CONFERENCE_SESSION_TOPIC_ID_3 = PAPER_ABSTRACT.CONFERENCE_SESSION_TOPIC_ID_2 == null ? PAPER_ABSTRACT.CONFERENCE_SESSION_TOPIC_ID_1 : PAPER_ABSTRACT.CONFERENCE_SESSION_TOPIC_ID_2,
                                CONFERENCE_SESSION_TOPIC_NAME_3 = PAPER_ABSTRACT.CONFERENCE_SESSION_TOPIC_NAME_2 == null ? PAPER_ABSTRACT.CONFERENCE_SESSION_TOPIC_NAME_1 : PAPER_ABSTRACT.CONFERENCE_SESSION_TOPIC_NAME_2,
                                CONFERENCE_SESSION_TOPIC_NAME_EN_3 = PAPER_ABSTRACT.CONFERENCE_SESSION_TOPIC_NAME_EN_2 == null ? PAPER_ABSTRACT.CONFERENCE_SESSION_TOPIC_NAME_EN_1 : PAPER_ABSTRACT.CONFERENCE_SESSION_TOPIC_NAME_EN_2,


                                confer.PAPER_TEXT_DEADLINE_4,
                                paper_text.PAPER_TEXT_4,
                                PAPER_ABSTRACT.TYPE_OF_STUDY_ID_4,
                                PAPER_ABSTRACT.TYPE_OF_STUDY_NAME_4,
                                PAPER_ABSTRACT.TYPE_OF_STUDY_NAME_EN_4,
                                PAPER_ABSTRACT.CONFERENCE_PRESENTATION_TYPE_ID_4,
                                PAPER_ABSTRACT.CONFERENCE_PRESENTATION_TYPE_NAME_4,
                                PAPER_ABSTRACT.CONFERENCE_PRESENTATION_TYPE_NAME_EN_4,
                                paper_text.FIRST_SUBMITTED_DATE_4,
                                paper_text.LAST_REVISED_DATE_4,
                                CONFERENCE_SESSION_TOPIC_ID_4 = PAPER_ABSTRACT.CONFERENCE_SESSION_TOPIC_ID_2 == null ? PAPER_ABSTRACT.CONFERENCE_SESSION_TOPIC_ID_1 : PAPER_ABSTRACT.CONFERENCE_SESSION_TOPIC_ID_2,
                                CONFERENCE_SESSION_TOPIC_NAME_4 = PAPER_ABSTRACT.CONFERENCE_SESSION_TOPIC_NAME_2 == null ? PAPER_ABSTRACT.CONFERENCE_SESSION_TOPIC_NAME_1 : PAPER_ABSTRACT.CONFERENCE_SESSION_TOPIC_NAME_2,
                                CONFERENCE_SESSION_TOPIC_NAME_EN_4 = PAPER_ABSTRACT.CONFERENCE_SESSION_TOPIC_NAME_EN_2 == null ? PAPER_ABSTRACT.CONFERENCE_SESSION_TOPIC_NAME_EN_1 : PAPER_ABSTRACT.CONFERENCE_SESSION_TOPIC_NAME_EN_2,
                                paper_text.PAPER_TEXT_ATTACHED_FILENAME_4,


                                CONFERENCE_NAME5 = confer.CONFERENCE_NAME + " - " + paper_text.PAPER_TEXT_TITLE_EN_5,
                                confer.PAPER_TEXT_DEADLINE_5,
                                paper_text.PAPER_TEXT_5,
                                PAPER_ABSTRACT.TYPE_OF_STUDY_ID_5,
                                PAPER_ABSTRACT.TYPE_OF_STUDY_NAME_5,
                                PAPER_ABSTRACT.TYPE_OF_STUDY_NAME_EN_5,
                                PAPER_ABSTRACT.CONFERENCE_PRESENTATION_TYPE_ID_5,
                                PAPER_ABSTRACT.CONFERENCE_PRESENTATION_TYPE_NAME_5,
                                PAPER_ABSTRACT.CONFERENCE_PRESENTATION_TYPE_NAME_EN_5,
                                paper_text.FIRST_SUBMITTED_DATE_5,
                                paper_text.LAST_REVISED_DATE_5,
                                CONFERENCE_SESSION_TOPIC_ID_5 = PAPER_ABSTRACT.CONFERENCE_SESSION_TOPIC_ID_2 == null ? PAPER_ABSTRACT.CONFERENCE_SESSION_TOPIC_ID_1 : PAPER_ABSTRACT.CONFERENCE_SESSION_TOPIC_ID_2,
                                CONFERENCE_SESSION_TOPIC_NAME_5 = PAPER_ABSTRACT.CONFERENCE_SESSION_TOPIC_NAME_2 == null ? PAPER_ABSTRACT.CONFERENCE_SESSION_TOPIC_NAME_1 : PAPER_ABSTRACT.CONFERENCE_SESSION_TOPIC_NAME_2,
                                CONFERENCE_SESSION_TOPIC_NAME_EN_5 = PAPER_ABSTRACT.CONFERENCE_SESSION_TOPIC_NAME_EN_2 == null ? PAPER_ABSTRACT.CONFERENCE_SESSION_TOPIC_NAME_EN_1 : PAPER_ABSTRACT.CONFERENCE_SESSION_TOPIC_NAME_EN_2,
                                paper_text.PAPER_TEXT_ATTACHED_FILENAME_5,


                                paper_text.PAPER_TEXT_WITHDRAWN,
                                paper_text.PAPER_TEXT_WITHDRAWN_DATE,
                                paper_text.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT,
                                //paper_text.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT_REVIEWER_PERSON_ID
                            };

                if (query != null)
                {
                    var jsonArray = new JArray();

                    foreach (var q in query)
                    {
                        if (q.PAPER_TEXT_TITLE_1 != null || q.PAPER_TEXT_DEADLINE_1 != null)
                        {
                            var json1 = new JObject(
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
                                            new JProperty("PAPER_TEXT_DEADLINE", q.PAPER_TEXT_DEADLINE_1),
                                            new JProperty("PAPER_TEXT_TITLE", q.PAPER_TEXT_TITLE_1),
                                            new JProperty("PAPER_TEXT_TITLE_EN", q.PAPER_TEXT_TITLE_EN_1),
                                            new JProperty("CONFERENCE_SESSION_TOPIC_ID", q.CONFERENCE_SESSION_TOPIC_ID_1),
                                            new JProperty("CONFERENCE_SESSION_TOPIC_NAME", q.CONFERENCE_SESSION_TOPIC_NAME_1),
                                            new JProperty("CONFERENCE_SESSION_TOPIC_NAME_EN", q.CONFERENCE_SESSION_TOPIC_NAME_EN_1),
                                            new JProperty("PAPER_TEXT", q.PAPER_TEXT_1),
                                            new JProperty("TYPE_OF_STUDY_ID", q.TYPE_OF_STUDY_ID_1),
                                            new JProperty("TYPE_OF_STUDY_NAME", q.TYPE_OF_STUDY_NAME_1),
                                            new JProperty("TYPE_OF_STUDY_NAME_EN", q.TYPE_OF_STUDY_NAME_EN_1),
                                            new JProperty("CONFERENCE_PRESENTATION_TYPE_ID", q.CONFERENCE_PRESENTATION_TYPE_ID_1),
                                            new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME", q.CONFERENCE_PRESENTATION_TYPE_NAME_1),
                                            new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME_EN", q.CONFERENCE_PRESENTATION_TYPE_NAME_EN_1),
                                            new JProperty("FIRST_SUBMITTED_DATE", q.FIRST_SUBMITTED_DATE_1),
                                            new JProperty("LAST_REVISED_DATE", q.LAST_REVISED_DATE_1),
                                            new JProperty("PAPER_TEXT_ATTACHED_FILENAME", q.PAPER_TEXT_ATTACHED_FILENAME_1),
                                            new JProperty("FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT", q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT),
                                            new JProperty("FROM_DATE", q.FROM_DATE),
                                            new JProperty("THRU_DATE", q.THRU_DATE),
                                            new JProperty("PAPER_TEXT_WITHDRAWN", q.PAPER_TEXT_WITHDRAWN),
                                            new JProperty("PAPER_TEXT_WITHDRAWN_DATE", q.PAPER_TEXT_WITHDRAWN_DATE),
                                            new JProperty("POSITION", 1)
                                            );
                            jsonArray.Add(json1);
                        }

                        if (q.PAPER_TEXT_TITLE_2 != null || q.PAPER_TEXT_DEADLINE_2 != null)
                        {
                            var json2 = new JObject(
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
                                            new JProperty("PAPER_TEXT_DEADLINE", q.PAPER_TEXT_DEADLINE_2),
                                            new JProperty("PAPER_TEXT_TITLE", q.PAPER_TEXT_TITLE_2),
                                            new JProperty("PAPER_TEXT_TITLE_EN", q.PAPER_TEXT_TITLE_EN_2),
                                            new JProperty("CONFERENCE_SESSION_TOPIC_ID", q.CONFERENCE_SESSION_TOPIC_ID_2),
                                            new JProperty("CONFERENCE_SESSION_TOPIC_NAME", q.CONFERENCE_SESSION_TOPIC_NAME_2),
                                            new JProperty("CONFERENCE_SESSION_TOPIC_NAME_EN", q.CONFERENCE_SESSION_TOPIC_NAME_EN_2),
                                            new JProperty("PAPER_TEXT", q.PAPER_TEXT_2),
                                            new JProperty("TYPE_OF_STUDY_ID", q.TYPE_OF_STUDY_ID_2),
                                            new JProperty("TYPE_OF_STUDY_NAME", q.TYPE_OF_STUDY_NAME_2),
                                            new JProperty("TYPE_OF_STUDY_NAME_EN", q.TYPE_OF_STUDY_NAME_EN_2),
                                            new JProperty("CONFERENCE_PRESENTATION_TYPE_ID", q.CONFERENCE_PRESENTATION_TYPE_ID_2),
                                            new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME", q.CONFERENCE_PRESENTATION_TYPE_NAME_2),
                                            new JProperty("CONFERENCE_PRESENTATION_TYPE_NAME_EN", q.CONFERENCE_PRESENTATION_TYPE_NAME_EN_2),
                                            new JProperty("FIRST_SUBMITTED_DATE", q.FIRST_SUBMITTED_DATE_2),
                                            new JProperty("LAST_REVISED_DATE", q.LAST_REVISED_DATE_2),
                                            new JProperty("PAPER_TEXT_ATTACHED_FILENAME", q.PAPER_TEXT_ATTACHED_FILENAME_2),
                                            new JProperty("FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT", q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT),
                                            new JProperty("FROM_DATE", q.FROM_DATE),
                                            new JProperty("THRU_DATE", q.THRU_DATE),
                                            new JProperty("PAPER_TEXT_WITHDRAWN", q.PAPER_TEXT_WITHDRAWN),
                                            new JProperty("PAPER_TEXT_WITHDRAWN_DATE", q.PAPER_TEXT_WITHDRAWN_DATE),
                                            new JProperty("POSITION", 2)
                                            );
                            jsonArray.Add(json2);
                        }

                        if (q.PAPER_TEXT_DEADLINE_3 != null)
                        {
                            var json3 = new JObject(
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
                                            new JProperty("PAPER_TEXT_DEADLINE", q.PAPER_TEXT_DEADLINE_3),
                                            new JProperty("PAPER_TEXT", q.PAPER_TEXT_3),
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
                                            new JProperty("PAPER_TEXT_ATTACHED_FILENAME", q.PAPER_TEXT_ATTACHED_FILENAME_3),
                                            new JProperty("FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT", q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT),
                                            new JProperty("FROM_DATE", q.FROM_DATE),
                                            new JProperty("THRU_DATE", q.THRU_DATE),
                                            new JProperty("PAPER_TEXT_WITHDRAWN", q.PAPER_TEXT_WITHDRAWN),
                                            new JProperty("PAPER_TEXT_WITHDRAWN_DATE", q.PAPER_TEXT_WITHDRAWN_DATE),
                                            new JProperty("POSITION", 3)
                                            );
                            jsonArray.Add(json3);
                        }

                        if (q.PAPER_TEXT_DEADLINE_4 != null)
                        {
                            var json4 = new JObject(
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
                                            new JProperty("PAPER_TEXT_DEADLINE", q.PAPER_TEXT_DEADLINE_4),
                                            new JProperty("PAPER_TEXT", q.PAPER_TEXT_4),
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
                                            new JProperty("PAPER_TEXT_ATTACHED_FILENAME", q.PAPER_TEXT_ATTACHED_FILENAME_4),
                                            new JProperty("FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT", q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT),
                                            new JProperty("FROM_DATE", q.FROM_DATE),
                                            new JProperty("THRU_DATE", q.THRU_DATE),
                                            new JProperty("PAPER_TEXT_WITHDRAWN", q.PAPER_TEXT_WITHDRAWN),
                                            new JProperty("PAPER_TEXT_WITHDRAWN_DATE", q.PAPER_TEXT_WITHDRAWN_DATE),
                                            new JProperty("POSITION", 4)
                                            );
                            jsonArray.Add(json4);
                        }

                        if (q.PAPER_TEXT_DEADLINE_5 != null)
                        {
                            var json5 = new JObject(
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
                                            new JProperty("PAPER_TEXT_DEADLINE", q.PAPER_TEXT_DEADLINE_5),
                                            new JProperty("PAPER_TEXT", q.PAPER_TEXT_5),
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
                                            new JProperty("PAPER_TEXT_ATTACHED_FILENAME", q.PAPER_TEXT_ATTACHED_FILENAME_5),
                                            new JProperty("FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT", q.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT),
                                            new JProperty("FROM_DATE", q.FROM_DATE),
                                            new JProperty("THRU_DATE", q.THRU_DATE),
                                            new JProperty("PAPER_TEXT_WITHDRAWN", q.PAPER_TEXT_WITHDRAWN),
                                            new JProperty("PAPER_TEXT_WITHDRAWN_DATE", q.PAPER_TEXT_WITHDRAWN_DATE),
                                            new JProperty("POSITION", 5)
                                            );
                            jsonArray.Add(json5);
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
            catch (Exception)
            {
                return ResponseFail(StringResource.Data_not_received);
            }
        }




        public class SavePaperText
        {
            public int PAPER_ID { get; set; }
            public String PAPER_TEXT_TITLE { get; set; }
            public String PAPER_TEXT_TITLE_EN { get; set; }
            public String PAPER_TEXT { get; set; }
            public int FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_ID { get; set; }
            public String FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_NAME { get; set; }
            public String FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_NAME_EN { get; set; }
            public String FINAL_APPROVED_FULL_PAPER_OR_WORK_IN_PROGRESS { get; set; }
            public int FINAL_APPROVED_TYPE_OF_STUDY_ID { get; set; }
            public String FINAL_APPROVED_TYPE_OF_STUDY_NAME { get; set; }
            public String FINAL_APPROVED_TYPE_OF_STUDY_NAME_EN { get; set; }
            public int FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_ID { get; set; }
            public String FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_NAME { get; set; }
            public String FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_NAME_EN { get; set; }
            public int POSITION { get; set; }
        }

        public class ResuleBoolean
        {
            public bool result { get; set; }
        }

        public class InfoUserAuthor
        {
            public int idAuthor { get; set; }
        }

        public class See_Paper
        {
            public int Id { get; set; }
            public int position { get; set; }
        }

        public class UpdatePaperText
        {
            public int PAPER_ID { get; set; }
            public String PAPER_TEXT_TITLE { get; set; }
            public String PAPER_TEXT_TITLE_EN { get; set; }
            public int CONFERENCE_ID { get; set; }
        }

        public class WithDrawnAbs
        {
            public int Id { get; set; }
        }

        
    }
}
