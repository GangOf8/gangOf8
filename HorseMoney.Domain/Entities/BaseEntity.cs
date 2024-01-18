using System.ComponentModel.DataAnnotations;

namespace HorseMoney.Domain.Entities;

public abstract class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    #region Methods

    public void Update()
    {
        UpdatedAt = DateTime.Now;
    }

    #endregion Methods
}
