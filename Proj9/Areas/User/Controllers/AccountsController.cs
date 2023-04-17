using Microsoft.AspNetCore.Mvc;

namespace Proj9.Areas.User.Controllers
{
    [Area("user")]
    public class AccountsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
