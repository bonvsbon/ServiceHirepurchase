using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.BalContext;
using Services.BalContext.Controller;
using Services.Common.Models;
using static Services.Common.Models.appSetting;
using Microsoft.Extensions.Options;
using Services.Common.Models.Data;
using Services.Common;

namespace Services.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractController : ControllerBase
    {
        Information _info;
        StateConfigs _state = new StateConfigs();
        Functional _func;
        RequestDataModel _reqModel;
        public ContractController(IOptions<StateConfigs> config)
        {
            _func = new Functional();
            _info = new Information(config);
            _reqModel = new RequestDataModel();
        }

        [HttpGet("{AgreementNo}")]
        public string Index(string AgreementNo)
        {
            return _info.REST_CustomerInformation(AgreementNo);
        }

        [HttpPost]
        public string getPost([FromBody] RequestModel _request)
        {
            return _info.REST_CustomerInformation(_request._data.AgreementNo);
        }

    }
}
