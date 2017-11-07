using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoMS.Entities_Framework;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using CoMS.Untils;



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
            var result = db.PAPER_TEXT.SingleOrDefault(x => x.PAPER_ID == id);
            return result;
        }


        public bool UpdateItemPaperText(int PAPER_ID,
                    String PAPER_TEXT_TITLE,
                    String PAPER_TEXT_TITLE_EN,
                    int CONFERENCE_ID,
                    String PAPER_TEXT,
                    String PAPER_TEXT_EN,
                    String PAPER_TEXT_ATTACHED_FILENAME,
                    int POSITION)
        {
            var result = GetPaperTextById(PAPER_ID);
            if (result != null)
            {
                switch (POSITION)
                {
                    case 1:
                        result.PAPER_TEXT_TITLE_1 = PAPER_TEXT_TITLE;
                        result.PAPER_TEXT_TITLE_EN_1 = PAPER_TEXT_TITLE_EN;
                        result.PAPER_TEXT_1 = PAPER_TEXT;
                        result.PAPER_TEXT_EN_1 = PAPER_TEXT_EN;
                        result.PAPER_TEXT_ATTACHED_FILENAME_1 = PAPER_TEXT_ATTACHED_FILENAME;
                        result.LAST_REVISED_DATE_1 = DateTime.Now;
                        break;
                    case 2:
                        result.PAPER_TEXT_TITLE_2 = PAPER_TEXT_TITLE;
                        result.PAPER_TEXT_TITLE_EN_2 = PAPER_TEXT_TITLE_EN;
                        result.PAPER_TEXT_2 = PAPER_TEXT;
                        result.PAPER_TEXT_EN_2 = PAPER_TEXT_EN;
                        result.PAPER_TEXT_ATTACHED_FILENAME_2 = PAPER_TEXT_ATTACHED_FILENAME;
                        result.LAST_REVISED_DATE_2 = DateTime.Now;
                        break;
                    case 3:
                        result.PAPER_TEXT_TITLE_3 = PAPER_TEXT_TITLE;
                        result.PAPER_TEXT_TITLE_EN_3 = PAPER_TEXT_TITLE_EN;
                        result.PAPER_TEXT_3 = PAPER_TEXT;
                        result.PAPER_TEXT_EN_3 = PAPER_TEXT_EN;
                        result.PAPER_TEXT_ATTACHED_FILENAME_3 = PAPER_TEXT_ATTACHED_FILENAME;
                        result.LAST_REVISED_DATE_3 = DateTime.Now;
                        break;
                    case 4:
                        result.PAPER_TEXT_TITLE_4 = PAPER_TEXT_TITLE;
                        result.PAPER_TEXT_TITLE_EN_4 = PAPER_TEXT_TITLE_EN;
                        result.PAPER_TEXT_4 = PAPER_TEXT;
                        result.PAPER_TEXT_EN_4 = PAPER_TEXT_EN;
                        result.PAPER_TEXT_ATTACHED_FILENAME_4 = PAPER_TEXT_ATTACHED_FILENAME;
                        result.LAST_REVISED_DATE_4 = DateTime.Now;
                        break;
                    case 5:
                        result.PAPER_TEXT_TITLE_5 = PAPER_TEXT_TITLE;
                        result.PAPER_TEXT_TITLE_EN_5 = PAPER_TEXT_TITLE_EN;
                        result.PAPER_TEXT_5 = PAPER_TEXT;
                        result.PAPER_TEXT_EN_5 = PAPER_TEXT_EN;
                        result.PAPER_TEXT_ATTACHED_FILENAME_5 = PAPER_TEXT_ATTACHED_FILENAME;
                        result.LAST_REVISED_DATE_5 = DateTime.Now;
                        break;
                }

                db.SaveChanges();
                return true;

            }
            else
            {
                return false;
            }
        }

        public bool WithdrawnPaperText(int id)
        {
            try
            {
                var paper = GetPaperTextById(id);
                paper.PAPER_TEXT_WITHDRAWN = true;
                paper.PAPER_TEXT_WITHDRAWN_DATE = DateTime.Now;
                string value = id + "-" + 1 + "-" + "PAPER_TEXT_WITHDRAWN";
                paper.PAPER_TEXT_WITHDRAWN_SCRIPT = Utils.EncryptMd5(value);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SavePaper(
                    int PAPER_ID,
                    String PAPER_TEXT_TITLE,
                    String PAPER_TEXT_TITLE_EN,
                    String PAPER_TEXT,
                    String PAPER_TEXT_EN,
                    String PAPER_TEXT_ATTACHED_FILENAME,
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
                    int CONFERENCE_ID
            )
        {
            //try
            //{
                //l?y deadline paper text ra so sánh ngày hi?n t?i
                //Xac dinh thuoc POSITION nao

                //var query = (from confer in db.CONFERENCEs
                //             where confer.CONFERENCE_ID == CONFERENCE_ID
                //             select new { confer.PAPER_TEXT_DEADLINE_1 }).Take(1);//"2017-07-27T00:00:00" //yyyy-MM-dd'T'HH:mm:ss.SSS

                //var t = new ResuleBoolean();

                //DateTime datetime = new DateTime();


                //foreach (var q in query)
                //{
                //    datetime = Convert.ToDateTime(q.PAPER_TEXT_DEADLINE_1);
                //}

                //if (DateTime.Compare(datetime, DateTime.Now) > 0)
                //{
                var paper = GetPaperTextById(PAPER_ID);
                if (paper.PAPER_TEXT_TITLE_1 != null)
                {
                    //var newPAPER = new PAPER_TEXT();
                    paper.PAPER_ID = PAPER_ID;
                    paper.PAPER_TEXT_TITLE_1 = PAPER_TEXT_TITLE;
                    paper.PAPER_TEXT_TITLE_EN_1 = PAPER_TEXT_TITLE_EN;
                    paper.PAPER_TEXT_1 = PAPER_TEXT;
                    paper.PAPER_TEXT_ATTACHED_FILENAME_1 = PAPER_TEXT_ATTACHED_FILENAME;
                    paper.PAPER_TEXT_EN_1 = PAPER_TEXT_EN;
                    paper.FIRST_SUBMITTED_DATE_1 = DateTime.Now;
                    paper.LAST_REVISED_DATE_1 = DateTime.Now;

                    paper.FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_ID = FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_ID;
                    paper.FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_NAME = FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_NAME;
                    paper.FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_NAME_EN = FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_NAME_EN;
                    paper.FINAL_APPROVED_FULL_PAPER_OR_WORK_IN_PROGRESS = FINAL_APPROVED_FULL_PAPER_OR_WORK_IN_PROGRESS;
                    paper.FINAL_APPROVED_TYPE_OF_STUDY_ID = FINAL_APPROVED_TYPE_OF_STUDY_ID;
                    paper.FINAL_APPROVED_TYPE_OF_STUDY_NAME = FINAL_APPROVED_TYPE_OF_STUDY_NAME;
                    paper.FINAL_APPROVED_TYPE_OF_STUDY_NAME_EN = FINAL_APPROVED_TYPE_OF_STUDY_NAME_EN;
                    paper.FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_ID = FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_ID;
                    paper.FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_NAME = FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_NAME;
                    paper.FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_NAME_EN = FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_NAME_EN;
                        string value = PAPER_ID + "-" + 0 + "-" + "PAPER_TEXT_WITHDRAWN";
                        string value2 = PAPER_ID + "-" + 0 + "-" + "FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT";
                    paper.PAPER_TEXT_WITHDRAWN_SCRIPT = Utils.EncryptMd5(value);
                    paper.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT_SCRIPT = Utils.EncryptMd5(value2);
                        //db.PAPER_TEXT.Add(newPAPER);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }


            //}
            //    else
            //    {
            //    return false;
            //}


        //}
        //    catch (Exception)
        //    {
        //        return false;
        //    }

        }

        //public bool UpdatePaperText(
        //            int PAPER_ID,
        //            String PAPER_TEXT_TITLE,
        //            String PAPER_TEXT_TITLE_EN,
        //            String PAPER_TEXT,
        //            int FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_ID,
        //            String FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_NAME,
        //            String FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_NAME_EN,
        //            String FINAL_APPROVED_FULL_PAPER_OR_WORK_IN_PROGRESS,
        //            int FINAL_APPROVED_TYPE_OF_STUDY_ID,
        //            String FINAL_APPROVED_TYPE_OF_STUDY_NAME,
        //            String FINAL_APPROVED_TYPE_OF_STUDY_NAME_EN,
        //            int FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_ID,
        //            String FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_NAME,
        //            String FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_NAME_EN,
        //            int CONFERENCE_ID
        //    )
        //{
        //    return true;
        //}

        

        public class SavePaperText
        {
            public int PAPER_ID { get; set; }
            public String PAPER_TEXT_TITLE { get; set; }
            public String PAPER_TEXT_TITLE_EN { get; set; }
            public String PAPER_TEXT { get; set; }
            public String PAPER_TEXT_EN { get; set; }
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

    }
}