using ContentManagementSystem.Entities;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace ContentManagementSystem.Data;

[ConnectionStringName("MongoDbConnString")]
public class ContentManagementSystemDbContext : AbpMongoDbContext
{
    public IMongoCollection<ContentManagement> Contents => Collection<ContentManagement>();
}