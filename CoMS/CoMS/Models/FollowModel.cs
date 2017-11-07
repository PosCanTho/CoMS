using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoMS.Resources;
using CoMS.Entities_Framework;
using CoMS.Untils;
using CoMS.Models;


namespace CoMS.Models
{
    public class FollowModel
    {
        private DB db;

        public FollowModel()
        {
            db = new DB();
        }

        public bool CheckFollow(string FOLLOWED_UserName, string FOLLOWING_UserName, int conferenceId)
        {
            var result = db.FOLLOWER_RELATIONSHIP.SingleOrDefault(x => x.FOLLOWED_UserName == FOLLOWED_UserName && x.FOLLOWING_UserName == FOLLOWING_UserName && x.CONFERENCE_ID == conferenceId);
            if (result != null)
            {
                return true;
            }
            return false;
        }

        public List<Follow> getListFollow(string userName, int conferenceId)
        {
            var followers = from f in db.FOLLOWER_RELATIONSHIP
                            join a in db.ACCOUNTs on f.FOLLOWING_UserName equals a.UserName
                            where f.FOLLOWED_UserName == userName && f.CONFERENCE_ID == conferenceId
                            select new Follow()
                            {
                                PERSON_ID = a.PERSON_ID,
                                Image = a.Image,

                                FOLLOWING_UserName = f.FOLLOWING_UserName,
                                FOLLOWING_CURRENT_FIRST_NAME = f.FOLLOWING_CURRENT_FIRST_NAME,
                                FOLLOWING_CURRENT_MIDDLE_NAME = f.FOLLOWING_CURRENT_MIDDLE_NAME,
                                FOLLOWING_CURRENT_LAST_NAME = f.FOLLOWING_CURRENT_LAST_NAME
                            };
            return followers.ToList();
        }

        public List<Follow> getListFollowMe(string userName, int conferenceId)
        {
            var followMe = from f in db.FOLLOWER_RELATIONSHIP
                           join a in db.ACCOUNTs on f.FOLLOWING_UserName equals a.UserName
                           where f.FOLLOWING_UserName == userName && f.CONFERENCE_ID == conferenceId
                           select new
                           Follow(){
                               PERSON_ID = a.PERSON_ID,
                               Image = a.Image,

                               FOLLOWING_UserName = f.FOLLOWED_UserName,
                               FOLLOWING_CURRENT_FIRST_NAME = f.FOLLOWED_CURRENT_FIRST_NAME,
                               FOLLOWING_CURRENT_MIDDLE_NAME = f.FOLLOWED_CURRENT_MIDDLE_NAME,
                               FOLLOWING_CURRENT_LAST_NAME = f.FOLLOWED_CURRENT_LAST_NAME,
                               CURRENT_HOME_ORGANIZATION_ID = a.CURRENT_HOME_ORGANIZATION_ID,
                               CURRENT_HOME_ORGANIZATION_NAME = a.CURRENT_HOME_ORGANIZATION_NAME,
                               CURRENT_HOME_ORGANIZATION_NAME_EN = a.CURRENT_HOME_ORGANIZATION_NAME_EN
                           };
            return followMe.ToList();
        }
    }

    public class Follow
    {
        public decimal? PERSON_ID { get; set; }
        public string Image { get; set; }
        public string FOLLOWING_UserName { get; set; }
        public string FOLLOWING_CURRENT_FIRST_NAME { get; set; }
        public string FOLLOWING_CURRENT_MIDDLE_NAME { get; set; }
        public string FOLLOWING_CURRENT_LAST_NAME { get; set; }
        public decimal? CURRENT_HOME_ORGANIZATION_ID { get; set; }
        public string CURRENT_HOME_ORGANIZATION_NAME { get; set; }
        public string CURRENT_HOME_ORGANIZATION_NAME_EN { get; set; }
    }
}