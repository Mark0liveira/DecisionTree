using ContentManagementSystem.Data;
using ContentManagementSystem.Services;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;
using Volo.Abp.Uow;

namespace ContentManagementSystem;

[DependsOn(typeof(AbpMongoDbModule))]
    public class ContentManagementModule : AbpModule
{
    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        context.ServiceProvider.GetRequiredService<ContentManagementService>();
    }
    
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
         context.Services.AddMongoDbContext<ContentManagementSystemDbContext>(options =>
             options.AddDefaultRepositories());
         
         // Configure<AbpUnitOfWorkDefaultOptions>(options =>
         // {
         //     options.TransactionBehavior = UnitOfWorkTransactionBehavior.Auto;
         // });
    }
}