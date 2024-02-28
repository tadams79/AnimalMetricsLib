using Xunit;
using AnimalMetricsLib.Services;
using AnimalMetricsLib.Models;
using System;
using AnimalMetricsLib.Interfaces;
using System.Collections.Generic;

namespace AnimalMetricsLib.Tests.Services
{
    public class AdjustedGrowthRateCalculatorTest
    {
        private readonly IAdjustedGrowthRateCalculator _growthRateCalculator = new AdjustedGrowthRateCalculator();
        // Test Data for Calculate Adjusted Growth Rate from Measurements
        public static IEnumerable<object[]> GrowthMeasurementData() 
            => new List<object[]> {
                // Empty set of measurments
                new object[] {
                    new List<GrowthMeasurement>(),
                    new NutritionInfo(),
                    0
                },
                // If NutritionInfo values are 0, then result is expected to be
                // NaN since things like OverallAdjustmentFactor can't be calculated.
                // Not sure if this is intended behavior or a bug.
                new object[] {
                    new List<GrowthMeasurement>() {
                        new GrowthMeasurement() {
                            Weight = 10, MeasurementDate = DateTime.Now
                        }
                    },
                    new NutritionInfo(),
                    double.NaN
                },
                // Test with a few valid measurements and valid nutrition information
                new object[] {
                    new List<GrowthMeasurement>() {
                        new GrowthMeasurement() {
                            Weight = 10, MeasurementDate = new DateTime(2023, 12, 15, 9, 0, 0)
                        },
                        new GrowthMeasurement() {
                            Weight = 15, MeasurementDate = new DateTime(2024, 1, 5, 11, 0, 0)
                        },
                        new GrowthMeasurement() {
                            Weight = 20, MeasurementDate = new DateTime(2024, 2, 3, 7, 0, 0)
                        }
                    },
                    new NutritionInfo() {
                        ActualProteinContent = 10,
                        RequiredProteinContent = 1,
                        ActualEnergyContent = 10,
                        RequiredEnergyContent = 1,
                        ActualVitaminMineralIndex = 10,
                        RequiredVitaminMineralIndex = 1
                    }, 2.00
                }

            };
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
        [Theory]
        [MemberData(nameof(GrowthMeasurementData))]
        public void CalculateAdjustedGrowthRateFromMeasurements(
            List<GrowthMeasurement> measurements, 
            NutritionInfo nutritionInfo,
            double expectedResult) 
        {
            var result = _growthRateCalculator.CalculateAdjustedGrowthRate(
                measurements, nutritionInfo);
            result = Math.Round(result, 2);
            Assert.Equal(expectedResult, result);
        }


    }
}
