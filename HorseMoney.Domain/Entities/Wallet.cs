using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseMoney.Domain.Entities;

[Table("Wallet")]
public class Wallet : BaseEntity
{
    [Required]
    [MaxLength(100)]
    [Column(TypeName = "VARCHAR")]
    public string Name { get; set; }

    
}
