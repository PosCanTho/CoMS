using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoMS.Entities_Framework;
using CoMS.Controllers;
using CoMS.Untils;
using PagedList;

namespace CoMS.Models
{
    public class NewFeedModel
    {
        private DB db;
        
        public NewFeedModel()
        {
            db = new DB();
        }

        public List<ActivityFeed> getListActivityFeed(decimal conferenceId, int page = 0, int pageSize = 10)
        {
            var activityFeeds = (from n in db.MESSAGE_FEED
                                 join a in db.ACCOUNTs on n.UserName equals a.UserName
                                 where n.CONFERENCE_ID == conferenceId && n.REPLYING_TO_MESSAGE_FEED_ID == null
                                 && n.PUBLIC_OR_PRIVATE_MESSAGE == "PUBLIC"
                                 select new {n,a}
                                ).AsEnumerable()
                                .Select(x => new ActivityFeed()
                                {
                                   
                                    MESSAGE_FEED_ID = x.n.MESSAGE_FEED_ID,
                                    UserName = x.n.UserName,
                                    CURRENT_LAST_NAME = x.n.CURRENT_LAST_NAME,
                                    CURRENT_FIRST_NAME = x.n.CURRENT_FIRST_NAME,
                                    REPLYING_TO_MESSAGE_FEED_ID = x.n.REPLYING_TO_MESSAGE_FEED_ID,
                                    MESSAGE_CONTENT = x.n.MESSAGE_CONTENT,
                                    ATTACHED_PHOTO_FILENAME = x.n.ATTACHED_PHOTO_FILENAME,
                                    ATTACHED_PHOTO_NOTE = x.n.ATTACHED_PHOTO_NOTE,
                                    ATTACHED_PHOTO_LONGITUDE = x.n.ATTACHED_PHOTO_LONGITUDE,
                                    ATTACHED_PHOTO_LATITUDE = x.n.ATTACHED_PHOTO_LATITUDE,
                                    Image = x.a.Image,
                                    Time = DateTimeFormater.GetTimeAgo(x.n.FROM_DATE.Value),
                                    FROM_DATE = x.n.FROM_DATE,
                                    THRU_DATE = x.n.THRU_DATE
                                });

            return activityFeeds.OrderByDescending(x => x.FROM_DATE).ToPagedList(page, pageSize).ToList();
        }

        public List<ActivityFeed> getListActivityFeedOfUser(string userName, decimal conferenceId, int page = 0, int pageSize = 10)
        {
            var activityFeeds = (from n in db.MESSAGE_FEED
                                 join a in db.ACCOUNTs on n.UserName equals a.UserName
                                 where n.UserName == userName && n.CONFERENCE_ID == conferenceId && n.REPLYING_TO_MESSAGE_FEED_ID == null
                                 && n.PUBLIC_OR_PRIVATE_MESSAGE == "PUBLIC"
                                 select new { n, a }
                                ).AsEnumerable()
                                .Select(x => new ActivityFeed()
                                {

                                    MESSAGE_FEED_ID = x.n.MESSAGE_FEED_ID,
                                    UserName = x.n.UserName,
                                    CURRENT_LAST_NAME = x.n.CURRENT_LAST_NAME,
                                    CURRENT_FIRST_NAME = x.n.CURRENT_FIRST_NAME,
                                    REPLYING_TO_MESSAGE_FEED_ID = x.n.REPLYING_TO_MESSAGE_FEED_ID,
                                    MESSAGE_CONTENT = x.n.MESSAGE_CONTENT,
                                    ATTACHED_PHOTO_FILENAME = x.n.ATTACHED_PHOTO_FILENAME,
                                    ATTACHED_PHOTO_NOTE = x.n.ATTACHED_PHOTO_NOTE,
                                    ATTACHED_PHOTO_LONGITUDE = x.n.ATTACHED_PHOTO_LONGITUDE,
                                    ATTACHED_PHOTO_LATITUDE = x.n.ATTACHED_PHOTO_LATITUDE,
                                    Image = x.a.Image,
                                    Time = DateTimeFormater.GetTimeAgo(x.n.FROM_DATE.Value),
                                    FROM_DATE = x.n.FROM_DATE,
                                    THRU_DATE = x.n.THRU_DATE
                                });

            return activityFeeds.OrderByDescending(x => x.FROM_DATE).ToPagedList(page, pageSize).ToList();
        }

        public List<ActivityFeed> getListActivityFeedComment(decimal? replyToId, int page = 0, int pageSize = 10)
        {
            var activityFeeds = (from n in db.MESSAGE_FEED
                                 join a in db.ACCOUNTs on n.UserName equals a.UserName
                                 where  n.PUBLIC_OR_PRIVATE_MESSAGE == "PUBLIC" && n.REPLYING_TO_MESSAGE_FEED_ID == replyToId
                                 select new { n, a }
                              ).AsEnumerable()
                              .Select(x => new ActivityFeed()
                              {

                                  MESSAGE_FEED_ID = x.n.MESSAGE_FEED_ID,
                                  UserName = x.n.UserName,
                                  CURRENT_LAST_NAME = x.n.CURRENT_LAST_NAME,
                                  CURRENT_FIRST_NAME = x.n.CURRENT_FIRST_NAME,
                                  REPLYING_TO_MESSAGE_FEED_ID = x.n.REPLYING_TO_MESSAGE_FEED_ID,
                                  MESSAGE_CONTENT = x.n.MESSAGE_CONTENT,
                                  ATTACHED_PHOTO_FILENAME = x.n.ATTACHED_PHOTO_FILENAME,
                                  ATTACHED_PHOTO_NOTE = x.n.ATTACHED_PHOTO_NOTE,
                                  ATTACHED_PHOTO_LONGITUDE = x.n.ATTACHED_PHOTO_LONGITUDE,
                                  ATTACHED_PHOTO_LATITUDE = x.n.ATTACHED_PHOTO_LATITUDE,
                                  Image = x.a.Image,
                                  Time = DateTimeFormater.GetTimeAgo(x.n.FROM_DATE.Value),
                                  FROM_DATE = x.n.FROM_DATE,
                                  THRU_DATE = x.n.THRU_DATE
                              });
            return activityFeeds.OrderBy(x => x.FROM_DATE).ToPagedList(page, pageSize).ToList();
        }
    }
}