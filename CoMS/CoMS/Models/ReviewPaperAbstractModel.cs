using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoMS.Entities_Framework;
using CoMS.Resources;
using CoMS.Untils;
using System.Text;

namespace CoMS.Models
{
    public class ReviewPaperAbstractModel
    {
        private DB db;

        public ReviewPaperAbstractModel()
        {
            db = new DB();
        }

        //public int GetAuThorAbstractRelationshipByIdPerson(int PERSON_ID)
        //{
        //    var t = from paper in db.AUTHOR_PAPER_ABSTRACT_RELATIONSHIP
        //            where paper.PERSON_ID == PERSON_ID
        //            select new { paper.PAPER_ID };

        //}
        //public REVIEWER_PAPER_ABSTRACT_RELATIONSHIP SeeReviewAbstract(int PERSON_ID, int CONFERENCE_BOARD_OF_REVIEW_ID, int CONFERENCE_ID,
        //   bool APPROVED
        //   )
        //{
        //    var review = from review_paper_abstract in db.REVIEWER_PAPER_ABSTRACT_RELATIONSHIP
        //                 where review_paper_abstract.PERSON_ID == PERSON_ID &&
        //                 review_paper_abstract.CONFERENCE_BOARD_OF_REVIEW_ID == CONFERENCE_BOARD_OF_REVIEW_ID &&
        //                 review_paper_abstract.CONFERENCE_ID == CONFERENCE_ID &&
        //                 review_paper_abstract.APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT == APPROVED
        //                 select review_paper_abstract;
        //    return review;
        //}

