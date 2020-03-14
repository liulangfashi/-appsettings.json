using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApplication2.Models;
using Microsoft.Extensions.Configuration;
using WebApplication2.Data;
using Npgsql;

namespace WebApplication2.Controllers
{
    public class ContentController : Controller
    {
       
        private readonly ILogger<ContentController> _logger;
        public AppSettings appsettings;
        public ContentController(ILogger<ContentController> logger, IOptions<AppSettings> setting)
        {
            _logger = logger;
            appsettings = setting.Value;
        }

        public IActionResult Index()
        {
            
            string appId = ConfigManager.Configuration["AppSettings:ConnectionString"];
            NpgsqlConnection SqlConn = new NpgsqlConnection(appId);
            //return View();
            string connectionstring = appsettings.ConnectionString;
            var contents = new List<Content>();
            for (int i = 1; i < 11; i++)
            {
                contents.Add(new Content { Id = i, title = $"{i}的标题", content = $"{i}的内容", status = 1, add_time = DateTime.Now.AddDays(-i) });
            }
            return View(new ContentViewModel { Contents = contents });
        }
    
 
    }
}
