using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ContentManagementSystem.Entities;
using ContentManagementSystem.Extensions;
using ContentManagementSystem.Mappers;
using ContentManagementSystem.Services.Dtos;
using ContentManagementSystem.Services.Dtos.@base;
using Microsoft.Extensions.Logging;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace ContentManagementSystem.Services;

public class ContentManagementService : ITransientDependency
{
    private readonly ILogger<ContentManagementService> _logger;
    private readonly IRepository<ContentManagement, Guid> _repository;
    private readonly IObjectMapper _mapper;
    
    public ContentManagementService(ILogger<ContentManagementService> logger, 
        IRepository<ContentManagement, Guid> repository, IObjectMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<List<ContentManagementDto>, Error>> GetAllAsync()
    {
        try
        {
            return await RetrieveAll();
        }
        catch (Exception e)
        {
            return LogException(e, ContentErrors.GetAll);
        }
    }

    public async Task<Result<ContentManagementDto, Error>> GetCMSContentAsync(Guid id)
    {
        try
        {
            return await RetrieveById(id);
        }
        catch (Exception e)
        {
            return LogException(e, ContentErrors.GetById);
        }
    }

    public async Task<Result<ContentManagement, Error>> InsertOrUpdateCMSContentAsync(ContentManagementDto model)
    {
        try
        {
            return await CreateOrUpdate(model);
        }
        catch (Exception e)
        {
            return LogException(e, ContentErrors.PostOrUpdate);
        }
    }

    private async Task<Result<List<ContentManagementDto>, Error>> RetrieveAll()
    {
        var contents = await _repository.GetListAsync();
        return contents.MapToDto();
    }
    
    private Error LogException(Exception e, Error message)
    {
        _logger.LogInformation($"{message.Code}: {e.Message}");
        return message;
    }
    
    private async Task<Result<ContentManagementDto, Error>> RetrieveById(Guid id)
    {
        var content = await _repository.GetAsync(id);
        return content.MapToDto();
    }
    
    private async Task<Result<ContentManagement, Error>> CreateOrUpdate(ContentManagementDto model)
    {
        if (model.Id.HasValue())
        {
            var content = await _repository.GetAsync(model.Id);
            content.Content = model.Content;
            content.Title = model.Title;
            return await _repository.UpdateAsync(content);
        }
        
        return await _repository.InsertAsync(model.MapToEntity());
    }
}