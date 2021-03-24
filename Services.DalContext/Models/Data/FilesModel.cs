using Microsoft.Extensions.Options;
using Services.Common.Models.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static Services.Common.Models.appSetting;

namespace Services.DalContext.Models.Data
{
    public class FilesModel : DalBase
    {
        private ResponseModel _response;
        private Statement _statement;
        private DataTable dt;
        public ResultAccess _resAccess;

        public FilesModel(IOptions<StateConfigs> config) : base(config)
        {
            _state = config.Value;

            _response = new ResponseModel();
            _resAccess = new ResultAccess(config);
            _statement = new Statement();
        }


        public string REST_InsertFilelog()
        {
            _statement.AppendStatement("EXEC REST_InsertFilelog ");
            _statement.AppendParameter("@Test", 0);

            _resAccess.ExecutenonResult(_statement);

            return "Success";
        }

    }
}
