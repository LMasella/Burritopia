using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Burritopia.Models;

namespace Burritopia.Controllers;

public class OrderController : Controller
{
    private MyContext _context;
    public OrderController(MyContext context)
    {
        _context = context;
    }

    [HttpPost("orders/create")]
    public IActionResult CreateOrder(Order newOrder)
    {
        if(ModelState.IsValid)
        {
            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("OrderNumber", newOrder.OrderId);
            return RedirectToAction("NewBurrito", "Order");
        }
        return RedirectToAction("Index", "Home");
    }

    [HttpGet("burritos/new")]
    public IActionResult NewBurrito()
    {
        if(HttpContext.Session.GetInt32("OrderNumber") == null)
        {
            return RedirectToAction("Index", "Home");
        }
        ViewBag.AllRice = _context.Rice.ToList();
        ViewBag.AllBeans = _context.Beans.ToList();
        ViewBag.AllAddOns = _context.AddOns.ToList();
        ViewBag.AllProteins = _context.Proteins.ToList();
        
        return View("NewBurrito");
    }

    [HttpPost("burritos/create")]
    public IActionResult CreateBurrito(Burrito newBurrito)
    {
        if(ModelState.IsValid)
        {
            Protein newBurritoProtein = _context.Proteins.FirstOrDefault(p => p.IngredientId == newBurrito.ProteinId);
            newBurrito.Price += newBurritoProtein.Price;
            if(newBurrito.DoubleMeat == true)
            {
                newBurrito.Price += newBurritoProtein.DoubleMeatPrice;
            }
            for(int i = 0; i < Request.Form["AddOns"].Count; i++)
            {
                newBurrito.Price += _context.AddOns.FirstOrDefault(a => a.IngredientId == Int32.Parse(Request.Form["Addons"][i])).Price;
            }
            _context.Burritos.Add(newBurrito);
            _context.SaveChanges();
            for(int i = 0; i < Request.Form["AddOns"].Count; i++)
            {
                Topping newTopping = new Topping {AddOnId = Int32.Parse(Request.Form["Addons"][i]), BurritoId = newBurrito.BurritoId};
                _context.Toppings.Add(newTopping);
                _context.SaveChanges();
            }
            return RedirectToAction("Checkout");
        }
        return NewBurrito();
    }

    [HttpGet("orders")]
    public IActionResult ViewOrders()
    {
        List<Order> Orders = _context.Orders.Where(o => o.Paid == true && o.Completed == false).Take(4)
            .Include(o => o.Burritos)
                .ThenInclude(b => b.Rice)
            .Include(o => o.Burritos)
                .ThenInclude(b => b.Beans)
            .Include(o => o.Burritos)
                .ThenInclude(b => b.Protein)
            .Include(o => o.Burritos)
                .ThenInclude(b => b.Toppings)
                .ThenInclude(t => t.AddOn)
            .ToList();
        return View("ViewOrders", Orders);
    }

    [HttpGet("checkout")]
    public IActionResult Checkout()
    {
        if(HttpContext.Session.GetInt32("OrderNumber") == null)
        {
            return RedirectToAction("Index", "Home");
        }
        Order? Order = _context.Orders
            .Include(o => o.Burritos)
                .ThenInclude(b => b.Rice)
            .Include(o => o.Burritos)
                .ThenInclude(b => b.Beans)
            .Include(o => o.Burritos)
                .ThenInclude(b => b.Protein)
            .Include(o => o.Burritos)
                .ThenInclude(b => b.Toppings)
                .ThenInclude(t => t.AddOn)
            .SingleOrDefault(o => o.OrderId == HttpContext.Session.GetInt32("OrderNumber"));
        if(Order == null)
        {
            return RedirectToAction("Index", "Home");
        }
        foreach(Burrito b in Order.Burritos)
        {
            Order.Total += b.Price;
        }
        return View("Checkout", Order);
    }

    [HttpPost("orders/{id}/place")]
    public IActionResult PlaceOrder(int id)
    {
        Order? Order = _context.Orders.Include(o => o.Burritos).SingleOrDefault(o => o.OrderId == id);
        if(Order == null)
        {
            return RedirectToAction("Index", "Home");
        }
        foreach(Burrito b in Order.Burritos)
        {
            Order.Total += b.Price;
        }
        Order.Paid = true;
        _context.SaveChanges();
        return RedirectToAction("Index", "Home");
    }

    [HttpPost("orders/{id}/complete")]
    public IActionResult CompleteOrder(int id)
    {
        Order? Order = _context.Orders.SingleOrDefault(o => o.OrderId == id);
        if(Order == null)
        {
            return RedirectToAction("ViewOrders", "Order");
        }
        Order.Completed = true;
        _context.SaveChanges();
        return RedirectToAction("ViewOrders", "Order");
    }
}