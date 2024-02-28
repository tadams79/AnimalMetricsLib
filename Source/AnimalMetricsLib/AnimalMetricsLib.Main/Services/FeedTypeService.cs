using AnimalMetricsLib.Data;
using AnimalMetricsLib.Interfaces;
using AnimalMetricsLib.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalMetricsLib.Services;

public class FeedTypeService(AnimalMetricsDbContext context) : IFeedTypeService
{
    private readonly AnimalMetricsDbContext _context = context;

    public async Task<List<FeedType>> GetAllAsync()
    {
        if (_context.FeedTypes != null) return await _context.FeedTypes.ToListAsync();
        return new List<FeedType>();
    }

    public async Task<FeedType?> GetByIdAsync(int id)
    {
        if (_context.FeedTypes != null) return await _context.FeedTypes.FindAsync(id);
        return null;
    }
}