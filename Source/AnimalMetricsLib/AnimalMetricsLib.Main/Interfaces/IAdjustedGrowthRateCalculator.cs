using AnimalMetricsLib.Models;

namespace AnimalMetricsLib.Interfaces;

/// <summary>
/// Represents a calculator for calculating the adjusted growth rate of an animal.
/// </summary>
public interface IAdjustedGrowthRateCalculator
{
    double CalculateAdjustedGrowthRate(Animal animal, NutritionInfo nutritionInfo);
    double CalculateAdjustedGrowthRate(List<GrowthMeasurement> measurements, 
        NutritionInfo nutritionInfo);
}
