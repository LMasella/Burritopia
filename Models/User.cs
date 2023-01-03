#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Burritopia.Models;

public class User
{
    [Key]
    public int UserId {get;set;}
    [Required]
    public string FirstName {get;set;}
    [Required]
    public string LastName {get;set;}
    [Required]
    [EmailAddress]
    [UniqueEmail]
    public string Email {get;set;}
    [Required]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "At least 8 characters there, bud.")]
    public string Password {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    [NotMapped]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword {get;set;}
}

public class UniqueEmail : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Email is required!");
        }

        MyContext _context = (MyContext)validationContext.GetService(typeof(MyContext));

        if(_context.Users.Any(e => e.Email == value.ToString()))
        {
            return new ValidationResult("Email already registered!");
        }
        return ValidationResult.Success;
    }
}