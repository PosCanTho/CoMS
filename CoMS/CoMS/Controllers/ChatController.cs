using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoMS.Resources;
using System.IO;
using Newtonsoft.Json;
using CoMS.Models;
using CoMS.Untils;
using CoMS.Entities_Framework;
using PagedList;

namespace CoMS.Controllers
{
    public class ChatController : BaseController
    {

        [HttpPost]
        [Route("api/SendMessage")]
        public HttpResponseMessage SendMessage([FromBody]Chat chat)
        {
            if (chat != null)
            {
                try
                {
                    var accountSend = db.ACCOUNTs.SingleOrDefault(x => x.UserName == chat.data.UserName);
                    var accountRecive = db.ACCOUNTs.SingleOrDefault(x => x.UserName == chat.data.RECIPIENT_UserName_1);
                    var conference = db.CONFERENCEs.SingleOrDefault(x => x.CONFERENCE_ID == chat.data.CONFERENCE_ID);
                    var manage = new ManageDeviceModel().GetDeviceUserName(chat.data.RECIPIENT_UserName_1);
                    if (accountSend == null)
                    {
                        return ResponseFail(StringResource.Account_does_not_exist);
                    }
                    else if (accountRecive == null)
                    {
                        return ResponseFail(StringResource.Account_does_not_exist);
                    }
                    else if (conference == null)
                    {
                        return ResponseFail(StringResource.Conference_do_not_exist);
                    }
                    else if (manage == null)
                    {
                        return ResponseFail(StringResource.Account_has_not_been_logged);
                    }
                    else if (String.IsNullOrEmpty(manage.DEVICE_TOKEN))
                    {
                        return ResponseFail(StringResource.Account_has_not_been_logged);
                    }
                    else
                    {
                        string deviceId = manage.DEVICE_TOKEN;
                        var result = "-1";
                        var webAddr = "https://fcm.googleapis.com/fcm/send";

                        var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                        httpWebRequest.ContentType = "application/json";
                        httpWebRequest.Headers.Add("Authorization:key=" + StringResource.Server_fcm_key);
                        httpWebRequest.Method = "POST";
                        /*Thêm vào CSDL*/
                        var messageFeed = new MESSAGE_FEED();
                        messageFeed.FROM_DATE = DateTime.Now;
                        messageFeed.UserName = chat.data.UserName;
                        messageFeed.CURRENT_FIRST_NAME = accountSend.CURRENT_FIRST_NAME;
                        messageFeed.CURRENT_MIDDLE_NAME = accountSend.CURRENT_MIDDLE_NAME;
                        messageFeed.CURRENT_LAST_NAME = accountSend.CURRENT_LAST_NAME;
                        messageFeed.CONFERENCE_ID = chat.data.CONFERENCE_ID;
                        messageFeed.CONFERENCE_NAME = conference.CONFERENCE_NAME;
                        messageFeed.CONFERENCE_NAME_EN = conference.CONFERENCE_NAME_EN;
                        messageFeed.PUBLIC_OR_PRIVATE_MESSAGE = "PRIVATE";
                        messageFeed.MESSAGE_CONTENT = chat.Body;
                        messageFeed.RECIPIENT_UserName_1 = chat.data.RECIPIENT_UserName_1;
                        messageFeed.RECIPIENT_CURRENT_LAST_NAME_1 = accountRecive.CURRENT_LAST_NAME;
                        messageFeed.RECIPIENT_CURRENT_MIDDLE_NAME_1 = accountRecive.CURRENT_MIDDLE_NAME;
                        messageFeed.RECIPIENT_CURRENT_FIRST_NAME_1 = accountRecive.CURRENT_FIRST_NAME;
                        new NewFeedModel().addNewFeed(messageFeed);

                        /*Tạo dữ liệu trả về*/
                        var msg = new MessageResponse();
                        msg.MESSAGE_FEED_ID = messageFeed.MESSAGE_FEED_ID;
                        msg.MESSAGE_CONTENT = messageFeed.MESSAGE_CONTENT;
                        msg.IsMoreThanOneDay = false;
                        msg.IsToDay = DateTimeFormater.CheckIsToday(messageFeed.FROM_DATE.Value);
                        msg.TimeFormat = DateTimeFormater.GetTimeAgo(messageFeed.FROM_DATE.Value);
                        msg.Time = messageFeed.FROM_DATE.Value;
                        msg.UserName = messageFeed.UserName;
                        msg.PERSON_ID_SEND = accountSend.PERSON_ID;
                        msg.ORGANIZATION_SEND = accountSend.CURRENT_HOME_ORGANIZATION_NAME;
                        msg.ORGANIZATION_EN_SEND = accountSend.CURRENT_HOME_ORGANIZATION_NAME_EN;
                        msg.Image = accountSend.Image;
                        msg.FULL_NAME_PERSON_SEND = Utils.GetFullName(messageFeed.CURRENT_FIRST_NAME, messageFeed.CURRENT_MIDDLE_NAME, messageFeed.CURRENT_LAST_NAME);
                        msg.RECIPIENT_UserName_1 = messageFeed.RECIPIENT_UserName_1;
                        msg.FULL_NAME_PERSON_RECIVE = Utils.GetFullName(messageFeed.RECIPIENT_CURRENT_FIRST_NAME_1, messageFeed.RECIPIENT_CURRENT_MIDDLE_NAME_1, messageFeed.RECIPIENT_CURRENT_LAST_NAME_1);
                        msg.IS_MESSAGE = true;

                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                        {

                            var notification = new Notification();
                            notification.body = chat.Body;
                            notification.title = msg.FULL_NAME_PERSON_SEND;
                            notification.sound = chat.Sound;
                            notification.priority = chat.Priority;

                            JsonData data = new JsonData();
                            data.Data = JsonConvert.SerializeObject(msg);

                            var json = new DataJson();
                            json.notification = notification;
                            json.data = data;
                            json.to = deviceId;

                            streamWriter.Write(JsonConvert.SerializeObject(json));
                            streamWriter.Flush();

                            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                            {
                                result = streamReader.ReadToEnd();
                            }

                            return ResponseSuccess(StringResource.Success, msg);
                        }
                    }
                }
                catch (Exception)
                {
                    return ResponseFail(StringResource.Sorry_an_error_has_occurred);
                }

            }
            else
            {
                return ResponseFail(StringResource.Data_not_received);
            }
        }


