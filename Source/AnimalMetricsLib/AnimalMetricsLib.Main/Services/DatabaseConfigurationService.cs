using AnimalMetricsLib.Data;
using Microsoft.EntityFrameworkCore;

namespace AnimalMetricsLib.Services;

public class DatabaseConfigurationService
{
    public static DbContextOptions GetDbContextOptions(string databaseType, string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AnimalMetricsDbContext>();

        switch (databaseType.ToLower())
        {
            case "mssql":
                optionsBuilder.UseSqlServer(connectionString);
                break;
            case "mariadb":
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                break;
            case "sqlite":
                optionsBuilder.UseSqlite(connectionString);
                break;
            case "postgresql":
                optionsBuilder.UseNpgsql(connectionString);
                break;
            default:
                throw new ArgumentException("Unsupported database type", nameof(databaseType));
        }

        return optionsBuilder.Options;
    }
}