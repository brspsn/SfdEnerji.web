using Microsoft.AspNetCore.Mvc;
using SfdEnerji.Repository.Shared.Abstract;

namespace SfdEnerji.web.Areas.Admin.Controllers
{
    public class PageController : ControllerBase

    {
        public PageController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
