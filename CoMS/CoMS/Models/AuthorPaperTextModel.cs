using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoMS.Entities_Framework;
using System.Text;
using System.Collections;
using System.Collections.Generic;



namespace CoMS.Models
{
    public class AuthorPaperTextModel
    {
        private DB db;

        public AuthorPaperTextModel()
        {
            db = new DB();
        }


        public bool Register(PAPER_TEXT paper)
        {
            try
            {
                db.PAPER_TEXT.Add(paper);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public PAPER_TEXT GetPaperTextById(int id)
        {
            return db.PAPER_TEXT.Find(id);
        }

        public bool SavePaper(
                    int PAPER_ID,
                    String PAPER_TEXT_TITLE,
                    String PAPER_TEXT_TITLE_EN,
                    String PAPER_TEXT,
                    int FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_ID,
                    String FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_NAME,
                    String FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_NAME_EN,
                    String FINAL_APPROVED_FULL_PAPER_OR_WORK_IN_PROGRESS,
                    int FINAL_APPROVED_TYPE_OF_STUDY_ID,
                    String FINAL_APPROVED_TYPE_OF_STUDY_NAME,
                    String FINAL_APPROVED_TYPE_OF_STUDY_NAME_EN,
                    int FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_ID,
                    String FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_NAME,
                    String FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_NAME_EN,
                    int POSITION
            )
        {
            try
            {
                var newPAPER = new PAPER_TEXT();
                newPAPER.PAPER_ID = PAPER_ID;

                switch (POSITION)
                {
                    case 1:
                        newPAPER.PAPER_TEXT_TITLE_1 = PAPER_TEXT_TITLE;
                        newPAPER.PAPER_TEXT_TITLE_EN_1 = PAPER_TEXT_TITLE_EN;
                        newPAPER.PAPER_TEXT_1 = PAPER_TEXT;
                        newPAPER.PAPER_TEXT_EN_1 = null;
                        newPAPER.FIRST_SUBMITTED_DATE_1 = DateTime.Now;
                        newPAPER.LAST_REVISED_DATE_1 = DateTime.Now;
                        break;
                    case 2:
                        newPAPER.PAPER_TEXT_TITLE_2 = PAPER_TEXT_TITLE;
                        newPAPER.PAPER_TEXT_TITLE_EN_2 = PAPER_TEXT_TITLE_EN;
                        newPAPER.PAPER_TEXT_2 = PAPER_TEXT;
                        newPAPER.PAPER_TEXT_EN_2 = null;
                        newPAPER.FIRST_SUBMITTED_DATE_2 = DateTime.Now;
                        newPAPER.LAST_REVISED_DATE_2 = DateTime.Now;
                        break;
                    case 3:
                        newPAPER.PAPER_TEXT_TITLE_3 = PAPER_TEXT_TITLE;
                        newPAPER.PAPER_TEXT_TITLE_EN_3 = PAPER_TEXT_TITLE_EN;
                        newPAPER.PAPER_TEXT_3 = PAPER_TEXT;
                        newPAPER.PAPER_TEXT_EN_3 = null;
                        newPAPER.FIRST_SUBMITTED_DATE_3 = DateTime.Now;
                        newPAPER.LAST_REVISED_DATE_3 = DateTime.Now;
                        break;
                    case 4:
                        newPAPER.PAPER_TEXT_TITLE_4 = PAPER_TEXT_TITLE;
                        newPAPER.PAPER_TEXT_TITLE_EN_4 = PAPER_TEXT_TITLE_EN;
                        newPAPER.PAPER_TEXT_4 = PAPER_TEXT;
                        newPAPER.PAPER_TEXT_EN_4 = null;
                        newPAPER.FIRST_SUBMITTED_DATE_4 = DateTime.Now;
                        newPAPER.LAST_REVISED_DATE_4 = DateTime.Now;
                        break;
                    case 5:
                        newPAPER.PAPER_TEXT_TITLE_5 = PAPER_TEXT_TITLE;
                        newPAPER.PAPER_TEXT_TITLE_EN_5 = PAPER_TEXT_TITLE_EN;
                        newPAPER.PAPER_TEXT_5 = PAPER_TEXT;
                        newPAPER.PAPER_TEXT_EN_5 = null;
                        newPAPER.FIRST_SUBMITTED_DATE_5 = DateTime.Now;
                        newPAPER.LAST_REVISED_DATE_5 = DateTime.Now;
                        break;
                }
                newPAPER.FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_ID = FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_ID;
                newPAPER.FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_NAME = FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_NAME;
                newPAPER.FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_NAME_EN = FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_NAME_EN;
                newPAPER.FINAL_APPROVED_FULL_PAPER_OR_WORK_IN_PROGRESS = FINAL_APPROVED_FULL_PAPER_OR_WORK_IN_PROGRESS;
                newPAPER.FINAL_APPROVED_TYPE_OF_STUDY_ID = FINAL_APPROVED_TYPE_OF_STUDY_ID;
                newPAPER.FINAL_APPROVED_TYPE_OF_STUDY_NAME = FINAL_APPROVED_TYPE_OF_STUDY_NAME;
                newPAPER.FINAL_APPROVED_TYPE_OF_STUDY_NAME_EN = FINAL_APPROVED_TYPE_OF_STUDY_NAME_EN;
                newPAPER.FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_ID = FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_ID;
                newPAPER.FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_NAME = FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_NAME;
                newPAPER.FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_NAME_EN = FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_NAME_EN;

                db.PAPER_TEXT.Add(newPAPER);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public bool UpdatePaperText(
                    int PAPER_ID,
                    String PAPER_TEXT_TITLE,
                    String PAPER_TEXT_TITLE_EN,
                    String PAPER_TEXT,
                    int FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_ID,
                    String FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_NAME,
                    String FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_NAME_EN,
                    String FINAL_APPROVED_FULL_PAPER_OR_WORK_IN_PROGRESS,
                    int FINAL_APPROVED_TYPE_OF_STUDY_ID,
                    String FINAL_APPROVED_TYPE_OF_STUDY_NAME,
                    String FINAL_APPROVED_TYPE_OF_STUDY_NAME_EN,
                    int FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_ID,
                    String FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_NAME,
                    String FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_NAME_EN,
                    int POSITION
            )
        {
            return true;
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

    }
}