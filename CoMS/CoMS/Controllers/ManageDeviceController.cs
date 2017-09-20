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
        [HttpPost]
        [Route("api/AddDevice")]
        public HttpResponseMessage AddDevice([FromBody]DeviceRequest request)
        {
            if (request == null)
            {
                return ResponseFail(StringResource.Data_not_received);
            }
            else
            {
                var model = new ManageDeviceModel();
                bool isExist = model.CheckPersonIdExist(request.PersonId);
                var device = new Manage_Device();
                if (isExist)
                {
                    device.DEVICE_TOKEN = request.DeviceToken;
                    device.PERSON_ID = request.PersonId;
                    device.UPDATE_DATE = DateTime.Now;
                    model.UpdateDevice(device);
                    return ResponseSuccess(StringResource.Success, device);
                }
                else
                {
                    device.DEVICE_TOKEN = request.DeviceToken;
                    device.PERSON_ID = request.PersonId;
                    device.CREATE_DATE = DateTime.Now;
                    model.AddDevice(device);
                    return ResponseSuccess(StringResource.Success, device);
                }
            }
        }
    }

    public class DeviceRequest
    {
        public decimal PersonId { get; set; }
        public string DeviceToken { get; set; }
    }
}
