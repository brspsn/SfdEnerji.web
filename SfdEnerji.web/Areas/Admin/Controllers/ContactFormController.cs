using Microsoft.AspNetCore.Mvc;

namespace SfdEnerji.web.Areas.Admin.Controllers
{
    public class ContactFormController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
