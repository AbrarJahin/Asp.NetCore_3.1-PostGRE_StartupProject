using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StartupProject_Asp.NetCore_PostGRE.Models;
using StartupProject_Asp.NetCore_PostGRE.Services.EmailService;

namespace StartupProject_Asp.NetCore_PostGRE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMailer Mailer;

        public HomeController(ILogger<HomeController> logger, IMailer mailer)
        {
            _logger = logger;
            Mailer = mailer;
        }

        public IActionResult Index()
        {
            return View();
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
