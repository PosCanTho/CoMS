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
    public class AuthorAbstractModel
    {
        private DB db;

        public AuthorAbstractModel()
        {
            db = new DB();
        }

        public PAPER_ABSTRACT GetPaperAbstractById(int id)
        {
            return db.PAPER_ABSTRACT.Find(id);
        }


        // Rút bài và thay đổi trạng thái trong csdl
        public bool WithdrawnPaperAbstract(int id)
        {
            try
            {
                var paperAbstract = GetPaperAbstractById(id);
                paperAbstract.PAPER_ABSTRACT_WITHDRAWN = true;
                paperAbstract.PAPER_ABSTRACT_WITHDRAWN_DATE = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        

        // update abstract
        public bool UpdateAbstractById(int PAPER_ID, String PAPER_ABSTRACT_TITLE, String PAPER_ABSTRACT_TITLE_EN, int CONFERENCE_SESSION_TOPIC_ID,
            String CONFERENCE_SESSION_TOPIC_NAME, String CONFERENCE_SESSION_TOPIC_NAME_EN, String PAPER_ABSTRACT_TEXT, String FULL_PAPER_OR_WORK_IN_PROGRESS,
            int TYPE_OF_STUDY_ID, String TYPE_OF_STUDY_NAME, String TYPE_OF_STUDY_NAME_EN, int CONFERENCE_PRESENTATION_TYPE_ID, String CONFERENCE_PRESENTATION_TYPE_NAME,
            String CONFERENCE_PRESENTATION_TYPE_NAME_EN, int POSITION)
        {
            try
            {


                var paperAbstract = GetPaperAbstractById(PAPER_ID);
                switch (POSITION)
                {
                    case 1:
                        paperAbstract.PAPER_ABSTRACT_TITLE_1 = PAPER_ABSTRACT_TITLE;
                        paperAbstract.PAPER_ABSTRACT_TITLE_EN_1 = PAPER_ABSTRACT_TITLE_EN;
                        paperAbstract.CONFERENCE_SESSION_TOPIC_ID_1 = CONFERENCE_SESSION_TOPIC_ID;
                        paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_1 = CONFERENCE_SESSION_TOPIC_NAME;
                        paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_EN_1 = CONFERENCE_SESSION_TOPIC_NAME_EN;
                        paperAbstract.PAPER_ABSTRACT_TEXT_1 = PAPER_ABSTRACT_TEXT;
                        paperAbstract.FULL_PAPER_OR_WORK_IN_PROGRESS_1 = FULL_PAPER_OR_WORK_IN_PROGRESS;
                        paperAbstract.TYPE_OF_STUDY_ID_1 = TYPE_OF_STUDY_ID;
                        paperAbstract.TYPE_OF_STUDY_NAME_1 = TYPE_OF_STUDY_NAME;
                        paperAbstract.TYPE_OF_STUDY_NAME_EN_1 = TYPE_OF_STUDY_NAME_EN;
                        paperAbstract.CONFERENCE_PRESENTATION_TYPE_ID_1 = CONFERENCE_PRESENTATION_TYPE_ID;
                        paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_1 = CONFERENCE_PRESENTATION_TYPE_NAME;
                        paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_EN_1 = CONFERENCE_PRESENTATION_TYPE_NAME_EN;
                        paperAbstract.LAST_REVISED_DATE_1 = DateTime.Now;
                        break;
                    case 2:
                        paperAbstract.PAPER_ABSTRACT_TITLE_2 = PAPER_ABSTRACT_TITLE;
                        paperAbstract.PAPER_ABSTRACT_TITLE_EN_2 = PAPER_ABSTRACT_TITLE_EN;
                        paperAbstract.CONFERENCE_SESSION_TOPIC_ID_2 = CONFERENCE_SESSION_TOPIC_ID;
                        paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_2 = CONFERENCE_SESSION_TOPIC_NAME;
                        paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_EN_2 = CONFERENCE_SESSION_TOPIC_NAME_EN;
                        paperAbstract.PAPER_ABSTRACT_TEXT_2 = PAPER_ABSTRACT_TEXT;
                        paperAbstract.FULL_PAPER_OR_WORK_IN_PROGRESS_2 = FULL_PAPER_OR_WORK_IN_PROGRESS;
                        paperAbstract.TYPE_OF_STUDY_ID_2 = TYPE_OF_STUDY_ID;
                        paperAbstract.TYPE_OF_STUDY_NAME_2 = TYPE_OF_STUDY_NAME;
                        paperAbstract.TYPE_OF_STUDY_NAME_EN_2 = TYPE_OF_STUDY_NAME_EN;
                        paperAbstract.CONFERENCE_PRESENTATION_TYPE_ID_2 = CONFERENCE_PRESENTATION_TYPE_ID;
                        paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_2 = CONFERENCE_PRESENTATION_TYPE_NAME;
                        paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_EN_2 = CONFERENCE_PRESENTATION_TYPE_NAME_EN;
                        paperAbstract.LAST_REVISED_DATE_2 = DateTime.Now;
                        break;
                    case 3:
                        paperAbstract.PAPER_ABSTRACT_TITLE_2 = PAPER_ABSTRACT_TITLE;
                        paperAbstract.PAPER_ABSTRACT_TITLE_EN_2 = PAPER_ABSTRACT_TITLE_EN;
                        paperAbstract.CONFERENCE_SESSION_TOPIC_ID_2 = CONFERENCE_SESSION_TOPIC_ID;
                        paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_2 = CONFERENCE_SESSION_TOPIC_NAME;
                        paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_EN_2 = CONFERENCE_SESSION_TOPIC_NAME_EN;

                        paperAbstract.PAPER_ABSTRACT_TEXT_3 = PAPER_ABSTRACT_TEXT;
                        paperAbstract.FULL_PAPER_OR_WORK_IN_PROGRESS_3 = FULL_PAPER_OR_WORK_IN_PROGRESS;
                        paperAbstract.TYPE_OF_STUDY_ID_3 = TYPE_OF_STUDY_ID;
                        paperAbstract.TYPE_OF_STUDY_NAME_3 = TYPE_OF_STUDY_NAME;
                        paperAbstract.TYPE_OF_STUDY_NAME_EN_3 = TYPE_OF_STUDY_NAME_EN;
                        paperAbstract.CONFERENCE_PRESENTATION_TYPE_ID_3 = CONFERENCE_PRESENTATION_TYPE_ID;
                        paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_3 = CONFERENCE_PRESENTATION_TYPE_NAME;
                        paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_EN_3 = CONFERENCE_PRESENTATION_TYPE_NAME_EN;
                        paperAbstract.LAST_REVISED_DATE_3 = DateTime.Now;
                        break;
                    case 4:
                        paperAbstract.PAPER_ABSTRACT_TITLE_2 = PAPER_ABSTRACT_TITLE;
                        paperAbstract.PAPER_ABSTRACT_TITLE_EN_2 = PAPER_ABSTRACT_TITLE_EN;
                        paperAbstract.CONFERENCE_SESSION_TOPIC_ID_2 = CONFERENCE_SESSION_TOPIC_ID;
                        paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_2 = CONFERENCE_SESSION_TOPIC_NAME;
                        paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_EN_2 = CONFERENCE_SESSION_TOPIC_NAME_EN;

                        paperAbstract.PAPER_ABSTRACT_TEXT_4 = PAPER_ABSTRACT_TEXT;
                        paperAbstract.FULL_PAPER_OR_WORK_IN_PROGRESS_4 = FULL_PAPER_OR_WORK_IN_PROGRESS;
                        paperAbstract.TYPE_OF_STUDY_ID_4 = TYPE_OF_STUDY_ID;
                        paperAbstract.TYPE_OF_STUDY_NAME_4 = TYPE_OF_STUDY_NAME;
                        paperAbstract.TYPE_OF_STUDY_NAME_EN_4 = TYPE_OF_STUDY_NAME_EN;
                        paperAbstract.CONFERENCE_PRESENTATION_TYPE_ID_4 = CONFERENCE_PRESENTATION_TYPE_ID;
                        paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_4 = CONFERENCE_PRESENTATION_TYPE_NAME;
                        paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_EN_4 = CONFERENCE_PRESENTATION_TYPE_NAME_EN;
                        paperAbstract.LAST_REVISED_DATE_4 = DateTime.Now;
                        break;
                    case 5:
                        paperAbstract.PAPER_ABSTRACT_TITLE_2 = PAPER_ABSTRACT_TITLE;
                        paperAbstract.PAPER_ABSTRACT_TITLE_EN_2 = PAPER_ABSTRACT_TITLE_EN;
                        paperAbstract.CONFERENCE_SESSION_TOPIC_ID_2 = CONFERENCE_SESSION_TOPIC_ID;
                        paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_2 = CONFERENCE_SESSION_TOPIC_NAME;
                        paperAbstract.CONFERENCE_SESSION_TOPIC_NAME_EN_2 = CONFERENCE_SESSION_TOPIC_NAME_EN;

                        paperAbstract.PAPER_ABSTRACT_TEXT_5 = PAPER_ABSTRACT_TEXT;
                        paperAbstract.FULL_PAPER_OR_WORK_IN_PROGRESS_5 = FULL_PAPER_OR_WORK_IN_PROGRESS;
                        paperAbstract.TYPE_OF_STUDY_ID_5 = TYPE_OF_STUDY_ID;
                        paperAbstract.TYPE_OF_STUDY_NAME_5 = TYPE_OF_STUDY_NAME;
                        paperAbstract.TYPE_OF_STUDY_NAME_EN_5 = TYPE_OF_STUDY_NAME_EN;
                        paperAbstract.CONFERENCE_PRESENTATION_TYPE_ID_5 = CONFERENCE_PRESENTATION_TYPE_ID;
                        paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_5 = CONFERENCE_PRESENTATION_TYPE_NAME;
                        paperAbstract.CONFERENCE_PRESENTATION_TYPE_NAME_EN_5 = CONFERENCE_PRESENTATION_TYPE_NAME_EN;
                        paperAbstract.LAST_REVISED_DATE_5 = DateTime.Now;
                        break;
                }
                paperAbstract.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT = null;
                paperAbstract.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_DATE = null;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }




    }
}