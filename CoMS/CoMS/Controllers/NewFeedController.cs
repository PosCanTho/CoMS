using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoMS.Resources;
using CoMS.Entities_Framework;
using CoMS.Untils;
using CoMS.Models;

namespace CoMS.Controllers
{
    public class NewFeedController : BaseController
    {
        private DB db = new DB();

        [HttpPost]
        [Route("api/CreateStatus")]
        public HttpResponseMessage CreateStatus([FromBody]Status status)
        {

            if (status != null)
            {
                var account = db.ACCOUNTs.SingleOrDefault(x => x.UserName == status.UserName);
                var conference = db.CONFERENCEs.SingleOrDefault(x => x.CONFERENCE_ID == status.CONFERENCE_ID);
                if (account == null)
                {
                    return ResponseFail(StringResource.Account_does_not_exist);
                }
                else if (conference == null)
                {
                    return ResponseFail(StringResource.Conference_do_not_exist);
                }
                else
                {
                    var messageFeed = new MESSAGE_FEED();
                    var result = db.MESSAGE_FEED.ToList();
                    if (result.Count > 0)
                    {
                        messageFeed.MESSAGE_FEED_ID = result.Last().MESSAGE_FEED_ID + 1;
                    }
                    else
                    {
                        messageFeed.MESSAGE_FEED_ID = 0;
                    }
                    messageFeed.UserName = status.UserName;
                    messageFeed.REPLYING_TO_MESSAGE_FEED_ID = status.REPLYING_TO_MESSAGE_FEED_ID >= 0 ? status.REPLYING_TO_MESSAGE_FEED_ID : null;
                    messageFeed.FROM_DATE = DateTime.Now;
                    messageFeed.CURRENT_LAST_NAME = account.CURRENT_LAST_NAME;
                    messageFeed.CURRENT_FIRST_NAME = account.CURRENT_FIRST_NAME;
                    messageFeed.CURRENT_MIDDLE_NAME = account.CURRENT_MIDDLE_NAME;
                    messageFeed.CONFERENCE_ID = status.CONFERENCE_ID;
                    messageFeed.CONFERENCE_NAME = conference.CONFERENCE_NAME;
                    messageFeed.CONFERENCE_NAME_EN = conference.CONFERENCE_NAME_EN;
                    messageFeed.PUBLIC_OR_PRIVATE_MESSAGE = "PUBLIC";
                    messageFeed.MESSAGE_CONTENT = status.MESSAGE_CONTENT;
                    messageFeed.ATTACHED_PHOTO_FILENAME = status.ATTACHED_PHOTO_FILENAME;
                    messageFeed.ATTACHED_PHOTO_NOTE = status.ATTACHED_PHOTO_NOTE;
                    messageFeed.ATTACHED_PHOTO_LONGITUDE = status.ATTACHED_PHOTO_LONGITUDE;
                    messageFeed.ATTACHED_PHOTO_LATITUDE = status.ATTACHED_PHOTO_LATITUDE;
                    db.MESSAGE_FEED.Add(messageFeed);
                    db.SaveChanges();

                    status.CURRENT_LAST_NAME = account.CURRENT_LAST_NAME;
                    status.CURRENT_FIRST_NAME = account.CURRENT_FIRST_NAME;
                    status.CURRENT_MIDDLE_NAME = account.CURRENT_MIDDLE_NAME;
                    status.MESSAGE_FEED_ID = messageFeed.MESSAGE_FEED_ID;
                    status.Image = account.Image;
                    status.Time = DateTimeFormater.GetTimeAgo(messageFeed.FROM_DATE.Value);

                    return ResponseSuccess(StringResource.Success, status);
                }

            }
            else
            {
                return ResponseFail(StringResource.Data_not_received);
            }
        }

        [HttpPost]
        [Route("api/ListNewFeed")]
        public HttpResponseMessage ListNewFeed(string userName, decimal conferenceId, int page, int pageSize)
        {
            var model = new NewFeedModel();
            var activityFeeds = model.getListActivityFeed(conferenceId, page, pageSize);

            foreach (ActivityFeed item in activityFeeds)
            {

                var list = model.getListActivityFeedComment(item.MESSAGE_FEED_ID);
                item.ListComment = list;
                var listLike = model.listLike(item.MESSAGE_FEED_ID);
                item.ListLike = listLike;
                item.IS_LIKED = model.checkIsLiked(userName, item.MESSAGE_FEED_ID);
            }

            return ResponseSuccess(StringResource.Success, activityFeeds);
        }

