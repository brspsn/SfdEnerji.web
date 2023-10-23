using Microsoft.AspNetCore.Mvc;
using SfdEnerji.Models;
using Microsoft.EntityFrameworkCore;
using SfdEnerji.Repository.Shared.Abstract;
using SfdEnerji.Utility;
using SfdEnerji.Repository.Shared.Concrete;

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
        public IActionResult GetAll()
        {
            return Json(new { data = unitOfWork.Services.GetAll().Include(s => s.Pictures).ToList() });
        }

        [HttpPost]
        public IActionResult Add([FromForm] Service service)
        {
            //var deneme = Request.Form["slug"];
            var deneme = service.slug;

            var thumbnail = Request.Form.Files["file"];
            var Extencion = Path.GetExtension(thumbnail.FileName);
            string dosyAdi = service.slug.TextClean() + "_" + Helper.RandomStringGenerator(5) + "_" + "-Hizmet" + Extencion;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "Services");


            if (thumbnail != null && thumbnail.Length > 0)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var stream = new FileStream(Path.Combine(path, dosyAdi), FileMode.Create);
                thumbnail.CopyToAsync(stream);
                service.Thumbnail = dosyAdi;

            }
            service.CreatedDate = DateTime.Now;
            service.ModifitedDate = DateTime.Now;
            unitOfWork.Services.Add(service);

            unitOfWork.Save();
            return Ok();

        }

        public IActionResult Pictures(int serviceId)
        {

            return View(unitOfWork.Services.GetAll(x => x.Id == serviceId).Include(s => s.Pictures).FirstOrDefault().Pictures.Where(p => p.IsDeleted == false).ToList());
        }

        public IActionResult PicturesAjax()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetAllPictures(int serviceId)
        {
            return Json(unitOfWork.Services.GetAll(x => x.Id == serviceId).Include(s => s.Pictures).FirstOrDefault().Pictures.Where(p => p.IsDeleted == false).ToList());
        }

        [HttpPost]
        public IActionResult SavePictures(List<IFormFile> postedFiles, int serviceId)
        {

            Service service = unitOfWork.Services.GetById(serviceId);

            foreach (var file in postedFiles)
            {
                var fileName = service.Name.TextClean() + "-" + Helper.RandomStringGenerator(10) + "-" + file.FileName.TextClean();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "Services", "Gallery");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                //dosyayi diske kaydetme kısmı
                var stream = new FileStream(path + "/" + fileName, FileMode.Create);
                file.CopyToAsync(stream);
                stream.Close();
                Picture picture = new Picture();
                picture.Path = fileName;
                picture.Description = "";
                picture.Name = service.slug;
                service.Pictures.Add(picture);


            }
            service.ModifitedDate= DateTime.Now;
            unitOfWork.Services.Update(service);
            unitOfWork.Save();

            return RedirectToAction("Pictures", serviceId);
        }

        public IActionResult DeletePicture(int pictureId, int serviceId)
        {

            unitOfWork.Pictures.DeleteById(pictureId);
            unitOfWork.Save();
            return RedirectToAction("Pictures", new { serviceId = serviceId });

        }

        public IActionResult DeletePictureAjax(int pictureId)
        {

            unitOfWork.Pictures.DeleteById(pictureId);
            unitOfWork.Save();
            return Ok();

        }

    }
}
