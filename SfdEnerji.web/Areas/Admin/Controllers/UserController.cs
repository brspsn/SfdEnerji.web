using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SfdEnerji.Models;
using SfdEnerji.Models.DTOs;
using SfdEnerji.Repository.Shared.Abstract;
using System.Security.Claims;

namespace SfdEnerji.web.Areas.Admin.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(); 
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginDto loginDto)
        {
            //Dtodaki username ve password null değil mi 
            AppUser user =_unitOfWork.Users.GetFirstOrDefault(u=>u.Name == loginDto.UserName&&u.Password==loginDto.Password);
            if (user==null)
            {
                return BadRequest("Kullanıcı adı veya şifre hatalı");
            }
            else
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name,user.Name));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                claims.Add(new Claim(ClaimTypes.Role,"Admin"));

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity),new AuthenticationProperties { IsPersistent=loginDto.RememberMe });
                return Ok();
            }
        }
    }
}
