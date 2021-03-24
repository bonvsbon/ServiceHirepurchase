using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using Services.Common;
using Services.Common.Models;
using Services.DalContext;
using Services.DalContext.Models;
using Services.DalContext.Models.Data;
using static Services.Common.Models.appSetting;

namespace Services.BalContext.Controller
{
    public class Information : DalBase
    {
        Functional _func;
        CustomerModel _cust;
        public Information(IOptions<StateConfigs> configs) : base(configs)
        {
            _func = new Functional();
            _cust = new CustomerModel(configs);
        }

        public string REST_CustomerInformation(string AgreementNo)
        {
            return _func.JsonSerialize(_cust.CustomerInformation(AgreementNo));
        }
    }
}
