using Microsoft.AspNetCore.Mvc;
using SavingCalculatorApi.Models;
using SavingCalculatorApi.Services;
using System.Collections.Generic;

namespace SavingCalculatorApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SavingCalculatorController : ControllerBase
    {
        private readonly SavingCalculatorService _savingCalculatorService;

        public SavingCalculatorController()
        {
            _savingCalculatorService = new SavingCalculatorService();
        }

        [HttpPost]
        public ActionResult<List<SavingResult>> CalculateTotalSavings([FromBody] SavingModel saving)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var results = _savingCalculatorService.CalculateSavings(saving.SavingAmountPerMonth, saving.InterestAmountPercent, saving.DurationMonths);
            return Ok(results);
        }
    }
}
