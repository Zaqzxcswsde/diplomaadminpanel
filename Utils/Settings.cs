using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;

namespace diplomaadminpanel.Utils
{
    internal static class Settings
    {
        public static IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // путь к каталогу с appsettings.json
            .AddJsonFile("settings.json", optional: false, reloadOnChange: true)
            .Build();
    }
}
