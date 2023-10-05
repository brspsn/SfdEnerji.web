using Microsoft.AspNetCore.Mvc;

namespace SfdEnerji.web.Areas.Admin.Controllers
{
    public class PictureController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
