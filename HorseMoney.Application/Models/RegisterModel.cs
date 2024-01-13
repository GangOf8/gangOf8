using System.ComponentModel.DataAnnotations;
using HorseMoney.Domain.Interfaces;

namespace HorseMoney.Application.Models;

public class RegisterModel : IRegisterModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }


}