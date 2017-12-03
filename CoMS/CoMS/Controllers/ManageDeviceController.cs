using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoMS.Entities_Framework;
using CoMS.Resources;
using CoMS.Models;

namespace CoMS.Controllers
{
    public class ManageDeviceController : BaseController
    {
        private DB db = new DB();

        [HttpPost]
        [Route("api/AddDevice")]
        public HttpResponseMessage AddDevice(string UserName, string DEVICE_TOKEN)
        {
            var account = db.ACCOUNTs.SingleOrDefault(x => x.UserName == UserName);
            if (account == null)
            {
                return ResponseFail(StringResource.Account_does_not_exist);
            }
            else if (String.IsNullOrEmpty(DEVICE_TOKEN))
            {
                return ResponseFail(StringResource.Token_is_not_empty);
            }
            else
            {
                var device = db.ACCOUNT_DEVICE_RELATIONSHIP.SingleOrDefault(x => x.UserName == UserName);
                if (device != null)
                {
                    device.DEVICE_TOKEN = DEVICE_TOKEN;
                    device.LAST_REVISED_DATE = DateTime.Now;
                    db.SaveChanges();
                    return ResponseSuccess(StringResource.Update_token_success);
                }
                else
                {
                    var newDevice = new ACCOUNT_DEVICE_RELATIONSHIP();
                    newDevice.DEVICE_TOKEN = DEVICE_TOKEN;
                    newDevice.UserName = UserName;
                    newDevice.PERSON_ID = account.PERSON_ID.Value;
                    newDevice.FIRST_LOGINED_DATE = DateTime.Now;
                    db.ACCOUNT_DEVICE_RELATIONSHIP.Add(newDevice);
                    db.SaveChanges();
                    return ResponseSuccess(StringResource.Add_device_token_success);
                }
            }
        }
    }
}
