﻿namespace AnimalMetricsLib.Models;

/// <summary>
/// Represents the nutritional information of an animal.
/// </summary>
public class NutritionInfo
{
    public double ActualProteinContent { get; init; }
    public double RequiredProteinContent { get; init; }
    public double ActualEnergyContent { get; init; }
    public double RequiredEnergyContent { get; init; }
    public double ActualVitaminMineralIndex { get; init; }
    public double RequiredVitaminMineralIndex { get; init; }
}