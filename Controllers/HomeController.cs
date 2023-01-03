using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Burritopia.Models;

namespace Burritopia.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;
    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View("Index");
    }

    [HttpPost("users/create")]
    public IActionResult CreateUser(User newUser)
    {
        if(ModelState.IsValid)
        {
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            return RedirectToAction("Order", "Order");
        }
        return Index();
    }

    [HttpPost("login")]
    public IActionResult Login(LoginUser user)
    {
        if (ModelState.IsValid)
        {
            User? userInDb = _context.Users.FirstOrDefault(u => u.Email == user.LEmail);
            if(userInDb == null)
            {
                ModelState.AddModelError("LEmail", "Invalid Email/Password");
                return Index();
            }
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            var result = hasher.VerifyHashedPassword(user, userInDb.Password, user.LPassword);
            if(result == 0)
            {
                ModelState.AddModelError("LEmail", "Invalid Email/Password");
                return Index();
            }
            HttpContext.Session.SetInt32("UserId", userInDb.UserId);
            return RedirectToAction("Order", "Order");
        }
        return Index();
    }

    [HttpPost("logout")]
    public RedirectToActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
