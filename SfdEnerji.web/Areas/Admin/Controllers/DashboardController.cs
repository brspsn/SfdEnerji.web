using Microsoft.AspNetCore.Mvc;

namespace SfdEnerji.web.Areas.Admin.Controllers
{
    public class DashboardController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
