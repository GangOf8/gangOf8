using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HorseMoney.Domain.Entities;

[Table("Income")]

public class Income : BaseEntity
{
    [Column("Income_at")]
    public DateTime Income_at { get; set; }
    
    [Required]
    [Column("Amount")]
    public decimal Amount { get; set; }
    
    [Column ("Recorrent")]
    public bool Recorrent { get; set; }
    
}