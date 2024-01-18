using System.ComponentModel.DataAnnotations;

namespace HorseMoney.Domain.Dto.WalletDto
{
    public record WalletUpdateDto
    {
        [Required]
        public Guid Id { get; private set; }
        [Required]
        public string Name { get; private set; }
    }
}
