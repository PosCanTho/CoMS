using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoMS.Entities_Framework;
using CoMS.Resources;
using CoMS.Untils;
using System.Text;
using CoMS.Controllers;

namespace CoMS.Models
{
    public class PaperAbstractModel
    {
        private DB db;

        public PaperAbstractModel()
        {
            db = new DB();
        }

        public object getListPaperAbstract(int personId, int conferenceId)
        {
            var result = (from a in db.AUTHOR_PAPER_ABSTRACT_RELATIONSHIP
                          join p in db.PAPER_ABSTRACT on a.PAPER_ID equals p.PAPER_ID
                          where a.PERSON_ID == personId && a.CONFERENCE_ID == conferenceId
                          select new { a, p })
                         .AsEnumerable()
                         .Select(x => new
                         {
                             PAPER_ID = x.p.PAPER_ID,
                             PAPER_ABSTRACT_TITLE = getMyPaperAbstract(x.p).PAPER_ABSTRACT_TITLE,
                             PAPER_ABSTRACT_TITLE_EN = getMyPaperAbstract(x.p).PAPER_ABSTRACT_TITLE_EN,
                             TIMES_SENT = getTimesSent(x.p),
                             FIRST_SUBMITTED_DATE = getMyPaperAbstract(x.p).FIRST_SUBMITTED_DATE,
                             LAST_REVISED_DATE = getMyPaperAbstract(x.p).LAST_REVISED_DATE,
                             CONFERENCE_SESSION_TOPIC_NAME = getMyPaperAbstract(x.p).CONFERENCE_SESSION_TOPIC_NAME,
                             CONFERENCE_SESSION_TOPIC_NAME_EN = getMyPaperAbstract(x.p).CONFERENCE_SESSION_TOPIC_NAME_EN,
                             x.p.PAPER_ABSTRACT_WITHDRAWN,
                             x.p.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT,
                             HAS_PAPPER_TEXT = checkAbstractHasPaperText(x.p.PAPER_ID),
                             x.p.PAPER_ABSTRACT_WITHDRAWN_DATE,
                             x.p.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_DATE
                         });
            return result.OrderByDescending(x => x.FIRST_SUBMITTED_DATE);
        }

