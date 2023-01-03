#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Burritopia.Models;

public class Burrito
{
    [Key]
    public int BurritoId {get;set;}
    [Required]
    public int OrderId {get;set;}
    [Required]
    public int ProteinId {get;set;}
    [Required]
    public int RiceId {get;set;}
    [Required]
    public int BeansId {get;set;}
    public List<Topping> Toppings {get;set;} = new List<Topping>();
    public bool DoubleMeat {get;set;}
    public double Price {get;set;} = 0;
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    public Protein? Protein {get;set;}
    public Rice? Rice {get;set;}
    public Beans? Beans {get;set;}
}