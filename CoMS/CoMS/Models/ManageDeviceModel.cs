using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoMS.Entities_Framework;

namespace CoMS.Models
{
    public class ManageDeviceModel
    {
        private MYDB myDB;
        public ManageDeviceModel()
        {
            myDB = new MYDB();
        }

        public Manage_Device GetDeviceByPersonId(decimal deviceId)
        {
            return myDB.Manage_Device.SingleOrDefault(x => x.PERSON_ID == deviceId);
        }

        public bool CheckPersonIdExist(decimal personId)
        {
            var result = myDB.Manage_Device.Where(x => x.PERSON_ID == personId).Count();
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public bool AddDevice(Manage_Device device)
        {
            try
            {
                myDB.Manage_Device.Add(device);
                myDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateDevice(Manage_Device device)
        {
            try
            {
                var deviceUpdate = GetDeviceByPersonId(device.PERSON_ID);
                deviceUpdate.PERSON_ID = device.PERSON_ID;
                deviceUpdate.DEVICE_TOKEN = device.DEVICE_TOKEN;
                deviceUpdate.UPDATE_DATE = device.UPDATE_DATE;
                myDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}