using System.ComponentModel.DataAnnotations;

namespace HorseMoney.Domain.Dto.WalletDto
{
    public record WalletIdDto
    {
        [Required]
        public Guid Id { get; private set; }
    }
}
