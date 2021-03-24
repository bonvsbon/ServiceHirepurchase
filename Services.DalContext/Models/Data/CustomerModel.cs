using Microsoft.Extensions.Options;
using Services.Common.Models.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static Services.Common.Models.appSetting;

namespace Services.DalContext.Models.Data
{
    public class CustomerModel : DalBase
    {
        private ResponseModel _response;
        private Statement _statement;
        private DataTable dt;
        public ResultAccess _resAccess;

        public CustomerModel(IOptions<StateConfigs> config) : base(config)
        {
            _state = config.Value;
            _response = new ResponseModel();
            _resAccess = new ResultAccess(config);
            _statement = new Statement();
        }

        public ResponseModel CustomerInformation(string AgreementNo)
        {
            _statement.AppendStatement("EXEC REST_CustomerInformation @AgreementNo");
            _statement.AppendParameter("@AgreementNo", AgreementNo);

            return _resAccess.ExecuteDataTable(_statement);
            
        }

    }
}
