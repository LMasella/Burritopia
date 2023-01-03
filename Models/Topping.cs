#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Burritopia.Models;

public class Topping
{
    [Key]
    public int ToppingId {get;set;}
    [Required]
    public int BurritoId {get;set;}
    [Required]
    public int AddOnId {get;set;}
    public Burrito? Burrito {get;set;}
    public AddOn? AddOn {get;set;}
}