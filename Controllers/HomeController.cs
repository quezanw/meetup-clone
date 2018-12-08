using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using BeltExam.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BeltExam.Controllers
{
    public class HomeController : Controller
    {

        private BeltExamContext dbContext;
    
        // here we can "inject" our context service into the constructor
        public HomeController(BeltExamContext context)
        {
            dbContext = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            HttpContext.Session.Clear();
            return View();
        }

        [HttpGet("Home")]

        public IActionResult Home() {
            if(HttpContext.Session.GetInt32("userId") == null) {
                return View("Index");
            }
            int userId = (int)HttpContext.Session.GetInt32("userId");
            ViewBag.user = dbContext.Users.
            Include(a => a.AttendedActivities).
            ThenInclude(a => a.Activity).
            FirstOrDefault(u => u.UserId == userId);
            ViewBag.activities = dbContext.Activities.Include(u => u.Planner).Include(a => a.Attendees).OrderByDescending(a => a.CreatedAt);
            return View();
        }

        [HttpGet("New")]

        public IActionResult New() {
            if(HttpContext.Session.GetInt32("userId") == null) {
                return View("Index");
            }
            int userId = (int)HttpContext.Session.GetInt32("userId");
            ViewBag.user = dbContext.Users.FirstOrDefault(u => u.UserId == userId);
            return View();
        }


        [HttpGet("activity/{id}")]

        public IActionResult Activity(int id) {
            if(HttpContext.Session.GetInt32("userId") == null) {
                return View("Index");
            }
            ViewBag.activity = dbContext.Activities.
            Include(p => p.Planner).
            Include(a => a.Attendees).
            ThenInclude(u => u.User).
            FirstOrDefault(a => a.ActivityId == id);
            int userId = (int)HttpContext.Session.GetInt32("userId");
            ViewBag.user = dbContext.Users.FirstOrDefault(u => u.UserId == userId);
            return View();
        }

        [HttpPost("new_activity")]

        public IActionResult NewActivity(Activity activity) {
            int userId = (int)HttpContext.Session.GetInt32("userId");
            ViewBag.user = dbContext.Users.
            Include(a => a.PlannedActivities).
            FirstOrDefault(u => u.UserId == userId);
            if(ModelState.IsValid) {
                if(DateTime.Now > activity.Date) {
                    ModelState.AddModelError("Date", "The Activity Date must be in the future.");
                    return View("New");
                }
                if((int)activity.Duration < 0) {
                    ModelState.AddModelError("Date", "The Activity Duration cannot be a negative number");
                    return View("New");
                }


                activity.Planner = dbContext.Users.FirstOrDefault(user => user.UserId == (int)HttpContext.Session.GetInt32("userId"));
                dbContext.Add(activity);
                dbContext.SaveChanges();
                Attendee Planner = new Attendee {
                    UserId = activity.UserId,
                    ActivityId = activity.ActivityId,
                };
                dbContext.Add(Planner);
                dbContext.SaveChanges();
                return Redirect("activity/" + activity.ActivityId);
            }
            return View("New");

        }

        [HttpGet("join/{activity_id}")]

        public IActionResult JoinActivity(int activity_id) {
            int userId = (int)HttpContext.Session.GetInt32("userId");
            ViewBag.user = dbContext.Users.FirstOrDefault(u => u.UserId == userId);
            Attendee a = new Attendee {
                UserId = userId,
                ActivityId = activity_id,
            };
            dbContext.Add(a);
            dbContext.SaveChanges();
            return RedirectToAction("Home");
        }

        
        [HttpGet("leave/{activity_id}")]

        public IActionResult LeaveActivity(int activity_id) {
            int userId = (int)HttpContext.Session.GetInt32("userId");
            ViewBag.user = dbContext.Users.FirstOrDefault(u => u.UserId == userId);
            var a = dbContext.Attendees.
            FirstOrDefault(attendee => (attendee.UserId == userId && attendee.ActivityId == activity_id));
            dbContext.Attendees.Remove(a);
            dbContext.SaveChanges();
            return RedirectToAction("Home");
        }


        [HttpPost("create")]
        public IActionResult Create(User user)
        {
            if(ModelState.IsValid) {
                if(dbContext.Users.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!"); 
                } else {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    user.Password = Hasher.HashPassword(user, user.Password);
                    dbContext.Add(user);
                    dbContext.SaveChanges();
                }
            }
            return View("Index");
        } 

        [HttpPost("login")]
        public IActionResult Login(LoginUser userSubmission) {
        
            if(ModelState.IsValid)
            {
                var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == userSubmission.LoginEmail);
                if(userInDb == null) {
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("Index");
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.LoginPassword);
                if(result == 0) {
                    ModelState.AddModelError("Password", "Invalid Email/Password");
                    return View("Index");
                }
                HttpContext.Session.SetInt32("userId", userInDb.UserId);
                return RedirectToAction("Home");
            }
            return View("Index");
        }

        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id) {
            var activity = dbContext.Activities.FirstOrDefault(a => a.ActivityId == id);
            dbContext.Activities.Remove(activity);
            dbContext.SaveChanges();
            return RedirectToAction("Home");
        }
    }

}