        [HttpPost]
        [Route("api/ListPhotoFeed")]
        public HttpResponseMessage ListPhotoFeed(string userName, decimal conferenceId, int page, int pageSize)
        {
            var model = new NewFeedModel();
            var photoFeeds = model.getListPhotoFeed(conferenceId, page, pageSize);
            var result = new List<PhotoResponse>();
            foreach (PhotoFeed item in photoFeeds)
            {
                var itemFeed = new PhotoResponse();
                itemFeed.Date = item.Date;
                itemFeed.ListFeed = new List<ActivityFeed>();
                foreach (MESSAGE_FEED feed in item.ListFeed)
                {
                    var account = new AccountModel().GetUserByUserName(feed.UserName);
                    var f = new ActivityFeed();
                    f.MESSAGE_FEED_ID = feed.MESSAGE_FEED_ID;
                    f.UserName = feed.UserName;
                    f.PERSON_ID = account.PERSON_ID;
                    f.CURRENT_LAST_NAME = feed.CURRENT_LAST_NAME;
                    f.CURRENT_MIDDLE_NAME = feed.CURRENT_MIDDLE_NAME;
                    f.CURRENT_FIRST_NAME = feed.CURRENT_FIRST_NAME;
                    f.REPLYING_TO_MESSAGE_FEED_ID = feed.REPLYING_TO_MESSAGE_FEED_ID;
                    f.MESSAGE_CONTENT = feed.MESSAGE_CONTENT;
                    f.ATTACHED_PHOTO_FILENAME = feed.ATTACHED_PHOTO_FILENAME;
                    f.ATTACHED_PHOTO_NOTE = feed.ATTACHED_PHOTO_NOTE;
                    f.ATTACHED_PHOTO_LONGITUDE = feed.ATTACHED_PHOTO_LONGITUDE;
                    f.ATTACHED_PHOTO_LATITUDE = feed.ATTACHED_PHOTO_LATITUDE;
                    f.Image = account.Image;
                    f.Time = DateTimeFormater.GetTimeAgo(feed.FROM_DATE.Value);
                    f.FROM_DATE = feed.FROM_DATE;
                    f.THRU_DATE = feed.THRU_DATE;
                    f.ListComment = model.getListActivityFeedComment(feed.MESSAGE_FEED_ID);
                    f.IS_LIKED = model.checkIsLiked(userName, feed.MESSAGE_FEED_ID);
                    f.ListLike = model.listLike(feed.MESSAGE_FEED_ID);
                    itemFeed.ListFeed.Add(f);
                }
                result.Add(itemFeed);
            }

            return ResponseSuccess(StringResource.Success, result);
        }

        [HttpPost]
        [Route("api/ListNewFeedOfUser")]
        public HttpResponseMessage ListNewFeedOfUser(string userNameLogin, string userName, decimal conferenceId, int page, int pageSize)
        {
            var model = new NewFeedModel();
            var activityFeeds = model.getListActivityFeedOfUser(userName, conferenceId, page, pageSize);

            foreach (ActivityFeed item in activityFeeds)
            {
                var list = model.getListActivityFeedComment(item.MESSAGE_FEED_ID);
                item.ListComment = list;
                var listLike = model.listLike(item.MESSAGE_FEED_ID);
                item.ListLike = listLike;
                item.IS_LIKED = model.checkIsLiked(userNameLogin, item.MESSAGE_FEED_ID);
            }

            return ResponseSuccess(StringResource.Success, activityFeeds);
        }

        [HttpPost]
        [Route("api/ListNewFeedOfSession")]
        public HttpResponseMessage ListNewFeedOfUser(string userNameLogin, int conferenceId, decimal conference_session_id, int page, int pageSize)
        {

            var listResult = (db.CONFERENCE_ATTENDEE_IN_REGISTERED_CONFERENCE_SESSION
                        .Join(db.ACCOUNTs, attendee => attendee.PERSON_ID, acc => acc.PERSON_ID, (attendee, acc) => new { attendee, acc }))
                        .Where(x => x.attendee.CONFERENCE_SESSION_ID == conference_session_id)
                        .AsEnumerable()
                        .ToList()
                        .Select(x => new UserOfSession()
                        {
                            UserName = x.acc.UserName,
                            Image = x.acc.Image,
                            CURRENT_FIRST_NAME = x.acc.CURRENT_FIRST_NAME,
                            CURRENT_MIDDLE_NAME = x.acc.CURRENT_MIDDLE_NAME,
                            CURRENT_LAST_NAME = x.acc.CURRENT_LAST_NAME
                        });
            var activityFeeds = new List<ActivityFeed>();
            var model = new NewFeedModel();
            foreach (UserOfSession item in listResult)
            {
                var list = model.getListActivityFeedOfUser(item.UserName, conferenceId, page, pageSize);
                foreach (ActivityFeed feed in list)
                {
                    var commemts = model.getListActivityFeedComment(feed.MESSAGE_FEED_ID);
                    feed.ListComment = commemts;
                    var likes = model.listLike(feed.MESSAGE_FEED_ID);
                    feed.ListLike = likes;
                    feed.IS_LIKED = model.checkIsLiked(userNameLogin, feed.MESSAGE_FEED_ID);
                    activityFeeds.AddRange(list);
                }
            }

            return ResponseSuccess(StringResource.Success, activityFeeds);
        }

