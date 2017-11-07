using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoMS.Entities_Framework;
using CoMS.Resources;
using System.IO;
using Newtonsoft.Json;
using CoMS.Models;
using CoMS.Untils;
using CoMS.Controllers;


namespace CoMS.Models
{
    public class ChannelModel
    {
        private DB db;

        public ChannelModel()
        {
             db = new DB();
        }

        public List<Presenter> getListAttendee(int personId, int conferenceId)
        {
            var listAttendee = (from ac_con in db.ACCOUNT_FOR_CONFERENCE
                                join ac in db.ACCOUNTs on ac_con.UserName equals ac.UserName
                                join per in db.People on ac.PERSON_ID equals per.PERSON_ID
                                where ac_con.CONFERENCE_ID == conferenceId && ac_con.CONFERENCE_ATTENDEE_RIGHT == true && ac.PERSON_ID != personId
                                select new
                                 Presenter()
                                {
                                    PERSON_ID = ac.PERSON_ID,
                                    CURRENT_LAST_NAME = ac.CURRENT_LAST_NAME,
                                    CURRENT_FIRST_NAME = ac.CURRENT_FIRST_NAME,
                                    CURRENT_MIDDLE_NAME = ac.CURRENT_MIDDLE_NAME,
                                    UserName = ac.UserName,
                                    Email = ac.Email,
                                    Image = ac.Image,
                                    CURRENT_HOME_ORGANIZATION_ID = ac.CURRENT_HOME_ORGANIZATION_ID,
                                    CURRENT_HOME_ORGANIZATION_NAME = ac.CURRENT_HOME_ORGANIZATION_NAME,
                                    CURRENT_HOME_ORGANIZATION_NAME_EN = ac.CURRENT_HOME_ORGANIZATION_NAME_EN,
                                    CURRENT_PHONE_NUMBER = per.CURRENT_PHONE_NUMBER,
                                    BIRTH_DATE = per.BIRTH_DATE,
                                    CURRENT_GENDER = per.CURRENT_GENDER,
                                    CONFERENCE_ADMIN_RIGHT = ac_con.CONFERENCE_ADMIN_RIGHT,
                                    REVIEWER_RIGHT = ac_con.REVIEWER_RIGHT,
                                    CONFERENCE_BOARD_OF_REVIEW_CHAIR_RIGHT = ac_con.CONFERENCE_BOARD_OF_REVIEW_CHAIR_RIGHT,
                                    AUTHOR_RIGHT = ac_con.AUTHOR_RIGHT,
                                    PRESENTER_RIGHT = ac_con.PRESENTER_RIGHT,
                                    CONFERENCE_ATTENDEE_RIGHT = ac_con.CONFERENCE_ATTENDEE_RIGHT,
                                    SUPPORT_STAFF_RIGHT = ac_con.SUPPORT_STAFF_RIGHT,
                                    CONFERENCE_ID = ac_con.CONFERENCE_ID,
                                    CONFERENCE_NAME = ac_con.CONFERENCE_NAME,
                                    FULL_NAME = ac.CURRENT_LAST_NAME + " " + ac.CURRENT_MIDDLE_NAME + " " + ac.CURRENT_FIRST_NAME
                                }).Distinct().ToList();
            return listAttendee;
        }

        public List<Presenter> getListPresenter(int personId, int conferenceId)
        {
            var listPresenter = (from ac_con in db.ACCOUNT_FOR_CONFERENCE
                                 join ac in db.ACCOUNTs on ac_con.UserName equals ac.UserName
                                 join per in db.People on ac.PERSON_ID equals per.PERSON_ID
                                 where ac_con.CONFERENCE_ID == conferenceId && ac_con.PRESENTER_RIGHT == true && ac.PERSON_ID != personId
                                 select new
                                  Presenter()
                                 {
                                     PERSON_ID = ac.PERSON_ID,
                                     CURRENT_LAST_NAME = ac.CURRENT_LAST_NAME,
                                     CURRENT_FIRST_NAME = ac.CURRENT_FIRST_NAME,
                                     CURRENT_MIDDLE_NAME = ac.CURRENT_MIDDLE_NAME,
                                     UserName = ac.UserName,
                                     Email = ac.Email,
                                     Image = ac.Image,
                                     CURRENT_HOME_ORGANIZATION_ID = ac.CURRENT_HOME_ORGANIZATION_ID,
                                     CURRENT_HOME_ORGANIZATION_NAME = ac.CURRENT_HOME_ORGANIZATION_NAME,
                                     CURRENT_HOME_ORGANIZATION_NAME_EN = ac.CURRENT_HOME_ORGANIZATION_NAME_EN,
                                     CURRENT_PHONE_NUMBER = per.CURRENT_PHONE_NUMBER,
                                     BIRTH_DATE = per.BIRTH_DATE,
                                     CURRENT_GENDER = per.CURRENT_GENDER,
                                     CONFERENCE_ADMIN_RIGHT = ac_con.CONFERENCE_ADMIN_RIGHT,
                                     REVIEWER_RIGHT = ac_con.REVIEWER_RIGHT,
                                     CONFERENCE_BOARD_OF_REVIEW_CHAIR_RIGHT = ac_con.CONFERENCE_BOARD_OF_REVIEW_CHAIR_RIGHT,
                                     AUTHOR_RIGHT = ac_con.AUTHOR_RIGHT,
                                     PRESENTER_RIGHT = ac_con.PRESENTER_RIGHT,
                                     CONFERENCE_ATTENDEE_RIGHT = ac_con.CONFERENCE_ATTENDEE_RIGHT,
                                     SUPPORT_STAFF_RIGHT = ac_con.SUPPORT_STAFF_RIGHT,
                                     CONFERENCE_ID = ac_con.CONFERENCE_ID,
                                     CONFERENCE_NAME = ac_con.CONFERENCE_NAME,
                                     FULL_NAME = ac.CURRENT_LAST_NAME + " " + ac.CURRENT_MIDDLE_NAME + " " + ac.CURRENT_FIRST_NAME
                                 }).Distinct().ToList();
            return listPresenter;
        }
    }
}