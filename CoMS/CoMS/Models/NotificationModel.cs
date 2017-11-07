using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoMS.Entities_Framework;
using PagedList;

namespace CoMS.Models
{
    public class NotificationModel
    {
        private MYDB myDB;
        public NotificationModel()
        {
            myDB = new MYDB();
        }

        public Notification GetNotificationById(decimal notificationId)
        {
            return myDB.Notifications.Find(notificationId);
        }

        public bool AddNotification(Notification notification)
        {
            try
            {
                myDB.Notifications.Add(notification);
                myDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Notification> ListNotificationByPersonId(decimal personId, int page = 1, int pageSize = 10)
        {
            var result = myDB.Notifications.Where(x => x.PERSON_ID_TO == personId).OrderByDescending(x => x.CREATE_DATE)
                .ToPagedList(page, pageSize).ToList();
            return result;
        }

        public bool UpdateReaded(decimal notificationId)
        {
            try
            {
                var notification = myDB.Notifications.Find(notificationId);
                notification.READED = true;
                myDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteAddNotification(decimal personId)
        {
            try
            {
                var list = myDB.Notifications.Where(x => x.PERSON_ID_TO == personId);
                myDB.Notifications.RemoveRange(list);
                myDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteAddNotificationById(decimal personId, decimal notificationId)
        {
            try
            {
                var list = myDB.Notifications.Where(x => x.PERSON_ID_TO == personId && x.NOTIFICATION_ID == notificationId);
                myDB.Notifications.RemoveRange(list);
                myDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int GetNumberUnread(decimal personId)
        {
            var result = myDB.Notifications.Where(x => x.PERSON_ID_TO == personId && x.READED == false).Count();
            return result;
        }
    }
}