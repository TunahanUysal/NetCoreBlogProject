using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetCoreCamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCamp.Controllers
{
    [AllowAnonymous]
    public class RegisterUserController : Controller
    {
        private readonly UserManager<AppUser> _usermanager;

        public RegisterUserController(UserManager<AppUser> usermanager)
        {
            _usermanager = usermanager;
        }

        [HttpGet]

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Index(UserSignUpViewModel userSignUpViewModel)
        {
            if (ModelState.IsValid && userSignUpViewModel.IsAcceptCheckBox==true)
            {
                AppUser user = new AppUser()
                {
                    Email = userSignUpViewModel.Mail,
                    UserName = userSignUpViewModel.Username,
                    NameSurname = userSignUpViewModel.nameSurname,

                };
                var result = await _usermanager.CreateAsync(user, userSignUpViewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("LoginIndex", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);

                    }
                }

            }
            ModelState.AddModelError("IsAcceptCheckBox", "Sayfamıza kayıt olabilmek için gizlilik sözleşmesini kabul etmeniz gerekmektedir!");
            return View(userSignUpViewModel);
        }
    }
}
