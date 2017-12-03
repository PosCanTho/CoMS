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
            var listAttendee = (from ca in db.CONFERENCE_ATTENDEE
                                join per in db.People on ca.PERSON_ID equals per.PERSON_ID
                                join ac in db.ACCOUNTs on per.PERSON_ID equals ac.PERSON_ID
                                where ca.CONFERENCE_ID == conferenceId select new { ca, per, ac } )
                               .AsEnumerable()
                               .Select(x => new Presenter()
                               {
                                   PERSON_ID = x.ac.PERSON_ID,
                                   CURRENT_LAST_NAME = x.ac.CURRENT_LAST_NAME,
                                   CURRENT_FIRST_NAME = x.ac.CURRENT_FIRST_NAME,
                                   CURRENT_MIDDLE_NAME = x.ac.CURRENT_MIDDLE_NAME,
                                   UserName = x.ac.UserName,
                                   Email = x.ac.Email,
                                   Image = x.ac.Image,
                                   CURRENT_HOME_ORGANIZATION_ID = x.ac.CURRENT_HOME_ORGANIZATION_ID,
                                   CURRENT_HOME_ORGANIZATION_NAME = x.ac.CURRENT_HOME_ORGANIZATION_NAME,
                                   CURRENT_HOME_ORGANIZATION_NAME_EN = x.ac.CURRENT_HOME_ORGANIZATION_NAME_EN,
                                   CURRENT_PHONE_NUMBER = x.per.CURRENT_PHONE_NUMBER,
                                   BIRTH_DATE = x.per.BIRTH_DATE,
                                   CURRENT_GENDER = x.per.CURRENT_GENDER,
                                   CONFERENCE_ID = x.ca.CONFERENCE_ID,
                                   CONFERENCE_NAME = x.ca.CONFERENCE_NAME,
                                   CONFERENCE_NAME_EN = x.ca.CONFERENCE_NAME_EN,
                                   FULL_NAME = x.ac.CURRENT_LAST_NAME + " " + x.ac.CURRENT_MIDDLE_NAME + " " + x.ac.CURRENT_FIRST_NAME,
                                   IS_FOLLOW = new FollowModel().CheckFollow(new AccountModel().GetAccountById(personId).UserName, x.ac.UserName, conferenceId)
                               }).Distinct().ToList();
            return listAttendee;
        }

        public List<Presenter> getListPresenter(int personId, int conferenceId)
        {
            var listPresenter = (from ca in db.PRESENTERs
                                join per in db.People on ca.PERSON_ID equals per.PERSON_ID
                                join ac in db.ACCOUNTs on per.PERSON_ID equals ac.PERSON_ID
                                where ca.CONFERENCE_ID == conferenceId
                                select new { ca, per, ac })
                               .AsEnumerable()
                               .Select(x => new Presenter()
                               {
                                   PERSON_ID = x.ac.PERSON_ID,
                                   CURRENT_LAST_NAME = x.ac.CURRENT_LAST_NAME,
                                   CURRENT_FIRST_NAME = x.ac.CURRENT_FIRST_NAME,
                                   CURRENT_MIDDLE_NAME = x.ac.CURRENT_MIDDLE_NAME,
                                   UserName = x.ac.UserName,
                                   Email = x.ac.Email,
                                   Image = x.ac.Image,
                                   CURRENT_HOME_ORGANIZATION_ID = x.ac.CURRENT_HOME_ORGANIZATION_ID,
                                   CURRENT_HOME_ORGANIZATION_NAME = x.ac.CURRENT_HOME_ORGANIZATION_NAME,
                                   CURRENT_HOME_ORGANIZATION_NAME_EN = x.ac.CURRENT_HOME_ORGANIZATION_NAME_EN,
                                   CURRENT_PHONE_NUMBER = x.per.CURRENT_PHONE_NUMBER,
                                   BIRTH_DATE = x.per.BIRTH_DATE,
                                   CURRENT_GENDER = x.per.CURRENT_GENDER,
                                   CONFERENCE_ID = x.ca.CONFERENCE_ID,
                                   CONFERENCE_NAME = x.ca.CONFERENCE_NAME,
                                   CONFERENCE_NAME_EN = x.ca.CONFERENCE_NAME_EN,
                                   FULL_NAME = x.ac.CURRENT_LAST_NAME + " " + x.ac.CURRENT_MIDDLE_NAME + " " + x.ac.CURRENT_FIRST_NAME,
                                   IS_FOLLOW = new FollowModel().CheckFollow(new AccountModel().GetAccountById(personId).UserName, x.ac.UserName, conferenceId)
                               }).Distinct().ToList();
            return listPresenter;
        }
    }
}