using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DojoDachi.Models;
 using Newtonsoft.Json;

namespace DojoDachi.Controllers
{
    public class HomeController : Controller
    {
        
        [HttpGet]
        [Route("")]
        public IActionResult Home(){
            if(HttpContext.Session.GetObjectFromJson<DojoDachiGuy>("DojoDachi") == null){
                DojoDachiGuy dude = new DojoDachiGuy();
                HttpContext.Session.SetObjectAsJson("DojoDachi", dude);
                ViewBag.responce = "Welcome to DojoDachi";
            }
             
            
            DojoDachiGuy dude2 = HttpContext.Session.GetObjectFromJson<DojoDachiGuy>("DojoDachi");
            
            ViewBag.happyness = dude2.happyness;
            ViewBag.energy = dude2.energy;
            ViewBag.fullness = dude2.fullness;
            ViewBag.meals = dude2.meals;
            
            return View("DoJoDachi");
        }

        [HttpGet]
        [Route("feed")]
        public IActionResult Feed(){
            DojoDachiGuy dude = HttpContext.Session.GetObjectFromJson<DojoDachiGuy>("DojoDachi");
            Random rand = new Random();
            int chance = rand.Next(1,5);
            int food = rand.Next(5,11);
            if(dude.meals == 0){
                ViewBag.happyness = dude.happyness;
                ViewBag.energy = dude.energy;
                ViewBag.fullness = dude.fullness;
                ViewBag.meals = dude.meals;
                ViewBag.responce = "You have no more meals.";
                return View("DoJoDachi");
            }
            dude.meals -= 1;
            if(chance == 1){
                ViewBag.responce = "DojoDachi did not like the meal.";
            }
            else{
                dude.fullness += food;
                ViewBag.responce = "DojoDachi ate a yummy meal! Fullness +"+food;
            }
            
            ViewBag.happyness = dude.happyness;
            ViewBag.energy = dude.energy;
            ViewBag.fullness = dude.fullness;
            ViewBag.meals = dude.meals;
            dude = winCheck(dude);
            ViewBag.win = dude.win;
            ViewBag.alive = dude.alive;
            HttpContext.Session.SetObjectAsJson("DojoDachi", dude);
            return View("DoJoDachi");
        }

        [HttpGet]
        [Route("play")]
        public IActionResult Play(){
            DojoDachiGuy dude = HttpContext.Session.GetObjectFromJson<DojoDachiGuy>("DojoDachi");
            Random rand = new Random();
            int chance = rand.Next(1,5);
            int happy = rand.Next(5,11);
            if(dude.energy <5){
                ViewBag.happyness = dude.happyness;
                ViewBag.energy = dude.energy;
                ViewBag.fullness = dude.fullness;
                ViewBag.meals = dude.meals;
                ViewBag.responce = "DojoDachi is too tired to play.";
                HttpContext.Session.SetObjectAsJson("DojoDachi", dude);
                return View("DojoDachi");
            }
            dude.energy = dude.energy - 5;
            if(chance == 1){
                ViewBag.happyness = dude.happyness;
                ViewBag.energy = dude.energy;
                ViewBag.fullness = dude.fullness;
                ViewBag.meals = dude.meals;
                ViewBag.responce = "DojoDachi dosen't like this game.";
                HttpContext.Session.SetObjectAsJson("DojoDachi", dude);
                return View("DojoDachi");
            }
            else{
                dude.happyness += happy;
                ViewBag.happyness = dude.happyness;
                ViewBag.energy = dude.energy;
                ViewBag.fullness = dude.fullness;
                ViewBag.meals = dude.meals;
                ViewBag.responce = "You play with DojoDachi. He defeats you. Happyness +"+happy;
                dude = winCheck(dude);
                ViewBag.win = dude.win;
                ViewBag.alive = dude.alive;
                HttpContext.Session.SetObjectAsJson("DojoDachi", dude);
                return View("DojoDachi");
            }
        }
        [HttpGet]
        [Route("sleep")]
        public IActionResult Sleep(){
            DojoDachiGuy dude = HttpContext.Session.GetObjectFromJson<DojoDachiGuy>("DojoDachi");
            dude.energy = dude.energy + 15;
            dude.happyness = dude.happyness - 5;
            dude.fullness = dude.fullness -5;

            ViewBag.happyness = dude.happyness;
            ViewBag.energy = dude.energy;
            ViewBag.fullness = dude.fullness;
            ViewBag.meals = dude.meals;
            
            ViewBag.responce = "DojoDachi sleeps, he dreams of your demise...";
            dude = winCheck(dude);
            ViewBag.win = dude.win;
            ViewBag.alive = dude.alive;
            HttpContext.Session.SetObjectAsJson("DojoDachi", dude);
            return View("DojoDachi");

        }
        [HttpGet]
        [Route("work")]
        public IActionResult Work(){
            DojoDachiGuy dude = HttpContext.Session.GetObjectFromJson<DojoDachiGuy>("DojoDachi");
            Random rand = new Random();
            int earnings = rand.Next(1,4);
            dude.meals = dude.meals + earnings;
            ViewBag.happyness = dude.happyness;
            ViewBag.energy = dude.energy;
            ViewBag.fullness = dude.fullness;
            ViewBag.meals = dude.meals;
            ViewBag.responce = "DojoDachi works, earns "+earnings+" meals.";
            HttpContext.Session.SetObjectAsJson("DojoDachi", dude);
            return View("DojoDachi");

        }

        [HttpGet]
        [Route("reset")]
        public IActionResult Reset(){
            HttpContext.Session.Clear();
            return RedirectToAction("Home");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public DojoDachiGuy winCheck(DojoDachiGuy dude){
            if(dude.happyness > 40 && dude.fullness > 40 && dude.energy > 40){
                dude.win = true;
            }
            else if(dude.happyness <= 0 || dude.fullness <= 0){
                dude.alive = false;
                
            }
            return dude;
        }

        
    }
    public static class SessionExtensions
{
    // We can call ".SetObjectAsJson" just like our other session set methods, by passing a key and a value
    public static void SetObjectAsJson(this ISession session, string key, object value)
    {
        // This helper function simply serializes theobject to JSON and stores it as a string in session
        session.SetString(key, JsonConvert.SerializeObject(value));
    }
       
    // generic type T is a stand-in indicating that we need to specify the type on retrieval
    public static T GetObjectFromJson<T>(this ISession session, string key)
    {
        string value = session.GetString(key);
        // Upon retrieval the object is deserialized based on the type we specified
        return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
    }
}
    
}
