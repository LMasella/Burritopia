using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Burritopia.Models;

namespace Burritopia.Controllers;

public class IngredientController : Controller
{
    private MyContext _context;
    public IngredientController(MyContext context)
    {
        _context = context;
    }
    [HttpGet("admin")]
    public IActionResult Admin()
    {
        return View("Admin");
    }

    [HttpGet("addons/new")]
    public IActionResult NewAddOn()
    {
        return View("NewAddOn");
    }

    [HttpPost("addons/create")]
    public IActionResult CreateAddOn(AddOn newAddOn)
    {
        if(ModelState.IsValid)
        {
            _context.AddOns.Add(newAddOn);
            _context.SaveChanges();
        }
        return RedirectToAction("NewAddOn", "Ingredient");
    }

    [HttpGet("proteins/new")]
    public IActionResult NewProtein()
    {
        return View("NewProtein");
    }

    [HttpPost("proteins/create")]
    public IActionResult CreateProtein(Protein newProtein)
    {
        if(ModelState.IsValid)
        {
            _context.Proteins.Add(newProtein);
            _context.SaveChanges();
        }
        return RedirectToAction("NewProtein", "Ingredient");
    }

    [HttpGet("beans/new")]
    public IActionResult NewBeans()
    {
        return View("NewBeans");
    }

    [HttpPost("beans/create")]
    public IActionResult CreateBeans(Beans newBeans)
    {
        if(ModelState.IsValid)
        {
            _context.Beans.Add(newBeans);
            _context.SaveChanges();
        }
        return RedirectToAction("NewBeans", "Ingredient");
    }

    [HttpGet("rice/new")]
    public IActionResult NewRice()
    {
        return View("NewRice");
    }

    [HttpPost("rice/create")]
    public IActionResult CreateRice(Rice newRice)
    {
        if(ModelState.IsValid)
        {
            _context.Rice.Add(newRice);
            _context.SaveChanges();
        }
        return RedirectToAction("NewRice", "Ingredient");
    }
}
