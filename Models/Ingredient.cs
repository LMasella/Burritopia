#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Burritopia.Models;

public class Ingredient
{
    [Key]
    public int IngredientId {get;set;}
    [Required]
    public string Name {get;set;}
    public bool InStock {get;set;} = true;
    [Required]
    public double Price {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    public string ToClass()
    {
        return this.Name.ToLower().Replace(" ", "");
    }
}

public class Protein : Ingredient
{
    [Required]
    public double DoubleMeatPrice {get;set;}
}
public class Rice : Ingredient {}
public class Beans : Ingredient {}
public class AddOn : Ingredient {}