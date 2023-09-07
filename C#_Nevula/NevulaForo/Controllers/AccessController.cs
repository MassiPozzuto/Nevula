﻿using Microsoft.AspNetCore.Mvc;

using NevulaForo.Models.DB;
using NevulaForo.Resources;
using NevulaForo.Services.Contract;
//using NevulaForo.Services.Implementation;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace NevulaForo.Controllers
{
    public class AccessController : Controller
    {
        private readonly IUserService _userService;

        public AccessController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.Password = Utilities.EncryptPassword(model.Password);

            User user_created = await _userService.SaveUser(model);

            UserRole user_role_created = new UserRole();
            user_role_created.IdUser = user_created.Id;
            user_role_created.IdRole = 1;
            user_role_created = await _userService.SaveUserRole(user_role_created);

            if (user_created.Id > 0 && user_role_created.Id > 0)
                return RedirectToAction("Login", "Access");

            ViewData["Message"] = "Error al crear el usuario";
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser.Identity != null)
            {
                if (claimUser.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password, string remember)
        {

            if (email == null || password == null)
            {
                ViewData["Message"] = "El correo y/o la contraseña es incorrecta. Compruebalo";
                return View();
            }

            User user_found = await _userService.GetUser(email, Utilities.EncryptPassword(password));

            List<Claim> claims = new List<Claim>()
            {
                new Claim("Id", user_found.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user_found.Username),
                new Claim(ClaimTypes.Email, user_found.Email),
                new Claim(ClaimTypes.Role, user_found.UserRoles.First().IdRole.ToString())
                
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true
            };

            if (remember != null)
            {
                properties.IsPersistent = true;
                properties.ExpiresUtc = DateTime.Now.AddDays(20);   
            } 

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Access");
        }
    }
}