        public MyPaperAbtract getMyPaperAbstract(PAPER_ABSTRACT paperAbstract)
        {
            if (!String.IsNullOrEmpty(paperAbstract.PAPER_ABSTRACT_TITLE_5) || !String.IsNullOrEmpty(paperAbstract.PAPER_ABSTRACT_TITLE_EN_5))
            {
                var myPaper = new MyPaperAbtract(paperAbstract.PAPER_ABSTRACT_TITLE_5, paperAbstract.PAPER_ABSTRACT_TITLE_EN_5, paperAbstract.CONFERENCE_SESSION_TOPIC_ID_5, paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_5,
                    paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_EN_5, paperAbstract.PAPER_ABSTRACT_TEXT_5, paperAbstract.PAPER_ABSTRACT_TEXT_EN_5, paperAbstract.PAPER_ABSTRACT_ATTACHED_FILENAME_5, paperAbstract.WORD_COUNT_OF_PAPER_ABSTRACT_5,
                    paperAbstract.KEYWORDS_5, paperAbstract.FULL_PAPER_OR_WORK_IN_PROGRESS_5, paperAbstract.TYPE_OF_STUDY_ID_5, paperAbstract.TYPE_OF_STUDY_NAME_5, paperAbstract.TYPE_OF_STUDY_NAME_EN_5,
                    paperAbstract.CONFERENCE_PRESENTATION_TYPE_ID_5, paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_5, paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_EN_5, paperAbstract.FIRST_SUBMITTED_DATE_5, paperAbstract.LAST_REVISED_DATE_5);
                return myPaper;
            }
            else if (!String.IsNullOrEmpty(paperAbstract.PAPER_ABSTRACT_TITLE_4) || !String.IsNullOrEmpty(paperAbstract.PAPER_ABSTRACT_TITLE_EN_4))
            {
                var myPaper = new MyPaperAbtract(paperAbstract.PAPER_ABSTRACT_TITLE_4, paperAbstract.PAPER_ABSTRACT_TITLE_EN_4, paperAbstract.CONFERENCE_SESSION_TOPIC_ID_4, paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_4,
                     paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_EN_4, paperAbstract.PAPER_ABSTRACT_TEXT_4, paperAbstract.PAPER_ABSTRACT_TEXT_EN_4, paperAbstract.PAPER_ABSTRACT_ATTACHED_FILENAME_4, paperAbstract.WORD_COUNT_OF_PAPER_ABSTRACT_4,
                     paperAbstract.KEYWORDS_4, paperAbstract.FULL_PAPER_OR_WORK_IN_PROGRESS_4, paperAbstract.TYPE_OF_STUDY_ID_4, paperAbstract.TYPE_OF_STUDY_NAME_4, paperAbstract.TYPE_OF_STUDY_NAME_EN_4,
                     paperAbstract.CONFERENCE_PRESENTATION_TYPE_ID_4, paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_4, paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_EN_4, paperAbstract.FIRST_SUBMITTED_DATE_4, paperAbstract.LAST_REVISED_DATE_4);
                return myPaper;
            }
            else if (!String.IsNullOrEmpty(paperAbstract.PAPER_ABSTRACT_TITLE_3) || !String.IsNullOrEmpty(paperAbstract.PAPER_ABSTRACT_TITLE_EN_3))
            {
                var myPaper = new MyPaperAbtract(paperAbstract.PAPER_ABSTRACT_TITLE_3, paperAbstract.PAPER_ABSTRACT_TITLE_EN_3, paperAbstract.CONFERENCE_SESSION_TOPIC_ID_3, paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_3,
                     paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_EN_3, paperAbstract.PAPER_ABSTRACT_TEXT_3, paperAbstract.PAPER_ABSTRACT_TEXT_EN_3, paperAbstract.PAPER_ABSTRACT_ATTACHED_FILENAME_3, paperAbstract.WORD_COUNT_OF_PAPER_ABSTRACT_3,
                     paperAbstract.KEYWORDS_3, paperAbstract.FULL_PAPER_OR_WORK_IN_PROGRESS_3, paperAbstract.TYPE_OF_STUDY_ID_3, paperAbstract.TYPE_OF_STUDY_NAME_3, paperAbstract.TYPE_OF_STUDY_NAME_EN_3,
                     paperAbstract.CONFERENCE_PRESENTATION_TYPE_ID_3, paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_3, paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_EN_3, paperAbstract.FIRST_SUBMITTED_DATE_3, paperAbstract.LAST_REVISED_DATE_3);
                return myPaper;
            }
            else if (!String.IsNullOrEmpty(paperAbstract.PAPER_ABSTRACT_TITLE_2) || !String.IsNullOrEmpty(paperAbstract.PAPER_ABSTRACT_TITLE_EN_2))
            {
                var myPaper = new MyPaperAbtract(paperAbstract.PAPER_ABSTRACT_TITLE_2, paperAbstract.PAPER_ABSTRACT_TITLE_EN_2, paperAbstract.CONFERENCE_SESSION_TOPIC_ID_2, paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_2,
                    paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_EN_2, paperAbstract.PAPER_ABSTRACT_TEXT_2, paperAbstract.PAPER_ABSTRACT_TEXT_EN_2, paperAbstract.PAPER_ABSTRACT_ATTACHED_FILENAME_2, paperAbstract.WORD_COUNT_OF_PAPER_ABSTRACT_2,
                    paperAbstract.KEYWORDS_2, paperAbstract.FULL_PAPER_OR_WORK_IN_PROGRESS_2, paperAbstract.TYPE_OF_STUDY_ID_2, paperAbstract.TYPE_OF_STUDY_NAME_2, paperAbstract.TYPE_OF_STUDY_NAME_EN_2,
                    paperAbstract.CONFERENCE_PRESENTATION_TYPE_ID_2, paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_2, paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_EN_2, paperAbstract.FIRST_SUBMITTED_DATE_2, paperAbstract.LAST_REVISED_DATE_2);
                return myPaper;
            }
            else if (!String.IsNullOrEmpty(paperAbstract.PAPER_ABSTRACT_TITLE_1) || !String.IsNullOrEmpty(paperAbstract.PAPER_ABSTRACT_TITLE_EN_1))
            {
                var myPaper = new MyPaperAbtract(paperAbstract.PAPER_ABSTRACT_TITLE_1, paperAbstract.PAPER_ABSTRACT_TITLE_EN_1, paperAbstract.CONFERENCE_SESSION_TOPIC_ID_1, paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_1,
                     paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_EN_1, paperAbstract.PAPER_ABSTRACT_TEXT_1, paperAbstract.PAPER_ABSTRACT_TEXT_EN_1, paperAbstract.PAPER_ABSTRACT_ATTACHED_FILENAME_1, paperAbstract.WORD_COUNT_OF_PAPER_ABSTRACT_1,
                     paperAbstract.KEYWORDS_1, paperAbstract.FULL_PAPER_OR_WORK_IN_PROGRESS_1, paperAbstract.TYPE_OF_STUDY_ID_1, paperAbstract.TYPE_OF_STUDY_NAME_1, paperAbstract.TYPE_OF_STUDY_NAME_EN_1,
                     paperAbstract.CONFERENCE_PRESENTATION_TYPE_ID_1, paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_1, paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_EN_1, paperAbstract.FIRST_SUBMITTED_DATE_1, paperAbstract.LAST_REVISED_DATE_1);
                return myPaper;
            }
            return new MyPaperAbtract();
        }

