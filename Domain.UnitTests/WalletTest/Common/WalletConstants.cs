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

        public static WalletDto VALID_WALLET_CREATE_DTO = new WalletDto()
        {
            Name = "VALID WALLET NAME"
        };
    }
}