        public bool ReviewPaperAbstract(
                    int PERSON_ID ,
                    int CONFERENCE_BOARD_OF_REVIEW_ID,
                    int CONFERENCE_ID,
                    int PAPER_ID,
                    int PROPOSED_CONFERENCE_SESSION_TOPIC_ID,
                    String PROPOSED_CONFERENCE_SESSION_TOPIC_NAME,
                    String PROPOSED_CONFERENCE_SESSION_TOPIC_NAME_EN,
                    int PROPOSED_TYPE_OF_STUDY_ID ,
                    String PROPOSED_TYPE_OF_STUDY_NAME,
                    String PROPOSED_TYPE_OF_STUDY_NAME_EN,
                    Boolean PROPOSED_FOR_PRESENTATION,
                    int PROPOSED_CONFERENCE_PRESENTATION_TYPE_ID,
                    String PROPOSED_CONFERENCE_PRESENTATION_TYPE_NAME,
                    String PROPOSED_CONFERENCE_PRESENTATION_TYPE_NAME_EN,
                    int PAPER_ABSTRACT_REVIEW_RATING_POINT,
                    String SIGNIFICANT_REVISION_OR_MINIMAL_REVISION_OR_REVISION_NEEDED_OR_NO_REVISION_NEEDED,
                    String REVIEW_TEXT,
                    String REVIEW_TEXT_EN,
                    bool APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT
            )
        {
            try
            {
                var idx = from review in db.REVIEWER_PAPER_ABSTRACT_RELATIONSHIP
                          where review.PERSON_ID == PERSON_ID &&
                            review.CONFERENCE_BOARD_OF_REVIEW_ID == CONFERENCE_BOARD_OF_REVIEW_ID &&
                            review.CONFERENCE_ID == CONFERENCE_ID
                          select new { review.PAPER_ABSTRACT_SUBMISSION_DEADLINE_ORDER_NUMBER };

                if (idx == null)
                {
                    var item = new REVIEWER_PAPER_ABSTRACT_RELATIONSHIP();
                    item.PERSON_ID = PERSON_ID;
                    item.CONFERENCE_BOARD_OF_REVIEW_ID = CONFERENCE_BOARD_OF_REVIEW_ID;
                    item.CONFERENCE_ID = CONFERENCE_ID;
                    item.PAPER_ABSTRACT_SUBMISSION_DEADLINE_ORDER_NUMBER = 1;
                    item.REVIEWED_DATE = DateTime.Now;
                    item.PROPOSED_CONFERENCE_SESSION_TOPIC_ID = PROPOSED_CONFERENCE_SESSION_TOPIC_ID;
                    item.PROPOSED_CONFERENCE_SESSION_TOPIC_NAME = PROPOSED_CONFERENCE_SESSION_TOPIC_NAME;
                    item.PROPOSED_CONFERENCE_SESSION_TOPIC_NAME_EN = PROPOSED_CONFERENCE_SESSION_TOPIC_NAME_EN;
                    item.PROPOSED_TYPE_OF_STUDY_ID = PROPOSED_TYPE_OF_STUDY_ID;
                    item.PROPOSED_TYPE_OF_STUDY_NAME = PROPOSED_TYPE_OF_STUDY_NAME;
                    item.PROPOSED_TYPE_OF_STUDY_NAME_EN = PROPOSED_TYPE_OF_STUDY_NAME_EN;
                    if (PROPOSED_FOR_PRESENTATION == true)
                    {
                        item.PROPOSED_CONFERENCE_PRESENTATION_TYPE_ID = PROPOSED_CONFERENCE_PRESENTATION_TYPE_ID;
                        item.PROPOSED_CONFERENCE_PRESENTATION_TYPE_NAME = PROPOSED_CONFERENCE_PRESENTATION_TYPE_NAME;
                        item.PROPOSED_CONFERENCE_PRESENTATION_TYPE_NAME_EN = PROPOSED_CONFERENCE_PRESENTATION_TYPE_NAME_EN;
                    }
                    item.PAPER_ABSTRACT_REVIEW_RATING_POINT = PAPER_ABSTRACT_REVIEW_RATING_POINT;
                    item.SIGNIFICANT_REVISION_OR_MINIMAL_REVISION_OR_REVISION_NEEDED_OR_NO_REVISION_NEEDED = SIGNIFICANT_REVISION_OR_MINIMAL_REVISION_OR_REVISION_NEEDED_OR_NO_REVISION_NEEDED;
                    item.REVIEW_TEXT = REVIEW_TEXT;
                    item.REVIEW_TEXT_EN = REVIEW_TEXT_EN;
                    item.APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT = APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT;
                    item.APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_DATE = DateTime.Now;

                    db.REVIEWER_PAPER_ABSTRACT_RELATIONSHIP.Add(item);
                    db.SaveChanges();

                    
                    return true;
                }
                else
                {
                    foreach (var t in idx)
                    {
                        var item = new REVIEWER_PAPER_ABSTRACT_RELATIONSHIP();
                        item.PERSON_ID = PERSON_ID;
                        item.CONFERENCE_BOARD_OF_REVIEW_ID = CONFERENCE_BOARD_OF_REVIEW_ID;
                        item.CONFERENCE_ID = CONFERENCE_ID;
                        item.PAPER_ABSTRACT_SUBMISSION_DEADLINE_ORDER_NUMBER = Convert.ToInt16(t.PAPER_ABSTRACT_SUBMISSION_DEADLINE_ORDER_NUMBER + 1);
                        item.REVIEWED_DATE = DateTime.Now;
                        item.PROPOSED_CONFERENCE_SESSION_TOPIC_ID = PROPOSED_CONFERENCE_SESSION_TOPIC_ID;
                        item.PROPOSED_CONFERENCE_SESSION_TOPIC_NAME = PROPOSED_CONFERENCE_SESSION_TOPIC_NAME;
                        item.PROPOSED_CONFERENCE_SESSION_TOPIC_NAME_EN = PROPOSED_CONFERENCE_SESSION_TOPIC_NAME_EN;
                        item.PROPOSED_TYPE_OF_STUDY_ID = PROPOSED_TYPE_OF_STUDY_ID;
                        item.PROPOSED_TYPE_OF_STUDY_NAME = PROPOSED_TYPE_OF_STUDY_NAME;
                        item.PROPOSED_TYPE_OF_STUDY_NAME_EN = PROPOSED_TYPE_OF_STUDY_NAME_EN;
                        if (PROPOSED_FOR_PRESENTATION == true)
                        {
                            item.PROPOSED_CONFERENCE_PRESENTATION_TYPE_ID = PROPOSED_CONFERENCE_PRESENTATION_TYPE_ID;
                            item.PROPOSED_CONFERENCE_PRESENTATION_TYPE_NAME = PROPOSED_CONFERENCE_PRESENTATION_TYPE_NAME;
                            item.PROPOSED_CONFERENCE_PRESENTATION_TYPE_NAME_EN = PROPOSED_CONFERENCE_PRESENTATION_TYPE_NAME_EN;
                        }
                        item.PAPER_ABSTRACT_REVIEW_RATING_POINT = PAPER_ABSTRACT_REVIEW_RATING_POINT;
                        item.SIGNIFICANT_REVISION_OR_MINIMAL_REVISION_OR_REVISION_NEEDED_OR_NO_REVISION_NEEDED = SIGNIFICANT_REVISION_OR_MINIMAL_REVISION_OR_REVISION_NEEDED_OR_NO_REVISION_NEEDED;
                        item.REVIEW_TEXT = REVIEW_TEXT;
                        item.REVIEW_TEXT_EN = REVIEW_TEXT_EN;
                        item.APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT = APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT;
                        item.APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_DATE = DateTime.Now;

                        db.REVIEWER_PAPER_ABSTRACT_RELATIONSHIP.Add(item);
                        db.SaveChanges();

                        //PAPER_ABSTRACT paper = db.PAPER_ABSTRACT.Find(PAPER_ID);
                        //paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT = APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT;
                        //paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_DATE = DateTime.Now;
                        //paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_REVIEWER_PERSON_ID = PERSON_ID;
                        //db.SaveChanges();

                        break;
                    }
                    return true;

                }
            }
            catch (Exception)
            {
                return false;
            }
            
            
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
            public int PROPOSED_TYPE_OF_STUDY_ID { get; set; }
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