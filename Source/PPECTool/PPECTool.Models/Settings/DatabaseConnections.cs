using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace PPECTool.Models.Settings
{
    public class DatabaseConnections
    {
        public string ServerName { get; set; }
        public string DBName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