        public MyPaperAbtract getMyPaperAbstract(int paperId, int reviewTime)
        {
            var paperAbstract = db.PAPER_ABSTRACT.Find(paperId);
            if (reviewTime == 5)
            {
                var myPaper = new MyPaperAbtract(paperAbstract.PAPER_ABSTRACT_TITLE_5, paperAbstract.PAPER_ABSTRACT_TITLE_EN_5, paperAbstract.CONFERENCE_SESSION_TOPIC_ID_5, paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_5,
                    paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_EN_5, paperAbstract.PAPER_ABSTRACT_TEXT_5, paperAbstract.PAPER_ABSTRACT_TEXT_EN_5, paperAbstract.PAPER_ABSTRACT_ATTACHED_FILENAME_5, paperAbstract.WORD_COUNT_OF_PAPER_ABSTRACT_5,
                    paperAbstract.KEYWORDS_5, paperAbstract.FULL_PAPER_OR_WORK_IN_PROGRESS_5, paperAbstract.TYPE_OF_STUDY_ID_5, paperAbstract.TYPE_OF_STUDY_NAME_5, paperAbstract.TYPE_OF_STUDY_NAME_EN_5,
                    paperAbstract.CONFERENCE_PRESENTATION_TYPE_ID_5, paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_5, paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_EN_5, paperAbstract.FIRST_SUBMITTED_DATE_5, paperAbstract.LAST_REVISED_DATE_5);
                return myPaper;
            }
            else if (reviewTime == 4)
            {
                var myPaper = new MyPaperAbtract(paperAbstract.PAPER_ABSTRACT_TITLE_4, paperAbstract.PAPER_ABSTRACT_TITLE_EN_4, paperAbstract.CONFERENCE_SESSION_TOPIC_ID_4, paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_4,
                     paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_EN_4, paperAbstract.PAPER_ABSTRACT_TEXT_4, paperAbstract.PAPER_ABSTRACT_TEXT_EN_4, paperAbstract.PAPER_ABSTRACT_ATTACHED_FILENAME_4, paperAbstract.WORD_COUNT_OF_PAPER_ABSTRACT_4,
                     paperAbstract.KEYWORDS_4, paperAbstract.FULL_PAPER_OR_WORK_IN_PROGRESS_4, paperAbstract.TYPE_OF_STUDY_ID_4, paperAbstract.TYPE_OF_STUDY_NAME_4, paperAbstract.TYPE_OF_STUDY_NAME_EN_4,
                     paperAbstract.CONFERENCE_PRESENTATION_TYPE_ID_4, paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_4, paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_EN_4, paperAbstract.FIRST_SUBMITTED_DATE_4, paperAbstract.LAST_REVISED_DATE_4);
                return myPaper;
            }
            else if (reviewTime == 3)
            {
                var myPaper = new MyPaperAbtract(paperAbstract.PAPER_ABSTRACT_TITLE_3, paperAbstract.PAPER_ABSTRACT_TITLE_EN_3, paperAbstract.CONFERENCE_SESSION_TOPIC_ID_3, paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_3,
                     paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_EN_3, paperAbstract.PAPER_ABSTRACT_TEXT_3, paperAbstract.PAPER_ABSTRACT_TEXT_EN_3, paperAbstract.PAPER_ABSTRACT_ATTACHED_FILENAME_3, paperAbstract.WORD_COUNT_OF_PAPER_ABSTRACT_3,
                     paperAbstract.KEYWORDS_3, paperAbstract.FULL_PAPER_OR_WORK_IN_PROGRESS_3, paperAbstract.TYPE_OF_STUDY_ID_3, paperAbstract.TYPE_OF_STUDY_NAME_3, paperAbstract.TYPE_OF_STUDY_NAME_EN_3,
                     paperAbstract.CONFERENCE_PRESENTATION_TYPE_ID_3, paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_3, paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_EN_3, paperAbstract.FIRST_SUBMITTED_DATE_3, paperAbstract.LAST_REVISED_DATE_3);
                return myPaper;
            }
            else if (reviewTime == 2)
            {
                var myPaper = new MyPaperAbtract(paperAbstract.PAPER_ABSTRACT_TITLE_2, paperAbstract.PAPER_ABSTRACT_TITLE_EN_2, paperAbstract.CONFERENCE_SESSION_TOPIC_ID_2, paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_2,
                    paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_EN_2, paperAbstract.PAPER_ABSTRACT_TEXT_2, paperAbstract.PAPER_ABSTRACT_TEXT_EN_2, paperAbstract.PAPER_ABSTRACT_ATTACHED_FILENAME_2, paperAbstract.WORD_COUNT_OF_PAPER_ABSTRACT_2,
                    paperAbstract.KEYWORDS_2, paperAbstract.FULL_PAPER_OR_WORK_IN_PROGRESS_2, paperAbstract.TYPE_OF_STUDY_ID_2, paperAbstract.TYPE_OF_STUDY_NAME_2, paperAbstract.TYPE_OF_STUDY_NAME_EN_2,
                    paperAbstract.CONFERENCE_PRESENTATION_TYPE_ID_2, paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_2, paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_EN_2, paperAbstract.FIRST_SUBMITTED_DATE_2, paperAbstract.LAST_REVISED_DATE_2);
                return myPaper;
            }
            else if (reviewTime == 1)
            {
                var myPaper = new MyPaperAbtract(paperAbstract.PAPER_ABSTRACT_TITLE_1, paperAbstract.PAPER_ABSTRACT_TITLE_EN_1, paperAbstract.CONFERENCE_SESSION_TOPIC_ID_1, paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_1,
                     paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_EN_1, paperAbstract.PAPER_ABSTRACT_TEXT_1, paperAbstract.PAPER_ABSTRACT_TEXT_EN_1, paperAbstract.PAPER_ABSTRACT_ATTACHED_FILENAME_1, paperAbstract.WORD_COUNT_OF_PAPER_ABSTRACT_1,
                     paperAbstract.KEYWORDS_1, paperAbstract.FULL_PAPER_OR_WORK_IN_PROGRESS_1, paperAbstract.TYPE_OF_STUDY_ID_1, paperAbstract.TYPE_OF_STUDY_NAME_1, paperAbstract.TYPE_OF_STUDY_NAME_EN_1,
                     paperAbstract.CONFERENCE_PRESENTATION_TYPE_ID_1, paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_1, paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_EN_1, paperAbstract.FIRST_SUBMITTED_DATE_1, paperAbstract.LAST_REVISED_DATE_1);
                return myPaper;
            }
            return new MyPaperAbtract();
        }