        [HttpPost]
        [Route("api/ListMessage")]
        public HttpResponseMessage ListMessage(string UserName, string RECIPIENT_UserName_1, int conferenceId, int page, int pageSize)
        {
            var accountSend = db.ACCOUNTs.SingleOrDefault(x => x.UserName == UserName);
            var list = db.MESSAGE_FEED.Where(x => (x.UserName == UserName && x.RECIPIENT_UserName_1 == RECIPIENT_UserName_1) || (x.UserName == RECIPIENT_UserName_1 && x.RECIPIENT_UserName_1 == UserName) && x.CONFERENCE_ID == conferenceId && (x.DELETED == false || x.DELETED == null))
                .Where(x => x.DELETED_UserName != UserName)
                .OrderByDescending(x => x.FROM_DATE)
                .ToPagedList(page, pageSize);
            var listMessage = new List<MessageResponse>();
            int size = list.Count;
            for (int i = 0; i < size; i++)
            {
                var item = list[i];
                var itemLater = list[i > 1 ? i - 1 : i];
                DateTime? dt = item.FROM_DATE;
                DateTime? dtLater = itemLater.FROM_DATE;
                if (dt.HasValue && dtLater.HasValue)
                {
                    var msg = new MessageResponse();
                    msg.MESSAGE_FEED_ID = item.MESSAGE_FEED_ID;
                    msg.MESSAGE_CONTENT = item.MESSAGE_CONTENT;
                    msg.IsToDay = DateTimeFormater.CheckIsToday(dt.Value);
                    msg.TimeFormat = DateTimeFormater.GetTimeAgo(dt.Value);
                    msg.Time = dt;
                    msg.UserName = item.UserName;
                    msg.PERSON_ID_SEND = accountSend.PERSON_ID;
                    msg.ORGANIZATION_SEND = accountSend.CURRENT_HOME_ORGANIZATION_NAME;
                    msg.ORGANIZATION_EN_SEND = accountSend.CURRENT_HOME_ORGANIZATION_NAME_EN;
                    msg.FULL_NAME_PERSON_SEND = Utils.GetFullName(item.CURRENT_FIRST_NAME, item.CURRENT_MIDDLE_NAME, item.CURRENT_LAST_NAME);
                    msg.RECIPIENT_UserName_1 = item.RECIPIENT_UserName_1;
                    msg.FULL_NAME_PERSON_RECIVE = Utils.GetFullName(item.RECIPIENT_CURRENT_FIRST_NAME_1, item.RECIPIENT_CURRENT_MIDDLE_NAME_1, item.RECIPIENT_CURRENT_LAST_NAME_1);
                    if (i > 0)
                    {
                        listMessage[i - 1].IsMoreThanOneDay = DateTimeFormater.CheckMoreThanOneDay(dtLater.Value, dt.Value);
                    }
                    listMessage.Add(msg);
                }
            }
            return ResponseSuccess(StringResource.Success, listMessage);
        }


