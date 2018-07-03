using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wedding_Planner.Models;

namespace Wedding_Planner.Controllers
{
    public class HomeController : Controller
    {
        private WeddingContext _context;
 
        public HomeController(WeddingContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Home(){
            List<User> AllUsers = _context.Users.ToList();
            ViewBag.Users = AllUsers;
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
                        User session = _context.Users.SingleOrDefault(login => login.Email == user.Email);
                        HttpContext.Session.SetInt32("UserID", user.UserID);
                        return RedirectToAction("Planner");
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
            User user = _context.Users.SingleOrDefault(u => u.Email == email);
            if(user != null && Password != null){
                var Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(user, user.Password, Password)){
                    HttpContext.Session.SetInt32("UserID", user.UserID);
                    return RedirectToAction("Planner");
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

        [HttpGet("Planner")]
        public IActionResult Planner(){
            int Uid = (int)HttpContext.Session.GetInt32("UserID");
            List<Wedding> weddings = _context.Weddings.Include(w => w.GuestList).ToList();
            ViewBag.UserId = Uid;
            ViewBag.List = weddings;
            return View();
        }

        [HttpGet("NewWedding")]
        public IActionResult NewWedding(){
            return View();
        }

        [HttpPost("WeddingProcess")]
        public IActionResult WeddingProcess(Wedding wedding){
            int Uid = (int)HttpContext.Session.GetInt32("UserID");
            
            if(ModelState.IsValid){
                wedding.UserID = Uid;
                _context.Add(wedding);
                _context.SaveChanges();
                return RedirectToAction("Planner");
            }
            else{
                return View("NewWedding");
            }
            
        }
        [HttpGet("Details/{weddingId}")]
        public IActionResult Details(int weddingId){
            Wedding wedding = _context.Weddings.
                Include(g => g.GuestList).
                        ThenInclude(g => g.User).
                            SingleOrDefault(w => w.WeddingID == weddingId); 
            ViewBag.detail = wedding;
            return View("Details");
        }
        [HttpGet("Logout")]
        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Home");
        }
        [HttpGet("Delete/{weddingID}")]
        public IActionResult Delete(int weddingID){
           Wedding wed = _context.Weddings.
            SingleOrDefault(w => w.WeddingID == weddingID);
            List<Guest> guests = _context.Guests.Where(g => g.WeddingID == weddingID).ToList();
           _context.RemoveRange(guests);
           _context.Remove(wed);
           _context.SaveChanges();
           return RedirectToAction("Planner");
        }
        [HttpGet("UNRSVP/{weddingID}")]
        public IActionResult UNRSVP(int weddingID){
            int Uid = (int)HttpContext.Session.GetInt32("UserID");
            //delete guest row
            List<Guest> data = _context.Guests.Where(g => g.WeddingID == weddingID).Where(g => g.UserID == Uid).ToList();
            Guest guest = data[0];
            _context.Guests.Remove(guest);
            _context.SaveChanges();
            //decrease wedding guest counter
            Wedding wedding = _context.Weddings.SingleOrDefault(w => w.WeddingID == weddingID);
            wedding.Guests -=1;
            _context.SaveChanges();
            return RedirectToAction("Planner");
        }
        [HttpGet("RSVP/{weddingID}")]
        public IActionResult RSVP(int weddingID){
            int Uid = (int)HttpContext.Session.GetInt32("UserID");
            //create new guest
            Guest guest = new Guest();
            guest.WeddingID = weddingID;
            guest.UserID = Uid;
            _context.Add(guest);
            _context.SaveChanges();
            //increment wedding counter
            Wedding wedding = _context.Weddings.SingleOrDefault(w => w.WeddingID == weddingID);
            wedding.Guests +=1;
            _context.SaveChanges();
            return RedirectToAction("Planner");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
