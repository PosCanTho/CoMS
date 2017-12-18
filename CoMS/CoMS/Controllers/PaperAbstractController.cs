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
    public class PaperAbstractController : BaseController
    {
        [HttpPost]
        [Route("api/ListPaperAbstract")]
        public HttpResponseMessage ListPaperAbstract(int personId, int conferenceId)
        {
            var model = new PaperAbstractModel();
            return ResponseSuccess(StringResource.Success, model.getListPaperAbstract(personId, conferenceId));
        }

        [HttpPost]
        [Route("api/GetPaperAbstract")]
        public HttpResponseMessage GetPaperPaperAbstract(int paperId)
        {
            var paper = db.PAPER_ABSTRACT.Find(paperId);
            var model = new PaperAbstractModel();
            if (paper == null)
            {
                return ResponseFail(StringResource.Paper_text_do_not_exist);
            }
            else
            {
                var paperAbstract = model.getMyPaperAbstract(paper);
                return ResponseSuccess(StringResource.Success, paperAbstract);
            }
        }


        [HttpPost]
        [Route("api/GetListAuthorOfPaperAbstract")]
        public HttpResponseMessage GetListAuthorOfPaperAbstract(int paperId)
        {
            var paper = db.PAPER_ABSTRACT.Find(paperId);
            var model = new PaperAbstractModel();
            if (paper == null)
            {
                return ResponseFail(StringResource.Paper_text_do_not_exist);
            }
            else
            {
                var listAuthor = (from a in db.AUTHOR_PAPER_ABSTRACT_RELATIONSHIP
                                  join au in db.AUTHORs on a.PERSON_ID equals au.PERSON_ID
                                  where a.PAPER_ID == paperId && au.CONFERENCE_ID == a.CONFERENCE_ID
                                  select new { a, au })
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
                                     FULL_NAME = Utils.GetFullName(x.au.CURRENT_FIRST_NAME, x.au.CURRENT_MIDDLE_NAME, x.au.CURRENT_LAST_NAME)
                                 }).Distinct();
                return ResponseSuccess(StringResource.Success, listAuthor);
            }
        }

        [HttpPost]
        [Route("api/GetFormSubmitPaperAbstract")]
        public HttpResponseMessage GetFormSubmitPaperAbstract(int conferenceId)
        {
            var conference = db.CONFERENCEs.Find(conferenceId);
            var form = new FormSubmitPaperAbstract();
            if (DateTime.Now <= conference.PAPER_ABSTRACT_DEADLINE_1)
            {
                form.NUMBER_PAPER_ABSTRACT_DEADLINE = 1;
                form.PAPER_ABSTRACT_DEADLINE = conference.PAPER_ABSTRACT_DEADLINE_1;
            }
            else if (DateTime.Now <= conference.PAPER_ABSTRACT_DEADLINE_2)
            {
                form.NUMBER_PAPER_ABSTRACT_DEADLINE = 2;
                form.PAPER_ABSTRACT_DEADLINE = conference.PAPER_ABSTRACT_DEADLINE_2;
            }
            else if (DateTime.Now <= conference.PAPER_ABSTRACT_DEADLINE_3)
            {
                form.NUMBER_PAPER_ABSTRACT_DEADLINE = 3;
                form.PAPER_ABSTRACT_DEADLINE = conference.PAPER_ABSTRACT_DEADLINE_3;
            }
            else if (DateTime.Now <= conference.PAPER_ABSTRACT_DEADLINE_4)
            {
                form.NUMBER_PAPER_ABSTRACT_DEADLINE = 4;
                form.PAPER_ABSTRACT_DEADLINE = conference.PAPER_ABSTRACT_DEADLINE_4;
            }
            else if (DateTime.Now <= conference.PAPER_ABSTRACT_DEADLINE_5)
            {
                form.NUMBER_PAPER_ABSTRACT_DEADLINE = 5;
                form.PAPER_ABSTRACT_DEADLINE = conference.PAPER_ABSTRACT_DEADLINE_5;
            }
            else
            {
                form.NUMBER_PAPER_ABSTRACT_DEADLINE = -1;
                form.PAPER_ABSTRACT_DEADLINE = DateTime.Now;
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
        [Route("api/SearchAuthor")]
        public HttpResponseMessage SearchAuthor([FromBody]Search body)
        {
            string searchString = body.SEARCH_STRING;
            var result = (from a in db.AUTHORs
                          join ac in db.ACCOUNTs on a.PERSON_ID equals ac.PERSON_ID
                          select new { a, ac })
                         .AsEnumerable()
                         .Where(x => x.ac.CURRENT_EMAIL.Contains(searchString) || x.ac.CURRENT_EMAIL.ToLower().Contains(searchString.ToLower()))
                         .Select(x => new
                         {
                             x.ac.PERSON_ID,
                             FULL_NAME = Utils.GetFullName(x.ac.CURRENT_FIRST_NAME, x.ac.CURRENT_MIDDLE_NAME, x.ac.CURRENT_LAST_NAME),
                             x.ac.CURRENT_FIRST_NAME,
                             x.ac.CURRENT_MIDDLE_NAME,
                             x.ac.CURRENT_LAST_NAME,
                             x.ac.UserName,
                             x.ac.CURRENT_EMAIL,
                             x.ac.CURRENT_HOME_ORGANIZATION_ID,
                             x.ac.CURRENT_HOME_ORGANIZATION_NAME,
                             x.ac.CURRENT_HOME_ORGANIZATION_NAME_EN
                         })
                         .Distinct();
            return ResponseSuccess(StringResource.Success, result);
        }

        [HttpPost]
        [Route("api/SearchOrganization")]
        public HttpResponseMessage SearchOrganization([FromBody]Search body)
        {
            string searchString = body.SEARCH_STRING;
            var result = db.ORGANIZATIONs.Where(x => x.ORGANIZATION_NAME.Contains(searchString) || x.ORGANIZATION_NAME_EN.Contains(searchString) || x.ORGANIZATION_NAME.ToLower().Contains(searchString.ToLower()) || x.ORGANIZATION_NAME_EN.ToLower().Contains(searchString.ToLower()))
                .Select(x => new
                {
                    x.ORGANIZATION_ID,
                    x.ORGANIZATION_NAME,
                    x.ORGANIZATION_NAME_EN
                }).Distinct();
            return ResponseSuccess(StringResource.Success, result);
        }

        [HttpPost]
        [Route("api/WithDrawPaperAbstract")]
        public HttpResponseMessage WithDrawPaperAbstract([FromBody]WithDrawForm body)
        {
            var paper = db.PAPER_ABSTRACT.Find(body.PAPER_ID);
            if (paper == null)
            {
                return ResponseFail(StringResource.Not_found_paper_abstract);
            }
            else
            {
                paper.PAPER_ABSTRACT_WITHDRAWN = true;
                paper.PAPER_ABSTRACT_WITHDRAWN_DATE = DateTime.Now;
                paper.PAPER_ABSTRACT_WITHDRAWN_NOTE = body.NOTE;
                db.SaveChanges();
                return ResponseSuccess(StringResource.Success);
            }
        }

        [HttpPost]
        [Route("api/RemoveAuthorOfPaperAbstract")]
        public HttpResponseMessage RemoveAuthorOfPaperAbstract(int paperId, int personId)
        {
            var paper = db.PAPER_ABSTRACT.Find(paperId);
            var person = db.People.Find(personId);
            if (paper == null)
            {
                return ResponseFail(StringResource.Paper_abstract_do_not_exist);
            }
            else if (person == null)
            {
                return ResponseFail(StringResource.Person_do_not_exist);
            }
            else
            {
                var author = db.AUTHOR_PAPER_ABSTRACT_RELATIONSHIP.Where(x => x.PAPER_ID == paperId && x.PERSON_ID == personId);
                db.AUTHOR_PAPER_ABSTRACT_RELATIONSHIP.RemoveRange(author);
                db.SaveChanges();
                return ResponseSuccess(StringResource.Success);
            }
        }

        [HttpPost]
        [Route("api/SubmitPaperAbstract")]
        public HttpResponseMessage SubmitPaperAbstract([FromBody]PaperAbstractSubmit body)
        {
            var person = db.People.Find(body.PERSON_ID);
            var conference = db.CONFERENCEs.Find(body.CONFERENCE_ID);
            var topic = db.CONFERENCE_SESSION_TOPIC.Find(body.CONFERENCE_SESSION_TOPIC_ID);
            var typeOfStudy = db.TYPE_OF_STUDY.Find(body.TYPE_OF_STUDY_ID);
            var presentationType = db.CONFERENCE_PRESENTATION_TYPE.Find(body.CONFERENCE_PRESENTATION_TYPE_ID);
            var model = new PaperAbstractModel();
            if (person == null)
            {
                return ResponseFail(StringResource.Person_do_not_exist);
            }
            else if (conference == null)
            {
                return ResponseFail(StringResource.Conference_do_not_exist);
            }
            else if (topic == null)
            {
                return ResponseFail(StringResource.Conference_session_topic_do_not_exist);
            }
            else if (typeOfStudy == null)
            {
                return ResponseFail(StringResource.Type_of_study_do_not_exist);
            }
            else if (presentationType == null)
            {
                return ResponseFail(StringResource.Conference_presentation_type_do_not_exist);
            }
            else if (!model.checkConferencePaperAbstractSubmitExpired(body.CONFERENCE_ID))
            {
                return ResponseFail(StringResource.Out_of_time);
            }
            else
            {
                var paperAbstact = new PAPER_ABSTRACT();
                var lastPaper = db.PAPER_ABSTRACT.ToList();
                if (lastPaper.Count > 0)
                {
                    paperAbstact.PAPER_ID = lastPaper.Last().PAPER_ID + 1;
                }
                else
                {
                    paperAbstact.PAPER_ID = 1;
                }
                paperAbstact.PAPER_NUMBER_OR_CODE = "PA" + paperAbstact.PAPER_ID;
                paperAbstact.PAPER_ABSTRACT_TITLE_1 = body.PAPER_ABSTRACT_TITLE;
                paperAbstact.PAPER_ABSTRACT_TITLE_EN_1 = body.PAPER_ABSTRACT_TITLE_EN;
                paperAbstact.CONFERENCE_SESSION_TOPIC_ID_1 = topic.CONFERENCE_SESSION_TOPIC_ID;
                paperAbstact.CONFERENCE_SESSION_TOPIC_NAME_1 = topic.CONFERENCE_SESSION_TOPIC_NAME;
                paperAbstact.CONFERENCE_SESSION_TOPIC_NAME_EN_1 = topic.CONFERENCE_SESSION_TOPIC_NAME_EN;
                paperAbstact.PAPER_ABSTRACT_TEXT_1 = body.PAPER_ABSTRACT_TEXT;
                paperAbstact.PAPER_ABSTRACT_TEXT_EN_1 = body.PAPER_ABSTRACT_TEXT_EN;
                paperAbstact.PAPER_ABSTRACT_ATTACHED_FILENAME_1 = body.PAPER_ABSTRACT_ATTACHED_FILENAME;
                paperAbstact.WORD_COUNT_OF_PAPER_ABSTRACT_1 = body.WORD_COUNT_OF_PAPER_ABSTRACT;
                paperAbstact.KEYWORDS_1 = body.KEYWORDS;
                paperAbstact.FULL_PAPER_OR_WORK_IN_PROGRESS_1 = body.FULL_PAPER_OR_WORK_IN_PROGRESS;
                paperAbstact.TYPE_OF_STUDY_ID_1 = typeOfStudy.TYPE_OF_STUDY_ID;
                paperAbstact.TYPE_OF_STUDY_NAME_1 = typeOfStudy.TYPE_OF_STUDY_NAME;
                paperAbstact.TYPE_OF_STUDY_NAME_EN_1 = typeOfStudy.TYPE_OF_STUDY_NAME_EN;
                paperAbstact.CONFERENCE_PRESENTATION_TYPE_ID_1 = presentationType.CONFERENCE_PRESENTATION_TYPE_ID;
                paperAbstact.CONFERENCE_PRESENTATION_TYPE_NAME_1 = presentationType.CONFERENCE_PRESENTATION_TYPE_NAME;
                paperAbstact.CONFERENCE_PRESENTATION_TYPE_NAME_EN_1 = presentationType.CONFERENCE_PRESENTATION_TYPE_NAME_EN;
                paperAbstact.FIRST_SUBMITTED_DATE_1 = DateTime.Now;
                paperAbstact.LAST_REVISED_DATE_1 = DateTime.Now;
                db.PAPER_ABSTRACT.Add(paperAbstact);
                db.SaveChanges();

                for (int i = 0; i < body.ListAuthor.Count; i++)
                {
                    var item = body.ListAuthor[i];
                    if (!model.checkIsAuthor(item.PERSON_ID)) return ResponseFail(StringResource.Account_does_not_author);
                    model.addAuthorPaperAbstract(item, body.CONFERENCE_ID, paperAbstact.PAPER_ID, i);
                }
                return ResponseSuccess(StringResource.Success);
            }
        }

        [HttpPost]
        [Route("api/UpdatePaperAbstract")]
        public HttpResponseMessage UpdatePaperAbstract([FromBody]PaperAbstractSubmit body)
        {
            var paper = db.PAPER_ABSTRACT.Find(body.PAPER_ID);
            var person = db.People.Find(body.PERSON_ID);
            var conference = db.CONFERENCEs.Find(body.CONFERENCE_ID);
            var topic = db.CONFERENCE_SESSION_TOPIC.Find(body.CONFERENCE_SESSION_TOPIC_ID);
            var typeOfStudy = db.TYPE_OF_STUDY.Find(body.TYPE_OF_STUDY_ID);
            var presentationType = db.CONFERENCE_PRESENTATION_TYPE.Find(body.CONFERENCE_PRESENTATION_TYPE_ID);
            var model = new PaperAbstractModel();
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
            else if (topic == null)
            {
                return ResponseFail(StringResource.Conference_session_topic_do_not_exist);
            }
            else if (typeOfStudy == null)
            {
                return ResponseFail(StringResource.Type_of_study_do_not_exist);
            }
            else if (presentationType == null)
            {
                return ResponseFail(StringResource.Conference_presentation_type_do_not_exist);
            }
            else if (!model.checkConferencePaperAbstractSubmitExpired(body.CONFERENCE_ID))
            {
                return ResponseFail(StringResource.Out_of_time);
            }
            else if (model.getTimesSent(paper) >= 5)
            {
                return ResponseFail(StringResource.The_number_of_submition_after_review_has_out);
            }
            else
            {
                if (model.checkPaperAbstractReviewed(body.PAPER_ID, body.CONFERENCE_ID, model.getTimesSent(paper)) == false)//Chưa ai review
                {

                    int number = model.getTimesSent(paper);
                    if (number == 1)//Cập nhật lại nhóm 1
                    {
                        paper.PAPER_NUMBER_OR_CODE = "PA" + paper.PAPER_ID;
                        paper.PAPER_ABSTRACT_TITLE_1 = body.PAPER_ABSTRACT_TITLE;
                        paper.PAPER_ABSTRACT_TITLE_EN_1 = body.PAPER_ABSTRACT_TITLE_EN;
                        paper.CONFERENCE_SESSION_TOPIC_ID_1 = topic.CONFERENCE_SESSION_TOPIC_ID;
                        paper.CONFERENCE_SESSION_TOPIC_NAME_1 = topic.CONFERENCE_SESSION_TOPIC_NAME;
                        paper.CONFERENCE_SESSION_TOPIC_NAME_EN_1 = topic.CONFERENCE_SESSION_TOPIC_NAME_EN;
                        paper.PAPER_ABSTRACT_TEXT_1 = body.PAPER_ABSTRACT_TEXT;
                        paper.PAPER_ABSTRACT_TEXT_EN_1 = body.PAPER_ABSTRACT_TEXT_EN;
                        paper.PAPER_ABSTRACT_ATTACHED_FILENAME_1 = body.PAPER_ABSTRACT_ATTACHED_FILENAME;
                        paper.WORD_COUNT_OF_PAPER_ABSTRACT_1 = body.WORD_COUNT_OF_PAPER_ABSTRACT;
                        paper.KEYWORDS_1 = body.KEYWORDS;
                        paper.FULL_PAPER_OR_WORK_IN_PROGRESS_1 = body.FULL_PAPER_OR_WORK_IN_PROGRESS;
                        paper.TYPE_OF_STUDY_ID_1 = typeOfStudy.TYPE_OF_STUDY_ID;
                        paper.TYPE_OF_STUDY_NAME_1 = typeOfStudy.TYPE_OF_STUDY_NAME;
                        paper.TYPE_OF_STUDY_NAME_EN_1 = typeOfStudy.TYPE_OF_STUDY_NAME_EN;
                        paper.CONFERENCE_PRESENTATION_TYPE_ID_1 = presentationType.CONFERENCE_PRESENTATION_TYPE_ID;
                        paper.CONFERENCE_PRESENTATION_TYPE_NAME_1 = presentationType.CONFERENCE_PRESENTATION_TYPE_NAME;
                        paper.CONFERENCE_PRESENTATION_TYPE_NAME_EN_1 = presentationType.CONFERENCE_PRESENTATION_TYPE_NAME_EN;
                        paper.LAST_REVISED_DATE_1 = DateTime.Now;
                        db.SaveChanges();

                        for (int i = 0; i < body.ListAuthor.Count; i++)
                        {
                            var item = body.ListAuthor[i];
                            if (!model.checkIsAuthor(item.PERSON_ID)) return ResponseFail(StringResource.Account_does_not_author);
                            model.addAuthorPaperAbstract(item, body.CONFERENCE_ID, paper.PAPER_ID, i);
                        }
                        return ResponseSuccess(StringResource.Success);
                    }
                    else if (number == 2)//Cập nhật lại nhóm 2
                    {
                        paper.PAPER_ABSTRACT_TITLE_2 = body.PAPER_ABSTRACT_TITLE;
                        paper.PAPER_ABSTRACT_TITLE_EN_2 = body.PAPER_ABSTRACT_TITLE_EN;
                        paper.CONFERENCE_SESSION_TOPIC_ID_2 = topic.CONFERENCE_SESSION_TOPIC_ID;
                        paper.CONFERENCE_SESSION_TOPIC_NAME_2 = topic.CONFERENCE_SESSION_TOPIC_NAME;
                        paper.CONFERENCE_SESSION_TOPIC_NAME_EN_2 = topic.CONFERENCE_SESSION_TOPIC_NAME_EN;
                        paper.PAPER_ABSTRACT_TEXT_2 = body.PAPER_ABSTRACT_TEXT;
                        paper.PAPER_ABSTRACT_TEXT_EN_2 = body.PAPER_ABSTRACT_TEXT_EN;
                        paper.PAPER_ABSTRACT_ATTACHED_FILENAME_2 = body.PAPER_ABSTRACT_ATTACHED_FILENAME;
                        paper.WORD_COUNT_OF_PAPER_ABSTRACT_2 = body.WORD_COUNT_OF_PAPER_ABSTRACT;
                        paper.KEYWORDS_2 = body.KEYWORDS;
                        paper.FULL_PAPER_OR_WORK_IN_PROGRESS_2 = body.FULL_PAPER_OR_WORK_IN_PROGRESS;
                        paper.TYPE_OF_STUDY_ID_2 = typeOfStudy.TYPE_OF_STUDY_ID;
                        paper.TYPE_OF_STUDY_NAME_2 = typeOfStudy.TYPE_OF_STUDY_NAME;
                        paper.TYPE_OF_STUDY_NAME_EN_2 = typeOfStudy.TYPE_OF_STUDY_NAME_EN;
                        paper.CONFERENCE_PRESENTATION_TYPE_ID_2 = presentationType.CONFERENCE_PRESENTATION_TYPE_ID;
                        paper.CONFERENCE_PRESENTATION_TYPE_NAME_2 = presentationType.CONFERENCE_PRESENTATION_TYPE_NAME;
                        paper.CONFERENCE_PRESENTATION_TYPE_NAME_EN_2 = presentationType.CONFERENCE_PRESENTATION_TYPE_NAME_EN;
                        paper.LAST_REVISED_DATE_2 = DateTime.Now;
                        db.SaveChanges();

                        for (int i = 0; i < body.ListAuthor.Count; i++)
                        {
                            var item = body.ListAuthor[i];
                            if (!model.checkIsAuthor(item.PERSON_ID)) return ResponseFail(StringResource.Account_does_not_author);
                            model.addAuthorPaperAbstract(item, body.CONFERENCE_ID, paper.PAPER_ID, i);
                        }
                        return ResponseSuccess(StringResource.Success);
                    }
                    else if (number == 3)//Cập nhật lại nhóm 3
                    {
                        paper.PAPER_ABSTRACT_TITLE_3 = body.PAPER_ABSTRACT_TITLE;
                        paper.PAPER_ABSTRACT_TITLE_EN_3 = body.PAPER_ABSTRACT_TITLE_EN;
                        paper.CONFERENCE_SESSION_TOPIC_ID_3 = topic.CONFERENCE_SESSION_TOPIC_ID;
                        paper.CONFERENCE_SESSION_TOPIC_NAME_3 = topic.CONFERENCE_SESSION_TOPIC_NAME;
                        paper.CONFERENCE_SESSION_TOPIC_NAME_EN_3 = topic.CONFERENCE_SESSION_TOPIC_NAME_EN;
                        paper.PAPER_ABSTRACT_TEXT_3 = body.PAPER_ABSTRACT_TEXT;
                        paper.PAPER_ABSTRACT_TEXT_EN_3 = body.PAPER_ABSTRACT_TEXT_EN;
                        paper.PAPER_ABSTRACT_ATTACHED_FILENAME_3 = body.PAPER_ABSTRACT_ATTACHED_FILENAME;
                        paper.WORD_COUNT_OF_PAPER_ABSTRACT_3 = body.WORD_COUNT_OF_PAPER_ABSTRACT;
                        paper.KEYWORDS_3 = body.KEYWORDS;
                        paper.FULL_PAPER_OR_WORK_IN_PROGRESS_3 = body.FULL_PAPER_OR_WORK_IN_PROGRESS;
                        paper.TYPE_OF_STUDY_ID_3 = typeOfStudy.TYPE_OF_STUDY_ID;
                        paper.TYPE_OF_STUDY_NAME_3 = typeOfStudy.TYPE_OF_STUDY_NAME;
                        paper.TYPE_OF_STUDY_NAME_EN_3 = typeOfStudy.TYPE_OF_STUDY_NAME_EN;
                        paper.CONFERENCE_PRESENTATION_TYPE_ID_3 = presentationType.CONFERENCE_PRESENTATION_TYPE_ID;
                        paper.CONFERENCE_PRESENTATION_TYPE_NAME_3 = presentationType.CONFERENCE_PRESENTATION_TYPE_NAME;
                        paper.CONFERENCE_PRESENTATION_TYPE_NAME_EN_3 = presentationType.CONFERENCE_PRESENTATION_TYPE_NAME_EN;
                        paper.LAST_REVISED_DATE_3 = DateTime.Now;
                        db.SaveChanges();

                        for (int i = 0; i < body.ListAuthor.Count; i++)
                        {
                            var item = body.ListAuthor[i];
                            if (!model.checkIsAuthor(item.PERSON_ID)) return ResponseFail(StringResource.Account_does_not_author);
                            model.addAuthorPaperAbstract(item, body.CONFERENCE_ID, paper.PAPER_ID, i);
                        }
                        return ResponseSuccess(StringResource.Success);
                    }
                    else if (number == 4)//Cập nhật lại nhóm 4
                    {
                        paper.PAPER_ABSTRACT_TITLE_4 = body.PAPER_ABSTRACT_TITLE;
                        paper.PAPER_ABSTRACT_TITLE_EN_4 = body.PAPER_ABSTRACT_TITLE_EN;
                        paper.CONFERENCE_SESSION_TOPIC_ID_4 = topic.CONFERENCE_SESSION_TOPIC_ID;
                        paper.CONFERENCE_SESSION_TOPIC_NAME_4 = topic.CONFERENCE_SESSION_TOPIC_NAME;
                        paper.CONFERENCE_SESSION_TOPIC_NAME_EN_4 = topic.CONFERENCE_SESSION_TOPIC_NAME_EN;
                        paper.PAPER_ABSTRACT_TEXT_4 = body.PAPER_ABSTRACT_TEXT;
                        paper.PAPER_ABSTRACT_TEXT_EN_4 = body.PAPER_ABSTRACT_TEXT_EN;
                        paper.PAPER_ABSTRACT_ATTACHED_FILENAME_4 = body.PAPER_ABSTRACT_ATTACHED_FILENAME;
                        paper.WORD_COUNT_OF_PAPER_ABSTRACT_4 = body.WORD_COUNT_OF_PAPER_ABSTRACT;
                        paper.KEYWORDS_4 = body.KEYWORDS;
                        paper.FULL_PAPER_OR_WORK_IN_PROGRESS_4 = body.FULL_PAPER_OR_WORK_IN_PROGRESS;
                        paper.TYPE_OF_STUDY_ID_4 = typeOfStudy.TYPE_OF_STUDY_ID;
                        paper.TYPE_OF_STUDY_NAME_4 = typeOfStudy.TYPE_OF_STUDY_NAME;
                        paper.TYPE_OF_STUDY_NAME_EN_4 = typeOfStudy.TYPE_OF_STUDY_NAME_EN;
                        paper.CONFERENCE_PRESENTATION_TYPE_ID_4 = presentationType.CONFERENCE_PRESENTATION_TYPE_ID;
                        paper.CONFERENCE_PRESENTATION_TYPE_NAME_4 = presentationType.CONFERENCE_PRESENTATION_TYPE_NAME;
                        paper.CONFERENCE_PRESENTATION_TYPE_NAME_EN_4 = presentationType.CONFERENCE_PRESENTATION_TYPE_NAME_EN;
                        paper.LAST_REVISED_DATE_4 = DateTime.Now;
                        db.SaveChanges();

                        for (int i = 0; i < body.ListAuthor.Count; i++)
                        {
                            var item = body.ListAuthor[i];
                            if (!model.checkIsAuthor(item.PERSON_ID)) return ResponseFail(StringResource.Account_does_not_author);
                            model.addAuthorPaperAbstract(item, body.CONFERENCE_ID, paper.PAPER_ID, i);
                        }
                        return ResponseSuccess(StringResource.Success);
                    }
                    else if (number == 5)//Cập nhật lại nhóm 5
                    {
                        paper.PAPER_ABSTRACT_TITLE_5 = body.PAPER_ABSTRACT_TITLE;
                        paper.PAPER_ABSTRACT_TITLE_EN_5 = body.PAPER_ABSTRACT_TITLE_EN;
                        paper.CONFERENCE_SESSION_TOPIC_ID_5 = topic.CONFERENCE_SESSION_TOPIC_ID;
                        paper.CONFERENCE_SESSION_TOPIC_NAME_5 = topic.CONFERENCE_SESSION_TOPIC_NAME;
                        paper.CONFERENCE_SESSION_TOPIC_NAME_EN_5 = topic.CONFERENCE_SESSION_TOPIC_NAME_EN;
                        paper.PAPER_ABSTRACT_TEXT_5 = body.PAPER_ABSTRACT_TEXT;
                        paper.PAPER_ABSTRACT_TEXT_EN_5 = body.PAPER_ABSTRACT_TEXT_EN;
                        paper.PAPER_ABSTRACT_ATTACHED_FILENAME_5 = body.PAPER_ABSTRACT_ATTACHED_FILENAME;
                        paper.WORD_COUNT_OF_PAPER_ABSTRACT_5 = body.WORD_COUNT_OF_PAPER_ABSTRACT;
                        paper.KEYWORDS_5 = body.KEYWORDS;
                        paper.FULL_PAPER_OR_WORK_IN_PROGRESS_5 = body.FULL_PAPER_OR_WORK_IN_PROGRESS;
                        paper.TYPE_OF_STUDY_ID_5 = typeOfStudy.TYPE_OF_STUDY_ID;
                        paper.TYPE_OF_STUDY_NAME_5 = typeOfStudy.TYPE_OF_STUDY_NAME;
                        paper.TYPE_OF_STUDY_NAME_EN_5 = typeOfStudy.TYPE_OF_STUDY_NAME_EN;
                        paper.CONFERENCE_PRESENTATION_TYPE_ID_5 = presentationType.CONFERENCE_PRESENTATION_TYPE_ID;
                        paper.CONFERENCE_PRESENTATION_TYPE_NAME_5 = presentationType.CONFERENCE_PRESENTATION_TYPE_NAME;
                        paper.CONFERENCE_PRESENTATION_TYPE_NAME_EN_5 = presentationType.CONFERENCE_PRESENTATION_TYPE_NAME_EN;
                        paper.LAST_REVISED_DATE_5 = DateTime.Now;
                        db.SaveChanges();

                        for (int i = 0; i < body.ListAuthor.Count; i++)
                        {
                            var item = body.ListAuthor[i];
                            if (!model.checkIsAuthor(item.PERSON_ID)) return ResponseFail(StringResource.Account_does_not_author);
                            model.addAuthorPaperAbstract(item, body.CONFERENCE_ID, paper.PAPER_ID, i);
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
                    if (paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT == null)//Chưa được duyệt cuối
                    {
                        return ResponseFail(StringResource.Paper_Abstract_is_being_reviewed_please_wait_for_results);
                    }
                    else if (paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT == true)
                    {
                        return ResponseFail(StringResource.Paper_Abstract_accepted);
                    }
                    else//Bài được duyệt cuối
                    {
                        //Cập nhật lại nhóm (2 hoặc 3,4,5), phân tự động review lại
                        int number = model.getTimesSent(paper);
                        if (number == 1)//Thêm nhóm 2
                        {
                            paper.PAPER_ABSTRACT_TITLE_2 = body.PAPER_ABSTRACT_TITLE;
                            paper.PAPER_ABSTRACT_TITLE_EN_2 = body.PAPER_ABSTRACT_TITLE_EN;
                            paper.CONFERENCE_SESSION_TOPIC_ID_2 = topic.CONFERENCE_SESSION_TOPIC_ID;
                            paper.CONFERENCE_SESSION_TOPIC_NAME_2 = topic.CONFERENCE_SESSION_TOPIC_NAME;
                            paper.CONFERENCE_SESSION_TOPIC_NAME_EN_2 = topic.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            paper.PAPER_ABSTRACT_TEXT_2 = body.PAPER_ABSTRACT_TEXT;
                            paper.PAPER_ABSTRACT_TEXT_EN_2 = body.PAPER_ABSTRACT_TEXT_EN;
                            paper.PAPER_ABSTRACT_ATTACHED_FILENAME_2 = body.PAPER_ABSTRACT_ATTACHED_FILENAME;
                            paper.WORD_COUNT_OF_PAPER_ABSTRACT_2 = body.WORD_COUNT_OF_PAPER_ABSTRACT;
                            paper.KEYWORDS_2 = body.KEYWORDS;
                            paper.FULL_PAPER_OR_WORK_IN_PROGRESS_2 = body.FULL_PAPER_OR_WORK_IN_PROGRESS;
                            paper.TYPE_OF_STUDY_ID_2 = typeOfStudy.TYPE_OF_STUDY_ID;
                            paper.TYPE_OF_STUDY_NAME_2 = typeOfStudy.TYPE_OF_STUDY_NAME;
                            paper.TYPE_OF_STUDY_NAME_EN_2 = typeOfStudy.TYPE_OF_STUDY_NAME_EN;
                            paper.CONFERENCE_PRESENTATION_TYPE_ID_2 = presentationType.CONFERENCE_PRESENTATION_TYPE_ID;
                            paper.CONFERENCE_PRESENTATION_TYPE_NAME_2 = presentationType.CONFERENCE_PRESENTATION_TYPE_NAME;
                            paper.CONFERENCE_PRESENTATION_TYPE_NAME_EN_2 = presentationType.CONFERENCE_PRESENTATION_TYPE_NAME_EN;
                            paper.FIRST_SUBMITTED_DATE_2 = DateTime.Now;
                            paper.LAST_REVISED_DATE_2 = DateTime.Now;
                            paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT = null;
                            paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_DATE = null;
                            paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_REVIEWER_PERSON_ID = null;
                            paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_SCRIPT = null;
                            db.SaveChanges();

                            model.assignedReviewerUpdate(paper.PAPER_ID, (Int16)2);

                            for (int i = 0; i < body.ListAuthor.Count; i++)
                            {
                                var item = body.ListAuthor[i];
                                if (!model.checkIsAuthor(item.PERSON_ID)) return ResponseFail(StringResource.Account_does_not_author);
                                model.addAuthorPaperAbstract(item, body.CONFERENCE_ID, paper.PAPER_ID, i);
                            }
                            return ResponseSuccess(StringResource.Success);
                        }
                        else if (number == 2)//Thêm nhóm 3
                        {
                            paper.PAPER_ABSTRACT_TITLE_3 = body.PAPER_ABSTRACT_TITLE;
                            paper.PAPER_ABSTRACT_TITLE_EN_3 = body.PAPER_ABSTRACT_TITLE_EN;
                            paper.CONFERENCE_SESSION_TOPIC_ID_3 = topic.CONFERENCE_SESSION_TOPIC_ID;
                            paper.CONFERENCE_SESSION_TOPIC_NAME_3 = topic.CONFERENCE_SESSION_TOPIC_NAME;
                            paper.CONFERENCE_SESSION_TOPIC_NAME_EN_3 = topic.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            paper.PAPER_ABSTRACT_TEXT_3 = body.PAPER_ABSTRACT_TEXT;
                            paper.PAPER_ABSTRACT_TEXT_EN_3 = body.PAPER_ABSTRACT_TEXT_EN;
                            paper.PAPER_ABSTRACT_ATTACHED_FILENAME_3 = body.PAPER_ABSTRACT_ATTACHED_FILENAME;
                            paper.WORD_COUNT_OF_PAPER_ABSTRACT_3 = body.WORD_COUNT_OF_PAPER_ABSTRACT;
                            paper.KEYWORDS_3 = body.KEYWORDS;
                            paper.FULL_PAPER_OR_WORK_IN_PROGRESS_3 = body.FULL_PAPER_OR_WORK_IN_PROGRESS;
                            paper.TYPE_OF_STUDY_ID_3 = typeOfStudy.TYPE_OF_STUDY_ID;
                            paper.TYPE_OF_STUDY_NAME_3 = typeOfStudy.TYPE_OF_STUDY_NAME;
                            paper.TYPE_OF_STUDY_NAME_EN_3 = typeOfStudy.TYPE_OF_STUDY_NAME_EN;
                            paper.CONFERENCE_PRESENTATION_TYPE_ID_3 = presentationType.CONFERENCE_PRESENTATION_TYPE_ID;
                            paper.CONFERENCE_PRESENTATION_TYPE_NAME_3 = presentationType.CONFERENCE_PRESENTATION_TYPE_NAME;
                            paper.CONFERENCE_PRESENTATION_TYPE_NAME_EN_3 = presentationType.CONFERENCE_PRESENTATION_TYPE_NAME_EN;
                            paper.FIRST_SUBMITTED_DATE_3 = DateTime.Now;
                            paper.LAST_REVISED_DATE_3 = DateTime.Now;
                            paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT = null;
                            paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_DATE = null;
                            paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_REVIEWER_PERSON_ID = null;
                            paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_SCRIPT = null;
                            db.SaveChanges();

                            model.assignedReviewerUpdate(paper.PAPER_ID, (Int16)3);

                            for (int i = 0; i < body.ListAuthor.Count; i++)
                            {
                                var item = body.ListAuthor[i];
                                if (!model.checkIsAuthor(item.PERSON_ID)) return ResponseFail(StringResource.Account_does_not_author);
                                model.addAuthorPaperAbstract(item, body.CONFERENCE_ID, paper.PAPER_ID, i);
                            }
                            return ResponseSuccess(StringResource.Success);
                        }
                        else if (number == 3)//Thêm nhóm 4
                        {
                            paper.PAPER_ABSTRACT_TITLE_4 = body.PAPER_ABSTRACT_TITLE;
                            paper.PAPER_ABSTRACT_TITLE_EN_4 = body.PAPER_ABSTRACT_TITLE_EN;
                            paper.CONFERENCE_SESSION_TOPIC_ID_4 = topic.CONFERENCE_SESSION_TOPIC_ID;
                            paper.CONFERENCE_SESSION_TOPIC_NAME_4 = topic.CONFERENCE_SESSION_TOPIC_NAME;
                            paper.CONFERENCE_SESSION_TOPIC_NAME_EN_4 = topic.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            paper.PAPER_ABSTRACT_TEXT_4 = body.PAPER_ABSTRACT_TEXT;
                            paper.PAPER_ABSTRACT_TEXT_EN_4 = body.PAPER_ABSTRACT_TEXT_EN;
                            paper.PAPER_ABSTRACT_ATTACHED_FILENAME_4 = body.PAPER_ABSTRACT_ATTACHED_FILENAME;
                            paper.WORD_COUNT_OF_PAPER_ABSTRACT_4 = body.WORD_COUNT_OF_PAPER_ABSTRACT;
                            paper.KEYWORDS_4 = body.KEYWORDS;
                            paper.FULL_PAPER_OR_WORK_IN_PROGRESS_4 = body.FULL_PAPER_OR_WORK_IN_PROGRESS;
                            paper.TYPE_OF_STUDY_ID_4 = typeOfStudy.TYPE_OF_STUDY_ID;
                            paper.TYPE_OF_STUDY_NAME_4 = typeOfStudy.TYPE_OF_STUDY_NAME;
                            paper.TYPE_OF_STUDY_NAME_EN_4 = typeOfStudy.TYPE_OF_STUDY_NAME_EN;
                            paper.CONFERENCE_PRESENTATION_TYPE_ID_4 = presentationType.CONFERENCE_PRESENTATION_TYPE_ID;
                            paper.CONFERENCE_PRESENTATION_TYPE_NAME_4 = presentationType.CONFERENCE_PRESENTATION_TYPE_NAME;
                            paper.CONFERENCE_PRESENTATION_TYPE_NAME_EN_4 = presentationType.CONFERENCE_PRESENTATION_TYPE_NAME_EN;
                            paper.FIRST_SUBMITTED_DATE_4 = DateTime.Now;
                            paper.LAST_REVISED_DATE_4 = DateTime.Now;
                            paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT = null;
                            paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_DATE = null;
                            paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_REVIEWER_PERSON_ID = null;
                            paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_SCRIPT = null;
                            db.SaveChanges();

                            model.assignedReviewerUpdate(paper.PAPER_ID, (Int16)4);

                            for (int i = 0; i < body.ListAuthor.Count; i++)
                            {
                                var item = body.ListAuthor[i];
                                if (!model.checkIsAuthor(item.PERSON_ID)) return ResponseFail(StringResource.Account_does_not_author);
                                model.addAuthorPaperAbstract(item, body.CONFERENCE_ID, paper.PAPER_ID, i);
                            }
                            return ResponseSuccess(StringResource.Success);
                        }
                        else if (number == 4)//Thêm nhóm 5
                        {
                            paper.PAPER_ABSTRACT_TITLE_5 = body.PAPER_ABSTRACT_TITLE;
                            paper.PAPER_ABSTRACT_TITLE_EN_5 = body.PAPER_ABSTRACT_TITLE_EN;
                            paper.CONFERENCE_SESSION_TOPIC_ID_5 = topic.CONFERENCE_SESSION_TOPIC_ID;
                            paper.CONFERENCE_SESSION_TOPIC_NAME_5 = topic.CONFERENCE_SESSION_TOPIC_NAME;
                            paper.CONFERENCE_SESSION_TOPIC_NAME_EN_5 = topic.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            paper.PAPER_ABSTRACT_TEXT_5 = body.PAPER_ABSTRACT_TEXT;
                            paper.PAPER_ABSTRACT_TEXT_EN_5 = body.PAPER_ABSTRACT_TEXT_EN;
                            paper.PAPER_ABSTRACT_ATTACHED_FILENAME_5 = body.PAPER_ABSTRACT_ATTACHED_FILENAME;
                            paper.WORD_COUNT_OF_PAPER_ABSTRACT_5 = body.WORD_COUNT_OF_PAPER_ABSTRACT;
                            paper.KEYWORDS_5 = body.KEYWORDS;
                            paper.FULL_PAPER_OR_WORK_IN_PROGRESS_5 = body.FULL_PAPER_OR_WORK_IN_PROGRESS;
                            paper.TYPE_OF_STUDY_ID_5 = typeOfStudy.TYPE_OF_STUDY_ID;
                            paper.TYPE_OF_STUDY_NAME_5 = typeOfStudy.TYPE_OF_STUDY_NAME;
                            paper.TYPE_OF_STUDY_NAME_EN_5 = typeOfStudy.TYPE_OF_STUDY_NAME_EN;
                            paper.CONFERENCE_PRESENTATION_TYPE_ID_5 = presentationType.CONFERENCE_PRESENTATION_TYPE_ID;
                            paper.CONFERENCE_PRESENTATION_TYPE_NAME_5 = presentationType.CONFERENCE_PRESENTATION_TYPE_NAME;
                            paper.CONFERENCE_PRESENTATION_TYPE_NAME_EN_5 = presentationType.CONFERENCE_PRESENTATION_TYPE_NAME_EN;
                            paper.FIRST_SUBMITTED_DATE_5 = DateTime.Now;
                            paper.LAST_REVISED_DATE_5 = DateTime.Now;
                            paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT = null;
                            paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_DATE = null;
                            paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_REVIEWER_PERSON_ID = null;
                            paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_SCRIPT = null;
                            db.SaveChanges();

                            model.assignedReviewerUpdate(paper.PAPER_ID, (Int16)5);

                            for (int i = 0; i < body.ListAuthor.Count; i++)
                            {
                                var item = body.ListAuthor[i];
                                if (!model.checkIsAuthor(item.PERSON_ID)) return ResponseFail(StringResource.Account_does_not_author);
                                model.addAuthorPaperAbstract(item, body.CONFERENCE_ID, paper.PAPER_ID, i);
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
        [Route("api/ListSubmitingHistoryPaperAbstract")]
        public HttpResponseMessage ListSubmitingHistoryPaperAbstract(int paperId)
        {
            var paperAbstract = db.PAPER_ABSTRACT.Find(paperId);
            if (paperAbstract == null)
            {
                return ResponseFail(StringResource.Paper_abstract_do_not_exist);
            }
            else
            {
                var listObj = new List<MyPaperAbtract>();
                if (!String.IsNullOrEmpty(paperAbstract.PAPER_ABSTRACT_TITLE_1) || !String.IsNullOrEmpty(paperAbstract.PAPER_ABSTRACT_TITLE_EN_1))
                {
                    var myPaper = new MyPaperAbtract(paperAbstract.PAPER_ABSTRACT_TITLE_1, paperAbstract.PAPER_ABSTRACT_TITLE_EN_1, paperAbstract.CONFERENCE_SESSION_TOPIC_ID_1, paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_1,
                     paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_EN_1, paperAbstract.PAPER_ABSTRACT_TEXT_1, paperAbstract.PAPER_ABSTRACT_TEXT_EN_1, paperAbstract.PAPER_ABSTRACT_ATTACHED_FILENAME_1, paperAbstract.WORD_COUNT_OF_PAPER_ABSTRACT_1,
                     paperAbstract.KEYWORDS_1, paperAbstract.FULL_PAPER_OR_WORK_IN_PROGRESS_1, paperAbstract.TYPE_OF_STUDY_ID_1, paperAbstract.TYPE_OF_STUDY_NAME_1, paperAbstract.TYPE_OF_STUDY_NAME_EN_1,
                     paperAbstract.CONFERENCE_PRESENTATION_TYPE_ID_1, paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_1, paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_EN_1, paperAbstract.FIRST_SUBMITTED_DATE_1, paperAbstract.LAST_REVISED_DATE_1);
                    listObj.Add(myPaper);
                }
                if (!String.IsNullOrEmpty(paperAbstract.PAPER_ABSTRACT_TITLE_2) || !String.IsNullOrEmpty(paperAbstract.PAPER_ABSTRACT_TITLE_EN_2))
                {
                    var myPaper = new MyPaperAbtract(paperAbstract.PAPER_ABSTRACT_TITLE_2, paperAbstract.PAPER_ABSTRACT_TITLE_EN_2, paperAbstract.CONFERENCE_SESSION_TOPIC_ID_2, paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_2,
                     paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_EN_2, paperAbstract.PAPER_ABSTRACT_TEXT_2, paperAbstract.PAPER_ABSTRACT_TEXT_EN_2, paperAbstract.PAPER_ABSTRACT_ATTACHED_FILENAME_2, paperAbstract.WORD_COUNT_OF_PAPER_ABSTRACT_2,
                     paperAbstract.KEYWORDS_2, paperAbstract.FULL_PAPER_OR_WORK_IN_PROGRESS_2, paperAbstract.TYPE_OF_STUDY_ID_2, paperAbstract.TYPE_OF_STUDY_NAME_2, paperAbstract.TYPE_OF_STUDY_NAME_EN_2,
                     paperAbstract.CONFERENCE_PRESENTATION_TYPE_ID_2, paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_2, paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_EN_2, paperAbstract.FIRST_SUBMITTED_DATE_2, paperAbstract.LAST_REVISED_DATE_2);
                    listObj.Add(myPaper);
                }
                if (!String.IsNullOrEmpty(paperAbstract.PAPER_ABSTRACT_TITLE_3) || !String.IsNullOrEmpty(paperAbstract.PAPER_ABSTRACT_TITLE_EN_3))
                {
                    var myPaper = new MyPaperAbtract(paperAbstract.PAPER_ABSTRACT_TITLE_3, paperAbstract.PAPER_ABSTRACT_TITLE_EN_3, paperAbstract.CONFERENCE_SESSION_TOPIC_ID_3, paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_3,
                     paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_EN_3, paperAbstract.PAPER_ABSTRACT_TEXT_3, paperAbstract.PAPER_ABSTRACT_TEXT_EN_3, paperAbstract.PAPER_ABSTRACT_ATTACHED_FILENAME_3, paperAbstract.WORD_COUNT_OF_PAPER_ABSTRACT_3,
                     paperAbstract.KEYWORDS_3, paperAbstract.FULL_PAPER_OR_WORK_IN_PROGRESS_3, paperAbstract.TYPE_OF_STUDY_ID_3, paperAbstract.TYPE_OF_STUDY_NAME_3, paperAbstract.TYPE_OF_STUDY_NAME_EN_3,
                     paperAbstract.CONFERENCE_PRESENTATION_TYPE_ID_3, paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_3, paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_EN_3, paperAbstract.FIRST_SUBMITTED_DATE_3, paperAbstract.LAST_REVISED_DATE_3);
                    listObj.Add(myPaper);
                }
                if (!String.IsNullOrEmpty(paperAbstract.PAPER_ABSTRACT_TITLE_4) || !String.IsNullOrEmpty(paperAbstract.PAPER_ABSTRACT_TITLE_EN_4))
                {
                    var myPaper = new MyPaperAbtract(paperAbstract.PAPER_ABSTRACT_TITLE_4, paperAbstract.PAPER_ABSTRACT_TITLE_EN_4, paperAbstract.CONFERENCE_SESSION_TOPIC_ID_4, paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_4,
                     paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_EN_4, paperAbstract.PAPER_ABSTRACT_TEXT_4, paperAbstract.PAPER_ABSTRACT_TEXT_EN_4, paperAbstract.PAPER_ABSTRACT_ATTACHED_FILENAME_4, paperAbstract.WORD_COUNT_OF_PAPER_ABSTRACT_4,
                     paperAbstract.KEYWORDS_4, paperAbstract.FULL_PAPER_OR_WORK_IN_PROGRESS_4, paperAbstract.TYPE_OF_STUDY_ID_4, paperAbstract.TYPE_OF_STUDY_NAME_4, paperAbstract.TYPE_OF_STUDY_NAME_EN_4,
                     paperAbstract.CONFERENCE_PRESENTATION_TYPE_ID_4, paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_4, paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_EN_4, paperAbstract.FIRST_SUBMITTED_DATE_4, paperAbstract.LAST_REVISED_DATE_4);
                    listObj.Add(myPaper);
                }
                if (!String.IsNullOrEmpty(paperAbstract.PAPER_ABSTRACT_TITLE_5) || !String.IsNullOrEmpty(paperAbstract.PAPER_ABSTRACT_TITLE_EN_5))
                {
                    var myPaper = new MyPaperAbtract(paperAbstract.PAPER_ABSTRACT_TITLE_5, paperAbstract.PAPER_ABSTRACT_TITLE_EN_5, paperAbstract.CONFERENCE_SESSION_TOPIC_ID_5, paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_5,
                    paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_EN_5, paperAbstract.PAPER_ABSTRACT_TEXT_5, paperAbstract.PAPER_ABSTRACT_TEXT_EN_5, paperAbstract.PAPER_ABSTRACT_ATTACHED_FILENAME_5, paperAbstract.WORD_COUNT_OF_PAPER_ABSTRACT_5,
                    paperAbstract.KEYWORDS_5, paperAbstract.FULL_PAPER_OR_WORK_IN_PROGRESS_5, paperAbstract.TYPE_OF_STUDY_ID_5, paperAbstract.TYPE_OF_STUDY_NAME_5, paperAbstract.TYPE_OF_STUDY_NAME_EN_5,
                    paperAbstract.CONFERENCE_PRESENTATION_TYPE_ID_5, paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_5, paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_EN_5, paperAbstract.FIRST_SUBMITTED_DATE_5, paperAbstract.LAST_REVISED_DATE_5);
                    listObj.Add(myPaper);
                }
                return ResponseSuccess(StringResource.Success, listObj);
            }
        }

        [HttpPost]
        [Route("api/ListReviewingHistoryPaperAbstract")]
        public HttpResponseMessage ListReviewingHistoryPaperAbstract(int paperId, int conferenceId, int reviewTime = 1)
        {
            var paper = db.PAPER_ABSTRACT.Find(paperId);
            var model = new PaperAbstractModel();
            if (paper == null)
            {
                return ResponseFail(StringResource.Paper_abstract_do_not_exist);
            }
            else
            {
                var paperAbstract = model.getMyPaperAbstract(paperId, reviewTime);
                var listReviewing = (from r in db.REVIEWER_PAPER_ABSTRACT_RELATIONSHIP
                                     join b in db.CONFERENCE_BOARD_OF_REVIEW on r.CONFERENCE_BOARD_OF_REVIEW_ID equals b.CONFERENCE_BOARD_OF_REVIEW_ID
                                     join p in db.People on r.PERSON_ID equals p.PERSON_ID
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
                                        paperAbstract.FIRST_SUBMITTED_DATE,
                                        paperAbstract.LAST_REVISED_DATE,
                                        x.b.CONFERENCE_BOARD_OF_REVIEW_NAME,
                                        x.b.CONFERENCE_BOARD_OF_REVIEW_NAME_EN,
                                        x.r.PAPER_ABSTRACT_SUBMISSION_DEADLINE_ORDER_NUMBER,
                                        x.r.REVIEWED_DATE,
                                        x.r.PROPOSED_CONFERENCE_SESSION_TOPIC_ID,
                                        x.r.PROPOSED_CONFERENCE_SESSION_TOPIC_NAME,
                                        x.r.PROPOSED_CONFERENCE_SESSION_TOPIC_NAME_EN,
                                        x.r.PROPOSED_TYPE_OF_STUDY_ID,
                                        x.r.PROPOSED_TYPE_OF_STUDY_NAME,
                                        x.r.PROPOSED_TYPE_OF_STUDY_NAME_EN,
                                        x.r.PROPOSED_FOR_PRESENTATION,
                                        x.r.PROPOSED_CONFERENCE_PRESENTATION_TYPE_ID,
                                        x.r.PROPOSED_CONFERENCE_PRESENTATION_TYPE_NAME,
                                        x.r.PROPOSED_CONFERENCE_PRESENTATION_TYPE_NAME_EN,
                                        x.r.PAPER_ABSTRACT_REVIEW_RATING_POINT,
                                        x.r.SIGNIFICANT_REVISION_OR_MINIMAL_REVISION_OR_REVISION_NEEDED_OR_NO_REVISION_NEEDED,
                                        x.r.REVIEW_TEXT,
                                        x.r.REVIEW_TEXT_EN,
                                        x.r.APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT,
                                        x.r.APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_DATE,
                                    }).OrderByDescending(x => x.REVIEWED_DATE);
                return ResponseSuccess(StringResource.Success, listReviewing);
            }
        }

        [HttpPost]
        [Route("api/CheckSubmitDeadlinePaperAbstract")]
        public HttpResponseMessage CheckSubmitDeadlinePaperAbstract(int conferenceId)
        {
            var model = new PaperAbstractModel();
            var result = model.checkConferencePaperAbstractSubmitExpired(conferenceId);
            if (result == true)
            {
                return ResponseSuccess(StringResource.Success);
            }
            return ResponseFail(StringResource.Expired_submit_paper_abstract);
        }
    }

    public class FormSubmitPaperAbstract
    {
        public int NUMBER_PAPER_ABSTRACT_DEADLINE { get; set; }
        public DateTime? PAPER_ABSTRACT_DEADLINE { get; set; }
        public object ListSessionTopic { get; set; }
        public object ListTypeOfStudy { get; set; }
        public object ListPresentationType { get; set; }
    }

    public class PaperAbstractSubmit
    {
        public int PAPER_ID { get; set; }
        public int PERSON_ID { get; set; }
        public int CONFERENCE_ID { get; set; }
        public string PAPER_ABSTRACT_TITLE { get; set; }
        public string PAPER_ABSTRACT_TITLE_EN { get; set; }
        public string PAPER_ABSTRACT_TEXT { get; set; }
        public string PAPER_ABSTRACT_TEXT_EN { get; set; }
        public int WORD_COUNT_OF_PAPER_ABSTRACT { get; set; }
        public string PAPER_ABSTRACT_ATTACHED_FILENAME { get; set; }
        public string KEYWORDS { get; set; }
        public string FULL_PAPER_OR_WORK_IN_PROGRESS { get; set; }
        public decimal? CONFERENCE_SESSION_TOPIC_ID { get; set; }
        public decimal? TYPE_OF_STUDY_ID { get; set; }
        public decimal? CONFERENCE_PRESENTATION_TYPE_ID { get; set; }
        public List<Author> ListAuthor { get; set; }
    }

    public class Author
    {
        public int PERSON_ID { get; set; }
        public string CURRENT_FIRST_NAME { get; set; }
        public string CURRENT_LAST_NAME { get; set; }
        public string CURRENT_MIDDLE_NAME { get; set; }
        public string CURRENT_PERSONAL_TITLE { get; set; }
        public string Email { get; set; }
        public int ORGANIZATION_ID_1 { get; set; }
        public string ORGANIZATION_1 { get; set; }
        public int ORGANIZATION_ID_2 { get; set; }
        public string ORGANIZATION_2 { get; set; }
        public int ORGANIZATION_ID_3 { get; set; }
        public string ORGANIZATION_3 { get; set; }
        public int ORGANIZATION_ID_4 { get; set; }
        public string ORGANIZATION_4 { get; set; }
        public int ORGANIZATION_ID_5 { get; set; }
        public string ORGANIZATION_5 { get; set; }
        public bool CORRESPONDING_AUTHOR { get; set; }
    }

    public class WithDrawForm
    {
        public int PAPER_ID { get; set; }
        public string NOTE { get; set; }
    }

    public class Search
    {
        public string SEARCH_STRING { get; set; }
    }
}