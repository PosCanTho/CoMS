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
                    messageFeed.CONFERENCE_NAME = status.CONFERENCE_NAME;
                    messageFeed.CONFERENCE_NAME_EN = status.CONFERENCE_NAME_EN;
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
        public HttpResponseMessage ListNewFeed(decimal conferenceId, int page, int pageSize)
        {
            var model = new NewFeedModel();
            var activityFeeds = model.getListActivityFeed(conferenceId, page, pageSize);

            foreach (ActivityFeed item in activityFeeds)
            {
                var list = model.getListActivityFeed( item.MESSAGE_FEED_ID, page, pageSize);
                if (list.Count > 0)
                {
                    item.ListComment = list;
                }
            }

            return ResponseSuccess(StringResource.Success, activityFeeds);
        }

        [HttpPost]
        [Route("api/ListNewFeedOfUser")]
        public HttpResponseMessage ListNewFeedOfUser(string userName, decimal conferenceId, int page, int pageSize)
        {
            var model = new NewFeedModel();
            var activityFeeds = model.getListActivityFeedOfUser(userName, conferenceId, page, pageSize);

            foreach (ActivityFeed item in activityFeeds)
            {
                var list = model.getListActivityFeedComment(item.MESSAGE_FEED_ID, page, pageSize);
                if (list.Count > 0)
                {
                    item.ListComment = list;
                }
            }

            return ResponseSuccess(StringResource.Success, activityFeeds);
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
        [Route("api/DeleteStatus")]
        public HttpResponseMessage DeleteStatus(string userName, decimal MESSAGE_FEED_ID)
        {
            var list = db.MESSAGE_FEED.Where(x => x.UserName == userName && x.MESSAGE_FEED_ID == MESSAGE_FEED_ID);
            db.MESSAGE_FEED.RemoveRange(list);
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
        public List<ActivityFeed> ListComment { get; set; }
    }
}
