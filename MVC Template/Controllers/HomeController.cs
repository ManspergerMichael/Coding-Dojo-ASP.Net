using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheWall.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace TheWall.Controllers
{
    public class HomeController : Controller
    {
        private WallContext _context;

        public HomeController(WallContext context){
            _context = context;
        }
        [HttpGet("")]
        public IActionResult Home(){
            return View("Login");
        }

        [HttpPost("Register")]
        public IActionResult Register(User user, string ConfirmPassword){
            User userEmail = _context.Users.SingleOrDefault(login => login.Email == user.Email);
            if(user.Password == ConfirmPassword){
                if(userEmail == null){
                    if(ModelState.IsValid){
                        user.createdAt = DateTime.Now;
                        user.updatedAt = DateTime.Now;
                        PasswordHasher<User> Hasher = new PasswordHasher<User>();
                        user.Password = Hasher.HashPassword(user, user.Password);
                        _context.Add(user);
                        _context.SaveChanges();
                        HttpContext.Session.SetInt32("UserID", user.UserID);
                        return RedirectToAction("Success");
                    }
                    else{
                        return View("Login");
                    }
                }
                else{
                    ViewBag.RegistrationError = "Email is in use.";
                    return View("Login");
                }
            }
            else{
                ViewBag.CPError = "Passwords do no match.";
                return View("Login");
            }

        }

        [HttpPost("Login")]
        public IActionResult Login(string email, string Password){
            var user = _context.Users.SingleOrDefault(u => u.Email == email);
            if(user != null && Password != null){
                var Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(user, user.Password, Password)){
                    HttpContext.Session.SetInt32("UserID", user.UserID);
                    return RedirectToAction("Success");
                }
                else{
                    ViewBag.loginError = "Email not registered";
                    return View("Login");
                }
            }
            else{
                ViewBag.loginError = "Invalid Password";
                return View("Login");
            }
            
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
