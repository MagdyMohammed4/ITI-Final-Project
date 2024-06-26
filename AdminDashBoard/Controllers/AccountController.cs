﻿using Jumia.Dtos.AccountDtos;
using Jumia.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace AdminDashBoard.Controllers
{
    public class AccountController : BaseController
    {
            private UserManager<UserIdentity> _userManager;
            private SignInManager<UserIdentity> _signinManager;

            public AccountController(UserManager<UserIdentity> userManager, SignInManager<UserIdentity> signInManager)
            {
                _userManager = userManager;
                _signinManager = signInManager;
            }
      
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
            public async Task<IActionResult> Register(RegisterDtos registerDtos)
            {
         
            if (ModelState.IsValid)
                {


                    var user = new UserIdentity() { UserName = registerDtos.Username, Email = registerDtos.Email, PhoneNumber = registerDtos.Phone };
                    IdentityResult res = await _userManager.CreateAsync(user, registerDtos.Password);

                        if (res.Succeeded && registerDtos.Password == registerDtos.Confirmpass)
                        {
                         await _userManager.AddToRoleAsync(user, "Admin");
                           await _signinManager.SignInAsync(user, isPersistent: false);
                            return RedirectToAction("Login");

                        }
                        else
                        {
                            foreach (var i in res.Errors)
                            {
                                ModelState.AddModelError("Error", i.Description);
                            }
                            return View(registerDtos);
                        }
                    }
        
                else
                {
                    return View(registerDtos);
                }
            }





        public IActionResult Login()
        {
            return View("Login");
        }


        [HttpPost]
        //public async Task<IActionResult> Login(LoginDtos loginDtos)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        var result = await _signinManager.PasswordSignInAsync(loginDtos.Username, loginDtos.Password, false, false);

        //        if (result.Succeeded)
        //        {
        //          //  HttpContext.Session.SetString("Username", loginDtos.Username);
        //          //  ViewBag.Username = HttpContext.Session.GetString("Username");
        //            return RedirectToAction("Index", "Category");
        //        }
        //        else
        //        {
        //            ViewData["ErrorMessage"] = "Invalid username or password.";
        //            return View("Login", loginDtos);
        //        }
        //    }

        //    return View("Login", loginDtos);
        //}
        public async Task<IActionResult> Login(LoginDtos loginDtos)
        {
            if (ModelState.IsValid)
            {
                var result = await _signinManager.PasswordSignInAsync(loginDtos.Username, loginDtos.Password, false, false);

                if (result.Succeeded)
                {
                    //  HttpContext.Session.SetString("Username", loginDtos.Username);
                    //  ViewBag.Username = HttpContext.Session.GetString("Username");
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    // Check if the username is incorrect
                    var user = await _userManager.FindByNameAsync(loginDtos.Username);
                    if (user == null)
                    {
                        ViewData["ErrorMessage"] = "Invalid username.";
                    }
                    else
                    {
                        ViewData["ErrorMessage"] = "Invalid password.";
                    }

                    return View("Login", loginDtos);
                }
            }

            return View("Login", loginDtos);
        }




        public async Task<IActionResult> logout()
        {
            await _signinManager.SignOutAsync();
            return RedirectToAction("index", "Home");
        }


    }

    }
