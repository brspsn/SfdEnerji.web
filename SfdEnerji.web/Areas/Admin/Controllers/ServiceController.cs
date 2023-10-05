using Microsoft.AspNetCore.Mvc;

namespace SfdEnerji.web.Areas.Admin.Controllers
{
    public class ServiceController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
