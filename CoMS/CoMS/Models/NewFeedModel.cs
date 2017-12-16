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

        public List<ActivityFeed> getListActivityFeed(decimal conferenceId, int page = 1, int pageSize = 10)
        {
            var activityFeeds = (from n in db.MESSAGE_FEED
                                 join a in db.ACCOUNTs on n.UserName equals a.UserName
                                 where n.CONFERENCE_ID == conferenceId && n.REPLYING_TO_MESSAGE_FEED_ID == null
                                 && n.PUBLIC_OR_PRIVATE_MESSAGE == "PUBLIC" && (n.DELETED == false || n.DELETED == null)
                                 select new { n, a }
                                ).AsEnumerable()
                                .Select(x => new ActivityFeed()
                                {

                                    MESSAGE_FEED_ID = x.n.MESSAGE_FEED_ID,
                                    UserName = x.n.UserName,
                                    PERSON_ID = x.a.PERSON_ID,
                                    CURRENT_LAST_NAME = x.n.CURRENT_LAST_NAME,
                                    CURRENT_MIDDLE_NAME = x.n.CURRENT_MIDDLE_NAME,
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

        public List<PhotoFeed> getListPhotoFeed(decimal conferenceId, int page = 1, int pageSize = 10)
        {
            var activityFeeds = (from n in db.MESSAGE_FEED
                                 join a in db.ACCOUNTs on n.UserName equals a.UserName
                                 where n.CONFERENCE_ID == conferenceId && n.REPLYING_TO_MESSAGE_FEED_ID == null
                                 && n.PUBLIC_OR_PRIVATE_MESSAGE == "PUBLIC" && (n.DELETED == false || n.DELETED == null)
                                 && n.ATTACHED_PHOTO_FILENAME != null && n.ATTACHED_PHOTO_FILENAME != ""
                                 select new { n, a })
                                 .AsEnumerable()
                                 .GroupBy(x => x.n.FROM_DATE.Value.ToString("yyyy-MM-dd"), x =>  x.n)
                                .Select(x => new PhotoFeed()
                                {
                                    Date = x.Key,
                                    ListFeed = x.ToList()
                                });

            return activityFeeds.OrderByDescending(x => x.Date).ToPagedList(page, pageSize).ToList();
        }

        private static DateTime GetFirstDayInMonth(DateTime? dateTime)
        {
            if (dateTime.HasValue)
            {
                var result = dateTime.Value.ToString("");
                return new DateTime(dateTime.Value.Date.Year, dateTime.Value.Date.Month, 1);
            }

            return DateTime.Now;
        }

        public List<ActivityFeed> getListActivityFeedOfUser(string userName, decimal conferenceId, int page = 1, int pageSize = 10)
        {
            var activityFeeds = (from n in db.MESSAGE_FEED
                                 join a in db.ACCOUNTs on n.UserName equals a.UserName
                                 where n.UserName == userName && n.CONFERENCE_ID == conferenceId && n.REPLYING_TO_MESSAGE_FEED_ID == null
                                 && n.PUBLIC_OR_PRIVATE_MESSAGE == "PUBLIC" && (n.DELETED == false || n.DELETED == null)
                                 select new { n, a }
                                ).AsEnumerable()
                                .Select(x => new ActivityFeed()
                                {

                                    MESSAGE_FEED_ID = x.n.MESSAGE_FEED_ID,
                                    UserName = x.n.UserName,
                                    PERSON_ID = x.a.PERSON_ID,
                                    CURRENT_LAST_NAME = x.n.CURRENT_LAST_NAME,
                                    CURRENT_MIDDLE_NAME = x.n.CURRENT_MIDDLE_NAME,
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

        public List<ActivityFeed> getListActivityFeedComment(decimal? replyToId, int page = 1, int pageSize = 10)
        {
            var activityFeeds = (from n in db.MESSAGE_FEED
                                 join a in db.ACCOUNTs on n.UserName equals a.UserName
                                 where n.PUBLIC_OR_PRIVATE_MESSAGE == "PUBLIC" && n.REPLYING_TO_MESSAGE_FEED_ID == replyToId && (n.DELETED == false || n.DELETED == null)
                                 select new { n, a }
                              ).AsEnumerable()
                              .Select(x => new ActivityFeed()
                              {

                                  MESSAGE_FEED_ID = x.n.MESSAGE_FEED_ID,
                                  UserName = x.n.UserName,
                                  PERSON_ID = x.a.PERSON_ID,
                                  CURRENT_LAST_NAME = x.n.CURRENT_LAST_NAME,
                                  CURRENT_MIDDLE_NAME = x.n.CURRENT_MIDDLE_NAME,
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
                                  THRU_DATE = x.n.THRU_DATE,
                                  CURRENT_HOME_ORGANIZATION_NAME = x.a.CURRENT_HOME_ORGANIZATION_NAME,
                                  CURRENT_HOME_ORGANIZATION_NAME_EN = x.a.CURRENT_HOME_ORGANIZATION_NAME_EN
                              });
            return activityFeeds.OrderBy(x => x.FROM_DATE).ToPagedList(page, pageSize).ToList();
        }

        public object listLike(decimal MESSAGE_FEED_ID, int page = 1, int pageSize = 10)
        {
            var list = db.PERSON_LIKING_MESSAGE_FEED
                .Join(db.ACCOUNTs, p => p.UserName, a => a.UserName, (p, a) => new { p, a })
                .Where(x => x.p.MESSAGE_FEED_ID == MESSAGE_FEED_ID)
                .Select(x => new
                {
                    MESSAGE_FEED_ID = x.p.MESSAGE_FEED_ID,
                    UserName = x.p.UserName,
                    PERSON_ID = x.p.PERSON_ID,
                    CURRENT_LAST_NAME = x.p.CURRENT_LAST_NAME,
                    CURRENT_FIRST_NAME = x.p.CURRENT_FIRST_NAME,
                    CURRENT_MIDDLE_NAME = x.p.CURRENT_MIDDLE_NAME,
                    LIKED_DATETIME = x.p.LIKED_DATETIME,
                    CURRENT_HOME_ORGANIZATION_NAME = x.a.CURRENT_HOME_ORGANIZATION_NAME,
                    CURRENT_HOME_ORGANIZATION_NAME_EN = x.a.CURRENT_HOME_ORGANIZATION_NAME_EN
                }).OrderBy(x => x.LIKED_DATETIME).ToPagedList(page, pageSize);
            return list;
        }

        public bool addNewFeed(MESSAGE_FEED messageFeed)
        {
            try
            {
                var result = db.MESSAGE_FEED.ToList();
                if (result.Count > 0)
                {
                    messageFeed.MESSAGE_FEED_ID = result.Last().MESSAGE_FEED_ID + 1;
                }
                else
                {
                    messageFeed.MESSAGE_FEED_ID = 0;
                }
                db.MESSAGE_FEED.Add(messageFeed);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public MESSAGE_FEED getLastMessage(string UserName, string RECIPIENT_UserName_1, int conferenceId)
        {

            var list = db.MESSAGE_FEED.Where(x => (x.UserName == UserName && x.RECIPIENT_UserName_1 == RECIPIENT_UserName_1) || (x.UserName == RECIPIENT_UserName_1 && x.RECIPIENT_UserName_1 == UserName) && x.CONFERENCE_ID == conferenceId)
                .Where(x => x.DELETED_UserName != UserName)
                .Where(x => x.DELETED == false || x.DELETED == null)
                .OrderByDescending(x => x.FROM_DATE).ToList();
            if (list.Count > 0)
            {
                return list.First();
            }
            return null;
        }

        public bool checkIsLiked(string userName, decimal messageFeedId)
        {
            var result = db.PERSON_LIKING_MESSAGE_FEED.Where(x => x.MESSAGE_FEED_ID == messageFeedId && x.UserName == userName).ToList();
            if (result.Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool updateMessageFeed(MESSAGE_FEED messageFeed)
        {
            try
            {
                var result = db.MESSAGE_FEED.SingleOrDefault(x => x.MESSAGE_FEED_ID == messageFeed.MESSAGE_FEED_ID);
                result.DELETED_UserName = messageFeed.DELETED_UserName;
                result.DELETED_DATETIME = messageFeed.DELETED_DATETIME;
                result.DELETED = messageFeed.DELETED;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteMessageFeed(decimal MESSAGE_FEED_ID)
        {
            try
            {
                var result = db.MESSAGE_FEED.SingleOrDefault(x => x.MESSAGE_FEED_ID == MESSAGE_FEED_ID);
                db.MESSAGE_FEED.Remove(result);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}