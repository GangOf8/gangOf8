using System.ComponentModel.DataAnnotations;

namespace HorseMoney.Application.Dto.WalletDto
{
    public record WalletCreateDto
    {
        [Required] public string Name;
    }
}