        [HttpPost]
        [Route("api/NewFeedDetail")]
        public HttpResponseMessage NewFeedDetail(int MESSAGE_FEED_ID, string userName)
        {

            var account = new AccountModel().GetUserByUserName(userName);
            if (account == null)
            {
                return ResponseFail(StringResource.Account_does_not_exist);
            }
            else
            {
                var model = new NewFeedModel();
                var result = db.MESSAGE_FEED.Find(MESSAGE_FEED_ID);
                if (result != null)
                {
                    var activityFeed = new ActivityFeed();
                    activityFeed.MESSAGE_FEED_ID = result.MESSAGE_FEED_ID;
                    activityFeed.UserName = result.UserName;
                    activityFeed.MESSAGE_CONTENT = result.MESSAGE_CONTENT;
                    activityFeed.CURRENT_LAST_NAME = result.CURRENT_LAST_NAME;
                    activityFeed.CURRENT_FIRST_NAME = result.CURRENT_FIRST_NAME;
                    activityFeed.REPLYING_TO_MESSAGE_FEED_ID = result.REPLYING_TO_MESSAGE_FEED_ID;
                    activityFeed.ATTACHED_PHOTO_FILENAME = result.ATTACHED_PHOTO_FILENAME;
                    activityFeed.ATTACHED_PHOTO_NOTE = result.ATTACHED_PHOTO_NOTE;
                    activityFeed.ATTACHED_PHOTO_LONGITUDE = result.ATTACHED_PHOTO_LONGITUDE;
                    activityFeed.ATTACHED_PHOTO_LATITUDE = result.ATTACHED_PHOTO_LATITUDE;
                    activityFeed.Time = DateTimeFormater.GetTimeAgo(result.FROM_DATE.Value);
                    activityFeed.Image = account.Image;
                    activityFeed.FROM_DATE = result.FROM_DATE;
                    activityFeed.THRU_DATE = result.THRU_DATE;
                    activityFeed.ListComment = model.getListActivityFeedComment(MESSAGE_FEED_ID);
                    activityFeed.ListLike = model.listLike(MESSAGE_FEED_ID);
                    activityFeed.IS_LIKED = model.checkIsLiked(userName, MESSAGE_FEED_ID);
                    return ResponseSuccess(StringResource.Success, activityFeed);
                }
                else
                {
                    return ResponseFail(StringResource.Can_not_load_detail);
                }
            }
        }


        [HttpPost]
        [Route("api/ListComment")]
        public HttpResponseMessage ListComment(decimal REPLYING_TO_MESSAGE_FEED_ID, int page, int pageSize)
        {
            var model = new NewFeedModel();
            var list = model.getListActivityFeedComment(REPLYING_TO_MESSAGE_FEED_ID, page, pageSize);
            return ResponseSuccess(StringResource.Success, list);
        }

        [HttpPost]
        [Route("api/ListLike")]
        public HttpResponseMessage ListLike(decimal MESSAGE_FEED_ID, int page, int pageSize)
        {
            return ResponseSuccess(StringResource.Success, new NewFeedModel().listLike(MESSAGE_FEED_ID, page, pageSize));
        }

