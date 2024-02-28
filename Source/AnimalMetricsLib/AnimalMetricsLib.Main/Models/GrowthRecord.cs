using System.ComponentModel.DataAnnotations;

namespace AnimalMetricsLib.Models;

/// <summary>
/// Represents a growth record for an animal.
/// </summary>
public class GrowthRecord
{
    [Key] public int Id { get; set; }
    public int AnimalId { get; set; }
    public double Weight { get; set; }
    public DateTime DateMeasured { get; set; }

    public Animal Animal { get; set; } = new();
}