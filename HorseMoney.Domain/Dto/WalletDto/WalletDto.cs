using System.ComponentModel.DataAnnotations;

namespace HorseMoney.Application.Dto.WalletDto
{
    public record WalletDto
    {
        [Required] public string Name;
    }
}
