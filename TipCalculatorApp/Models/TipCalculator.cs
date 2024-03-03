using System.ComponentModel.DataAnnotations;

namespace TipCalculatorApp.Models
{
    public class TipCalculator
    {
        [Required(ErrorMessage = "Meal cost is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Meal cost must be greater than 0")]
        public decimal MealCost { get; set; }

        public decimal CalculateTip(int percentage)
        {
            return MealCost * (percentage / 100m);
        }
    }
}