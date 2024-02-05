using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace DecisionTree.Data;

public class DecisionTreeEFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public DecisionTreeEFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the DecisionTreeDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<DecisionTreeDbContext>()
            .Database
            .MigrateAsync();
    }
}
