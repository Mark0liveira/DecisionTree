using System;
using Volo.Abp.Domain.Entities;

namespace ContentManagementSystem.Entities;

public class ContentManagement : AggregateRoot<Guid>
{
    public string Content { get; set; }
    public string Title { get; set; }
}