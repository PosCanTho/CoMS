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
    public class PaperTextModel
    {
        private DB db;

        public PaperTextModel()
        {
            db = new DB();
        }

        public object getListPaperText(int personId, int conferenceId)
        {

            var result = (from a in db.AUTHOR_PAPER_TEXT_RELATIONSHIP
                          join p in db.PAPER_TEXT on a.PAPER_ID equals p.PAPER_ID
                          where a.PERSON_ID == personId && a.CONFERENCE_ID == conferenceId
                          select new { a, p })
                             .AsEnumerable()
                             .Select(x => new
                             {
                                 x.p.PAPER_ID,
                                 TIMES_SENT = getTimesSent(x.p),
                                 getMyPaperText(x.p).PAPER_TEXT_TITLE,
                                 getMyPaperText(x.p).PAPER_TEXT_TITLE_EN,
                                 getMyPaperText(x.p).PAPER_TEXT,
                                 getMyPaperText(x.p).PAPER_TEXT_EN,
                                 getMyPaperText(x.p).PAPER_TEXT_ATTACHED_FILENAME,
                                 getMyPaperText(x.p).NUMBER_OF_PAGES_OF_PAPER_TEXT,
                                 getMyPaperText(x.p).FIRST_SUBMITTED_DATE,
                                 getMyPaperText(x.p).LAST_REVISED_DATE,
                                 x.p.PAPER_TEXT_WITHDRAWN,
                                 x.p.PAPER_TEXT_WITHDRAWN_DATE,
                                 x.p.PAPER_TEXT_WITHDRAWN_NOTE,
                                 x.p.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT,
                                 x.p.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT_DATE
                             });
            return result.OrderByDescending(x => x.FIRST_SUBMITTED_DATE);
        }

        public MyPaperText getMyPaperText(PAPER_TEXT paperText)
        {
            if (!String.IsNullOrEmpty(paperText.PAPER_TEXT_TITLE_5) || !String.IsNullOrEmpty(paperText.PAPER_TEXT_TITLE_EN_5))
            {
                var myPaper = new MyPaperText(paperText.PAPER_TEXT_TITLE_5, paperText.PAPER_TEXT_TITLE_EN_5, paperText.PAPER_TEXT_5, paperText.PAPER_TEXT_EN_5, paperText.PAPER_TEXT_ATTACHED_FILENAME_5, paperText.NUMBER_OF_PAGES_OF_PAPER_TEXT_5, paperText.FIRST_SUBMITTED_DATE_5, paperText.LAST_REVISED_DATE_5);
                return myPaper;
            }
            else if (!String.IsNullOrEmpty(paperText.PAPER_TEXT_TITLE_4) || !String.IsNullOrEmpty(paperText.PAPER_TEXT_TITLE_EN_4))
            {
                var myPaper = new MyPaperText(paperText.PAPER_TEXT_TITLE_4, paperText.PAPER_TEXT_TITLE_EN_4, paperText.PAPER_TEXT_4, paperText.PAPER_TEXT_EN_4, paperText.PAPER_TEXT_ATTACHED_FILENAME_4, paperText.NUMBER_OF_PAGES_OF_PAPER_TEXT_4, paperText.FIRST_SUBMITTED_DATE_4, paperText.LAST_REVISED_DATE_4);
                return myPaper;
            }
            else if (!String.IsNullOrEmpty(paperText.PAPER_TEXT_TITLE_3) || !String.IsNullOrEmpty(paperText.PAPER_TEXT_TITLE_EN_3))
            {
                var myPaper = new MyPaperText(paperText.PAPER_TEXT_TITLE_3, paperText.PAPER_TEXT_TITLE_EN_3, paperText.PAPER_TEXT_3, paperText.PAPER_TEXT_EN_3, paperText.PAPER_TEXT_ATTACHED_FILENAME_3, paperText.NUMBER_OF_PAGES_OF_PAPER_TEXT_3, paperText.FIRST_SUBMITTED_DATE_3, paperText.LAST_REVISED_DATE_3);
                return myPaper;
            }
            else if (!String.IsNullOrEmpty(paperText.PAPER_TEXT_TITLE_2) || !String.IsNullOrEmpty(paperText.PAPER_TEXT_TITLE_EN_2))
            {
                var myPaper = new MyPaperText(paperText.PAPER_TEXT_TITLE_2, paperText.PAPER_TEXT_TITLE_EN_2, paperText.PAPER_TEXT_2, paperText.PAPER_TEXT_EN_2, paperText.PAPER_TEXT_ATTACHED_FILENAME_2, paperText.NUMBER_OF_PAGES_OF_PAPER_TEXT_2, paperText.FIRST_SUBMITTED_DATE_2, paperText.LAST_REVISED_DATE_2);
                return myPaper;
            }
            else if (!String.IsNullOrEmpty(paperText.PAPER_TEXT_TITLE_1) || !String.IsNullOrEmpty(paperText.PAPER_TEXT_TITLE_EN_1))
            {
                var myPaper = new MyPaperText(paperText.PAPER_TEXT_TITLE_1, paperText.PAPER_TEXT_TITLE_EN_1, paperText.PAPER_TEXT_1, paperText.PAPER_TEXT_EN_1, paperText.PAPER_TEXT_ATTACHED_FILENAME_1, paperText.NUMBER_OF_PAGES_OF_PAPER_TEXT_1, paperText.FIRST_SUBMITTED_DATE_1, paperText.LAST_REVISED_DATE_1);
                return myPaper;
            }

            return new MyPaperText();
        }

        public MyPaperText getMyPaperText(int paperId, int reviewTime)
        {
            var paperText = db.PAPER_TEXT.Find(paperId);
            if (reviewTime == 5)
            {
                var myPaper = new MyPaperText(paperText.PAPER_TEXT_TITLE_5, paperText.PAPER_TEXT_TITLE_EN_5, paperText.PAPER_TEXT_5, paperText.PAPER_TEXT_EN_5, paperText.PAPER_TEXT_ATTACHED_FILENAME_5, paperText.NUMBER_OF_PAGES_OF_PAPER_TEXT_5, paperText.FIRST_SUBMITTED_DATE_5, paperText.LAST_REVISED_DATE_5);
                return myPaper;
            }
            else if (reviewTime == 4)
            {
                var myPaper = new MyPaperText(paperText.PAPER_TEXT_TITLE_4, paperText.PAPER_TEXT_TITLE_EN_4, paperText.PAPER_TEXT_4, paperText.PAPER_TEXT_EN_4, paperText.PAPER_TEXT_ATTACHED_FILENAME_4, paperText.NUMBER_OF_PAGES_OF_PAPER_TEXT_4, paperText.FIRST_SUBMITTED_DATE_4, paperText.LAST_REVISED_DATE_4);
                return myPaper;
            }
            else if (reviewTime == 3)
            {
                var myPaper = new MyPaperText(paperText.PAPER_TEXT_TITLE_3, paperText.PAPER_TEXT_TITLE_EN_3, paperText.PAPER_TEXT_3, paperText.PAPER_TEXT_EN_3, paperText.PAPER_TEXT_ATTACHED_FILENAME_3, paperText.NUMBER_OF_PAGES_OF_PAPER_TEXT_3, paperText.FIRST_SUBMITTED_DATE_3, paperText.LAST_REVISED_DATE_3);
                return myPaper;
            }
            else if (reviewTime == 2)
            {
                var myPaper = new MyPaperText(paperText.PAPER_TEXT_TITLE_2, paperText.PAPER_TEXT_TITLE_EN_2, paperText.PAPER_TEXT_2, paperText.PAPER_TEXT_EN_2, paperText.PAPER_TEXT_ATTACHED_FILENAME_2, paperText.NUMBER_OF_PAGES_OF_PAPER_TEXT_2, paperText.FIRST_SUBMITTED_DATE_2, paperText.LAST_REVISED_DATE_2);
                return myPaper;
            }
            else if (reviewTime == 1)
            {
                var myPaper = new MyPaperText(paperText.PAPER_TEXT_TITLE_1, paperText.PAPER_TEXT_TITLE_EN_1, paperText.PAPER_TEXT_1, paperText.PAPER_TEXT_EN_1, paperText.PAPER_TEXT_ATTACHED_FILENAME_1, paperText.NUMBER_OF_PAGES_OF_PAPER_TEXT_1, paperText.FIRST_SUBMITTED_DATE_1, paperText.LAST_REVISED_DATE_1);
                return myPaper;
            }

            return new MyPaperText();
        }

        public int getTimesSent(PAPER_TEXT paperText)
        {
            if (!String.IsNullOrEmpty(paperText.PAPER_TEXT_TITLE_5) || !String.IsNullOrEmpty(paperText.PAPER_TEXT_TITLE_EN_5))
            {
                return 5;
            }
            else if (!String.IsNullOrEmpty(paperText.PAPER_TEXT_TITLE_4) || !String.IsNullOrEmpty(paperText.PAPER_TEXT_TITLE_EN_4))
            {
                return 4;
            }
            else if (!String.IsNullOrEmpty(paperText.PAPER_TEXT_TITLE_3) || !String.IsNullOrEmpty(paperText.PAPER_TEXT_TITLE_EN_3))
            {
                return 3;
            }
            else if (!String.IsNullOrEmpty(paperText.PAPER_TEXT_TITLE_2) || !String.IsNullOrEmpty(paperText.PAPER_TEXT_TITLE_EN_2))
            {
                return 2;
            }
            else if (!String.IsNullOrEmpty(paperText.PAPER_TEXT_TITLE_1) || !String.IsNullOrEmpty(paperText.PAPER_TEXT_TITLE_EN_1))
            {
                return 1;
            }
            return 0;
        }

        //Trả về true là còn hạn, false là hết hạn gửi bài báo
        public bool checkConferencePaperTextSubmitExpired(int conferenceId)
        {
            try
            {
                var conference = db.CONFERENCEs.Find(conferenceId);
                if (DateTime.Now <= conference.PAPER_TEXT_DEADLINE_1 || DateTime.Now <= conference.PAPER_TEXT_DEADLINE_2 || DateTime.Now <= conference.PAPER_TEXT_DEADLINE_3
                    || DateTime.Now <= conference.PAPER_TEXT_DEADLINE_4 || DateTime.Now <= conference.PAPER_TEXT_DEADLINE_5)
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

        //Trả về true tác giả này đã phân cho bài báo này, và ngược lại
        public bool checkAuthor(int personId, int conferenceId, decimal paperId)
        {
            try
            {
                var authorRe = db.AUTHOR_PAPER_TEXT_RELATIONSHIP.Where(x => x.PERSON_ID == personId && x.PAPER_ID == paperId && x.CONFERENCE_ID == conferenceId).ToList();
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

        public void addAuthorPaperText(Author item, int conferenceId, decimal paperId, int authorNumber)
        {
            var author = new AUTHOR_PAPER_TEXT_RELATIONSHIP();
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
            db.AUTHOR_PAPER_TEXT_RELATIONSHIP.Add(author);
            db.SaveChanges();
        }

        //Trả về true là bài báo đã review, ngược lại chưa được review
        public bool checkPaperTextReviewed(int paperId, int conferenceId, int deadLineNumber)
        {
            try
            {
                var result = db.REVIEWER_PAPER_TEXT_RELATIONSHIP.Where(x => x.PAPER_ID == paperId && x.CONFERENCE_ID == conferenceId && x.PAPER_TEXT_SUBMISSION_DEADLINE_ORDER_NUMBER == deadLineNumber && x.PROPOSED_REVISED_CONFERENCE_SESSION_TOPIC_ID != null).ToList();
                if (result.Count > 0)
                {
                    return true;
                }
                var result2 = db.PAPER_TEXT.Where(x => x.PAPER_ID == paperId && x.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT != null).ToList();
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

        //Kiểm tra bài báo đã được gán người này review chưa, true là rồi, false là chưa
        public bool checkIsassignedReviewerUpdate(decimal personId, decimal conferenceId, decimal paperId, int deadLineNumber)
        {
            try
            {
                var result = db.REVIEWER_PAPER_TEXT_RELATIONSHIP.Where(x => x.PAPER_ID == paperId && x.CONFERENCE_ID == conferenceId && x.PERSON_ID == personId && x.PAPER_TEXT_SUBMISSION_DEADLINE_ORDER_NUMBER == deadLineNumber).ToList();
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
            var list = db.REVIEWER_PAPER_TEXT_RELATIONSHIP.Where(x => x.PAPER_ID == paperId).ToList();
            if (list.Count > 0)
            {
                foreach (REVIEWER_PAPER_TEXT_RELATIONSHIP item in list)
                {
                    var review = new REVIEWER_PAPER_TEXT_RELATIONSHIP();
                    review.PERSON_ID = item.PERSON_ID;
                    review.CONFERENCE_BOARD_OF_REVIEW_ID = item.CONFERENCE_BOARD_OF_REVIEW_ID;
                    review.CONFERENCE_ID = item.CONFERENCE_ID;
                    review.PAPER_ID = paperId;
                    review.PAPER_TEXT_SUBMISSION_DEADLINE_ORDER_NUMBER = deadlineNumber;
                    if (this.checkIsassignedReviewerUpdate(review.PERSON_ID, review.CONFERENCE_ID, review.PAPER_ID, review.PAPER_TEXT_SUBMISSION_DEADLINE_ORDER_NUMBER) == false)
                    {
                        db.REVIEWER_PAPER_TEXT_RELATIONSHIP.Add(review);
                        db.SaveChanges();
                    }
                }
            }
        }

        //Kiểm tra bài báo đã được gán board of review chưa, true là rồi, false là chưa
        public bool checkIsassignedBoardReviewerUpdate(decimal boardOfReviewId, decimal conferenceId, decimal paperId, int deadLineNumber)
        {
            try
            {
                var result = db.PAPER_REVIEW_SUMUP_BY_CONFERENCE_BOARD_OF_REVIEW.Where(x => x.PAPER_ID == paperId && x.CONFERENCE_ID == conferenceId && x.CONFERENCE_BOARD_OF_REVIEW_ID == boardOfReviewId && x.PAPER_TEXT_SUBMISSION_DEADLINE_ORDER_NUMBER == deadLineNumber).ToList();
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

        public void assignedBoardOfReviewerUpdate(decimal paperId, Int16 deadlineNumber)
        {
            var list = db.PAPER_REVIEW_SUMUP_BY_CONFERENCE_BOARD_OF_REVIEW.Where(x => x.PAPER_ID == paperId).ToList();
            if (list.Count > 0)
            {
                foreach (PAPER_REVIEW_SUMUP_BY_CONFERENCE_BOARD_OF_REVIEW item in list)
                {
                    var review = new PAPER_REVIEW_SUMUP_BY_CONFERENCE_BOARD_OF_REVIEW();
                    review.CONFERENCE_BOARD_OF_REVIEW_ID = item.CONFERENCE_BOARD_OF_REVIEW_ID;
                    review.CONFERENCE_ID = item.CONFERENCE_ID;
                    review.PAPER_ID = paperId;
                    review.PAPER_TEXT_SUBMISSION_DEADLINE_ORDER_NUMBER = deadlineNumber;
                    if (this.checkIsassignedBoardReviewerUpdate(review.CONFERENCE_BOARD_OF_REVIEW_ID, review.CONFERENCE_ID, review.PAPER_ID, review.PAPER_TEXT_SUBMISSION_DEADLINE_ORDER_NUMBER) == false)
                    {
                        db.PAPER_REVIEW_SUMUP_BY_CONFERENCE_BOARD_OF_REVIEW.Add(review);
                        db.SaveChanges();
                    }
                }
            }
        }


    }

    public class MyPaperText
    {
        public string PAPER_TEXT_TITLE { get; set; }
        public string PAPER_TEXT_TITLE_EN { get; set; }
        public string PAPER_TEXT { get; set; }
        public string PAPER_TEXT_EN { get; set; }
        public string PAPER_TEXT_ATTACHED_FILENAME { get; set; }
        public short? NUMBER_OF_PAGES_OF_PAPER_TEXT { get; set; }
        public DateTime? FIRST_SUBMITTED_DATE { get; set; }
        public DateTime? LAST_REVISED_DATE { get; set; }

        public MyPaperText()
        {

        }

        public MyPaperText(string PAPER_TEXT_TITLE, string PAPER_TEXT_TITLE_EN, string PAPER_TEXT, string PAPER_TEXT_EN, string PAPER_TEXT_ATTACHED_FILENAME,
            short? NUMBER_OF_PAGES_OF_PAPER_TEXT, DateTime? FIRST_SUBMITTED_DATE, DateTime? LAST_REVISED_DATE)
        {
            this.PAPER_TEXT_TITLE = PAPER_TEXT_TITLE;
            this.PAPER_TEXT_TITLE_EN = PAPER_TEXT_TITLE_EN;
            this.PAPER_TEXT = PAPER_TEXT;
            this.PAPER_TEXT_EN = PAPER_TEXT_EN;
            this.PAPER_TEXT_ATTACHED_FILENAME = PAPER_TEXT_ATTACHED_FILENAME;
            this.NUMBER_OF_PAGES_OF_PAPER_TEXT = NUMBER_OF_PAGES_OF_PAPER_TEXT;
            this.FIRST_SUBMITTED_DATE = FIRST_SUBMITTED_DATE;
            this.LAST_REVISED_DATE = LAST_REVISED_DATE;
        }
    }

}