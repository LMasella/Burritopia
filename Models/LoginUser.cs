#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Burritopia.Models;

public class LoginUser
{
    [Required(ErrorMessage = "Invalid Email/Password.")]
    [EmailAddress]
    public string LEmail {get;set;}
    [Required(ErrorMessage = "You forgot to put in your password!")]
    [DataType(DataType.Password)]
    public string LPassword {get;set;}
}