        public CONFERENCE_BOARD_OF_REVIEW getConferenceBoardOfReview(int boardId)
        {
            return db.CONFERENCE_BOARD_OF_REVIEW.Find(boardId);
        }

        public int getTimesSent(PAPER_ABSTRACT paperAbstract)
        {
            if (!String.IsNullOrEmpty(paperAbstract.PAPER_ABSTRACT_TITLE_5) || !String.IsNullOrEmpty(paperAbstract.PAPER_ABSTRACT_TITLE_EN_5))
            {
                return 5;
            }
            else if (!String.IsNullOrEmpty(paperAbstract.PAPER_ABSTRACT_TITLE_4) || !String.IsNullOrEmpty(paperAbstract.PAPER_ABSTRACT_TITLE_EN_4))
            {
                return 4;
            }
            else if (!String.IsNullOrEmpty(paperAbstract.PAPER_ABSTRACT_TITLE_3) || !String.IsNullOrEmpty(paperAbstract.PAPER_ABSTRACT_TITLE_EN_3))
            {
                return 3;
            }
            else if (!String.IsNullOrEmpty(paperAbstract.PAPER_ABSTRACT_TITLE_2) || !String.IsNullOrEmpty(paperAbstract.PAPER_ABSTRACT_TITLE_EN_2))
            {
                return 2;
            }
            else if (!String.IsNullOrEmpty(paperAbstract.PAPER_ABSTRACT_TITLE_1) || !String.IsNullOrEmpty(paperAbstract.PAPER_ABSTRACT_TITLE_EN_1))
            {
                return 1;
            }
            return 0;
        }

