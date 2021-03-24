using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Services.Common;
using Services.Common.Models.Data;
using Services.DalContext.Models.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using static Services.Common.Models.appSetting;
 
namespace Services.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        StateConfigs _state = new StateConfigs();
        Functional _func;
        FilesModel _file;
        private bool result;
        public FileController(IOptions<StateConfigs> config)
        {
            _state = config.Value;
            _func = new Functional();
            _file = new FilesModel(config);
        }

        [HttpPost]
        public string ReceiveFileFromClient(List<IFormFile> files)
        {
            string fileName = "";
            string savePath = "";
            string localPath = "";
            string targetDirectory = "";

            foreach (IFormFile file in files)
            { 
            
                targetDirectory = _state.StoragePath._localPath;

                fileName = file.FileName;

                localPath = Path.Combine(targetDirectory, fileName);

                if (!_func.CheckExistingDirectory(targetDirectory))
                {
                    _func.DirectoryCreate(targetDirectory);
                }
                if (_func.CheckExistingFile(targetDirectory, fileName))
                {
                    continue;
                    //_func.DestroyFileFromName(targetDirectory, fileName);
                }
                using (var fileStream = new FileStream(localPath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                using (var client = new WebClient())
                {
                    savePath = string.Format("{0}/{1}", _state.FtpConfig._ftpPath, fileName);
                    client.Credentials = new NetworkCredential(_state.FtpConfig._username, _state.FtpConfig._password);
                    client.UploadFile(savePath, WebRequestMethods.Ftp.UploadFile, localPath);
                }

                _func.DestroyFileFromName(targetDirectory, fileName);
                _file.REST_InsertFilelog();
            }


            return fileName;
        }

    }
}
