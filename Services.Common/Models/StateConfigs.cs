using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Common.Models
{
    public class appSetting
    {
        readonly IOptions<StateConfigs> _conf;
        public appSetting(IOptions<StateConfigs> config)
        {
            _conf = config;
        }
        public class StateConfigs
        {
            public ConnectionString ConnectionStrings { get; set; }
            public Storages StoragePath { get; set; }
            public FTP FtpConfig { get; set; }
        }
        public class ConnectionString
        {
            public string isProd { get; set; }
            public string _prod { get; set; }
            public string _dev { get; set; }
        }

        public class Storages
        {
            public string _ftpPath { get; set; }
            public string _localPath { get; set; }
        }
        public class FTP
        {
            public string _username { get; set; }
            public string _password { get; set; }
            public string _ftpPath { get; set; }
        }
    }
}
