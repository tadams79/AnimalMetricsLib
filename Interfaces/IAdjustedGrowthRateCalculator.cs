using AnimalMetricsLib.Models;

namespace AnimalMetricsLib.Interfaces;

public interface IAdjustedGrowthRateCalculator
{
    double CalculateAdjustedGrowthRate(Animal animal, NutritionInfo nutritionInfo);
}