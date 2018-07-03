using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankAccounts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;


namespace BankAccounts.Controllers
{
    public class HomeController : Controller
    {
        private UserContext _context;
        public HomeController(UserContext context){
            _context = context;
        }
        [HttpGet("")]
        public IActionResult Home(){
            //List<User> AllUsers = _context.User.ToList();
            //ViewBag.Users = AllUsers;
            return View("Login");
        }
        [HttpPost("Register")]
        public IActionResult Register(User user, string ConfirmPassword){
            User userEmail = _context.User.SingleOrDefault(login => login.Email == user.Email);
            if(user.Password == ConfirmPassword){
                if(userEmail == null){
                    if(ModelState.IsValid){
                        //hash password create user
                        PasswordHasher<User> Hasher = new PasswordHasher<User>();
                        user.Password = Hasher.HashPassword(user, user.Password);
                        _context.Add(user);
                        _context.SaveChanges();
                        //create account for user
                        //retreve newly created user
                        User newUser = _context.User.SingleOrDefault(login => login.Email == user.Email);
                        Account newAccount = new Account();
                        newAccount.Balance = 100.00;
                        newAccount.UserID = newUser.UserID;
                        //newAccount.User = newUser;
                        _context.Account.Add(newAccount);
                        _context.SaveChanges();
                        
                        //set user id to session
                        HttpContext.Session.SetInt32("UserID", newUser.UserID);
                        return RedirectToAction("Success");
                    }
                    //if modelstate is invalid return to login with error messages
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
            User user = _context.User.SingleOrDefault(u => u.Email == email);
            if(user != null && Password != null){
                var Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(user, user.Password, Password)){
                    HttpContext.Session.SetInt32("UserID",user.UserID);
                    //int? session = HttpContext.Session.GetInt32("UserID");
                    //System.Console.WriteLine(session);
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
        [HttpGet("account")]
        public IActionResult Success(){
            int Uid = (int)HttpContext.Session.GetInt32("UserID");
            //System.Console.WriteLine(Uid);
            //Account account = _context.Account.
            //    Include(u => u.User).SingleOrDefault(u => u.User_ID == Uid);

            List<Account> details = _context.Account.Include(x => x.User).
            Include(x => x.Transactions).Where(x => x.UserID == Uid).ToList();
            HttpContext.Session.SetInt32("AccountID", details[0].AccountID);
            // User unpack = user[0];
            
            //ViewBag.account = account;
            return View("Dashboard",details);
        }

        public IActionResult Process(double change){
            int? Uid = HttpContext.Session.GetInt32("UserID");
            int? Aid = HttpContext.Session.GetInt32("AccountID");

            //insert into transaction table
            Transaction trans = new Transaction();
            trans.AccountID = (int)Aid;
            trans.BalanceChange = change;
            trans.Date = System.DateTime.Now;
            _context.Add(trans);
            _context.SaveChanges();

            //update account balance
            Account account = _context.Account.SingleOrDefault(a => a.AccountID == Aid);
            account.Balance = account.Balance + change;
            _context.SaveChanges();

            return RedirectToAction("Success");

            //System.Console.WriteLine(Uid);
            //System.Console.WriteLine(Aid);
            //System.Console.WriteLine(change);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
