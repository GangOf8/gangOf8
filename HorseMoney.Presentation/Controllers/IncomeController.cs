using System.Net;
using HorseMoney.Domain.Dto.IncomeDto;
using HorseMoney.Domain.Interfaces.IIncome;
using HorseMoney.Presentation.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace HorseMoney.Presentation.Controllers;


[Route("api/[controller]")]
public class IncomeController : BaseController
{
    #region Properties

    private readonly ICreateIncomeUseCase _createIncome;

    #endregion Properties

    #region Constructors

    public IncomeController(ICreateIncomeUseCase createIncome)
    {
        _createIncome = createIncome;
    }

    #endregion Constructors

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] IncomeCreateDto incomeDto)
    {
        var result = await _createIncome.Execute(incomeDto);
        return ResponseBase(HttpStatusCode.Created, result, "Success");
    }
}