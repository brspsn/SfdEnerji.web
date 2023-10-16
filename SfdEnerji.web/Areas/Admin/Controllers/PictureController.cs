using Microsoft.AspNetCore.Mvc;
using SfdEnerji.Repository.Shared.Abstract;

namespace SfdEnerji.web.Areas.Admin.Controllers
{
    public class PictureController : ControllerBase
    {
        public PictureController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
