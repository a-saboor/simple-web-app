using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Proj9.Models;
using System.Diagnostics;

namespace Proj9.Controllers
{
    public class AccountsController : Controller
    {
        private readonly ILogger<AccountsController> _logger;

        public AccountsController(ILogger<AccountsController> logger) { _logger = logger; }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Reg()
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
