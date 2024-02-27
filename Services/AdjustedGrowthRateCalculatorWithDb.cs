using AnimalMetricsLib.Data;
using AnimalMetricsLib.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalMetricsLib.Services;

public class AdjustedGrowthRateCalculatorWithDb(DbContextOptions options) : AdjustedGrowthRateCalculator
{
    private readonly AnimalMetricsDbContext _context = new AnimalMetricsDbContext(options);
    // Assuming base class does not have a constructor that needs parameters

    public async Task SaveCalculationAsync(Animal animal, NutritionInfo nutritionInfo)
    {
        if (_context.Animals != null) _context.Animals.Add(animal);
        if (_context.NutritionInfos != null) _context.NutritionInfos.Add(nutritionInfo);
        await _context.SaveChangesAsync();
    }
}