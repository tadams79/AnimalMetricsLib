using Xunit;
using AnimalMetricsLib.Services;
using AnimalMetricsLib.Models;
using System;

namespace AnimalMetricsLib.Tests.Services
{
    public class AdjustedGrowthRateCalculatorTest
    {
        private readonly AdjustedGrowthRateCalculator _growthRateCalculator = new AdjustedGrowthRateCalculator();

        [Theory]
        [InlineData(10.0, 20.0, 10, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0)] // Basic growth condition
        [InlineData(20.0, 40.0, 10, 2.0, 2.0, 2.0, 2.0, 2.0, 2.0)] // Extended growth condition
        [InlineData(10.0, 20.0, 0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0)] // Divided by zero condition
        [InlineData(20.0, 40.0, -10, 2.0, 2.0, 2.0, 2.0, 2.0, 2.0)] // Negative period
        [InlineData(20.0, 10.0, 10, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0)] // Losing weight
        [InlineData(0.0, 0.0, 0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0)] // All zero
        [InlineData(Double.PositiveInfinity, Double.PositiveInfinity, Int32.MaxValue, Double.PositiveInfinity,
            Double.PositiveInfinity,
            Double.PositiveInfinity, Double.PositiveInfinity, Double.PositiveInfinity,
            Double.PositiveInfinity)] // All positive infinity
        public void CalculateAdjustedGrowthRateTests(double initialWeight, double finalWeight, int durationInDays,
            double actualProteinContent, double requiredProteinContent,
            double actualEnergyContent, double requiredEnergyContent,
            double actualVitaminMineralIndex, double requiredVitaminMineralIndex)
        {
            var animal = new Animal
            {
                InitialWeight = initialWeight,
                FinalWeight = finalWeight,
                DurationInDays = durationInDays
            };

            var nutritionInfo = new NutritionInfo
            {
                ActualProteinContent = actualProteinContent,
                RequiredProteinContent = requiredProteinContent,
                ActualEnergyContent = actualEnergyContent,
                RequiredEnergyContent = requiredEnergyContent,
                ActualVitaminMineralIndex = actualVitaminMineralIndex,
                RequiredVitaminMineralIndex = requiredVitaminMineralIndex
            };

            _growthRateCalculator.CalculateAdjustedGrowthRate(animal, nutritionInfo);
        }
    }
}