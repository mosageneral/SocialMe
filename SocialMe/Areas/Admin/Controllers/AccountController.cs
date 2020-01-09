using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.Infrastructure;
using BL.Security;
using Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Models;

namespace SocialMe.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly IHostingEnvironment _he;
        public AccountController(IUnitOfWork uow, IHostingEnvironment he)
        {
            _uow = uow;
            _he = he;
        }
        public IActionResult Index()
        {

            return View(_uow.UserRepository.GetAll().ToHashSet());
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterUser user,IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                if (user.Password == user.ConfirmPassword)
                {
                    var EncryptedPassword = EncryptANDDecrypt.EncryptText(user.Password);
                    User User = new User();
                    User.UserName = user.UserName;
                    User.Email = user.Email;
                    User.Password = EncryptedPassword;
                    User.ImagePath = FileHelper.FileUpload(Image, _he, AppSession.UsersUploads);
                    User.Phone = user.Email;
                    User.Role = "User";
                    _uow.UserRepository.Add(User);
                    _uow.Save();
                    AppSession.CurrentUser = User;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(user);
                }
            }
            else
            {
                return View(user);
            }
           
        }
        [HttpGet]

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login login)
        {

            var user = _uow.UserRepository.GetMany(a => a.UserName == login.UserName && a.Password == EncryptANDDecrypt.EncryptText(login.Password)).FirstOrDefault();
            if (user!=null)
            {
                AppSession.CurrentUser = user;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(login);
            }
           
        }
    }
}