        [HttpPost]
        [Route("api/LikeOrUnLike")]
        public HttpResponseMessage LikeOrUnLike(string UserName, decimal MESSAGE_FEED_ID)
        {
            try
            {
                var account = new AccountModel().GetUserByUserName(UserName);
                var newFeed = db.MESSAGE_FEED.SingleOrDefault(x => x.MESSAGE_FEED_ID == MESSAGE_FEED_ID);
                if (account == null)
                {
                    return ResponseFail(StringResource.Account_does_not_exist);
                }
                else if (newFeed == null)
                {
                    return ResponseFail(StringResource.Activity_feed_do_not_exist);
                }
                else
                {
                    var result = db.PERSON_LIKING_MESSAGE_FEED.Where(x => x.MESSAGE_FEED_ID == MESSAGE_FEED_ID && x.UserName == UserName);
                    if (result.ToList().Count > 0)
                    {
                        newFeed.NUMBER_OF_LIKES = newFeed.NUMBER_OF_LIKES - 1;
                        db.PERSON_LIKING_MESSAGE_FEED.RemoveRange(result);
                        db.SaveChanges();
                    }
                    else
                    {
                        newFeed.NUMBER_OF_LIKES = newFeed.NUMBER_OF_LIKES + 1;
                        var personLinking = new PERSON_LIKING_MESSAGE_FEED();
                        personLinking.MESSAGE_FEED_ID = MESSAGE_FEED_ID;
                        personLinking.UserName = UserName;
                        personLinking.PERSON_ID = account.PERSON_ID;
                        personLinking.LIKED_DATETIME = DateTime.Now;
                        personLinking.CURRENT_FIRST_NAME = account.CURRENT_FIRST_NAME;
                        personLinking.CURRENT_MIDDLE_NAME = account.CURRENT_MIDDLE_NAME;
                        personLinking.CURRENT_LAST_NAME = account.CURRENT_LAST_NAME;
                        db.PERSON_LIKING_MESSAGE_FEED.Add(personLinking);
                        db.SaveChanges();
                    }
                    return ResponseSuccess(StringResource.Success);
                }
            }
            catch
            {
                return ResponseFail(StringResource.Can_not_like);
            }
        }

        [HttpPost]
        [Route("api/DeleteStatus")]
        public HttpResponseMessage DeleteStatus(string userName, decimal MESSAGE_FEED_ID)
        {
            var list = db.MESSAGE_FEED.SingleOrDefault(x => x.UserName == userName && x.MESSAGE_FEED_ID == MESSAGE_FEED_ID);
            list.DELETED = true;
            list.DELETED_DATETIME = DateTime.Now;
            db.SaveChanges();
            return ResponseSuccess(StringResource.Success);
        }
    }

    public class Status
    {
        public decimal MESSAGE_FEED_ID { get; set; }
        public string UserName { get; set; }
        public decimal? REPLYING_TO_MESSAGE_FEED_ID { get; set; }
        public string CURRENT_LAST_NAME { get; set; }
        public string CURRENT_FIRST_NAME { get; set; }
        public string CURRENT_MIDDLE_NAME { get; set; }
        public decimal CONFERENCE_ID { get; set; }
        public string CONFERENCE_NAME { get; set; }
        public string CONFERENCE_NAME_EN { get; set; }
        public string MESSAGE_CONTENT { get; set; }
        public string ATTACHED_PHOTO_FILENAME { get; set; }
        public string ATTACHED_PHOTO_NOTE { get; set; }
        public string ATTACHED_PHOTO_LONGITUDE { get; set; }
        public string ATTACHED_PHOTO_LATITUDE { get; set; }
        public string Image { get; set; }
        public string Time { get; set; }
    }

    public class ActivityFeed
    {
        public decimal MESSAGE_FEED_ID { get; set; }
        public string UserName { get; set; }
        public decimal? PERSON_ID { get; set; }
        public string CURRENT_HOME_ORGANIZATION_NAME { get; set; }
        public string CURRENT_HOME_ORGANIZATION_NAME_EN { get; set; }
        public string CURRENT_LAST_NAME { get; set; }
        public string CURRENT_FIRST_NAME { get; set; }
        public string CURRENT_MIDDLE_NAME { get; set; }
        public decimal? REPLYING_TO_MESSAGE_FEED_ID { get; set; }
        public string MESSAGE_CONTENT { get; set; }
        public string ATTACHED_PHOTO_FILENAME { get; set; }
        public string ATTACHED_PHOTO_NOTE { get; set; }
        public string ATTACHED_PHOTO_LONGITUDE { get; set; }
        public string ATTACHED_PHOTO_LATITUDE { get; set; }
        public string Image { get; set; }
        public string Time { get; set; }
        public DateTime? FROM_DATE { get; set; }
        public DateTime? THRU_DATE { get; set; }
        public bool IS_LIKED { get; set; }
        public List<ActivityFeed> ListComment { get; set; }
        public object ListLike { get; set; }
    }

    public class UserOfSession
    {
        public string UserName { get; set; }
        public string Image { get; set; }
        public string CURRENT_FIRST_NAME { get; set; }
        public string CURRENT_LAST_NAME { get; set; }
        public string CURRENT_MIDDLE_NAME { get; set; }
    }

    public class PhotoFeed
    {
        public string Date { get; set; }
        public List<MESSAGE_FEED> ListFeed { get; set; }
    }

    public class PhotoResponse
    {
        public string Date { get; set; }
        public List<ActivityFeed> ListFeed { get; set; }
    }
}