        //Trả về true là bài tóm tắt đã review, ngược lại chưa được review
        public bool checkPaperAbstractReviewed(int paperId, int conferenceId, int deadLineNumber)
        {
            try
            {
                var result = db.REVIEWER_PAPER_ABSTRACT_RELATIONSHIP.Where(x => x.PAPER_ID == paperId && x.CONFERENCE_ID == conferenceId && x.PAPER_ABSTRACT_SUBMISSION_DEADLINE_ORDER_NUMBER == deadLineNumber && x.PROPOSED_CONFERENCE_SESSION_TOPIC_ID != null).ToList();
                if (result.Count > 0)
                {
                    return true;
                }
                var result2 = db.PAPER_ABSTRACT.Where(x => x.PAPER_ID == paperId && x.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT != null).ToList();
                if (result2.Count > 0)
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

        //Trả về true là còn hạn, false là hết hạn gửi bài tóm tắt
        public bool checkConferencePaperAbstractSubmitExpired(int conferenceId)
        {
            try
            {
                var conference = db.CONFERENCEs.Find(conferenceId);
                if (DateTime.Now <= conference.PAPER_ABSTRACT_DEADLINE_1 || DateTime.Now <= conference.PAPER_ABSTRACT_DEADLINE_2 || DateTime.Now <= conference.PAPER_ABSTRACT_DEADLINE_3
                    || DateTime.Now <= conference.PAPER_ABSTRACT_DEADLINE_4 || DateTime.Now <= conference.PAPER_ABSTRACT_DEADLINE_5)
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

        //Trả về true là có bài báo, false là không có bài báo
        public bool checkAbstractHasPaperText(decimal paperAbstractId)
        {
            try
            {
                var result = db.PAPER_TEXT.Where(x => x.PAPER_ID == paperAbstractId).ToList();
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

        //Trả về true là bài tóm tắt đã được duyệt, ngược lại chưa được duyệt 
        public bool checkStatusPaperAbstract(int paperId)
        {
            try
            {
                var result = db.PAPER_ABSTRACT.Where(x => x.PAPER_ID == paperId && x.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT != null).ToList();
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

        public ORGANIZATION addOrganization(int id, string name, string nameEn)
        {
            var org = db.ORGANIZATIONs.Where(x => x.ORGANIZATION_ID == id).ToList();
            var orgName = db.ORGANIZATIONs.Where(x => x.ORGANIZATION_NAME == name).ToList();
            var orgNameEn = db.ORGANIZATIONs.Where(x => x.ORGANIZATION_NAME_EN == nameEn).ToList();
            if (org.Count > 0)
            {
                return org[0];
            }
            else if (orgName.Count > 0)
            {
                return orgName[0];
            }
            else if (orgNameEn.Count > 0)
            {
                return orgNameEn[0];
            }
            else if (!String.IsNullOrEmpty(name) && name != "null")
            {
                var newOrg = new ORGANIZATION();
                var lastOrg = db.ORGANIZATIONs.ToList();
                if (lastOrg.Count > 0)
                {
                    newOrg.ORGANIZATION_ID = lastOrg.Last().ORGANIZATION_ID + 1;
                }
                else
                {
                    newOrg.ORGANIZATION_ID = 1;
                }
                newOrg.ORGANIZATION_NAME = name;
                newOrg.ORGANIZATION_NAME_EN = nameEn;
                db.ORGANIZATIONs.Add(newOrg);
                db.SaveChanges();
                return newOrg;
            }
            return null;
        }

        //Trả về true là tác giả, false là không phải tác giả
        public bool checkIsAuthor(int personId)
        {
            try
            {
                var result = db.AUTHORs.Where(x => x.PERSON_ID == personId).ToList();
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

        public AUTHOR addAuthor(string firstName, string lastName, string middleName, string email, string title, int conferneceId)
        {
            var person = db.People.Where(x => x.CURRENT_PERSONAL_EMAIL == email).ToList();
            var conference = db.CONFERENCEs.Find(conferneceId);
            if (person.Count > 0)
            {
                var listAuthor = db.AUTHORs.AsEnumerable().Where(x => x.PERSON_ID == person[0].PERSON_ID).ToList();
                if (listAuthor.Count > 0)
                {
                    return listAuthor[0];
                }
                else
                {
                    var addAuthor = new AUTHOR();
                    addAuthor.PERSON_ID = person[0].PERSON_ID;
                    addAuthor.CURRENT_FIRST_NAME = firstName;
                    addAuthor.CURRENT_MIDDLE_NAME = middleName;
                    addAuthor.CURRENT_LAST_NAME = lastName;
                    addAuthor.CURRENT_PERSONAL_TITLE = title;
                    addAuthor.CONFERENCE_ID = conferneceId;
                    addAuthor.CONFERENCE_NAME = conference.CONFERENCE_NAME;
                    addAuthor.CONFERENCE_NAME_EN = conference.CONFERENCE_NAME_EN;
                    db.AUTHORs.Add(addAuthor);
                    db.SaveChanges();

                    return addAuthor;
                }
            }
            else
            {
                var addPerson = new PERSON();
                var lastPerson = db.People.ToList();
                if (lastPerson.Count > 0)
                {
                    addPerson.PERSON_ID = lastPerson.Last().PERSON_ID + 1;
                }
                else
                {
                    addPerson.PERSON_ID = 1;
                }
                addPerson.CURRENT_FIRST_NAME = firstName;
                addPerson.CURRENT_MIDDLE_NAME = middleName;
                addPerson.CURRENT_LAST_NAME = lastName;
                addPerson.CURRENT_PERSONAL_TITLE = title;
                addPerson.CURRENT_PERSONAL_EMAIL = email;
                db.People.Add(addPerson);
                db.SaveChanges();

                var addAuthor = new AUTHOR();
                addAuthor.PERSON_ID = addPerson.PERSON_ID;
                addAuthor.CURRENT_FIRST_NAME = firstName;
                addAuthor.CURRENT_MIDDLE_NAME = middleName;
                addAuthor.CURRENT_LAST_NAME = lastName;
                addAuthor.CURRENT_PERSONAL_TITLE = title;
                addAuthor.CONFERENCE_ID = conferneceId;
                addAuthor.CONFERENCE_NAME = conference.CONFERENCE_NAME;
                addAuthor.CONFERENCE_NAME_EN = conference.CONFERENCE_NAME_EN;
                db.AUTHORs.Add(addAuthor);
                db.SaveChanges();

                return addAuthor;
            }
        }

        //Trả về true tác giả này đã phân cho bài tóm tắt này, và ngược lại
        public bool checkAuthor(int personId, int conferenceId, decimal paperId)
        {
            try
            {
                var authorRe = db.AUTHOR_PAPER_ABSTRACT_RELATIONSHIP.Where(x => x.PERSON_ID == personId && x.PAPER_ID == paperId && x.CONFERENCE_ID == conferenceId).ToList();
                if (authorRe.Count > 0)
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


        public void addAuthorPaperAbstract(Author item, int conferenceId, decimal paperId, int authorNumber)
        {
            var author = new AUTHOR_PAPER_ABSTRACT_RELATIONSHIP();
            if (item.PERSON_ID <= 0)
            {
                var addAuthor = this.addAuthor(item.CURRENT_FIRST_NAME, item.CURRENT_LAST_NAME, item.CURRENT_MIDDLE_NAME, item.Email, item.CURRENT_PERSONAL_TITLE, conferenceId);
                author.PERSON_ID = addAuthor.PERSON_ID;
            }
            else
            {
                author.PERSON_ID = item.PERSON_ID;
            }

            if (this.checkAuthor(item.PERSON_ID, conferenceId, paperId)) return;

            author.CONFERENCE_ID = conferenceId;
            author.PAPER_ID = paperId;

            var org1 = this.addOrganization(item.ORGANIZATION_ID_1, item.ORGANIZATION_1, item.ORGANIZATION_1);
            if (org1 != null)
            {
                author.ORGANIZATION_ID_1 = org1.ORGANIZATION_ID;
                author.ORGANIZATION_NAME_1 = org1.ORGANIZATION_NAME;
                author.ORGANIZATION_NAME_EN_1 = org1.ORGANIZATION_NAME_EN;
            }

            var org2 = this.addOrganization(item.ORGANIZATION_ID_2, item.ORGANIZATION_2, item.ORGANIZATION_2);
            if (org2 != null)
            {
                author.ORGANIZATION_ID_2 = org2.ORGANIZATION_ID;
                author.ORGANIZATION_NAME_2 = org2.ORGANIZATION_NAME;
                author.ORGANIZATION_NAME_EN_2 = org2.ORGANIZATION_NAME_EN;
            }

            var org3 = this.addOrganization(item.ORGANIZATION_ID_3, item.ORGANIZATION_3, item.ORGANIZATION_3);
            if (org3 != null)
            {
                author.ORGANIZATION_ID_3 = org3.ORGANIZATION_ID;
                author.ORGANIZATION_NAME_3 = org3.ORGANIZATION_NAME;
                author.ORGANIZATION_NAME_EN_3 = org3.ORGANIZATION_NAME_EN;
            }

            var org4 = this.addOrganization(item.ORGANIZATION_ID_4, item.ORGANIZATION_4, item.ORGANIZATION_4);
            if (org4 != null)
            {
                author.ORGANIZATION_ID_4 = org4.ORGANIZATION_ID;
                author.ORGANIZATION_NAME_4 = org4.ORGANIZATION_NAME;
                author.ORGANIZATION_NAME_EN_4 = org4.ORGANIZATION_NAME_EN;
            }

            var org5 = this.addOrganization(item.ORGANIZATION_ID_5, item.ORGANIZATION_5, item.ORGANIZATION_5);
            if (org5 != null)
            {
                author.ORGANIZATION_ID_5 = org5.ORGANIZATION_ID;
                author.ORGANIZATION_NAME_5 = org5.ORGANIZATION_NAME;
                author.ORGANIZATION_NAME_EN_5 = org5.ORGANIZATION_NAME_EN;
            }

            author.FROM_DATE = DateTime.Now;
            author.CORRESPONDING_AUTHOR = item.CORRESPONDING_AUTHOR;
            author.AUTHOR_ORDER_NUMBER = (Int16)authorNumber;
            db.AUTHOR_PAPER_ABSTRACT_RELATIONSHIP.Add(author);
            db.SaveChanges();
        }

        //Kiểm tra bài tóm tắt đã được gán người này review chưa, true là rồi, false là chưa
        public bool checkIsassignedReviewerUpdate(decimal personId, decimal conferenceId, decimal paperId, int deadLineNumber)
        {
            try
            {
                var result = db.REVIEWER_PAPER_ABSTRACT_RELATIONSHIP.Where(x => x.PAPER_ID == paperId && x.CONFERENCE_ID == conferenceId && x.PERSON_ID == personId && x.PAPER_ABSTRACT_SUBMISSION_DEADLINE_ORDER_NUMBER == deadLineNumber).ToList();
                if (result.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return true;
            }
        }

        public void assignedReviewerUpdate(decimal paperId, Int16 deadlineNumber)
        {
            var list = db.REVIEWER_PAPER_ABSTRACT_RELATIONSHIP.Where(x => x.PAPER_ID == paperId).ToList();
            if (list.Count > 0)
            {
                foreach (REVIEWER_PAPER_ABSTRACT_RELATIONSHIP item in list)
                {
                    var review = new REVIEWER_PAPER_ABSTRACT_RELATIONSHIP();
                    review.PERSON_ID = item.PERSON_ID;
                    review.CONFERENCE_BOARD_OF_REVIEW_ID = item.CONFERENCE_BOARD_OF_REVIEW_ID;
                    review.CONFERENCE_ID = item.CONFERENCE_ID;
                    review.PAPER_ID = paperId;
                    review.PAPER_ABSTRACT_SUBMISSION_DEADLINE_ORDER_NUMBER = deadlineNumber;
                    if (this.checkIsassignedReviewerUpdate(review.PERSON_ID, review.CONFERENCE_ID, review.PAPER_ID, review.PAPER_ABSTRACT_SUBMISSION_DEADLINE_ORDER_NUMBER) == false)
                    {
                        db.REVIEWER_PAPER_ABSTRACT_RELATIONSHIP.Add(review);
                        db.SaveChanges();
                    }
                }
            }
        }
    }

    public class MyPaperAbtract
    {
        public string PAPER_ABSTRACT_TITLE { get; set; }
        public string PAPER_ABSTRACT_TITLE_EN { get; set; }
        public decimal? CONFERENCE_SESSION_TOPIC_ID { get; set; }
        public string CONFERENCE_SESSION_TOPIC_NAME { get; set; }
        public string CONFERENCE_SESSION_TOPIC_NAME_EN { get; set; }
        public string PAPER_ABSTRACT_TEXT { get; set; }
        public string PAPER_ABSTRACT_TEXT_EN { get; set; }
        public string PAPER_ABSTRACT_ATTACHED_FILENAME { get; set; }
        public int? WORD_COUNT_OF_PAPER_ABSTRACT { get; set; }
        public string KEYWORDS { get; set; }
        public string FULL_PAPER_OR_WORK_IN_PROGRESS { get; set; }
        public decimal? TYPE_OF_STUDY_ID { get; set; }
        public string TYPE_OF_STUDY_NAME { get; set; }
        public string TYPE_OF_STUDY_NAME_EN { get; set; }
        public decimal? CONFERENCE_PRESENTATION_TYPE_ID { get; set; }
        public string CONFERENCE_PRESENTATION_TYPE_NAME { get; set; }
        public string CONFERENCE_PRESENTATION_TYPE_NAME_EN { get; set; }
        public DateTime? FIRST_SUBMITTED_DATE { get; set; }
        public DateTime? LAST_REVISED_DATE { get; set; }

        public MyPaperAbtract()
        {

        }

        public MyPaperAbtract(string PAPER_ABSTRACT_TITLE, string PAPER_ABSTRACT_TITLE_EN, decimal? CONFERENCE_SESSION_TOPIC_ID, string CONFERENCE_SESSION_TOPIC_NAME, string CONFERENCE_SESSION_TOPIC_NAME_EN, string PAPER_ABSTRACT_TEXT, string PAPER_ABSTRACT_TEXT_EN, string PAPER_ABSTRACT_ATTACHED_FILENAME, int? WORD_COUNT_OF_PAPER_ABSTRACT, string KEYWORDS, string FULL_PAPER_OR_WORK_IN_PROGRESS,
            decimal? TYPE_OF_STUDY_ID, string TYPE_OF_STUDY_NAME, string TYPE_OF_STUDY_NAME_EN, decimal? CONFERENCE_PRESENTATION_TYPE_ID, string CONFERENCE_PRESENTATION_TYPE_NAME, string CONFERENCE_PRESENTATION_TYPE_NAME_EN, DateTime? FIRST_SUBMITTED_DATE, DateTime? LAST_REVISED_DATE)
        {
            this.PAPER_ABSTRACT_TITLE = PAPER_ABSTRACT_TITLE;
            this.PAPER_ABSTRACT_TITLE_EN = PAPER_ABSTRACT_TITLE_EN;
            this.CONFERENCE_SESSION_TOPIC_ID = CONFERENCE_SESSION_TOPIC_ID;
            this.CONFERENCE_SESSION_TOPIC_NAME = CONFERENCE_SESSION_TOPIC_NAME;
            this.CONFERENCE_SESSION_TOPIC_NAME_EN = CONFERENCE_SESSION_TOPIC_NAME_EN;
            this.PAPER_ABSTRACT_TEXT = PAPER_ABSTRACT_TEXT;
            this.PAPER_ABSTRACT_TEXT_EN = PAPER_ABSTRACT_TEXT_EN;
            this.PAPER_ABSTRACT_ATTACHED_FILENAME = PAPER_ABSTRACT_ATTACHED_FILENAME;
            this.WORD_COUNT_OF_PAPER_ABSTRACT = WORD_COUNT_OF_PAPER_ABSTRACT;
            this.KEYWORDS = KEYWORDS;
            this.FULL_PAPER_OR_WORK_IN_PROGRESS = FULL_PAPER_OR_WORK_IN_PROGRESS;
            this.TYPE_OF_STUDY_ID = TYPE_OF_STUDY_ID;
            this.TYPE_OF_STUDY_NAME = TYPE_OF_STUDY_NAME;
            this.TYPE_OF_STUDY_NAME_EN = TYPE_OF_STUDY_NAME_EN;
            this.CONFERENCE_PRESENTATION_TYPE_ID = CONFERENCE_PRESENTATION_TYPE_ID;
            this.CONFERENCE_PRESENTATION_TYPE_NAME = CONFERENCE_PRESENTATION_TYPE_NAME;
            this.CONFERENCE_PRESENTATION_TYPE_NAME_EN = CONFERENCE_PRESENTATION_TYPE_NAME_EN;
            this.FIRST_SUBMITTED_DATE = FIRST_SUBMITTED_DATE;
            this.LAST_REVISED_DATE = LAST_REVISED_DATE;
        }
    }
}