using Microsoft.AspNetCore.Mvc;
using Proj9.DAL.Entities;
using Proj9.Services;
using System.Threading.Tasks;

namespace Proj9.Areas.Admin.Controllers
{
    public class ItemCatController : AdminBaseController
    {
        private readonly IItemCatService _itemCatService;

        public ItemCatController(IItemCatService itemCatService) { _itemCatService = itemCatService; }

        public IActionResult Index() { return View(); }
        public IActionResult List() { return PartialView(); }

        public IActionResult Create() { return View(); }

        [HttpPost]
        public async Task<JsonResult> Create(ItemCategory itemCatDto)
        {
            if (ModelState.IsValid)
            {
                if (await _itemCatService.CreateItemCat(itemCatDto))
                {
                    return Json(new { success = true, msg = "Successful" });
                }
                else
                {
                    return Json(new { success = false, msg = "Failed..!" });
                }
            }
            else
            {
                return Json(new { success = false, msg = "Please fill form properly!" });
            }
        }
    }
}
