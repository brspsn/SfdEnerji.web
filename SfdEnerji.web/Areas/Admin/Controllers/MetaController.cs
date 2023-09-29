using Microsoft.AspNetCore.Mvc;

namespace SfdEnerji.web.Areas.Admin.Controllers
{
    public class MetaController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
