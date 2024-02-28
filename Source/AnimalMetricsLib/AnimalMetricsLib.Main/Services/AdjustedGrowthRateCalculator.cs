using AnimalMetricsLib.Interfaces;
using AnimalMetricsLib.Models;

namespace AnimalMetricsLib.Services;

public class AdjustedGrowthRateCalculator : IAdjustedGrowthRateCalculator
{
    public double CalculateAdjustedGrowthRate(Animal animal, NutritionInfo nutritionInfo)
    {
        AdjustmentFactors adjustmentFactors = nutritionInfo;        
        double adjustedGrowthRate = GetBasicGrowthRate(animal, nutritionInfo)
            * adjustmentFactors.OverallAdjustmentFactor;
        return adjustedGrowthRate;
    }
    public double CalculateAdjustedGrowthRate(List<GrowthMeasurement> measurements,
        NutritionInfo nutritionInfo) 
    {
        if (measurements.Count == 0) { return 0; }
        AdjustmentFactors adjustmentFactors = nutritionInfo;        
        return GetBasicGrowthRate(measurements, adjustmentFactors) * 
            adjustmentFactors.OverallAdjustmentFactor;
    }
    private double GetBasicGrowthRate(
        List<GrowthMeasurement> measurements,
        AdjustmentFactors adjustmentFactors) 
    {
        if (measurements.Count == 0) { return 0; }
        var earliestWeighIn = measurements.MinBy(g => g.MeasurementDate);
        var latestWeighIn = measurements.MaxBy(g => g.MeasurementDate);
        var duration = (
            (latestWeighIn?.MeasurementDate - earliestWeighIn?.MeasurementDate) 
            ?? TimeSpan.Zero
        ).TotalDays;
        return ((latestWeighIn?.Weight - earliestWeighIn?.Weight) ?? 0) 
            / duration;
    }
    private double GetBasicGrowthRate(Animal animal,
            AdjustmentFactors adjustmentFactors) 
        => (animal.FinalWeight - animal.InitialWeight) / animal.DurationInDays;
}
