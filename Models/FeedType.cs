using System.ComponentModel.DataAnnotations;

namespace AnimalMetricsLib.Models;

/// <summary>
/// Represents a type of feed.
/// </summary>
public class FeedType(string name, double nutritionalValue)
{
    [Key] public int Id { get; set; }
    public string Name { get; set; } = name;
    public double ProteinContent { get; set; }
    public double EnergyContent { get; set; }

    // A simple metric to represent nutritional value
    public double NutritionalValue { get; set; } = nutritionalValue;
}