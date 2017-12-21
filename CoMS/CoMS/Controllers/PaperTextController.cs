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
    public class PaperTextController : BaseController
    {
        [HttpPost]
        [Route("api/ListPaperText")]
        public HttpResponseMessage ListPaperText(int personId, int conferenceId)
        {
            var model = new PaperTextModel();
            return ResponseSuccess(StringResource.Success, model.getListPaperText(personId, conferenceId));
        }

        [HttpPost]
        [Route("api/GetPaperText")]
        public HttpResponseMessage GetPaperText(int paperId)
        {
            var paper = db.PAPER_TEXT.Find(paperId);
            var model = new PaperTextModel();
            if (paper == null)
            {
                return ResponseFail(StringResource.Paper_text_do_not_exist);
            }
            else
            {
                var paperAbstract = model.getMyPaperText(paper);
                return ResponseSuccess(StringResource.Success, paperAbstract);
            }
        }


        [HttpPost]
        [Route("api/GetListAuthorOfPaperText")]
        public HttpResponseMessage GetListAuthorOfPaperText(int paperId)
        {
            var paper = db.PAPER_TEXT.Find(paperId);
            var model = new PaperAbstractModel();
            if (paper == null)
            {
                return ResponseFail(StringResource.Paper_text_do_not_exist);
            }
            else
            {
                var listAuthor = (from a in db.AUTHOR_PAPER_TEXT_RELATIONSHIP
                                  join au in db.AUTHORs on a.PERSON_ID equals au.PERSON_ID
                                  join p in db.People on a.PERSON_ID equals p.PERSON_ID
                                  where a.PAPER_ID == paperId && au.CONFERENCE_ID == a.CONFERENCE_ID
                                  select new { a, au,p })
                                 .AsEnumerable()
                                 .Distinct()
                                 .Select(x => new
                                 {
                                     x.a.PERSON_ID,
                                     x.a.CONFERENCE_ID,
                                     x.a.PAPER_ID,
                                     x.au.CURRENT_FIRST_NAME,
                                     x.au.CURRENT_MIDDLE_NAME,
                                     x.au.CURRENT_LAST_NAME,
                                     FULL_NAME = Utils.GetFullName(x.au.CURRENT_FIRST_NAME, x.au.CURRENT_MIDDLE_NAME, x.au.CURRENT_LAST_NAME),
                                     x.p.CURRENT_PERSONAL_EMAIL
                                 }).Distinct();
                return ResponseSuccess(StringResource.Success, listAuthor);
            }
        }

        [HttpPost]
        [Route("api/GetFormSubmitPaperText")]
        public HttpResponseMessage GetFormSubmitPaperText(int conferenceId)
        {
            var conference = db.CONFERENCEs.Find(conferenceId);
            var form = new FormSubmitPaperText();
            if (DateTime.Now <= conference.PAPER_TEXT_DEADLINE_1)
            {
                form.NUMBER_PAPER_TEXT_DEADLINE = 1;
                form.PAPER_TEXT_DEADLINE = conference.PAPER_TEXT_DEADLINE_1;
            }
            else if (DateTime.Now <= conference.PAPER_TEXT_DEADLINE_2)
            {
                form.NUMBER_PAPER_TEXT_DEADLINE = 2;
                form.PAPER_TEXT_DEADLINE = conference.PAPER_TEXT_DEADLINE_2;
            }
            else if (DateTime.Now <= conference.PAPER_TEXT_DEADLINE_3)
            {
                form.NUMBER_PAPER_TEXT_DEADLINE = 3;
                form.PAPER_TEXT_DEADLINE = conference.PAPER_TEXT_DEADLINE_3;
            }
            else if (DateTime.Now <= conference.PAPER_TEXT_DEADLINE_4)
            {
                form.NUMBER_PAPER_TEXT_DEADLINE = 4;
                form.PAPER_TEXT_DEADLINE = conference.PAPER_TEXT_DEADLINE_4;
            }
            else if (DateTime.Now <= conference.PAPER_TEXT_DEADLINE_5)
            {
                form.NUMBER_PAPER_TEXT_DEADLINE = 5;
                form.PAPER_TEXT_DEADLINE = conference.PAPER_TEXT_DEADLINE_5;
            }
            else
            {
                return ResponseFail(StringResource.Out_of_time);
            }
            form.ListSessionTopic = db.CONFERENCE_SESSION_TOPIC.Where(x => x.CONFERENCE_ID == conferenceId).
                                    Select(x => new
                                    {
                                        x.CONFERENCE_SESSION_TOPIC_ID,
                                        x.CONFERENCE_SESSION_TOPIC_NAME,
                                        x.CONFERENCE_SESSION_TOPIC_NAME_EN
                                    });
            form.ListTypeOfStudy = from c in db.CONFERENCE_TYPE_OF_STUDY_RELATIONSHIP
                                   join t in db.TYPE_OF_STUDY on c.TYPE_OF_STUDY_ID equals t.TYPE_OF_STUDY_ID
                                   where c.CONFERENCE_ID == conferenceId
                                   select new { t.TYPE_OF_STUDY_ID, t.TYPE_OF_STUDY_NAME, t.TYPE_OF_STUDY_NAME_EN };
            form.ListPresentationType = from s in db.SESSION_TOPIC_CONFERENCE_PRESENTATION_TYPE
                                        join c in db.CONFERENCE_PRESENTATION_TYPE on s.CONFERENCE_PRESENTATION_TYPE_ID equals c.CONFERENCE_PRESENTATION_TYPE_ID
                                        where s.CONFERENCE_ID == conferenceId
                                        select new { c.CONFERENCE_PRESENTATION_TYPE_ID, c.CONFERENCE_PRESENTATION_TYPE_NAME, c.CONFERENCE_PRESENTATION_TYPE_NAME_EN };
            return ResponseSuccess(StringResource.Success, form);
        }

        [HttpPost]
        [Route("api/WithDrawPaperText")]
        public HttpResponseMessage WithDrawPaperText([FromBody]WithDrawForm body)
        {
            var paper = db.PAPER_TEXT.Find(body.PAPER_ID);
            var model = new PaperTextModel();
            if (paper == null)
            {
                return ResponseFail(StringResource.Paper_text_do_not_exist);
            }
            else
            {
                paper.PAPER_TEXT_WITHDRAWN = true;
                paper.PAPER_TEXT_WITHDRAWN_DATE = DateTime.Now;
                paper.PAPER_TEXT_WITHDRAWN_NOTE = body.NOTE;
                db.SaveChanges();
                return ResponseSuccess(StringResource.Success);
            }
           
        }

        [HttpPost]
        [Route("api/RemoveAuthorOfPaperText")]
        public HttpResponseMessage RemoveAuthorOfPaperText(int paperId, int personId)
        {
            var paper = db.PAPER_TEXT.Find(paperId);
            var person = db.People.Find(personId);
            if (paper == null)
            {
                return ResponseFail(StringResource.Paper_text_do_not_exist);
            }
            else if (person == null)
            {
                return ResponseFail(StringResource.Person_do_not_exist);
            }
            else
            {
                var author = db.AUTHOR_PAPER_TEXT_RELATIONSHIP.Where(x => x.PAPER_ID == paperId && x.PERSON_ID == personId);
                db.AUTHOR_PAPER_TEXT_RELATIONSHIP.RemoveRange(author);
                db.SaveChanges();
                return ResponseSuccess(StringResource.Success);
            }
        }

        [HttpPost]
        [Route("api/SubmitPaperText")]
        public HttpResponseMessage SubmitPaperText([FromBody]PaperTextSubmit body)
        {
            var person = db.People.Find(body.PERSON_ID);
            var conference = db.CONFERENCEs.Find(body.CONFERENCE_ID);
            var model = new PaperTextModel();
            if (person == null)
            {
                return ResponseFail(StringResource.Person_do_not_exist);
            }
            else if (conference == null)
            {
                return ResponseFail(StringResource.Conference_do_not_exist);
            }
            else if (!model.checkConferencePaperTextSubmitExpired(body.CONFERENCE_ID))
            {
                return ResponseFail(StringResource.Out_of_time);
            }
            else
            {
                var paperText = new PAPER_TEXT();
                paperText.PAPER_ID = body.PAPER_ID;
                paperText.PAPER_NUMBER_OR_CODE = "PA" + paperText.PAPER_ID;
                paperText.PAPER_TEXT_TITLE_1 = body.PAPER_TEXT_TITLE;
                paperText.PAPER_TEXT_TITLE_EN_1 = body.PAPER_TEXT_TITLE_EN;
                paperText.PAPER_TEXT_1 = body.PAPER_TEXT;
                paperText.PAPER_TEXT_EN_1 = body.PAPER_TEXT_EN;
                paperText.PAPER_TEXT_ATTACHED_FILENAME_1 = body.PAPER_TEXT_ATTACHED_FILENAME;
                paperText.NUMBER_OF_PAGES_OF_PAPER_TEXT_1 = body.NUMBER_OF_PAGES_OF_PAPER_TEXT;
                paperText.FIRST_SUBMITTED_DATE_1 = DateTime.Now;
                paperText.LAST_REVISED_DATE_1 = DateTime.Now;
                db.PAPER_TEXT.Add(paperText);
                db.SaveChanges();

                for (int i = 0; i < body.ListAuthor.Count; i++)
                {
                    var item = body.ListAuthor[i];
                    model.addAuthorPaperText(item, body.CONFERENCE_ID, paperText.PAPER_ID, i);
                }
                return ResponseSuccess(StringResource.Success);
            }
        }

        [HttpPost]
        [Route("api/UpdatePaperText")]
        public HttpResponseMessage UpdatePaperText([FromBody]PaperTextSubmit body)
        {
            var paper = db.PAPER_TEXT.Find(body.PAPER_ID);
            var person = db.People.Find(body.PERSON_ID);
            var conference = db.CONFERENCEs.Find(body.CONFERENCE_ID);
            var model = new PaperTextModel();
            if (paper == null)
            {
                return ResponseFail(StringResource.Paper_abstract_do_not_exist);
            }
            else if (person == null)
            {
                return ResponseFail(StringResource.Person_do_not_exist);
            }
            else if (conference == null)
            {
                return ResponseFail(StringResource.Conference_do_not_exist);
            }
            else if (!model.checkConferencePaperTextSubmitExpired(body.CONFERENCE_ID))
            {
                return ResponseFail(StringResource.Out_of_time);
            }
            else if (model.getTimesSent(paper) >= 5)
            {
                return ResponseFail(StringResource.The_number_of_submition_after_review_has_out);
            }
            else
            {
                if (model.checkPaperTextReviewed(body.PAPER_ID, body.CONFERENCE_ID, model.getTimesSent(paper)) == false)//Chưa ai review
                {

                    int number = model.getTimesSent(paper);
                    if (number == 1)//Cập nhật lại nhóm 1
                    {
                        paper.PAPER_TEXT_TITLE_1 = body.PAPER_TEXT_TITLE;
                        paper.PAPER_TEXT_TITLE_EN_1 = body.PAPER_TEXT_TITLE_EN;
                        paper.PAPER_TEXT_1 = body.PAPER_TEXT;
                        paper.PAPER_TEXT_EN_1 = body.PAPER_TEXT_EN;
                        paper.PAPER_TEXT_ATTACHED_FILENAME_1 = body.PAPER_TEXT_ATTACHED_FILENAME;
                        paper.NUMBER_OF_PAGES_OF_PAPER_TEXT_1 = body.NUMBER_OF_PAGES_OF_PAPER_TEXT;
                        paper.LAST_REVISED_DATE_1 = DateTime.Now;
                        db.SaveChanges();

                        for (int i = 0; i < body.ListAuthor.Count; i++)
                        {
                            var item = body.ListAuthor[i];
                            if (!model.checkIsAuthor(item.PERSON_ID)) return ResponseFail(StringResource.Account_does_not_author);
                            model.addAuthorPaperText(item, body.CONFERENCE_ID, paper.PAPER_ID, i);
                        }
                        return ResponseSuccess(StringResource.Success);
                    }
                    else if (number == 2)//Cập nhật lại nhóm 2
                    {

                        paper.PAPER_TEXT_TITLE_2 = body.PAPER_TEXT_TITLE;
                        paper.PAPER_TEXT_TITLE_EN_2 = body.PAPER_TEXT_TITLE_EN;
                        paper.PAPER_TEXT_2 = body.PAPER_TEXT;
                        paper.PAPER_TEXT_EN_2 = body.PAPER_TEXT_EN;
                        paper.PAPER_TEXT_ATTACHED_FILENAME_2 = body.PAPER_TEXT_ATTACHED_FILENAME;
                        paper.NUMBER_OF_PAGES_OF_PAPER_TEXT_2 = body.NUMBER_OF_PAGES_OF_PAPER_TEXT;
                        paper.LAST_REVISED_DATE_2 = DateTime.Now;
                        db.SaveChanges();

                        for (int i = 0; i < body.ListAuthor.Count; i++)
                        {
                            var item = body.ListAuthor[i];
                            if (!model.checkIsAuthor(item.PERSON_ID)) return ResponseFail(StringResource.Account_does_not_author);
                            model.addAuthorPaperText(item, body.CONFERENCE_ID, paper.PAPER_ID, i);
                        }
                        return ResponseSuccess(StringResource.Success);
                    }
                    else if (number == 3)//Cập nhật lại nhóm 3
                    {

                        paper.PAPER_TEXT_TITLE_3 = body.PAPER_TEXT_TITLE;
                        paper.PAPER_TEXT_TITLE_EN_3 = body.PAPER_TEXT_TITLE_EN;
                        paper.PAPER_TEXT_3 = body.PAPER_TEXT;
                        paper.PAPER_TEXT_EN_3 = body.PAPER_TEXT_EN;
                        paper.PAPER_TEXT_ATTACHED_FILENAME_3 = body.PAPER_TEXT_ATTACHED_FILENAME;
                        paper.NUMBER_OF_PAGES_OF_PAPER_TEXT_3 = body.NUMBER_OF_PAGES_OF_PAPER_TEXT;
                        paper.LAST_REVISED_DATE_3 = DateTime.Now;
                        db.SaveChanges();

                        for (int i = 0; i < body.ListAuthor.Count; i++)
                        {
                            var item = body.ListAuthor[i];
                            if (!model.checkIsAuthor(item.PERSON_ID)) return ResponseFail(StringResource.Account_does_not_author);
                            model.addAuthorPaperText(item, body.CONFERENCE_ID, paper.PAPER_ID, i);
                        }
                        return ResponseSuccess(StringResource.Success);
                    }
                    else if (number == 4)//Cập nhật lại nhóm 4
                    {
                        paper.PAPER_TEXT_TITLE_4 = body.PAPER_TEXT_TITLE;
                        paper.PAPER_TEXT_TITLE_EN_4 = body.PAPER_TEXT_TITLE_EN;
                        paper.PAPER_TEXT_4 = body.PAPER_TEXT;
                        paper.PAPER_TEXT_EN_4 = body.PAPER_TEXT_EN;
                        paper.PAPER_TEXT_ATTACHED_FILENAME_4 = body.PAPER_TEXT_ATTACHED_FILENAME;
                        paper.NUMBER_OF_PAGES_OF_PAPER_TEXT_4 = body.NUMBER_OF_PAGES_OF_PAPER_TEXT;
                        paper.LAST_REVISED_DATE_4 = DateTime.Now;
                        db.SaveChanges();

                        for (int i = 0; i < body.ListAuthor.Count; i++)
                        {
                            var item = body.ListAuthor[i];
                            if (!model.checkIsAuthor(item.PERSON_ID)) return ResponseFail(StringResource.Account_does_not_author);
                            model.addAuthorPaperText(item, body.CONFERENCE_ID, paper.PAPER_ID, i);
                        }
                        return ResponseSuccess(StringResource.Success);
                    }
                    else if (number == 5)//Cập nhật lại nhóm 5
                    {
                        paper.PAPER_TEXT_TITLE_5 = body.PAPER_TEXT_TITLE;
                        paper.PAPER_TEXT_TITLE_EN_5 = body.PAPER_TEXT_TITLE_EN;
                        paper.PAPER_TEXT_5 = body.PAPER_TEXT;
                        paper.PAPER_TEXT_EN_5 = body.PAPER_TEXT_EN;
                        paper.PAPER_TEXT_ATTACHED_FILENAME_5 = body.PAPER_TEXT_ATTACHED_FILENAME;
                        paper.NUMBER_OF_PAGES_OF_PAPER_TEXT_5 = body.NUMBER_OF_PAGES_OF_PAPER_TEXT;
                        paper.LAST_REVISED_DATE_5 = DateTime.Now;
                        db.SaveChanges();

                        for (int i = 0; i < body.ListAuthor.Count; i++)
                        {
                            var item = body.ListAuthor[i];
                            if (!model.checkIsAuthor(item.PERSON_ID)) return ResponseFail(StringResource.Account_does_not_author);
                            model.addAuthorPaperText(item, body.CONFERENCE_ID, paper.PAPER_ID, i);
                        }
                        return ResponseSuccess(StringResource.Success);
                    }
                    else
                    {
                        return ResponseFail(StringResource.The_number_of_submition_after_review_has_out);
                    }

                }
                else//Đã có người review
                {
                    if (paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT == null)//Chưa được duyệt cuối
                    {
                        return ResponseFail(StringResource.Paper_Text_is_being_reviewed_please_wait_for_results);
                    }
                    else if (paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT == true)
                    {
                        return ResponseFail(StringResource.Paper_Text_accepted);
                    }
                    else//Bài được duyệt cuối
                    {
                        //Thêm nhóm (2 hoặc 3,4,5), phân tự động review lại
                        int number = model.getTimesSent(paper);
                        if (number == 1)//Thêm nhóm 2
                        {
                            paper.PAPER_TEXT_TITLE_2 = body.PAPER_TEXT_TITLE;
                            paper.PAPER_TEXT_TITLE_EN_2 = body.PAPER_TEXT_TITLE_EN;
                            paper.PAPER_TEXT_2 = body.PAPER_TEXT;
                            paper.PAPER_TEXT_EN_2 = body.PAPER_TEXT_EN;
                            paper.PAPER_TEXT_ATTACHED_FILENAME_2 = body.PAPER_TEXT_ATTACHED_FILENAME;
                            paper.NUMBER_OF_PAGES_OF_PAPER_TEXT_2 = body.NUMBER_OF_PAGES_OF_PAPER_TEXT;
                            paper.FIRST_SUBMITTED_DATE_2 = DateTime.Now;
                            paper.LAST_REVISED_DATE_2 = DateTime.Now;
                            paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT = null;
                            paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT_DATE = null;
                            paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT_REVIEWER_PERSON_ID = null;
                            paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT_SCRIPT = null;
                            db.SaveChanges();

                            model.assignedBoardOfReviewerUpdate(paper.PAPER_ID, (Int16)2);
                            model.assignedReviewerUpdate(paper.PAPER_ID, (Int16)2);

                            for (int i = 0; i < body.ListAuthor.Count; i++)
                            {
                                var item = body.ListAuthor[i];
                                if (!model.checkIsAuthor(item.PERSON_ID)) return ResponseFail(StringResource.Account_does_not_author);
                                model.addAuthorPaperText(item, body.CONFERENCE_ID, paper.PAPER_ID, i);
                            }
                            return ResponseSuccess(StringResource.Success);
                        }
                        else if (number == 2)//Thêm nhóm 3
                        {
                            paper.PAPER_TEXT_TITLE_3 = body.PAPER_TEXT_TITLE;
                            paper.PAPER_TEXT_TITLE_EN_3 = body.PAPER_TEXT_TITLE_EN;
                            paper.PAPER_TEXT_3 = body.PAPER_TEXT;
                            paper.PAPER_TEXT_EN_3 = body.PAPER_TEXT_EN;
                            paper.PAPER_TEXT_ATTACHED_FILENAME_3 = body.PAPER_TEXT_ATTACHED_FILENAME;
                            paper.NUMBER_OF_PAGES_OF_PAPER_TEXT_3 = body.NUMBER_OF_PAGES_OF_PAPER_TEXT;
                            paper.FIRST_SUBMITTED_DATE_3 = DateTime.Now;
                            paper.LAST_REVISED_DATE_3 = DateTime.Now;
                            paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT = null;
                            paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT_DATE = null;
                            paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT_REVIEWER_PERSON_ID = null;
                            paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT_SCRIPT = null;
                            db.SaveChanges();

                            model.assignedBoardOfReviewerUpdate(paper.PAPER_ID, (Int16)3);
                            model.assignedReviewerUpdate(paper.PAPER_ID, (Int16)3);

                            for (int i = 0; i < body.ListAuthor.Count; i++)
                            {
                                var item = body.ListAuthor[i];
                                if (!model.checkIsAuthor(item.PERSON_ID)) return ResponseFail(StringResource.Account_does_not_author);
                                model.addAuthorPaperText(item, body.CONFERENCE_ID, paper.PAPER_ID, i);
                            }
                            return ResponseSuccess(StringResource.Success);
                        }
                        else if (number == 3)//Thêm nhóm 4
                        {
                            paper.PAPER_TEXT_TITLE_4 = body.PAPER_TEXT_TITLE;
                            paper.PAPER_TEXT_TITLE_EN_4 = body.PAPER_TEXT_TITLE_EN;
                            paper.PAPER_TEXT_4 = body.PAPER_TEXT;
                            paper.PAPER_TEXT_EN_4 = body.PAPER_TEXT_EN;
                            paper.PAPER_TEXT_ATTACHED_FILENAME_4 = body.PAPER_TEXT_ATTACHED_FILENAME;
                            paper.NUMBER_OF_PAGES_OF_PAPER_TEXT_4 = body.NUMBER_OF_PAGES_OF_PAPER_TEXT;
                            paper.FIRST_SUBMITTED_DATE_4 = DateTime.Now;
                            paper.LAST_REVISED_DATE_4 = DateTime.Now;
                            paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT = null;
                            paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT_DATE = null;
                            paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT_REVIEWER_PERSON_ID = null;
                            paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT_SCRIPT = null;
                            db.SaveChanges();

                            model.assignedBoardOfReviewerUpdate(paper.PAPER_ID, (Int16)4);
                            model.assignedReviewerUpdate(paper.PAPER_ID, (Int16)4);

                            for (int i = 0; i < body.ListAuthor.Count; i++)
                            {
                                var item = body.ListAuthor[i];
                                if (!model.checkIsAuthor(item.PERSON_ID)) return ResponseFail(StringResource.Account_does_not_author);
                                model.addAuthorPaperText(item, body.CONFERENCE_ID, paper.PAPER_ID, i);
                            }
                            return ResponseSuccess(StringResource.Success);
                        }
                        else if (number == 4)//Thêm nhóm 5
                        {
                            paper.PAPER_TEXT_TITLE_5 = body.PAPER_TEXT_TITLE;
                            paper.PAPER_TEXT_TITLE_EN_5 = body.PAPER_TEXT_TITLE_EN;
                            paper.PAPER_TEXT_5 = body.PAPER_TEXT;
                            paper.PAPER_TEXT_EN_5 = body.PAPER_TEXT_EN;
                            paper.PAPER_TEXT_ATTACHED_FILENAME_5 = body.PAPER_TEXT_ATTACHED_FILENAME;
                            paper.NUMBER_OF_PAGES_OF_PAPER_TEXT_5 = body.NUMBER_OF_PAGES_OF_PAPER_TEXT;
                            paper.FIRST_SUBMITTED_DATE_5 = DateTime.Now;
                            paper.LAST_REVISED_DATE_5 = DateTime.Now;
                            paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT = null;
                            paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT_DATE = null;
                            paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT_REVIEWER_PERSON_ID = null;
                            paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT_SCRIPT = null;
                            db.SaveChanges();

                            model.assignedBoardOfReviewerUpdate(paper.PAPER_ID, (Int16)5);
                            model.assignedReviewerUpdate(paper.PAPER_ID, (Int16)5);

                            for (int i = 0; i < body.ListAuthor.Count; i++)
                            {
                                var item = body.ListAuthor[i];
                                if (!model.checkIsAuthor(item.PERSON_ID)) return ResponseFail(StringResource.Account_does_not_author);
                                model.addAuthorPaperText(item, body.CONFERENCE_ID, paper.PAPER_ID, i);
                            }
                            return ResponseSuccess(StringResource.Success);
                        }
                        else
                        {
                            return ResponseFail(StringResource.The_number_of_submition_after_review_has_out);
                        }

                    }
                }
            }

        }

        [HttpPost]
        [Route("api/ListSubmitingHistoryPaperText")]
        public HttpResponseMessage ListSubmitingHistoryPaperText(int paperId)
        {
            var paperText = db.PAPER_TEXT.Find(paperId);
            var paperAbstract = db.PAPER_ABSTRACT.Find(paperId);
            var model = new PaperAbstractModel();
            var myPaperAbstract = model.getMyPaperAbstract(paperAbstract);
            if (paperText == null)
            {
                return ResponseFail(StringResource.Paper_text_do_not_exist);
            }
            else if (paperAbstract == null)
            {
                return ResponseFail(StringResource.Paper_abstract_do_not_exist);
            }
            else
            {
                var listObj = new List<ListPaperTextSubmit>();
                if (!String.IsNullOrEmpty(paperText.PAPER_TEXT_TITLE_1) || !String.IsNullOrEmpty(paperText.PAPER_TEXT_TITLE_EN_1))
                {
                    var listPaperText = new ListPaperTextSubmit();
                    listPaperText.PAPER_TEXT_TITLE = paperText.PAPER_TEXT_TITLE_1;
                    listPaperText.PAPER_TEXT_TITLE_EN = paperText.PAPER_TEXT_TITLE_EN_1;
                    listPaperText.PAPER_TEXT = paperText.PAPER_TEXT_1;
                    listPaperText.PAPER_TEXT_EN = paperText.PAPER_TEXT_EN_1;
                    listPaperText.CONFERENCE_SESSION_TOPIC_ID = myPaperAbstract.CONFERENCE_SESSION_TOPIC_ID;
                    listPaperText.CONFERENCE_SESSION_TOPIC_NAME = myPaperAbstract.CONFERENCE_SESSION_TOPIC_NAME;
                    listPaperText.CONFERENCE_SESSION_TOPIC_NAME_EN = myPaperAbstract.CONFERENCE_SESSION_TOPIC_NAME_EN;
                    listPaperText.TYPE_OF_STUDY_ID = myPaperAbstract.TYPE_OF_STUDY_ID;
                    listPaperText.TYPE_OF_STUDY_NAME = myPaperAbstract.TYPE_OF_STUDY_NAME;
                    listPaperText.TYPE_OF_STUDY_NAME_EN = myPaperAbstract.TYPE_OF_STUDY_NAME_EN;
                    listPaperText.CONFERENCE_PRESENTATION_TYPE_ID = myPaperAbstract.CONFERENCE_PRESENTATION_TYPE_ID;
                    listPaperText.CONFERENCE_PRESENTATION_TYPE_NAME = myPaperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME;
                    listPaperText.CONFERENCE_PRESENTATION_TYPE_NAME_EN = myPaperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_EN;
                    listPaperText.PAPER_TEXT_ATTACHED_FILENAME = paperText.PAPER_TEXT_ATTACHED_FILENAME_1;
                    listPaperText.NUMBER_OF_PAGES_OF_PAPER_TEXT = paperText.NUMBER_OF_PAGES_OF_PAPER_TEXT_1;
                    listPaperText.FIRST_SUBMITTED_DATE = paperText.FIRST_SUBMITTED_DATE_1;
                    listPaperText.LAST_REVISED_DATE = paperText.LAST_REVISED_DATE_1;
                    listObj.Add(listPaperText);
                }
                if (!String.IsNullOrEmpty(paperText.PAPER_TEXT_TITLE_2) || !String.IsNullOrEmpty(paperText.PAPER_TEXT_TITLE_2))
                {
                    var listPaperText = new ListPaperTextSubmit();
                    listPaperText.PAPER_TEXT_TITLE = paperText.PAPER_TEXT_TITLE_2;
                    listPaperText.PAPER_TEXT_TITLE_EN = paperText.PAPER_TEXT_TITLE_EN_2;
                    listPaperText.PAPER_TEXT = paperText.PAPER_TEXT_2;
                    listPaperText.PAPER_TEXT_EN = paperText.PAPER_TEXT_EN_2;
                    listPaperText.CONFERENCE_SESSION_TOPIC_ID = myPaperAbstract.CONFERENCE_SESSION_TOPIC_ID;
                    listPaperText.CONFERENCE_SESSION_TOPIC_NAME = myPaperAbstract.CONFERENCE_SESSION_TOPIC_NAME;
                    listPaperText.CONFERENCE_SESSION_TOPIC_NAME_EN = myPaperAbstract.CONFERENCE_SESSION_TOPIC_NAME_EN;
                    listPaperText.TYPE_OF_STUDY_ID = myPaperAbstract.TYPE_OF_STUDY_ID;
                    listPaperText.TYPE_OF_STUDY_NAME = myPaperAbstract.TYPE_OF_STUDY_NAME;
                    listPaperText.TYPE_OF_STUDY_NAME_EN = myPaperAbstract.TYPE_OF_STUDY_NAME_EN;
                    listPaperText.CONFERENCE_PRESENTATION_TYPE_ID = myPaperAbstract.CONFERENCE_PRESENTATION_TYPE_ID;
                    listPaperText.CONFERENCE_PRESENTATION_TYPE_NAME = myPaperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME;
                    listPaperText.CONFERENCE_PRESENTATION_TYPE_NAME_EN = myPaperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_EN;
                    listPaperText.PAPER_TEXT_ATTACHED_FILENAME = paperText.PAPER_TEXT_ATTACHED_FILENAME_2;
                    listPaperText.NUMBER_OF_PAGES_OF_PAPER_TEXT = paperText.NUMBER_OF_PAGES_OF_PAPER_TEXT_2;
                    listPaperText.FIRST_SUBMITTED_DATE = paperText.FIRST_SUBMITTED_DATE_2;
                    listPaperText.LAST_REVISED_DATE = paperText.LAST_REVISED_DATE_2;
                    listObj.Add(listPaperText);
                }
                if (!String.IsNullOrEmpty(paperText.PAPER_TEXT_TITLE_3) || !String.IsNullOrEmpty(paperText.PAPER_TEXT_TITLE_3))
                {
                    var listPaperText = new ListPaperTextSubmit();
                    listPaperText.PAPER_TEXT_TITLE = paperText.PAPER_TEXT_TITLE_3;
                    listPaperText.PAPER_TEXT_TITLE_EN = paperText.PAPER_TEXT_TITLE_EN_3;
                    listPaperText.PAPER_TEXT = paperText.PAPER_TEXT_3;
                    listPaperText.PAPER_TEXT_EN = paperText.PAPER_TEXT_EN_3;
                    listPaperText.CONFERENCE_SESSION_TOPIC_ID = myPaperAbstract.CONFERENCE_SESSION_TOPIC_ID;
                    listPaperText.CONFERENCE_SESSION_TOPIC_NAME = myPaperAbstract.CONFERENCE_SESSION_TOPIC_NAME;
                    listPaperText.CONFERENCE_SESSION_TOPIC_NAME_EN = myPaperAbstract.CONFERENCE_SESSION_TOPIC_NAME_EN;
                    listPaperText.TYPE_OF_STUDY_ID = myPaperAbstract.TYPE_OF_STUDY_ID;
                    listPaperText.TYPE_OF_STUDY_NAME = myPaperAbstract.TYPE_OF_STUDY_NAME;
                    listPaperText.TYPE_OF_STUDY_NAME_EN = myPaperAbstract.TYPE_OF_STUDY_NAME_EN;
                    listPaperText.CONFERENCE_PRESENTATION_TYPE_ID = myPaperAbstract.CONFERENCE_PRESENTATION_TYPE_ID;
                    listPaperText.CONFERENCE_PRESENTATION_TYPE_NAME = myPaperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME;
                    listPaperText.CONFERENCE_PRESENTATION_TYPE_NAME_EN = myPaperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_EN;
                    listPaperText.PAPER_TEXT_ATTACHED_FILENAME = paperText.PAPER_TEXT_ATTACHED_FILENAME_3;
                    listPaperText.NUMBER_OF_PAGES_OF_PAPER_TEXT = paperText.NUMBER_OF_PAGES_OF_PAPER_TEXT_3;
                    listPaperText.FIRST_SUBMITTED_DATE = paperText.FIRST_SUBMITTED_DATE_3;
                    listPaperText.LAST_REVISED_DATE = paperText.LAST_REVISED_DATE_3;
                    listObj.Add(listPaperText);
                }
                if (!String.IsNullOrEmpty(paperText.PAPER_TEXT_TITLE_4) || !String.IsNullOrEmpty(paperText.PAPER_TEXT_TITLE_4))
                {
                    var listPaperText = new ListPaperTextSubmit();
                    listPaperText.PAPER_TEXT_TITLE = paperText.PAPER_TEXT_TITLE_4;
                    listPaperText.PAPER_TEXT_TITLE_EN = paperText.PAPER_TEXT_TITLE_EN_4;
                    listPaperText.PAPER_TEXT = paperText.PAPER_TEXT_4;
                    listPaperText.PAPER_TEXT_EN = paperText.PAPER_TEXT_EN_4;
                    listPaperText.CONFERENCE_SESSION_TOPIC_ID = myPaperAbstract.CONFERENCE_SESSION_TOPIC_ID;
                    listPaperText.CONFERENCE_SESSION_TOPIC_NAME = myPaperAbstract.CONFERENCE_SESSION_TOPIC_NAME;
                    listPaperText.CONFERENCE_SESSION_TOPIC_NAME_EN = myPaperAbstract.CONFERENCE_SESSION_TOPIC_NAME_EN;
                    listPaperText.TYPE_OF_STUDY_ID = myPaperAbstract.TYPE_OF_STUDY_ID;
                    listPaperText.TYPE_OF_STUDY_NAME = myPaperAbstract.TYPE_OF_STUDY_NAME;
                    listPaperText.TYPE_OF_STUDY_NAME_EN = myPaperAbstract.TYPE_OF_STUDY_NAME_EN;
                    listPaperText.CONFERENCE_PRESENTATION_TYPE_ID = myPaperAbstract.CONFERENCE_PRESENTATION_TYPE_ID;
                    listPaperText.CONFERENCE_PRESENTATION_TYPE_NAME = myPaperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME;
                    listPaperText.CONFERENCE_PRESENTATION_TYPE_NAME_EN = myPaperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_EN;
                    listPaperText.PAPER_TEXT_ATTACHED_FILENAME = paperText.PAPER_TEXT_ATTACHED_FILENAME_4;
                    listPaperText.NUMBER_OF_PAGES_OF_PAPER_TEXT = paperText.NUMBER_OF_PAGES_OF_PAPER_TEXT_4;
                    listPaperText.FIRST_SUBMITTED_DATE = paperText.FIRST_SUBMITTED_DATE_4;
                    listPaperText.LAST_REVISED_DATE = paperText.LAST_REVISED_DATE_4;
                    listObj.Add(listPaperText);
                }
                if (!String.IsNullOrEmpty(paperText.PAPER_TEXT_TITLE_5) || !String.IsNullOrEmpty(paperText.PAPER_TEXT_TITLE_5))
                {
                    var listPaperText = new ListPaperTextSubmit();
                    listPaperText.PAPER_TEXT_TITLE = paperText.PAPER_TEXT_TITLE_5;
                    listPaperText.PAPER_TEXT_TITLE_EN = paperText.PAPER_TEXT_TITLE_EN_5;
                    listPaperText.PAPER_TEXT = paperText.PAPER_TEXT_5;
                    listPaperText.PAPER_TEXT_EN = paperText.PAPER_TEXT_EN_5;
                    listPaperText.CONFERENCE_SESSION_TOPIC_ID = myPaperAbstract.CONFERENCE_SESSION_TOPIC_ID;
                    listPaperText.CONFERENCE_SESSION_TOPIC_NAME = myPaperAbstract.CONFERENCE_SESSION_TOPIC_NAME;
                    listPaperText.CONFERENCE_SESSION_TOPIC_NAME_EN = myPaperAbstract.CONFERENCE_SESSION_TOPIC_NAME_EN;
                    listPaperText.TYPE_OF_STUDY_ID = myPaperAbstract.TYPE_OF_STUDY_ID;
                    listPaperText.TYPE_OF_STUDY_NAME = myPaperAbstract.TYPE_OF_STUDY_NAME;
                    listPaperText.TYPE_OF_STUDY_NAME_EN = myPaperAbstract.TYPE_OF_STUDY_NAME_EN;
                    listPaperText.CONFERENCE_PRESENTATION_TYPE_ID = myPaperAbstract.CONFERENCE_PRESENTATION_TYPE_ID;
                    listPaperText.CONFERENCE_PRESENTATION_TYPE_NAME = myPaperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME;
                    listPaperText.CONFERENCE_PRESENTATION_TYPE_NAME_EN = myPaperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_EN;
                    listPaperText.PAPER_TEXT_ATTACHED_FILENAME = paperText.PAPER_TEXT_ATTACHED_FILENAME_5;
                    listPaperText.NUMBER_OF_PAGES_OF_PAPER_TEXT = paperText.NUMBER_OF_PAGES_OF_PAPER_TEXT_5;
                    listPaperText.FIRST_SUBMITTED_DATE = paperText.FIRST_SUBMITTED_DATE_5;
                    listPaperText.LAST_REVISED_DATE = paperText.LAST_REVISED_DATE_5;
                    listObj.Add(listPaperText);
                }
                return ResponseSuccess(StringResource.Success, listObj);
            }
        }

        [HttpPost]
        [Route("api/ListReviewingHistoryPaperText")]
        public HttpResponseMessage ListReviewingHistoryPaperText(int paperId, int conferenceId, int reviewTime = 1)
        {
            var paper = db.PAPER_TEXT.Find(paperId);
            var model = new PaperTextModel();
            if (paper == null)
            {
                return ResponseFail(StringResource.Paper_text_do_not_exist);
            }
            else
            {
                var paperText = model.getMyPaperText(paperId, reviewTime);
                var listReviewing = (from r in db.REVIEWER_PAPER_TEXT_RELATIONSHIP
                                     join b in db.CONFERENCE_BOARD_OF_REVIEW on r.CONFERENCE_BOARD_OF_REVIEW_ID equals b.CONFERENCE_BOARD_OF_REVIEW_ID
                                     join p in db.People on r.PERSON_ID equals p.PERSON_ID
                                     where r.PAPER_ID == paperId && r.CONFERENCE_ID == conferenceId && r.PAPER_TEXT_SUBMISSION_DEADLINE_ORDER_NUMBER == reviewTime && r.REVIEWED_DATE != null
                                     select new { r, b, p })
                                     .AsEnumerable()
                                    .Select(x => new
                                    {
                                        x.r.PERSON_ID,
                                        x.r.CONFERENCE_BOARD_OF_REVIEW_ID,
                                        x.r.CONFERENCE_ID,
                                        x.r.PAPER_ID,
                                        REVIEW_CURRENT_FIRST_NAME = x.p.CURRENT_FIRST_NAME,
                                        REVIEW_CURRENT_MIDDLE_NAME = x.p.CURRENT_MIDDLE_NAME,
                                        REVIEW_CURRENT_LAST_NAME = x.p.CURRENT_LAST_NAME,
                                        REVIEW_FULL_NAME = Utils.GetFullName(x.p.CURRENT_FIRST_NAME, x.p.CURRENT_MIDDLE_NAME, x.p.CURRENT_LAST_NAME),
                                        paperText.PAPER_TEXT_TITLE,
                                        paperText.PAPER_TEXT_TITLE_EN,
                                        paperText.FIRST_SUBMITTED_DATE,
                                        paperText.LAST_REVISED_DATE,
                                        x.b.CONFERENCE_BOARD_OF_REVIEW_NAME,
                                        x.b.CONFERENCE_BOARD_OF_REVIEW_NAME_EN,
                                        x.r.PAPER_TEXT_SUBMISSION_DEADLINE_ORDER_NUMBER,
                                        x.r.REVIEWED_DATE,
                                        x.r.PROPOSED_REVISED_CONFERENCE_SESSION_TOPIC_ID,
                                        x.r.PROPOSED_REVISED_CONFERENCE_SESSION_TOPIC_NAME,
                                        x.r.PROPOSED_REVISED_CONFERENCE_SESSION_TOPIC_NAME_EN,
                                        x.r.PROPOSED_TYPE_OF_STUDY_ID,
                                        x.r.PROPOSED_TYPE_OF_STUDY_NAME,
                                        x.r.PROPOSED_TYPE_OF_STUDY_NAME_EN,
                                        x.r.PROPOSED_CONFERENCE_PRESENTATION_TYPE_ID,
                                        x.r.PROPOSED_CONFERENCE_PRESENTATION_TYPE_NAME,
                                        x.r.PROPOSED_CONFERENCE_PRESENTATION_TYPE_NAME_EN,
                                        x.r.PAPER_TEXT_REVIEW_RATING_POINT,
                                        x.r.SIGNIFICANT_REVISION_OR_MINIMAL_REVISION_OR_REVISION_NEEDED_OR_NO_REVISION_NEEDED,
                                        x.r.REVIEW_TEXT,
                                        x.r.REVIEW_TEXT_EN,
                                        x.r.APPROVAL_OR_REJECTION_OF_PAPER_TEXT,
                                        x.r.APPROVAL_OR_REJECTION_OF_PAPER_TEXT_DATE,
                                    }).Distinct().OrderByDescending(x => x.REVIEWED_DATE);
                return ResponseSuccess(StringResource.Success, listReviewing);
            }
        }

        [HttpPost]
        [Route("api/ListFinalReviewingHistoryPaperText")]
        public HttpResponseMessage ListFinalReviewingHistoryPaperText(int paperId, int conferenceId, int reviewTime = 1)
        {
            var paper = db.PAPER_TEXT.Find(paperId);
            if (paper == null)
            {
                return ResponseFail(StringResource.Paper_text_do_not_exist);
            }
            else
            {
                var listReviewing = db.PAPER_REVIEW_SUMUP_BY_CONFERENCE_BOARD_OF_REVIEW.Where(x => x.PAPER_ID == paperId && x.CONFERENCE_ID == conferenceId && x.PAPER_TEXT_SUBMISSION_DEADLINE_ORDER_NUMBER == reviewTime && x.FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_ID != null)
               .Select(x => new
               {
                   x.CONFERENCE_BOARD_OF_REVIEW_ID,
                   x.CONFERENCE_ID,
                   x.PAPER_ID,
                   x.PAPER_TEXT_SUBMISSION_DEADLINE_ORDER_NUMBER,
                   x.FIRST_SUBMITTED_DATE,
                   x.LAST_REVISED_DATE,
                   x.FIRST_REVIEWED_DATE,
                   x.FINAL_REVIEWED_DATE,
                   x.WITHDRAWN,
                   x.WITHDRAWN_DATE,
                   x.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT,
                   x.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT_DATE,
                   x.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT_REVIEWER_PERSON_ID,
                   x.FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_ID,
                   x.FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_NAME,
                   x.FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_NAME_EN,
                   x.FINAL_APPROVED_FULL_PAPER_OR_WORK_IN_PROGRESS,
                   x.FINAL_APPROVED_TYPE_OF_STUDY_ID,
                   x.FINAL_APPROVED_TYPE_OF_STUDY_NAME,
                   x.FINAL_APPROVED_TYPE_OF_STUDY_NAME_EN,
                   x.FINAL_APPROVED_FOR_PRESENTATION,
                   x.FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_ID,
                   x.FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_NAME,
                   x.FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_NAME_EN,

               }).OrderBy(x => x.PAPER_TEXT_SUBMISSION_DEADLINE_ORDER_NUMBER);
                return ResponseSuccess(StringResource.Success, listReviewing);
            }
        }

        [HttpPost]
        [Route("api/CheckSubmitDeadlinePaperText")]
        public HttpResponseMessage CheckSubmitDeadlinePaperText(int conferenceId)
        {
            var model = new PaperTextModel();
            var result = model.checkConferencePaperTextSubmitExpired(conferenceId);
            if (result == true)
            {
                return ResponseSuccess(StringResource.Success);
            }
            return ResponseFail(StringResource.Expired_submit_paper_text);
        }

        [HttpPost]
        [Route("api/CheckPaperTextSubmitionNumber")]
        public HttpResponseMessage CheckPaperTextSubmitionNumber(int paperId)
        {
            var model = new PaperTextModel();
            var paperText = db.PAPER_TEXT.Find(paperId);
            if (paperText == null)
            {
                return ResponseFail(StringResource.Paper_text_do_not_exist);
            }
            else
            {
                var result = model.getTimesSent(paperText);
                if (paperText.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT != null)
                {
                    if (result >= 5)
                    {
                        return ResponseFail(StringResource.The_number_of_submition_after_review_has_out);
                    }
                }
                return ResponseSuccess(StringResource.Success);
            }
        }
    }

    public class FormSubmitPaperText
    {
        public int NUMBER_PAPER_TEXT_DEADLINE { get; set; }
        public DateTime? PAPER_TEXT_DEADLINE { get; set; }
        public object ListSessionTopic { get; set; }
        public object ListTypeOfStudy { get; set; }
        public object ListPresentationType { get; set; }
    }

    public class PaperTextSubmit
    {
        public int PAPER_ID { get; set; }
        public int PERSON_ID { get; set; }
        public int CONFERENCE_ID { get; set; }
        public string PAPER_TEXT_TITLE { get; set; }
        public string PAPER_TEXT_TITLE_EN { get; set; }
        public string PAPER_TEXT { get; set; }
        public string PAPER_TEXT_EN { get; set; }
        public string PAPER_TEXT_ATTACHED_FILENAME { get; set; }
        public short? NUMBER_OF_PAGES_OF_PAPER_TEXT { get; set; }
        public List<Author> ListAuthor { get; set; }
    }

    public class ListPaperTextSubmit
    {
        public string PAPER_TEXT_TITLE { get; set; }
        public string PAPER_TEXT_TITLE_EN { get; set; }
        public string PAPER_TEXT { get; set; }
        public string PAPER_TEXT_EN { get; set; }
        public decimal? CONFERENCE_SESSION_TOPIC_ID { get; set; }
        public string CONFERENCE_SESSION_TOPIC_NAME { get; set; }
        public string CONFERENCE_SESSION_TOPIC_NAME_EN { get; set; }
        public decimal? CONFERENCE_PRESENTATION_TYPE_ID { get; set; }
        public string CONFERENCE_PRESENTATION_TYPE_NAME { get; set; }
        public string CONFERENCE_PRESENTATION_TYPE_NAME_EN { get; set; }
        public decimal? TYPE_OF_STUDY_ID { get; set; }
        public string TYPE_OF_STUDY_NAME { get; set; }
        public string TYPE_OF_STUDY_NAME_EN { get; set; }
        public string PAPER_TEXT_ATTACHED_FILENAME { get; set; }
        public short? NUMBER_OF_PAGES_OF_PAPER_TEXT { get; set; }
        public DateTime? FIRST_SUBMITTED_DATE { get; set; }
        public DateTime? LAST_REVISED_DATE { get; set; }
    }
}
