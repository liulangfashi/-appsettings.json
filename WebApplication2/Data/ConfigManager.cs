using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;

namespace WebApplication2.Data
{
    public class ConfigManager
    {
        public static IConfiguration Configuration { get; set; }

        static ConfigManager()
        {
            //ReloadOnChange = true 当appsettings.json被修改时重新加载            

            #region 方式1（ok）

            Configuration = new ConfigurationBuilder()
                .Add(new JsonConfigurationSource
                {
                    Path = "appsettings.json",
                    ReloadOnChange = true
                }).Build();

            #endregion

            #region 方式2（ok）

            //Configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json").Build();

            #endregion
        }
    }
 
}