        [HttpPost]
        [Route("api/DeleteAllMessage")]
        public HttpResponseMessage DeleteAllMessage(string UserName, string RECIPIENT_UserName_1, int conferenceId)
        {
            try
            {
                var list = db.MESSAGE_FEED.Where(x => (x.UserName == UserName && x.RECIPIENT_UserName_1 == RECIPIENT_UserName_1) || (x.UserName == RECIPIENT_UserName_1 && x.RECIPIENT_UserName_1 == UserName) && (x.DELETED_UserName != UserName) && x.CONFERENCE_ID == conferenceId && (x.DELETED == false || x.DELETED == null));
                var model = new NewFeedModel();
                foreach (MESSAGE_FEED item in list)
                {
                    if (item.DELETED_UserName == null || item.DELETED_UserName == UserName)
                    {
                        var itemUpdate = db.MESSAGE_FEED.SingleOrDefault(x => x.MESSAGE_FEED_ID == item.MESSAGE_FEED_ID);
                        item.DELETED_UserName = UserName;
                        item.DELETED_DATETIME = DateTime.Now;
                        var result = model.updateMessageFeed(item);
                    }
                    else
                    {
                        var itemUpdate = db.MESSAGE_FEED.SingleOrDefault(x => x.MESSAGE_FEED_ID == item.MESSAGE_FEED_ID);
                        item.DELETED_UserName = UserName;
                        item.DELETED_DATETIME = DateTime.Now;
                        item.DELETED = true;
                        var result = model.updateMessageFeed(item);
                    }
                    
                }
                return ResponseSuccess(StringResource.Success);
            }
            catch (Exception)
            {
                return ResponseFail(StringResource.Delete_list_message_fail);
            }
        }


        [HttpGet]
        [Route("api/ListConversation")]
        public HttpResponseMessage ListConversation(string UserName, int conferenceId)
        {
            var acccount = db.ACCOUNTs.SingleOrDefault(x => x.UserName == UserName);
            if (acccount == null)
            {
                return ResponseFail(StringResource.Account_does_not_exist);
            }
            else
            {
                var list = from f in db.MESSAGE_FEED
                                       where (f.UserName == UserName || f.RECIPIENT_UserName_1 == UserName) && f.PUBLIC_OR_PRIVATE_MESSAGE == "PRIVATE" && f.CONFERENCE_ID == conferenceId && f.DELETED_UserName != UserName
                                       group f by new { f.UserName, f.RECIPIENT_UserName_1} into x
                                       select new Conversation() {
                                           UserName = x.Key.UserName,
                                           RECIPIENT_UserName_1 = x.Key.RECIPIENT_UserName_1
                                       };
                var listConversation = new List<Conversation>();
                foreach (Conversation item in list)
                {
                    
                    if (!listConversation.Any(x => (x.UserName == item.UserName && x.RECIPIENT_UserName_1 == item.RECIPIENT_UserName_1) || (x.UserName == item.RECIPIENT_UserName_1 && x.RECIPIENT_UserName_1 == item.UserName)))
                    {
                        var ac = new AccountModel().GetUserByUserName(item.UserName != UserName ? item.UserName : item.RECIPIENT_UserName_1);
                        if (ac != null)
                        {
                            item.Name = Utils.GetFullName(ac.CURRENT_FIRST_NAME, ac.CURRENT_MIDDLE_NAME, ac.CURRENT_LAST_NAME);
                            item.Image = ac.Image;
                            var lastMessage = new NewFeedModel().getLastMessage(UserName, (item.UserName != UserName ? item.UserName : item.RECIPIENT_UserName_1), conferenceId);
                            if (lastMessage != null)
                            {
                                item.Message = lastMessage.MESSAGE_CONTENT;
                            }
                            listConversation.Add(item);
                        }
                    }
                }

                return ResponseSuccess(StringResource.Success, listConversation);
            }
        }
    }

    public class Chat
    {
        public string Body { get; set; }
        public string Sound { get; set; }
        public string Priority { get; set; }
        public Data data { get; set; }
    }

    public class Notification
    {
        public string body { get; set; }
        public string title { get; set; }
        public string sound { get; set; }
        public string priority { get; set; }
    }

    public class Data
    {
        public string UserName { get; set; }
        public int CONFERENCE_ID { get; set; }
        public string RECIPIENT_UserName_1 { get; set; }
    }

    public class DataJson
    {
        public Notification notification { get; set; }
        public JsonData data { get; set; }
        public string to { get; set; }
    }

    public class MessageResponse
    {
        public decimal MESSAGE_FEED_ID { get; set; }
        public string MESSAGE_CONTENT { get; set; }
        public bool IsMoreThanOneDay { get; set; }
        public bool IsToDay { get; set; }
        public string TimeFormat { get; set; }
        public DateTime? Time { get; set; }
        public string UserName { get; set; }
        public string Image { get; set; }
        public string FULL_NAME_PERSON_SEND { get; set; }
        public string RECIPIENT_UserName_1 { get; set; }
        public decimal? PERSON_ID_SEND { get; set; }
        public string ORGANIZATION_SEND { get; set; }
        public string ORGANIZATION_EN_SEND { get; set; }
        public string FULL_NAME_PERSON_RECIVE { get; set; }
        public decimal? RECIPIENT_MESSAGING_GROUP_ID_1 { get; set; }
        public string RECIPIENT_MESSAGING_GROUP_NAME_1 { get; set; }
        public string RECIPIENT_MESSAGING_GROUP_NAME_EN_1 { get; set; }
        public bool IS_MESSAGE_GROUP { get; set; }
        public bool IS_MESSAGE { get; set; }
    }

    public class JsonData
    {
        public string Data { get; set; }
    }

    public class Conversation
    {
        public string UserName { get; set; }
        public string RECIPIENT_UserName_1 { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string Image { get; set; }
    }
}
