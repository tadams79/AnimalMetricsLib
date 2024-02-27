using System.ComponentModel.DataAnnotations;

namespace AnimalMetricsLib.Models;

public class GrowthRecord
{
    [Key] public int Id { get; set; }
    public int AnimalId { get; set; }
    public double Weight { get; set; }
    public DateTime DateMeasured { get; set; }

    public Animal Animal { get; set; } = new();
}