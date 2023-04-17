using Microsoft.AspNetCore.Mvc;
using Proj9.AuthorizationProvider;

namespace Proj9.Areas.Admin.Controllers
{
    [Area("admin"), AuthorizeAdmin]
    public class AdminBaseController : Controller { }
}
