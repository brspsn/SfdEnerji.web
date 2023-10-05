using Microsoft.AspNetCore.Mvc;

namespace SfdEnerji.web.Areas.Admin.Controllers
{
    public class ProjectController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
