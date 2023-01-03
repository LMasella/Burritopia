#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace Burritopia.Models;

public class MyContext : DbContext 
{   
    public MyContext(DbContextOptions options) : base(options) {}

    public DbSet<User> Users {get;set;}
    public DbSet<Order> Orders {get;set;}
    public DbSet<Burrito> Burritos {get;set;}
    public DbSet<Ingredient> Ingredients {get;set;}
    public DbSet<Protein> Proteins {get;set;}
    public DbSet<Rice> Rice {get;set;}
    public DbSet<Beans> Beans {get;set;}
    public DbSet<AddOn> AddOns {get;set;}
    public DbSet<Topping> Toppings {get;set;}
}