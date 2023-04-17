using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Proj9.DTOs;
using Proj9.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj9.Areas.Admin.Controllers
{
    public class AccountsController : AdminBaseController
    {
        private IAuthService _authService;

        public AccountsController(IAuthService authService) { _authService = authService; }
        private const string AccountType = "AccountType";
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost("/login")]
        public async Task<IActionResult> Index(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.AdminLogin(loginDto);
                if (result.Item1)
                {
                    HttpContext.Session.SetString(AccountType, "Admin");
                    return Json(new { success = true, url = "/admin/Dashboard/", message = result.Item2 });
                }
                else
                    return Json(new { success = false, url = "", message = result.Item2 });
            }
            else
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return Json(new { success = false, url = "", message = allErrors.Select(x => x.ErrorMessage) });
            }

        }

        [AllowAnonymous]
        public async Task<IActionResult> logout()
        {
            await Task.Run(() => HttpContext.Session.Clear());
            return View(nameof(Index));
        }
    }
}
