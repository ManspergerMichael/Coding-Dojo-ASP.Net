using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginRegistration.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace LoginRegistration.Controllers
{
    public class HomeController : Controller
    {
        private UserContext _context;
        public HomeController(UserContext context){
            _context = context;
        }
        [HttpGet("")]
        public IActionResult Home(){
            List<User> AllUsers = _context.User.ToList();
            ViewBag.Users = AllUsers;
            return View("Login");
        }
        [HttpPost("Register")]
        public IActionResult Register(User user, string ConfirmPassword){
            User userEmail = _context.User.SingleOrDefault(login => login.email == user.email);
            if(user.Password == ConfirmPassword){
                if(userEmail == null){
                    if(ModelState.IsValid){
                        user.createdAt = DateTime.Now;
                        user.updatedAt = DateTime.Now;
                        PasswordHasher<User> Hasher = new PasswordHasher<User>();
                        user.Password = Hasher.HashPassword(user, user.Password);
                        _context.Add(user);
                        _context.SaveChanges();
                        User userSession = _context.User.SingleOrDefault(u => u.email == user.email);
                        HttpContext.Session.SetInt32("UserID",userSession.id);
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
            User user = _context.User.SingleOrDefault(u => u.email == email);
            if(user != null && Password != null){
                var Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(user, user.Password, Password)){
                    HttpContext.Session.SetInt32("UserID",user.id);
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
        [HttpGet("Success")]
        public IActionResult Success(){
            int Uid = (int)HttpContext.Session.GetInt32("UserID");
            List<User> AllUsers = _context.User.ToList();
            ViewBag.Users = AllUsers;
            return View("Success");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
