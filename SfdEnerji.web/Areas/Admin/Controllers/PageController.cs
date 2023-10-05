using Microsoft.AspNetCore.Mvc;

namespace SfdEnerji.web.Areas.Admin.Controllers
{
    public class PageController : ControllerBase

    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
