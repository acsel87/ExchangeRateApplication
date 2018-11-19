using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace ER_Library
{
    public static class GlobalConfig
    {
        public static string GetAppConfig(string name)
        {
            return  ConfigurationManager.AppSettings[name];
        }       
    }
}
