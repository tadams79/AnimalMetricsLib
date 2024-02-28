namespace AnimalMetricsLib.Models;

/// <summary>
/// Represents an animal weight at a specific point in time
/// </summary>
public class GrowthMeasurement
{
    public double Weight { get; set; }
    public DateTime MeasurementDate { get; set; }
}
