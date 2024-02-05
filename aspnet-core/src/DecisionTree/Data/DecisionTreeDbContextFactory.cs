using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DecisionTree.Data;

public class DecisionTreeDbContextFactory : IDesignTimeDbContextFactory<DecisionTreeDbContext>
{
    public DecisionTreeDbContext CreateDbContext(string[] args)
    {

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<DecisionTreeDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new DecisionTreeDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
