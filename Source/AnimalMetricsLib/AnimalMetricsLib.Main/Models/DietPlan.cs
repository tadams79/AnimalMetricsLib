using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AnimalMetricsLib.Models;

/// <summary>
/// Represents a diet plan for an animal.
/// </summary>
public class DietPlan
{
    [Key] public int Id { get; set; }
    public int AnimalId { get; set; }
    public Dictionary<FeedType, double> Feeds { get; set; } = new Dictionary<FeedType, double>();

    public Animal Animal = new Animal();
}