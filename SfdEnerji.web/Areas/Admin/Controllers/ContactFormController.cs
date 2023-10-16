using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SfdEnerji.Models;
using SfdEnerji.Repository.Shared.Abstract;

namespace SfdEnerji.web.Areas.Admin.Controllers
{
    public class ContactFormController : ControllerBase
    {
        public ContactFormController(IUnitOfWork unitOfWork):base(unitOfWork) 
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Add(ContactForm contactForm)
        {
            unitOfWork.ContactForms.Add(contactForm);
            unitOfWork.Save();
            return View();
        }

        public IActionResult GetAll()
        {
            return Json(new { data = unitOfWork.ContactForms.GetAll().ToList() });
        }

        [HttpPost]
        public IActionResult DeleteById(int contactFormId)
        {
            unitOfWork.ContactForms.DeLeteById(contactFormId);
            unitOfWork.Save();
            return Ok("Başarıyla Silindi");
        }

        [HttpPost]
        public IActionResult Update(ContactForm contactForm)
        {
            unitOfWork.ContactForms.Update(contactForm);
            unitOfWork.Save();
            return Ok();

        }
    }
}
