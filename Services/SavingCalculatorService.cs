using SavingCalculatorApi.Models;
using System.Collections.Generic;

namespace SavingCalculatorApi.Services
{
    public class SavingCalculatorService
    {
        public List<SavingResult> CalculateSavings(decimal savingAmountPerMonth, double interestAmountPercent, int durationMonths)
        {
            double monthlyRate = interestAmountPercent / 100 / 12;
            var results = new List<SavingResult>();
            decimal balance = 0;

            // Mengambil tahun dan bulan saat ini
            int startYear = DateTime.Now.Year;
            int startMonth = DateTime.Now.Month;

            for (int i = 0; i < durationMonths; i++)
            {
                balance = balance * (1 + (decimal)monthlyRate) + savingAmountPerMonth;

                int currentMonth = (startMonth + i - 1) % 12 + 1;
                int currentYear = startYear + (startMonth + i - 1) / 12;

                results.Add(new SavingResult { Year = currentYear, Month = currentMonth, Balance = balance });
            }

            return results;
        }
    }
}
