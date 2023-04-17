using Microsoft.AspNetCore.Mvc;
using Proj9.Services;
using System.Threading.Tasks;

namespace Proj9.ViewComponents
{
    [ViewComponent(Name = "ItemCategory_VC")]
    public class ItemCategory_VC : ViewComponent
    {
        private readonly ItemCatService _orderCatService;
        public ItemCategory_VC(ItemCatService itemCatService)
        {
            _orderCatService = itemCatService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View((IViewComponentResult)await _orderCatService.GetAllItemCat());
        }
    }
}
