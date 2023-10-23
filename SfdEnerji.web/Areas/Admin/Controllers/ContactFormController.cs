using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SfdEnerji.Models;
using SfdEnerji.Models.DTOs;
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
            return Json(new
            {
                data = unitOfWork.ContactForms.GetAll().Select(cf => new ContactFormDto
                {
                    Id = cf.Id,
                    Name = cf.Name,
                    Message = cf.Message.Substring(0, 100),
                    CreatedDate = cf.CreatedDate,
                    MessageLenght = cf.Message.Length,
                    Email = cf.Email,
                    Subject = cf.Subject



                }).ToList()
            });
        }

        [HttpPost]
        public IActionResult DeleteById(int contactFormId)
        {
            unitOfWork.ContactForms.DeleteById(contactFormId);
            unitOfWork.Save();
            return Ok("Başarıyla silindi");
        }

        [HttpPost]
        public IActionResult Update(ContactForm contactForm)
        {
            unitOfWork.ContactForms.Update(contactForm);
            unitOfWork.Save();
            return Ok();
        }
        [HttpPost]
        public string ReadMessage(int contactFormId)
        {
            return unitOfWork.ContactForms.GetById(contactFormId).Message;
        }

    }
}
