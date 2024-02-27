namespace AnimalMetricsLib.Models;

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
}