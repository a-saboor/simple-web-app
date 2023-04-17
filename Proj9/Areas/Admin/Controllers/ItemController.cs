using Microsoft.AspNetCore.Mvc;
using Proj9.DAL.Entities;
using Proj9.Services;
using System.Threading.Tasks;

namespace Proj9.Areas.Admin.Controllers
{
    public class ItemController : AdminBaseController
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService) { _itemService = itemService; }

        public IActionResult Index() { return View(); }
        public IActionResult List() { return View(); }

        public IActionResult Create() { return View(); }

        [HttpPost]
        public async Task<IActionResult> Create(ItemMaster itemMasterDto)
        {
            if (await _itemService.CreateItem(itemMasterDto))
            {

            }
            return RedirectToAction(nameof(Index));
        }
    }
}
