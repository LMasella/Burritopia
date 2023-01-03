#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Burritopia.Models;

public class Order
{
    [Key]
    public int OrderId {get;set;}
    [Required]
    public string Name {get;set;}
    public List<Burrito> Burritos {get;set;} = new List<Burrito>();
    public double Total {get;set;} = 0;
    public bool Paid {get;set;} = false;
    public bool Completed {get;set;} = false;
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
}