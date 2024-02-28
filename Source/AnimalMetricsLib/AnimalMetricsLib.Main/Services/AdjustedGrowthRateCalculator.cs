using AnimalMetricsLib.Interfaces;
using AnimalMetricsLib.Models;

namespace AnimalMetricsLib.Services;

public class AdjustedGrowthRateCalculator : IAdjustedGrowthRateCalculator
{
    public double CalculateAdjustedGrowthRate(Animal animal, NutritionInfo nutritionInfo)
    {
        var adjustmentFactors = new AdjustmentFactors
        {
            ActualProteinContent = nutritionInfo.ActualProteinContent,
            RequiredProteinContent = nutritionInfo.RequiredProteinContent,
            ActualEnergyContent = nutritionInfo.ActualEnergyContent,
            RequiredEnergyContent = nutritionInfo.RequiredEnergyContent,
            ActualVitaminMineralIndex = nutritionInfo.ActualVitaminMineralIndex,
            RequiredVitaminMineralIndex = nutritionInfo.RequiredVitaminMineralIndex
        };
        
        double basicGrowthRate = (animal.FinalWeight - animal.InitialWeight) / animal.DurationInDays;
        double adjustedGrowthRate = basicGrowthRate * adjustmentFactors.OverallAdjustmentFactor;
        return adjustedGrowthRate;
    }
}