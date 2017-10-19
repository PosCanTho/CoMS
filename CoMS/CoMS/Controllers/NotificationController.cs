using CoMS.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoMS.Models;
using CoMS.Entities_Framework;
using System.IO;
using Newtonsoft.Json;
using CoMS.Untils;

namespace CoMS.Controllers
{
    public class NotificationController : BaseController
    {
        [HttpPost]
        [Route("api/SendNotification")]
        public HttpResponseMessage SendMessage([FromBody]NotificationRequest notificationData)
        {
            if (notificationData != null)
            {
                try
                {
                    var result = "-1";
                    var webAddr = "https://fcm.googleapis.com/fcm/send";
                    string DeviceId = new ManageDeviceModel().GetDeviceByPersonId(notificationData.PersonIdTo).DEVICE_TOKEN;

                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Headers.Add("Authorization:key=" + StringResource.Server_fcm_key);
                    httpWebRequest.Method = "POST";
                    /*Thêm vào CSDL*/
                    var notificationModel = new NotificationModel();
                    var notifi = new CoMS.Entities_Framework.Notification();
                    notifi.PERSON_ID_FROM = notificationData.PersonIdFrom;
                    notifi.PERSON_ID_TO = notificationData.PersonIdTo;
                    notifi.MESSAGE = notificationData.Message;
                    notifi.CREATE_DATE = DateTime.Now;
                    notifi.READED = false;
                    notifi.TITLE = notificationData.Title;

                    notificationModel.AddNotification(notifi);

                    /*Tạo dữ liệu trả về*/
                    var notificationResponse = new NotificationResponse();
                    notificationResponse.NotificationId = notifi.NOTIFICATION_ID;
                    notificationResponse.Title = notifi.TITLE;
                    notificationResponse.Message = notifi.MESSAGE;
                    notificationResponse.Image = notifi.IMAGE;
                    notificationResponse.PersonIdFrom = notifi.PERSON_ID_FROM;
                    notificationResponse.PersonIdTo = notifi.PERSON_ID_TO;
                    notificationResponse.Readed = notifi.READED.Value;
                    notificationResponse.CreateDate = notifi.CREATE_DATE.Value;
                    notificationResponse.NumberUnread = notificationModel.GetNumberUnread(notifi.PERSON_ID_TO);

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {

                        /*Tạo dữ liệu trả về*/
                        var notification = new Notification();
                        notification.body = notificationData.Message;
                        notification.title = notificationData.Title;
                        notification.sound = notificationData.Sound;
                        notification.priority = notificationData.Priority;

                        JsonData data = new JsonData();
                        data.Data = JsonConvert.SerializeObject(notificationResponse);

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

                    return ResponseSuccess(StringResource.Success, notificationResponse);
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
        [Route("api/ListNotification")]
        public HttpResponseMessage ListNotification([FromBody]ListNotificationRequest request)
        {
            var model = new NotificationModel();
            var list = model.ListNotificationByPersonId(request.PersonId, request.Page, request.PageSize);
            var listResponse = new List<NotificationResponse>();
            foreach (var item in list)
            {
                var notificationResponse = new NotificationResponse();
                notificationResponse.NotificationId = item.NOTIFICATION_ID;
                notificationResponse.Title = item.TITLE;
                notificationResponse.Message = item.MESSAGE;
                notificationResponse.Image = item.IMAGE;
                notificationResponse.PersonIdFrom = item.PERSON_ID_FROM;
                notificationResponse.PersonIdTo = item.PERSON_ID_TO;
                notificationResponse.Readed = item.READED.Value;
                notificationResponse.CreateDate = item.CREATE_DATE.Value;
                notificationResponse.NumberUnread = model.GetNumberUnread(item.PERSON_ID_TO);
                listResponse.Add(notificationResponse);

            }
            return ResponseSuccess(StringResource.Success, listResponse);
        }

        [HttpPost]
        [Route("api/UpdateReaded")]
        public HttpResponseMessage UpdateReaded([FromBody]UpdateReadedRequest request)
        {
            var model = new NotificationModel();
            var result = model.UpdateReaded(request.NotificationId);
            if (result)
            {
                var response = new UpdateReadedResponse();
                response.PersonId = request.PersonId;
                response.NumberUnread = model.GetNumberUnread(request.PersonId);
                return ResponseSuccess(StringResource.Success, response);
            }
            return ResponseFail(StringResource.Sorry_an_error_has_occurred);
        }

        [HttpGet]
        [Route("api/DeleteNotification")]
        public HttpResponseMessage DeleteNotification(decimal personId)
        {
            var model = new NotificationModel();
            var result = model.DeleteAddNotification(personId);
            if (result)
            {
                return ResponseSuccess(StringResource.Success);
            }
            return ResponseFail(StringResource.Sorry_an_error_has_occurred);
        }
    }

    public class NotificationRequest
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public decimal PersonIdFrom { get; set; }
        public decimal PersonIdTo { get; set; }

        public string Sound { get; set; }
        public string Priority { get; set; }
    }

    public class ListNotificationRequest
    {
        public decimal PersonId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }

    public class NotificationResponse
    {
        public decimal NotificationId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Image { get; set; }
        public decimal PersonIdFrom { get; set; }
        public decimal PersonIdTo { get; set; }
        public bool Readed { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal NumberUnread { get; set; }
    }

    public class UpdateReadedRequest
    {
        public decimal PersonId { get; set; }
        public decimal NotificationId { get; set; }
    }

    public class UpdateReadedResponse
    {
        public decimal PersonId { get; set; }
        public decimal NumberUnread { get; set; }
    }


}
