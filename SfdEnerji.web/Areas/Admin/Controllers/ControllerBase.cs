using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SfdEnerji.Repository.Shared.Abstract;

namespace SfdEnerji.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ControllerBase : Controller
    {
        public readonly IUnitOfWork unitOfWork;

        public ControllerBase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
