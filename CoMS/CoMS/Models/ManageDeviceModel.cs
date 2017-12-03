using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoMS.Entities_Framework;

namespace CoMS.Models
{
    public class ManageDeviceModel
    {
        private DB db;
        public ManageDeviceModel()
        {
            db = new DB();
        }

        public ACCOUNT_DEVICE_RELATIONSHIP GetDeviceUserName(string UserName)
        {
            return db.ACCOUNT_DEVICE_RELATIONSHIP.SingleOrDefault(x => x.UserName == UserName);
        }
    }
}