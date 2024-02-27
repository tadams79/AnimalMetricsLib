using AnimalMetricsLib.Models;

namespace AnimalMetricsLib.Interfaces;

public interface IFeedTypeService
{
    Task<List<FeedType?>> GetAllAsync();
    Task<FeedType?> GetByIdAsync(int id);
}