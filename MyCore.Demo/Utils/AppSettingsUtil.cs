using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyCore.Demo.Utils
{
    public class AppSettingsUtil
    {
        static IConfiguration _configuration;

        static AppSettingsUtil()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("AppSettings.json");
            _configuration = builder.Build();
        }

        public static string Get(string key)
        {
            return _configuration[key];
        }
    }
}
