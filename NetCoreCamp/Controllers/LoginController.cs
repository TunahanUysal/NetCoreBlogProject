using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetCoreCamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NetCoreCamp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult LoginIndex()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginIndex(USerSignInViewModel signIn)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(signIn.username, signIn.password, true, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("DashboardIndex", "Dashboard");
                }
                else
                {
                    return RedirectToAction("LoginIndex");
                }
            }
            else 
                return View();

           

        }


     
       
        

    }
            
}


//    var item = writerManager.GetWriterByConfirm(writer);
//    if (item!=null)
//    {
//        HttpContext.Session.SetString("username", writer.WriterMail);
//        return RedirectToAction("WriterIndex", "Writer");
//    }
//    else
//    {
//    return View(); 
//    }


//

//var item = writerManager.GetWriterByConfirm(writer);
//if (item != null)
//{

//    var claims = new List<Claim>
//                {
//                    new Claim(ClaimTypes.Email,writer.WriterMail),
//                    new Claim(ClaimTypes.Name,writer.WriterId.ToString())
//                };
//    var userIdentity = new ClaimsIdentity(claims, "a");
//    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
//    await HttpContext.SignInAsync(principal);




//    return RedirectToAction("DashboardIndex", "Dashboard");
//}
//else
//{
//    return View();
//}