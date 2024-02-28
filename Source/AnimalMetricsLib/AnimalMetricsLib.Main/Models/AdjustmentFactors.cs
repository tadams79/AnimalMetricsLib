namespace AnimalMetricsLib.Models;

/// <summary>
/// Represents the adjustment factors for the animal's nutrition information.
/// </summary>
public class AdjustmentFactors
{
    public double ActualProteinContent { get; set; }
    public double RequiredProteinContent { get; set; }
    public double ActualEnergyContent { get; set; }
    public double RequiredEnergyContent { get; set; }
    public double ActualVitaminMineralIndex { get; set; }
    public double RequiredVitaminMineralIndex { get; set; }
    
    private double ProteinContentAdjustmentFactor => ActualProteinContent / RequiredProteinContent;
    private double EnergyContentAdjustmentFactor => ActualEnergyContent / RequiredEnergyContent;
    private double VitaminMineralIndexAdjustmentFactor => ActualVitaminMineralIndex / RequiredVitaminMineralIndex;
    public double OverallAdjustmentFactor => (ProteinContentAdjustmentFactor + EnergyContentAdjustmentFactor + VitaminMineralIndexAdjustmentFactor) / 3;
    public static implicit operator AdjustmentFactors(NutritionInfo nutritionInfo)
        => new AdjustmentFactors() {
            ActualProteinContent = nutritionInfo.ActualProteinContent,
            RequiredProteinContent = nutritionInfo.RequiredProteinContent,
            ActualEnergyContent = nutritionInfo.ActualEnergyContent,
            RequiredEnergyContent = nutritionInfo.RequiredEnergyContent,
            ActualVitaminMineralIndex = nutritionInfo.ActualVitaminMineralIndex,
            RequiredVitaminMineralIndex = nutritionInfo.RequiredVitaminMineralIndex
        };
}
