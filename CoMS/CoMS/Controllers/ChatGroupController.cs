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
    public class ChatGroupController : BaseController
    {
        private DB db = new DB();

        [HttpPost]
        [Route("api/SendMessageGroup")]
        public HttpResponseMessage SendMessageGroup([FromBody]ChatGroup chat)
        {
            var accountSend = db.ACCOUNTs.SingleOrDefault(x => x.UserName == chat.data.UserName);
            var group = db.MESSAGING_GROUP.SingleOrDefault(x => x.MESSAGING_GROUP_ID == chat.data.MESSAGING_GROUP_ID);
            var conference = db.CONFERENCEs.SingleOrDefault(x => x.CONFERENCE_ID == chat.data.CONFERENCE_ID);
            if (accountSend == null)
            {
                return ResponseFail(StringResource.Account_does_not_exist);
            }
            else if (group == null)
            {
                return ResponseFail(StringResource.Message_group_do_not_exist);
            }
            else if (conference == null)
            {
                return ResponseFail(StringResource.Conference_do_not_exist);
            }
            else
            {
                var listMember = db.ACCOUNT_MESSAGING_GROUP_MEMBERSHIP.Where(x => x.MESSAGING_GROUP_ID == chat.data.MESSAGING_GROUP_ID
                && (x.GROUP_ASSIGNED_OR_GROUP_JOIN_REQUEST_OR_GROUP_JOIN_REQUEST_APPROVED == "GROUP ASSIGNED" || x.GROUP_ASSIGNED_OR_GROUP_JOIN_REQUEST_OR_GROUP_JOIN_REQUEST_APPROVED == "GROUP JOIN REQUEST APPROVED")
                && (x.DELETED == false || x.DELETED == null)).ToList();

                var adminGroup = new ACCOUNT_MESSAGING_GROUP_MEMBERSHIP();
                adminGroup.UserName = group.CREATED_UserName;
                listMember.Add(adminGroup);

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
                messageFeed.RECIPIENT_MESSAGING_GROUP_ID_1 = group.MESSAGING_GROUP_ID;
                messageFeed.RECIPIENT_MESSAGING_GROUP_NAME_1 = group.MESSAGING_GROUP_NAME;
                messageFeed.RECIPIENT_MESSAGING_GROUP_NAME_EN_1 = group.MESSAGING_GROUP_NAME;
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
                msg.RECIPIENT_MESSAGING_GROUP_ID_1 = messageFeed.RECIPIENT_MESSAGING_GROUP_ID_1;
                msg.RECIPIENT_MESSAGING_GROUP_NAME_1 = messageFeed.RECIPIENT_MESSAGING_GROUP_NAME_1;
                msg.RECIPIENT_MESSAGING_GROUP_NAME_EN_1 = messageFeed.RECIPIENT_MESSAGING_GROUP_NAME_EN_1;
                msg.IS_MESSAGE_GROUP = true;

                foreach (ACCOUNT_MESSAGING_GROUP_MEMBERSHIP item in listMember)
                {

                    var memberRecive = db.ACCOUNT_DEVICE_RELATIONSHIP.SingleOrDefault(x => x.UserName == item.UserName);
                    if (memberRecive != null)
                    {
                        var deviceId = memberRecive.DEVICE_TOKEN;
                        if (deviceId != null)
                        {
                            var result = "-1";
                            var webAddr = "https://fcm.googleapis.com/fcm/send";

                            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                            httpWebRequest.ContentType = "application/json";
                            httpWebRequest.Headers.Add("Authorization:key=" + StringResource.Server_fcm_key);
                            httpWebRequest.Method = "POST";

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
                            }
                        }
                    }
                }

                return ResponseSuccess(StringResource.Success, msg);
            }
        }

        [HttpPost]
        [Route("api/ListMessageGroup")]
        public HttpResponseMessage ListMessageGroup(int MESSAGING_GROUP_ID, int conferenceId, int page, int pageSize)
        {
            var list = db.MESSAGE_FEED.Where(x => x.RECIPIENT_MESSAGING_GROUP_ID_1 == MESSAGING_GROUP_ID && x.PUBLIC_OR_PRIVATE_MESSAGE == "PRIVATE" && x.CONFERENCE_ID == conferenceId)
                .Where(x => x.DELETED == false || x.DELETED == null)
                .OrderByDescending(x => x.FROM_DATE).ToPagedList(page, pageSize);
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
                    var accountSend = db.ACCOUNTs.SingleOrDefault(x => x.UserName == item.UserName);
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
                    msg.Image = new AccountModel().GetUserByUserName(item.UserName).Image;
                    msg.FULL_NAME_PERSON_SEND = Utils.GetFullName(item.CURRENT_FIRST_NAME, item.CURRENT_MIDDLE_NAME, item.CURRENT_LAST_NAME);
                    msg.RECIPIENT_MESSAGING_GROUP_ID_1 = item.RECIPIENT_MESSAGING_GROUP_ID_1;
                    msg.RECIPIENT_MESSAGING_GROUP_NAME_1 = item.RECIPIENT_MESSAGING_GROUP_NAME_1;
                    msg.RECIPIENT_MESSAGING_GROUP_NAME_EN_1 = item.RECIPIENT_MESSAGING_GROUP_NAME_EN_1;
                    msg.IS_MESSAGE_GROUP = true;
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
        [Route("api/DeleteMessageGroup")]
        public HttpResponseMessage DeleteMessageGroup(int MESSAGE_FEED_ID, string userName, int conferenceId)
        {
            try
            {
                var messageFeed = db.MESSAGE_FEED.SingleOrDefault(x => x.MESSAGE_FEED_ID == MESSAGE_FEED_ID && x.PUBLIC_OR_PRIVATE_MESSAGE == "PRIVATE" && x.CONFERENCE_ID == conferenceId && x.UserName == userName);
                if (messageFeed == null)
                {
                    return ResponseFail(StringResource.Message_do_not_exist);
                }
                else
                {
                    messageFeed.DELETED = true;
                    messageFeed.DELETED_UserName = userName;
                    messageFeed.DELETED_DATETIME = DateTime.Now;
                    db.SaveChanges();
                    return ResponseSuccess(StringResource.Success);
                }
            }
            catch
            {
                return ResponseFail(StringResource.Can_not_delete_message);
            }
        }

        [HttpPost]
        [Route("api/JoinChannel")]
        public HttpResponseMessage JoinChannel(string userName, int MESSAGING_GROUP_ID, int conferenceId)
        {
            var account = db.ACCOUNTs.SingleOrDefault(x => x.UserName == userName);
            var group = db.MESSAGING_GROUP.SingleOrDefault(x => x.MESSAGING_GROUP_ID == MESSAGING_GROUP_ID);
            var conference = db.CONFERENCEs.SingleOrDefault(x => x.CONFERENCE_ID == conferenceId);
            var joinRequestIsExist = db.ACCOUNT_MESSAGING_GROUP_MEMBERSHIP.Where(x => x.UserName == userName && x.MESSAGING_GROUP_ID == MESSAGING_GROUP_ID && x.GROUP_ASSIGNED_OR_GROUP_JOIN_REQUEST_OR_GROUP_JOIN_REQUEST_APPROVED == "GROUP JOIN REQUEST" && (x.DELETED == false || x.DELETED == null)).ToList();
            var joined = db.ACCOUNT_MESSAGING_GROUP_MEMBERSHIP.Where(x => x.UserName == userName && x.MESSAGING_GROUP_ID == MESSAGING_GROUP_ID && (x.GROUP_ASSIGNED_OR_GROUP_JOIN_REQUEST_OR_GROUP_JOIN_REQUEST_APPROVED == "GROUP ASSIGNED" || x.GROUP_ASSIGNED_OR_GROUP_JOIN_REQUEST_OR_GROUP_JOIN_REQUEST_APPROVED == "GROUP JOIN REQUEST APPROVED") && (x.DELETED == false || x.DELETED == null)).ToList();
            if (account == null)
            {
                return ResponseFail(StringResource.Account_does_not_exist);
            }
            else if (group == null)
            {
                return ResponseFail(StringResource.Message_group_do_not_exist);
            }
            else if (conference == null)
            {
                return ResponseFail(StringResource.Conference_do_not_exist);
            }
            else if (joinRequestIsExist.Count > 0)
            {
                return ResponseFail(StringResource.You_have_submitted_your_request);
            }
            else if (joined.Count > 0)
            {
                return ResponseFail(StringResource.You_joined_the_group);
            }
            else
            {
                var member = new ACCOUNT_MESSAGING_GROUP_MEMBERSHIP();
                member.UserName = account.UserName;
                member.MESSAGING_GROUP_ID = MESSAGING_GROUP_ID;
                member.START_DATETIME = DateTime.Now;
                member.CREATED_UserName = group.CREATED_UserName;
                member.MESSAGING_GROUP_MODERATOR = userName == group.CREATED_UserName ? true : false;
                member.GROUP_ASSIGNED_OR_GROUP_JOIN_REQUEST_OR_GROUP_JOIN_REQUEST_APPROVED = StringResource.GROUP_JOIN_REQUEST;
                db.ACCOUNT_MESSAGING_GROUP_MEMBERSHIP.Add(member);
                db.SaveChanges();
                return ResponseSuccess(StringResource.Success);
            }
        }

        [HttpPost]
        [Route("api/ListJoinChannel")]
        public HttpResponseMessage ListJoinChannel(string userName, int MESSAGING_GROUP_ID)
        {

            var account = db.ACCOUNTs.SingleOrDefault(x => x.UserName == userName);
            var group = db.MESSAGING_GROUP.SingleOrDefault(x => x.MESSAGING_GROUP_ID == MESSAGING_GROUP_ID && (x.DELETED == false || x.DELETED == null));
            if (account == null)
            {
                return ResponseFail(StringResource.Account_does_not_exist);
            }
            else if (group == null)
            {
                return ResponseFail(StringResource.Message_group_do_not_exist);
            }
            else
            {
                var list = new AccountMessagingGroupMemberModel().getListJoinChannel(userName, MESSAGING_GROUP_ID);

                return ResponseSuccess(StringResource.Success, list);
            }
        }

        [HttpPost]
        [Route("api/ApprovedRequest")]
        public HttpResponseMessage ApprovedRequest(string userName, string userNameApprove, int MESSAGING_GROUP_ID)
        {
            var account = db.ACCOUNTs.SingleOrDefault(x => x.UserName == userName);
            var group = db.MESSAGING_GROUP.SingleOrDefault(x => x.MESSAGING_GROUP_ID == MESSAGING_GROUP_ID && (x.DELETED == false || x.DELETED == null));
            if (account == null)
            {
                return ResponseFail(StringResource.Account_does_not_exist);
            }
            else if (group == null)
            {
                return ResponseFail(StringResource.Message_group_do_not_exist);
            }
            else
            {
                var member = db.ACCOUNT_MESSAGING_GROUP_MEMBERSHIP.SingleOrDefault(x => x.UserName == userNameApprove && x.MESSAGING_GROUP_ID == MESSAGING_GROUP_ID && x.GROUP_ASSIGNED_OR_GROUP_JOIN_REQUEST_OR_GROUP_JOIN_REQUEST_APPROVED == "GROUP JOIN REQUEST" && (x.DELETED == false || x.DELETED == null));
                if (member != null)
                {
                    member.GROUP_ASSIGNED_OR_GROUP_JOIN_REQUEST_OR_GROUP_JOIN_REQUEST_APPROVED = "GROUP JOIN REQUEST APPROVED";
                    db.SaveChanges();
                    return ResponseSuccess(StringResource.Success);
                }
                else
                {
                    return ResponseFail(StringResource.Member_do_not_exist);
                }
            }
        }

        [HttpPost]
        [Route("api/RejectRequest")]
        public HttpResponseMessage RejectRequest(string userName, string userNameReject, int MESSAGING_GROUP_ID)
        {
            var account = db.ACCOUNTs.SingleOrDefault(x => x.UserName == userName);
            var accountReject = db.ACCOUNTs.SingleOrDefault(x => x.UserName == userNameReject);
            var group = db.MESSAGING_GROUP.SingleOrDefault(x => x.MESSAGING_GROUP_ID == MESSAGING_GROUP_ID && (x.DELETED == false || x.DELETED == null));
            if (account == null || accountReject == null)
            {
                return ResponseFail(StringResource.Account_does_not_exist);
            }
            else if (group == null)
            {
                return ResponseFail(StringResource.Message_group_do_not_exist);
            }
            else
            {
                var member = db.ACCOUNT_MESSAGING_GROUP_MEMBERSHIP.SingleOrDefault(x => x.UserName == userNameReject && x.MESSAGING_GROUP_ID == MESSAGING_GROUP_ID && x.GROUP_ASSIGNED_OR_GROUP_JOIN_REQUEST_OR_GROUP_JOIN_REQUEST_APPROVED == "GROUP JOIN REQUEST" && (x.DELETED == false || x.DELETED == null));
                if (member != null)
                {
                    member.DELETED = true;
                    member.DELETED_UserName = userName;
                    db.SaveChanges();
                    return ResponseSuccess(StringResource.Success);
                }
                else
                {
                    return ResponseFail(StringResource.Member_do_not_exist);
                }
            }
        }


        [HttpPost]
        [Route("api/CheckIsJoinChannel")]
        public HttpResponseMessage CheckIsJoinChannel(string userName, int MESSAGING_GROUP_ID)
        {
            var account = db.ACCOUNTs.SingleOrDefault(x => x.UserName == userName);
            var group = db.MESSAGING_GROUP.SingleOrDefault(x => x.MESSAGING_GROUP_ID == MESSAGING_GROUP_ID);
            if (account == null)
            {
                return ResponseFail(StringResource.Account_does_not_exist);
            }else if(group == null)
            {
                return ResponseFail(StringResource.Message_group_do_not_exist);
            }
            else
            {
                
                var check = new CheckJoin();
                var result = db.ACCOUNT_MESSAGING_GROUP_MEMBERSHIP.SingleOrDefault(x => x.MESSAGING_GROUP_ID == MESSAGING_GROUP_ID && x.UserName == userName && (x.DELETED == false || x.DELETED == null));
                if (result != null)
                {
                    check.UserName = result.UserName;
                    check.MESSAGING_GROUP_ID = result.MESSAGING_GROUP_ID;
                    check.MESSAGING_GROUP_MODERATOR = result.MESSAGING_GROUP_MODERATOR;
                    check.GROUP_ASSIGNED_OR_GROUP_JOIN_REQUEST_OR_GROUP_JOIN_REQUEST_APPROVED = result.GROUP_ASSIGNED_OR_GROUP_JOIN_REQUEST_OR_GROUP_JOIN_REQUEST_APPROVED;
                    return ResponseSuccess(StringResource.Success, check);
                }else if (group.CREATED_UserName == userName)
                {
                    check.UserName = userName;
                    check.MESSAGING_GROUP_ID = MESSAGING_GROUP_ID;
                    check.MESSAGING_GROUP_MODERATOR = true;
                    check.GROUP_ASSIGNED_OR_GROUP_JOIN_REQUEST_OR_GROUP_JOIN_REQUEST_APPROVED = "GROUP ASSIGNED";
                    return ResponseSuccess(StringResource.Success, check);
                }
                else
                {
                    check.UserName = userName;
                    check.MESSAGING_GROUP_ID = MESSAGING_GROUP_ID;
                    check.MESSAGING_GROUP_MODERATOR = false;
                    check.GROUP_ASSIGNED_OR_GROUP_JOIN_REQUEST_OR_GROUP_JOIN_REQUEST_APPROVED = "GROUP UNASSIGNED";
                    return ResponseSuccess(StringResource.Success, check);
                }
            }
        }
    }

    public class ChatGroup
    {
        public string Body { get; set; }
        public string Sound { get; set; }
        public string Priority { get; set; }
        public DataGroup data { get; set; }
    }

    public class DataGroup
    {
        public string UserName { get; set; }
        public int MESSAGING_GROUP_ID { get; set; }
        public int CONFERENCE_ID { get; set; }
    }

    public class CheckJoin
    {
        public string UserName { get; set; }
        public decimal MESSAGING_GROUP_ID { get; set; }
        public bool? MESSAGING_GROUP_MODERATOR { get; set; }
        public string GROUP_ASSIGNED_OR_GROUP_JOIN_REQUEST_OR_GROUP_JOIN_REQUEST_APPROVED { get; set; }
    }
}
