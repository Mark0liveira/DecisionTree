using System;
using System.Collections.Generic;
using ContentManagementSystem.Entities;
using ContentManagementSystem.Services;
using ContentManagementSystem.Services.Dtos;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace ContentManagementSystem.Application.Tests.Mocks;

internal class ContentManagementSystemMock
{
    internal static Guid CmsId = Guid.NewGuid();
    
    internal static readonly ContentManagement ContentManagement = new()
    {
        ConcurrencyStamp = "",
        Content = "<div>test</div>",
        Title = "Test Title"
    };
    
    internal static readonly ContentManagement ContentManagement2 = new()
    {
        ConcurrencyStamp = "",
        Content = "<div>test 2</div>",
        Title = "Test Title 2"
    };
    
    internal static List<ContentManagement> ContentManagements =>
    [
        ContentManagement, 
        ContentManagement2
    ];
    
    internal static ContentManagementDto ContentManagementDto => new()
    {
        Content = "<div>test</div>",
        Title = "Test Title",
        Id = CmsId
    };
    
    internal static ContentManagementDto NewContentManagementDto => new()
    {
        Content = "<div>test</div>",
        Title = "Test Title"
    };
    
    internal readonly IRepository<ContentManagement, Guid> FakeRepo = Substitute.For<IRepository<ContentManagement, Guid>>();
    internal readonly ILogger<ContentManagementService> FakeLogger = Substitute.For<ILogger<ContentManagementService>>();
    internal readonly IObjectMapper FakeMapper = Substitute.For<IObjectMapper>();
}