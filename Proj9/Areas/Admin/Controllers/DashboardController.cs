using Microsoft.AspNetCore.Mvc;

namespace Proj9.Areas.Admin.Controllers
{
    public class DashboardController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
