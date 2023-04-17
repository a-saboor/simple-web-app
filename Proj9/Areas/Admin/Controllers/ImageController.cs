using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proj9.DAL.Entities;
using Proj9.Services;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Proj9.Areas.Admin.Controllers
{
    public class ImageController : AdminBaseController
    {
        //private readonly IItemService _itemService;

        //public ImageController(IItemService itemService) { _itemService = itemService; }

        public IActionResult Index() { return View(); }
        public IActionResult List() { return View(); }

        public IActionResult Create() { return View(); }

        [HttpPost]
        public async Task<IActionResult> Create(ItemMaster itemMasterDto)
        {
            try
            {
                //var url = "https://image-background-removal3.p.rapidapi.com/BackgroundRemoverLambda";

                //var oReq = new { url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ2nkYh11Mswy-IVb5tM3C4c_nlbYOvNyso9w&usqp=CAU" };

                //var strReq = JsonConvert.SerializeObject(oReq);

                //using var web = new WebClient();
                //web.Headers.Add("x-rapidapi-key", "xxxxxx");
                //var response = web.UploadData(url, "POST", Encoding.UTF8.GetBytes(strReq));
                //var b64Response = Convert.FromBase64String(Encoding.UTF8.GetString(response));
                //File.WriteAllBytes("result3.png", b64Response);
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception)
            {
                return RedirectToAction(nameof(Create));
            }
        }
    }
}
