using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoMS.Models
{
    public class ResponseData
    {
        public ResponseData()
        {
            this.errorCode = 1;
            this.message = "Success";
            this.data = null;
        }

        public ResponseData(int errorCode, string message)
        {
            this.errorCode = errorCode;
            this.message = message;
        }

        public ResponseData(int errorCode, string message, object data)
        {
            this.errorCode = errorCode;
            this.message = message;
            this.data = data;
        }
        public int errorCode { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }
}