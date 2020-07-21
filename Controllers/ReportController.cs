using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using report_builder.Models;
using System.IO;
using report_builder.src;
using Newtonsoft.Json;


namespace report_builder.Controllers
{
    public class ReportController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public ReportController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult<string> Index()
        {
            string templateContent = System.IO.File.ReadAllText(Path.Join(Directory.GetCurrentDirectory(),"report-templates","executive-clara-rc.json"));
            
            RenderElement bst = JsonConvert.DeserializeObject<RenderElement>(templateContent);
            ReportBuilder rb = new ReportBuilder(bst,DataStructure.DataStructureExample);
            string result = rb.Render();
            return View("Index",result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
