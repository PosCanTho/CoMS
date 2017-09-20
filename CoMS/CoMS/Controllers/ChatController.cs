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
                    var result = "-1";
                    var webAddr = "https://fcm.googleapis.com/fcm/send";
                    string DeviceId = new ManageDeviceModel().GetDeviceByPersonId(chat.data.PersonIdTo).DEVICE_TOKEN;

                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Headers.Add("Authorization:key=" + StringResource.Server_fcm_key);
                    httpWebRequest.Method = "POST";
                    /*Thêm vào CSDL*/
                    var conversationReplyModel = new ConversationReplyModel();
                    var conversationReply = new Conversation_Reply();
                    conversationReply.MESSAGE = chat.Body;
                    conversationReply.TIME = DateTime.Now;
                    conversationReply.PERSON_ID_FROM = chat.data.PersonIdFrom;
                    conversationReply.PERSON_ID_TO = chat.data.PersonIdTo;
                    conversationReplyModel.AddMessage(conversationReply);

                    /*Tạo dữ liệu trả về*/
                    DateTime? dt = conversationReply.TIME;
                    var msg = new MessageResponse();
                    msg.ConversationReplyId = conversationReply.CONVERSATION_REPLY_ID;
                    msg.Message = conversationReply.MESSAGE;
                    if (dt.HasValue)
                    {
                        msg.TimeFormat = DateTimeFormater.GetTimeAgo(dt.Value);
                        msg.IsToDay = DateTimeFormater.CheckIsToday(dt.Value);
                    }
                    msg.Time = dt;
                    msg.PersonIdFrom = conversationReply.PERSON_ID_FROM;
                    msg.PersonIdTo = conversationReply.PERSON_ID_TO;
                    msg.IsMoreThanOneDay = false;

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        var accountModel = new AccountModel();
                        var accountFrom = accountModel.GetAccountById(chat.data.PersonIdFrom);

                        var notification = new Notification();
                        notification.body = chat.Body;
                        notification.title = Utils.GetFullName(accountFrom.CURRENT_FIRST_NAME, accountFrom.CURRENT_MIDDLE_NAME, accountFrom.CURRENT_LAST_NAME);
                        notification.sound = chat.Sound;
                        notification.priority = chat.Priority;

                        JsonData data = new JsonData();
                        data.Data = JsonConvert.SerializeObject(msg);

                        var json = new DataJson();
                        json.notification = notification;
                        json.data = data;
                        json.to = DeviceId;


                        streamWriter.Write(JsonConvert.SerializeObject(json));
                        streamWriter.Flush();
                    }

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        result = streamReader.ReadToEnd();
                    }

                    return ResponseSuccess(StringResource.Success, msg);
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
        public HttpResponseMessage ListMessage([FromBody]ListMessageData data)
        {
            var conversationReplyModel = new ConversationReplyModel();
            var list = conversationReplyModel.ListMessage(data.PersonIdFrom, data.PersonIdTo, data.Page, data.PageSize);
            var listMessage = new List<MessageResponse>();
            int lenght = list.Count;
            for (int i = 0; i < lenght; i++)
            {
                var item = list[i];
                var itemLater = list[i > 1 ? i - 1 : i];
                DateTime? dt = item.TIME;
                DateTime? dtLater = itemLater.TIME;
                if (dt.HasValue && dtLater.HasValue)
                {
                    var msg = new MessageResponse();
                    msg.ConversationReplyId = item.CONVERSATION_REPLY_ID;
                    msg.Message = item.MESSAGE;
                    msg.TimeFormat = DateTimeFormater.GetTimeAgo(dt.Value);
                    msg.Time = dt;
                    msg.PersonIdFrom = item.PERSON_ID_FROM;
                    msg.PersonIdTo = item.PERSON_ID_TO;
                    msg.IsToDay = DateTimeFormater.CheckIsToday(dt.Value);
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
        public HttpResponseMessage DeleteAllMessage(decimal personIdDelete, [FromBody]Data data)
        {
            try
            {
                var model = new ConversationReplyModel();
                var list = model.ListAllMessage(data.PersonIdFrom, data.PersonIdTo);
                int size = list.Count;
                for (int i = 0; i < size; i++)
                {
                    var item = list[i];
                    if (item.PERSON_ID_DELETE != null)
                    {
                        model.DeleteConversationReply(item.CONVERSATION_REPLY_ID);
                    }
                    else
                    {
                        item.PERSON_ID_DELETE = personIdDelete;
                        model.UpdatePersonIdDelete(item);
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
        public HttpResponseMessage ListConversation(decimal personId)
        {
            var model = new ConversationReplyModel();
            var list = model.ListConversation(personId);
            var listConversation = new List<Conversation_Reply>();
            var listConversationResponse = new List<Conversation>();
            foreach (Conversation_Reply item in list)
            {
                var personIdFrom = item.PERSON_ID_FROM;
                var personIdTo = item.PERSON_ID_TO;
                if (personIdFrom.HasValue && personIdTo.HasValue)
                {
                    var conversation = model.GetConversationReplyLast(personIdFrom.Value, personIdTo.Value);
                    bool isExist = listConversation.Any(c => c.CONVERSATION_REPLY_ID == conversation.CONVERSATION_REPLY_ID);
                    if (!isExist)
                    {
                        var accountModel = new AccountModel();
                        var conversationResponse = new Conversation();
                        conversationResponse.PersonId = personIdFrom.Value == personId ? personIdTo.Value : personIdFrom.Value;

                        var account = accountModel.GetAccountById(conversationResponse.PersonId);
                    
                            conversationResponse.Name = Utils.GetFullName(account.CURRENT_FIRST_NAME, account.CURRENT_MIDDLE_NAME, account.CURRENT_LAST_NAME);
                            conversationResponse.Message = conversation.MESSAGE;

                            listConversation.Add(conversation);
                            listConversationResponse.Add(conversationResponse);
                        

                    }
                }
            }
            return ResponseSuccess(StringResource.Success, listConversationResponse);
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
        public int PersonIdFrom { get; set; }
        public int PersonIdTo { get; set; }
    }

    public class DataJson
    {
        public Notification notification { get; set; }
        public JsonData data { get; set; }
        public string to { get; set; }
    }

    public class MessageResponse
    {
        public decimal ConversationReplyId { get; set; }
        public string Message { get; set; }
        public bool IsMoreThanOneDay { get; set; }
        public bool IsToDay { get; set; }
        public string TimeFormat { get; set; }
        public DateTime? Time { get; set; }
        public decimal? PersonIdFrom { get; set; }
        public decimal? PersonIdTo { get; set; }
    }

    public class ListMessageData
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int PersonIdFrom { get; set; }
        public int PersonIdTo { get; set; }
    }

    public class JsonData
    {
        public string Data { get; set; }
    }

    public class Conversation
    {
        public decimal PersonId { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string Image { get; set; }
    }
}
