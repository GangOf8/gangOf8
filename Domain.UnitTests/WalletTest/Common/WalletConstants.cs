using HorseMoney.Application.Dto.WalletDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UnitTests.WalletTest.Common
{
    public class WalletConstants
    {
        public static WalletCreateDto VALID_WALLET_CREATE_DTO = new WalletCreateDto()
        {
            Name = "VALID WALLET NAME"
        };
    }
}