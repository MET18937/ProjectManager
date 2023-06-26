using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using ProjectManager.DomainModel.Interfaces;
using ProjectManager.DomainModel.Dtos;
using System.Text.Json;
using ProjectManager.DomainModel.Exceptions;

namespace ProjectManager.MvcFrontend.Controllers
{
    public class AccountController : Controller
    {

        public AccountController()
        {
        }

        [HttpGet()]
        public IActionResult Login()
        {
            return View(new LoginDto() { UserName = "max", Password = "geheim12" });
        }


        [HttpPost]
        public IActionResult Login(LoginDto dto)
        {
            if (dto.UserName == "max" && dto.Password == "geheim12")
            {
                HttpContext.Response.Cookies.Append("login_56baif", "true", new CookieOptions()
                {
                    Expires = DateTime.Now.AddMinutes(100000000),
                });
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Error", "Account");
            }
        }


        [HttpGet()]
        public IActionResult LogOut()
        {
            HttpContext.Response.Cookies.Delete("login_56baif");

            return RedirectToAction("Index", "Home");
        }

       

        [HttpGet()]
        public IActionResult Error()
        {
            return View();
        }
    }
}
