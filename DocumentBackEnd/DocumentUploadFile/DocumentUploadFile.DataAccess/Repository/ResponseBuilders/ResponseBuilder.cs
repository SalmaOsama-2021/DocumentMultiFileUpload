using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DocumentUploadFile.DataAccess.Repository.ResponseBuilders
{
    public class ResponseBuilder
    {
        public static ResponseBuilder Create(HttpStatusCode statusCode, object result = null, string responseMsg = null, object error = null)
        {
            return new ResponseBuilder(statusCode, result, responseMsg, error);
        }
        public int statusCode { get; set; }

        public string requestId { get; }

        public object error { get; set; }

        public object result { get; set; }

        public object success { get; set; }
        public string responseMessage { get; set; }
        protected ResponseBuilder(HttpStatusCode statusCode, object result = null, string responseMsg = null,
            object error = null)
        {
            this.requestId = Guid.NewGuid().ToString();
            this.statusCode = (int)statusCode;
            this.success = ((int)statusCode) == 200 ? true : false;
            this.result = result;
            this.responseMessage = responseMsg;
            this.error = error != null ? error : new string[] { };

        }
    }
    }
