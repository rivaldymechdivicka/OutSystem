namespace SavingCalculatorApi.Models
{
    public class SavingModel
    {
        public decimal SavingAmountPerMonth { get; set; }
        public int DurationMonths { get; set; }
        public double InterestAmountPercent { get; set; }
    }
}
