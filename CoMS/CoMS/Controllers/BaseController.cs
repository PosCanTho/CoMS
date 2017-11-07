using CoMS.Models;
using CoMS.Untils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using CoMS.Entities_Framework;
using CoMS.Resources;
using System.IO;
using Newtonsoft.Json;

namespace CoMS.Controllers
{
    public class BaseController : ApiController
    {
        public DB db = new DB();
       
        protected HttpResponseMessage ResponseFail(string msg)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(Constants.ERROR_CODE_FAIL, msg));
        }

        protected HttpResponseMessage ResponseFail(string msg, object data)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(Constants.ERROR_CODE_FAIL, msg, data));
        }

        protected HttpResponseMessage ResponseSuccess(string msg)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(Constants.ERROR_CODE_SUCCESS, msg));
        }
        protected HttpResponseMessage ResponseSuccess(string msg, object data)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(Constants.ERROR_CODE_SUCCESS, msg, data));
        }

    }
}