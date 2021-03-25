using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Services.Common.Models.Data
{
    public class ResponseModel
    {
        public string _errorMessage { get; set; }
        public DataTable _data { get; set; }
        public string _statusCode { get; set; }
        public string GetStateHttp(StatusHttp code)
        {
            string resultCode = "";
            switch (code)
            {
                case StatusHttp.Created:
                    resultCode = "201";
                    break;
                case StatusHttp.Accepted:
                    resultCode = "202";
                    break;
                case StatusHttp.InvalidToken:
                    resultCode = "400";
                    break;
                case StatusHttp.SecurityError:
                    resultCode = "401";
                    break;
                case StatusHttp.NotFound:
                    resultCode = "404";
                    break;
                case StatusHttp.InternalError:
                    resultCode = "500";
                    break;
                default:
                    resultCode = "200";
                    break;
            }

            return resultCode;
        }
        public enum StatusHttp
        {
            OK,
            Created,
            Accepted,
            NotFound,
            InternalError,
            InvalidToken,
            SecurityError
        }
    }
}
