using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheWall.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
                        return RedirectToAction("TheWall");
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
                ViewBag.ConfirmPasswordError = "Passwords do no match.";
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
                    return RedirectToAction("TheWall");
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

        [HttpGet("TheWall")]
        public IActionResult TheWall(){
            List<User> data = _context.Users.
                Include(m => m.Messages).
                    ThenInclude(c => c.Comments).
                        ToList();            
            ViewBag.data = data;
            return View("TheWall");
        }

        [HttpPost("NewMessage")]
        public IActionResult NewMessage(string MessageText){
            int Uid = (int)HttpContext.Session.GetInt32("UserID");
            Message newMessage = new Message();
            newMessage.MessageText = MessageText;
            newMessage.UserID = Uid;
            newMessage.createdAt = DateTime.Now;
            newMessage.updatedAt = DateTime.Now;
            _context.Add(newMessage);
            _context.SaveChanges();
            return RedirectToAction("TheWall");
        }

        [HttpPost("NewComment")]
        public IActionResult NewComment(string commentText, int messageID){
            int Uid = (int)HttpContext.Session.GetInt32("UserID");
            Comment newComment = new Comment();
            newComment.CommentText = commentText;
            newComment.MessageID = messageID;
            newComment.UserID = Uid;
            newComment.createdAt = DateTime.Now;
            newComment.updatedAt = DateTime.Now;
            _context.Add(newComment);
            _context.SaveChanges();

            return RedirectToAction("TheWall");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
