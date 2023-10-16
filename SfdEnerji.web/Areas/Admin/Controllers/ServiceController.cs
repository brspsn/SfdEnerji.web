using Microsoft.AspNetCore.Mvc;
using SfdEnerji.Repository.Shared.Abstract;

namespace SfdEnerji.web.Areas.Admin.Controllers
{
    public class ServiceController : ControllerBase
    {
        public ServiceController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
