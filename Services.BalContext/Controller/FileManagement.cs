using Microsoft.Extensions.Options;
using Services.DalContext;
using Services.DalContext.Models;
using Services.DalContext.Models.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static Services.Common.Models.appSetting;

namespace Services.BalContext.Controller
{
    public class FileManagement : DalBase
    {
        FilesModel _file;
        private Statement _statement;
        private DataTable dt;
        public ResultAccess _resAccess;
        public FileManagement(IOptions<StateConfigs> configs) : base(configs)
        {
            _file = new FilesModel(configs);
            _statement = new Statement();
            _resAccess = new ResultAccess(configs);
        }

        public string REST_InsertFileLog(string FileName, string OriginalFile, long fileSize, string PhoneNumber, string CallDate, string CallTime, string CreateBy)
        {
            _file.REST_InsertFilelog(FileName, OriginalFile, fileSize, PhoneNumber, CallDate, CallTime, CreateBy);
            return "";
        }

    }
}
